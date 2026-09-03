using System;
using System.Data;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL.Repositories
{
    public class CategoryRepository
    {
        public DataTable GetAllCategories(bool includeInactive = true)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT 
                    c.Id, 
                    c.Name, 
                    c.IsActive,
                    COUNT(p.Id) AS ProductCount
                FROM Categories c
                LEFT JOIN Products p ON c.Id = p.CategoryId
                " + (includeInactive ? "" : "WHERE c.IsActive = 1 ") + @"
                GROUP BY c.Id, c.Name, c.IsActive
                ORDER BY c.Id ASC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataRow GetCategoryById(int id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Id, Name, IsActive FROM Categories WHERE Id = @Id;";

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

        public int InsertCategory(string name, int isActive = 1)
        {
            string sql = @"
                INSERT INTO Categories (Name, IsActive)
                VALUES (@Name, @IsActive);
                SELECT last_insert_rowid();";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public bool UpdateCategory(int id, string name, int isActive)
        {
            string sql = "UPDATE Categories SET Name = @Name, IsActive = @IsActive WHERE Id = @Id;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteCategory(int id)
        {
            // Nếu có sản phẩm liên kết thì không xóa cứng mà ném ngoại lệ hoặc trả false
            if (HasProducts(id))
            {
                return false;
            }

            string sql = "DELETE FROM Categories WHERE Id = @Id;";
            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool HasProducts(int categoryId)
        {
            string sql = "SELECT COUNT(1) FROM Products WHERE CategoryId = @CategoryId;";
            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                long count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
