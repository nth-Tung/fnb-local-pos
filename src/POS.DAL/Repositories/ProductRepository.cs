using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL.Repositories
{
    public class ProductRepository
    {
        // 1. Hàm lấy toàn bộ sản phẩm đang kinh doanh để nạp vào menu quầy
        public DataTable GetActiveProducts()
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT p.Id, p.CategoryId, p.Name, p.Price, p.ProductType, c.Name AS CategoryName 
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                WHERE p.IsActive = 1
                ORDER BY p.CategoryId, p.Name;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        // 2. Hàm lọc sản phẩm đa tiêu chí cho màn hình Quản lý Menu
        public DataTable GetFilteredProducts(int? categoryId = null, string keyword = null, bool? isActive = null)
        {
            DataTable dt = new DataTable();
            var conditions = new List<string>();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                conditions.Add("p.CategoryId = @CategoryId");
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                conditions.Add("(p.Name LIKE @Keyword OR c.Name LIKE @Keyword)");
            }

            if (isActive.HasValue)
            {
                conditions.Add("p.IsActive = @IsActive");
            }

            string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

            string sql = $@"
                SELECT 
                    p.Id, 
                    p.CategoryId, 
                    COALESCE(c.Name, 'Chưa phân loại') AS CategoryName, 
                    p.Name, 
                    p.Price, 
                    p.ProductType, 
                    p.IsActive,
                    (SELECT COUNT(1) FROM ProductModifiers pm WHERE pm.ProductId = p.Id) AS ModifierCount
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                {whereClause}
                ORDER BY p.CategoryId ASC, p.Id DESC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);
                }

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword.Trim() + "%");
                }

                if (isActive.HasValue)
                {
                    cmd.Parameters.AddWithValue("@IsActive", isActive.Value ? 1 : 0);
                }

                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // 3. Lấy thông tin chi tiết của 1 sản phẩm theo Id
        public DataRow GetProductById(int id)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT p.Id, p.CategoryId, p.Name, p.Price, p.ProductType, p.IsActive, c.Name AS CategoryName
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id
                WHERE p.Id = @Id;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // 4. Lấy danh sách Id các Topping được gán cho món ăn
        public List<int> GetModifierIdsByProductId(int productId)
        {
            var list = new List<int>();
            string sql = "SELECT ModifierId FROM ProductModifiers WHERE ProductId = @ProductId;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToInt32(reader["ModifierId"]));
                    }
                }
            }
            return list;
        }

        // 5. Thêm mới sản phẩm kèm danh sách Topping (Sử dụng SQLite Transaction)
        public int InsertProduct(string name, int categoryId, decimal price, string productType, int isActive, List<int> modifierIds)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    string sqlProduct = @"
                        INSERT INTO Products (CategoryId, Name, Price, ProductType, IsActive)
                        VALUES (@CategoryId, @Name, @Price, @ProductType, @IsActive);
                        SELECT last_insert_rowid();";

                    int newProductId;
                    using (var cmd = new SQLiteCommand(sqlProduct, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        cmd.Parameters.AddWithValue("@Name", name.Trim());
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@ProductType", string.IsNullOrEmpty(productType) ? "SINGLE" : productType);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        newProductId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (modifierIds != null && modifierIds.Count > 0)
                    {
                        string sqlMod = "INSERT INTO ProductModifiers (ProductId, ModifierId) VALUES (@ProductId, @ModifierId);";
                        foreach (int modId in modifierIds)
                        {
                            using (var cmdMod = new SQLiteCommand(sqlMod, conn, trans))
                            {
                                cmdMod.Parameters.AddWithValue("@ProductId", newProductId);
                                cmdMod.Parameters.AddWithValue("@ModifierId", modId);
                                cmdMod.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                    return newProductId;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // 6. Cập nhật thông tin sản phẩm và liên kết Topping (Transaction)
        public bool UpdateProduct(int id, string name, int categoryId, decimal price, string productType, int isActive, List<int> modifierIds)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    string sqlProduct = @"
                        UPDATE Products 
                        SET CategoryId = @CategoryId, Name = @Name, Price = @Price, ProductType = @ProductType, IsActive = @IsActive
                        WHERE Id = @Id;";

                    int affected;
                    using (var cmd = new SQLiteCommand(sqlProduct, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        cmd.Parameters.AddWithValue("@Name", name.Trim());
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@ProductType", string.IsNullOrEmpty(productType) ? "SINGLE" : productType);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        affected = cmd.ExecuteNonQuery();
                    }

                    // Cập nhật lại danh sách Topping
                    using (var cmdDel = new SQLiteCommand("DELETE FROM ProductModifiers WHERE ProductId = @ProductId;", conn, trans))
                    {
                        cmdDel.Parameters.AddWithValue("@ProductId", id);
                        cmdDel.ExecuteNonQuery();
                    }

                    if (modifierIds != null && modifierIds.Count > 0)
                    {
                        string sqlMod = "INSERT INTO ProductModifiers (ProductId, ModifierId) VALUES (@ProductId, @ModifierId);";
                        foreach (int modId in modifierIds)
                        {
                            using (var cmdMod = new SQLiteCommand(sqlMod, conn, trans))
                            {
                                cmdMod.Parameters.AddWithValue("@ProductId", id);
                                cmdMod.Parameters.AddWithValue("@ModifierId", modId);
                                cmdMod.ExecuteNonQuery();
                            }
                        }
                    }

                    trans.Commit();
                    return affected > 0;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // 7. Bật / Tắt trạng thái kinh doanh của món (Bật/Tắt nhanh)
        public bool ToggleProductStatus(int id, bool isActive)
        {
            string sql = "UPDATE Products SET IsActive = @IsActive WHERE Id = @Id;";
            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 8. Xóa món ăn: Nếu đã phát sinh hóa đơn thì chuyển IsActive = 0 (Soft delete), nếu chưa thì Hard delete
        public bool DeleteProduct(int id, out bool wasSoftDeleted)
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    // Kiểm tra xem món đã nằm trong hóa đơn nào chưa
                    string sqlCheck = "SELECT COUNT(1) FROM OrderDetails WHERE ProductId = @Id;";
                    long orderCount;
                    using (var cmd = new SQLiteCommand(sqlCheck, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        orderCount = Convert.ToInt64(cmd.ExecuteScalar());
                    }

                    if (orderCount > 0)
                    {
                        // Đã có trong hóa đơn cũ -> Soft delete để giữ toàn vẹn lịch sử hóa đơn
                        string sqlSoft = "UPDATE Products SET IsActive = 0 WHERE Id = @Id;";
                        using (var cmd = new SQLiteCommand(sqlSoft, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.ExecuteNonQuery();
                        }
                        wasSoftDeleted = true;
                    }
                    else
                    {
                        // Chưa phát sinh hóa đơn -> Xóa sạch liên kết và xóa món
                        using (var cmd1 = new SQLiteCommand("DELETE FROM ProductModifiers WHERE ProductId = @Id;", conn, trans))
                        {
                            cmd1.Parameters.AddWithValue("@Id", id);
                            cmd1.ExecuteNonQuery();
                        }

                        using (var cmd2 = new SQLiteCommand("DELETE FROM Products WHERE Id = @Id;", conn, trans))
                        {
                            cmd2.Parameters.AddWithValue("@Id", id);
                            cmd2.ExecuteNonQuery();
                        }
                        wasSoftDeleted = false;
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // 9. Lấy danh sách Topping của 1 món cụ thể
        public DataTable GetModifiersByProductId(int productId)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT m.Id, m.Name, m.Price 
                FROM Modifiers m
                INNER JOIN ProductModifiers pm ON m.Id = pm.ModifierId
                WHERE pm.ProductId = @ProductId AND m.IsActive = 1;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // 10. Lấy danh sách nhóm danh mục đang hoạt động
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Id, Name FROM Categories WHERE IsActive = 1 ORDER BY Id ASC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
