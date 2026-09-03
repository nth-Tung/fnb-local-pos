using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL.Repositories
{
    public class OrderRepository
    {
        // Hàm sinh mã hóa đơn tự động theo ngày (Ví dụ: HD-20260331-001)
        public string GenerateOrderNumber()
        {
            string dateStr = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"HD-{dateStr}-";

            string sql = "SELECT COUNT(*) FROM Orders WHERE OrderNumber LIKE @Prefix";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Prefix", prefix + "%");
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return prefix + (count + 1).ToString("D3"); // Tự tăng 001, 002...
            }
        }

        // Lưu đơn bán nhanh tại quầy (Đã thanh toán ngay - Quick Service)
        public bool SaveOrder(Dictionary<string, object> orderInfo, List<Dictionary<string, object>> orderItems)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string insertOrderSql = @"
                        INSERT INTO Orders (OrderNumber, TableId, OrderStatus, TotalAmount, DiscountAmount, PaymentMethod, CreatedAt, SettledAt, CreatedBy, Note)
                        VALUES (@OrderNumber, NULL, 'PAID', @TotalAmount, @DiscountAmount, @PaymentMethod, @CreatedAt, @SettledAt, @CreatedBy, @Note);
                        SELECT last_insert_rowid();";

                    long newOrderId = 0;
                    using (var cmd = new SQLiteCommand(insertOrderSql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderNumber", orderInfo["OrderNumber"]);
                        cmd.Parameters.AddWithValue("@TotalAmount", orderInfo["TotalAmount"]);
                        cmd.Parameters.AddWithValue("@DiscountAmount", orderInfo["DiscountAmount"]);
                        cmd.Parameters.AddWithValue("@PaymentMethod", orderInfo["PaymentMethod"]);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@SettledAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CreatedBy", orderInfo["CreatedBy"]);
                        cmd.Parameters.AddWithValue("@Note", orderInfo.ContainsKey("Note") ? orderInfo["Note"] : DBNull.Value);

                        newOrderId = (long)cmd.ExecuteScalar();
                    }

                    InsertDetailsInternal(conn, transaction, newOrderId, orderItems);

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Lưu đơn hàng mở cho Bàn (Chưa thanh toán - Table Service Open Tab)
        public bool SaveOpenTableOrder(int tableId, string orderNumber, string cashier, decimal totalAmount, decimal discountAmount, List<Dictionary<string, object>> orderItems, out long newOrderId)
        {
            newOrderId = 0;
            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string insertOrderSql = @"
                        INSERT INTO Orders (OrderNumber, TableId, OrderStatus, TotalAmount, DiscountAmount, PaymentMethod, CreatedAt, CreatedBy)
                        VALUES (@OrderNumber, @TableId, 'OPEN', @TotalAmount, @DiscountAmount, 'UNPAID', @CreatedAt, @CreatedBy);
                        SELECT last_insert_rowid();";

                    using (var cmd = new SQLiteCommand(insertOrderSql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
                        cmd.Parameters.AddWithValue("@TableId", tableId);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CreatedBy", cashier);

                        newOrderId = (long)cmd.ExecuteScalar();
                    }

                    InsertDetailsInternal(conn, transaction, newOrderId, orderItems);

                    // Cập nhật trạng thái bàn sang OCCUPIED và gắn CurrentOrderId
                    string updateTableSql = "UPDATE Tables SET Status = 'OCCUPIED', CurrentOrderId = @OrderId WHERE Id = @TableId;";
                    using (var cmdTable = new SQLiteCommand(updateTableSql, conn, transaction))
                    {
                        cmdTable.Parameters.AddWithValue("@OrderId", newOrderId);
                        cmdTable.Parameters.AddWithValue("@TableId", tableId);
                        cmdTable.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Cập nhật món vào đơn mở của Bàn khi khách gọi thêm món / đổi món
        public bool UpdateOpenTableOrder(long orderId, decimal totalAmount, decimal discountAmount, List<Dictionary<string, object>> orderItems)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string updateOrderSql = @"
                        UPDATE Orders 
                        SET TotalAmount = @TotalAmount, DiscountAmount = @DiscountAmount 
                        WHERE Id = @OrderId;";

                    using (var cmd = new SQLiteCommand(updateOrderSql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount);
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa chi tiết cũ và chèn lại toàn bộ chi tiết mới
                    string deleteDetailsSql = "DELETE FROM OrderDetails WHERE OrderId = @OrderId;";
                    using (var cmdDel = new SQLiteCommand(deleteDetailsSql, conn, transaction))
                    {
                        cmdDel.Parameters.AddWithValue("@OrderId", orderId);
                        cmdDel.ExecuteNonQuery();
                    }

                    InsertDetailsInternal(conn, transaction, orderId, orderItems);

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Lấy chi tiết đơn hàng đang mở của một bàn để hiển thị lại lên giỏ hàng POS
        public DataTable GetOpenOrderDetails(long orderId)
        {
            string sql = @"
                SELECT od.Id, od.OrderId, od.ProductId, p.Name AS ProductName, p.ProductType,
                       od.Quantity, od.UnitPrice, od.ParentDetailId, od.Note,
                       c.Name AS CategoryName
                FROM OrderDetails od
                LEFT JOIN Products p ON od.ProductId = p.Id
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                WHERE od.OrderId = @OrderId
                ORDER BY od.Id ASC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Thanh toán hóa đơn bàn (Chuyển Order sang PAID và giải phóng Bàn về EMPTY)
        public bool SettleTableOrder(int tableId, long orderId, string paymentMethod, decimal finalTotal, decimal discountAmount)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string updateOrderSql = @"
                        UPDATE Orders 
                        SET OrderStatus = 'PAID', PaymentMethod = @PaymentMethod, 
                            TotalAmount = @FinalTotal, DiscountAmount = @DiscountAmount, 
                            SettledAt = @SettledAt 
                        WHERE Id = @OrderId;";

                    using (var cmd = new SQLiteCommand(updateOrderSql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        cmd.Parameters.AddWithValue("@FinalTotal", finalTotal);
                        cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount);
                        cmd.Parameters.AddWithValue("@SettledAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    string freeTableSql = @"
                        UPDATE Tables 
                        SET Status = 'EMPTY', CurrentOrderId = NULL 
                        WHERE Id = @TableId;";

                    using (var cmdTable = new SQLiteCommand(freeTableSql, conn, transaction))
                    {
                        cmdTable.Parameters.AddWithValue("@TableId", tableId);
                        cmdTable.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private void InsertDetailsInternal(SQLiteConnection conn, SQLiteTransaction transaction, long orderId, List<Dictionary<string, object>> orderItems)
        {
            var mainItemIds = new Dictionary<string, long>();

            string insertDetailSql = @"
                INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, ParentDetailId, Note)
                VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @ParentDetailId, @Note);
                SELECT last_insert_rowid();";

            // Vòng 1: Món chính
            foreach (var item in orderItems)
            {
                if (!item.ContainsKey("ParentKey") || item["ParentKey"] == null)
                {
                    using (var cmd = new SQLiteCommand(insertDetailSql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@ProductId", item["ProductId"]);
                        cmd.Parameters.AddWithValue("@Quantity", item["Quantity"]);
                        cmd.Parameters.AddWithValue("@UnitPrice", item["UnitPrice"]);
                        cmd.Parameters.AddWithValue("@ParentDetailId", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Note", item.ContainsKey("Note") ? item["Note"] : DBNull.Value);

                        long detailId = (long)cmd.ExecuteScalar();

                        if (item.ContainsKey("ItemKey") && item["ItemKey"] != null)
                        {
                            mainItemIds[item["ItemKey"].ToString()] = detailId;
                        }
                    }
                }
            }

            // Vòng 2: Topping phụ thuộc
            foreach (var item in orderItems)
            {
                if (item.ContainsKey("ParentKey") && item["ParentKey"] != null)
                {
                    string parentKey = item["ParentKey"].ToString();
                    if (mainItemIds.ContainsKey(parentKey))
                    {
                        long parentDetailId = mainItemIds[parentKey];

                        using (var cmd = new SQLiteCommand(insertDetailSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrderId", orderId);
                            cmd.Parameters.AddWithValue("@ProductId", item["ProductId"]);
                            cmd.Parameters.AddWithValue("@Quantity", item["Quantity"]);
                            cmd.Parameters.AddWithValue("@UnitPrice", item["UnitPrice"]);
                            cmd.Parameters.AddWithValue("@ParentDetailId", parentDetailId);
                            cmd.Parameters.AddWithValue("@Note", DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
