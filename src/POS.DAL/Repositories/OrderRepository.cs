using System;
using System.Collections.Generic;
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

        // Hàm lưu trọn gói hóa đơn xuống Database sử dụng cấu trúc Dictionary linh hoạt
        public bool SaveOrder(Dictionary<string, object> orderInfo, List<Dictionary<string, object>> orderItems)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Chèn dữ liệu vào bảng Orders
                    string insertOrderSql = @"
                        INSERT INTO Orders (OrderNumber, TotalAmount, DiscountAmount, PaymentMethod, CreatedAt, CreatedBy)
                        VALUES (@OrderNumber, @TotalAmount, @DiscountAmount, @PaymentMethod, @CreatedAt, @CreatedBy);
                        SELECT last_insert_rowid();"; // Lấy ngay ID vừa tự sinh ra

                    long newOrderId = 0;
                    using (var cmd = new SQLiteCommand(insertOrderSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderNumber", orderInfo["OrderNumber"]);
                        cmd.Parameters.AddWithValue("@TotalAmount", orderInfo["TotalAmount"]);
                        cmd.Parameters.AddWithValue("@DiscountAmount", orderInfo["DiscountAmount"]);
                        cmd.Parameters.AddWithValue("@PaymentMethod", orderInfo["PaymentMethod"]);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CreatedBy", orderInfo["CreatedBy"]);

                        newOrderId = (long)cmd.ExecuteScalar();
                    }

                    // Từ điển lưu vết ID món chính để gán cho Topping đi kèm
                    var mainItemIds = new Dictionary<string, long>();

                    // 2. Chèn dữ liệu vào bảng OrderDetails (Duyệt vòng 1: Lưu các món chính trước)
                    string insertDetailSql = @"
                        INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice, ParentDetailId, Note)
                        VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @ParentDetailId, @Note);
                        SELECT last_insert_rowid();";

                    foreach (var item in orderItems)
                    {
                        // Kiểm tra nếu là món chính (Không có thuộc tính ParentKey)
                        if (!item.ContainsKey("ParentKey") || item["ParentKey"] == null)
                        {
                            using (var cmd = new SQLiteCommand(insertDetailSql, conn))
                            {
                                cmd.Parameters.AddWithValue("@OrderId", newOrderId);
                                cmd.Parameters.AddWithValue("@ProductId", item["ProductId"]);
                                cmd.Parameters.AddWithValue("@Quantity", item["Quantity"]);
                                cmd.Parameters.AddWithValue("@UnitPrice", item["UnitPrice"]);
                                cmd.Parameters.AddWithValue("@ParentDetailId", DBNull.Value);
                                cmd.Parameters.AddWithValue("@Note", item.ContainsKey("Note") ? item["Note"] : DBNull.Value);

                                long detailId = (long)cmd.ExecuteScalar();

                                // Lưu lại mã tham chiếu duy nhất của giao diện để tí nữa Topping tìm đến
                                if (item.ContainsKey("ItemKey"))
                                {
                                    mainItemIds[item["ItemKey"].ToString()] = detailId;
                                }
                            }
                        }
                    }

                    // 3. Chèn dữ liệu vào bảng OrderDetails (Duyệt vòng 2: Lưu các Topping/Modifier bám theo món chính)
                    foreach (var item in orderItems)
                    {
                        if (item.ContainsKey("ParentKey") && item["ParentKey"] != null)
                        {
                            string parentKey = item["ParentKey"].ToString();
                            if (mainItemIds.ContainsKey(parentKey))
                            {
                                long parentDetailId = mainItemIds[parentKey];

                                using (var cmd = new SQLiteCommand(insertDetailSql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@OrderId", newOrderId);
                                    cmd.Parameters.AddWithValue("@ProductId", item["ProductId"]);
                                    cmd.Parameters.AddWithValue("@Quantity", item["Quantity"]);
                                    cmd.Parameters.AddWithValue("@UnitPrice", item["UnitPrice"]);
                                    cmd.Parameters.AddWithValue("@ParentDetailId", parentDetailId); // Chỉ định nó thuộc ly nước nào
                                    cmd.Parameters.AddWithValue("@Note", DBNull.Value);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; // Đẩy lỗi ra ngoài để tầng UI hiển thị thông báo
                }
            }
        }
    }
}
