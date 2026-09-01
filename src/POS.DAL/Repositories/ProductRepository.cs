using System;
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
                WHERE p.IsActive = 1";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        // 2. Hàm lấy danh sách Topping/Modifier của một món cụ thể (Sửa đổi phần thiếu)
        public DataTable GetModifiersByProductId(int productId)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT m.Id, m.Name, m.Price 
                FROM Modifiers m
                INNER JOIN ProductModifiers pm ON m.Id = pm.ModifierId
                WHERE pm.ProductId = @ProductId AND m.IsActive = 1";

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
        // 3. Hàm lấy danh sách nhóm danh mục đang hoạt động
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Id, Name FROM Categories WHERE IsActive = 1 ORDER BY Id";

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
