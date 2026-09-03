using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL.Repositories
{
    public class TableRepository
    {
        public DataTable GetAllTables(int? areaId = null, bool includeInactive = false)
        {
            string sql = @"
                SELECT t.Id, t.AreaId, a.Name AS AreaName, t.Name, t.Capacity, t.Status,
                       t.CurrentOrderId, t.SortOrder, t.IsActive,
                       o.OrderNumber, o.TotalAmount AS OrderTotal, o.CreatedAt AS OccupiedSince, o.CreatedBy,
                       (SELECT COUNT(*) FROM OrderDetails od WHERE od.OrderId = t.CurrentOrderId AND od.ParentDetailId IS NULL) AS ItemCount
                FROM Tables t
                INNER JOIN Areas a ON t.AreaId = a.Id
                LEFT JOIN Orders o ON t.CurrentOrderId = o.Id
                WHERE (@AreaId IS NULL OR t.AreaId = @AreaId)
                  AND (@IncludeInactive = 1 OR (t.IsActive = 1 AND a.IsActive = 1))
                ORDER BY a.SortOrder ASC, t.SortOrder ASC, t.Id ASC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AreaId", (object)areaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IncludeInactive", includeInactive ? 1 : 0);

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataRow GetTableById(int id)
        {
            string sql = @"
                SELECT t.Id, t.AreaId, a.Name AS AreaName, t.Name, t.Capacity, t.Status,
                       t.CurrentOrderId, t.SortOrder, t.IsActive,
                       o.OrderNumber, o.TotalAmount AS OrderTotal, o.CreatedAt AS OccupiedSince, o.CreatedBy,
                       (SELECT COUNT(*) FROM OrderDetails od WHERE od.OrderId = t.CurrentOrderId AND od.ParentDetailId IS NULL) AS ItemCount
                FROM Tables t
                INNER JOIN Areas a ON t.AreaId = a.Id
                LEFT JOIN Orders o ON t.CurrentOrderId = o.Id
                WHERE t.Id = @Id LIMIT 1;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        public bool InsertTable(int areaId, string name, int capacity, int sortOrder, bool isActive, out int newId)
        {
            newId = 0;
            string sql = @"
                INSERT INTO Tables (AreaId, Name, Capacity, Status, SortOrder, IsActive)
                VALUES (@AreaId, @Name, @Capacity, 'EMPTY', @SortOrder, @IsActive);
                SELECT last_insert_rowid();";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AreaId", areaId);
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                cmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);

                object res = cmd.ExecuteScalar();
                if (res != null && long.TryParse(res.ToString(), out long inserted))
                {
                    newId = (int)inserted;
                    return true;
                }
                return false;
            }
        }

        public bool UpdateTable(int id, int areaId, string name, int capacity, int sortOrder, bool isActive)
        {
            string sql = @"
                UPDATE Tables
                SET AreaId = @AreaId, Name = @Name, Capacity = @Capacity, SortOrder = @SortOrder, IsActive = @IsActive
                WHERE Id = @Id;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@AreaId", areaId);
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                cmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteTable(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            var tableRow = GetTableById(id);
            if (tableRow == null)
            {
                errorMessage = "Không tìm thấy thông tin bàn cần xóa!";
                return false;
            }

            string status = tableRow["Status"].ToString();
            if (status != "EMPTY")
            {
                errorMessage = "Bàn đang có khách ngồi hoặc đang chờ thanh toán! Không thể xóa bàn này.";
                return false;
            }

            string sql = "DELETE FROM Tables WHERE Id = @Id;";
            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTableStatus(int tableId, string status, long? orderId)
        {
            string sql = @"
                UPDATE Tables 
                SET Status = @Status, CurrentOrderId = @CurrentOrderId 
                WHERE Id = @Id;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", tableId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@CurrentOrderId", (object)orderId ?? DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Chuyển toàn bộ đơn hàng từ Bàn A sang Bàn B (Bàn B phải đang trống)
        /// </summary>
        public bool MoveTable(int fromTableId, int toTableId, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Kiểm tra Bàn nguồn (fromTable)
                    var fromRow = GetTableById(fromTableId);
                    if (fromRow == null || fromRow["CurrentOrderId"] == DBNull.Value)
                    {
                        errorMessage = "Bàn chuyển đi không có đơn hàng đang hoạt động!";
                        return false;
                    }

                    long orderId = Convert.ToInt64(fromRow["CurrentOrderId"]);
                    string fromStatus = fromRow["Status"].ToString();

                    // 2. Kiểm tra Bàn đích (toTable)
                    var toRow = GetTableById(toTableId);
                    if (toRow == null)
                    {
                        errorMessage = "Không tìm thấy bàn đích cần chuyển đến!";
                        return false;
                    }
                    if (toRow["Status"].ToString() != "EMPTY")
                    {
                        errorMessage = $"Bàn đích '{toRow["Name"]}' đang có khách! Chỉ có thể chuyển sang bàn còn trống.";
                        return false;
                    }

                    // 3. Cập nhật Orders.TableId = toTableId
                    using (var cmdOrder = new SQLiteCommand("UPDATE Orders SET TableId = @ToTableId WHERE Id = @OrderId;", conn, transaction))
                    {
                        cmdOrder.Parameters.AddWithValue("@ToTableId", toTableId);
                        cmdOrder.Parameters.AddWithValue("@OrderId", orderId);
                        cmdOrder.ExecuteNonQuery();
                    }

                    // 4. Cập nhật Bàn đích: Status = fromStatus, CurrentOrderId = orderId
                    using (var cmdTo = new SQLiteCommand("UPDATE Tables SET Status = @Status, CurrentOrderId = @OrderId WHERE Id = @ToTableId;", conn, transaction))
                    {
                        cmdTo.Parameters.AddWithValue("@Status", fromStatus);
                        cmdTo.Parameters.AddWithValue("@OrderId", orderId);
                        cmdTo.Parameters.AddWithValue("@ToTableId", toTableId);
                        cmdTo.ExecuteNonQuery();
                    }

                    // 5. Cập nhật Bàn nguồn: Status = 'EMPTY', CurrentOrderId = NULL
                    using (var cmdFrom = new SQLiteCommand("UPDATE Tables SET Status = 'EMPTY', CurrentOrderId = NULL WHERE Id = @FromTableId;", conn, transaction))
                    {
                        cmdFrom.Parameters.AddWithValue("@FromTableId", fromTableId);
                        cmdFrom.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorMessage = "Lỗi khi chuyển bàn: " + ex.Message;
                    return false;
                }
            }
        }

        /// <summary>
        /// Gộp đơn từ Bàn A vào Bàn B (Cả hai bàn đều đang có khách)
        /// </summary>
        public bool MergeTables(int fromTableId, int toTableId, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    var fromRow = GetTableById(fromTableId);
                    var toRow = GetTableById(toTableId);

                    if (fromRow == null || fromRow["CurrentOrderId"] == DBNull.Value)
                    {
                        errorMessage = "Bàn gộp đi không có đơn hàng!";
                        return false;
                    }
                    if (toRow == null || toRow["CurrentOrderId"] == DBNull.Value)
                    {
                        errorMessage = "Bàn nhận gộp không có đơn hàng!";
                        return false;
                    }

                    long fromOrderId = Convert.ToInt64(fromRow["CurrentOrderId"]);
                    long toOrderId = Convert.ToInt64(toRow["CurrentOrderId"]);

                    // 1. Chuyển toàn bộ OrderDetails từ fromOrderId sang toOrderId
                    using (var cmdMoveDetails = new SQLiteCommand("UPDATE OrderDetails SET OrderId = @ToOrderId WHERE OrderId = @FromOrderId;", conn, transaction))
                    {
                        cmdMoveDetails.Parameters.AddWithValue("@ToOrderId", toOrderId);
                        cmdMoveDetails.Parameters.AddWithValue("@FromOrderId", fromOrderId);
                        cmdMoveDetails.ExecuteNonQuery();
                    }

                    // 2. Tính lại tổng tiền cho toOrderId
                    string recalcSql = @"
                        SELECT COALESCE(SUM(Quantity * UnitPrice), 0) FROM OrderDetails WHERE OrderId = @ToOrderId;";
                    decimal newTotal = 0;
                    using (var cmdRecalc = new SQLiteCommand(recalcSql, conn, transaction))
                    {
                        cmdRecalc.Parameters.AddWithValue("@ToOrderId", toOrderId);
                        newTotal = Convert.ToDecimal(cmdRecalc.ExecuteScalar());
                    }

                    // 3. Cập nhật lại tổng tiền cho toOrderId
                    using (var cmdUpdateOrder = new SQLiteCommand("UPDATE Orders SET TotalAmount = @NewTotal WHERE Id = @ToOrderId;", conn, transaction))
                    {
                        cmdUpdateOrder.Parameters.AddWithValue("@NewTotal", newTotal);
                        cmdUpdateOrder.Parameters.AddWithValue("@ToOrderId", toOrderId);
                        cmdUpdateOrder.ExecuteNonQuery();
                    }

                    // 4. Xóa hóa đơn rỗng fromOrderId
                    using (var cmdDeleteFromOrder = new SQLiteCommand("DELETE FROM Orders WHERE Id = @FromOrderId;", conn, transaction))
                    {
                        cmdDeleteFromOrder.Parameters.AddWithValue("@FromOrderId", fromOrderId);
                        cmdDeleteFromOrder.ExecuteNonQuery();
                    }

                    // 5. Trả Bàn nguồn về EMPTY
                    using (var cmdResetFrom = new SQLiteCommand("UPDATE Tables SET Status = 'EMPTY', CurrentOrderId = NULL WHERE Id = @FromTableId;", conn, transaction))
                    {
                        cmdResetFrom.Parameters.AddWithValue("@FromTableId", fromTableId);
                        cmdResetFrom.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorMessage = "Lỗi khi gộp bàn: " + ex.Message;
                    return false;
                }
            }
        }
    }
}
