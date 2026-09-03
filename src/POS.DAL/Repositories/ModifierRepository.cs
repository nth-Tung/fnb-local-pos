using System;
using System.Data;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL.Repositories
{
    public class ModifierRepository
    {
        public DataTable GetAllModifiers(bool includeInactive = true)
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT Id, Name, Price, IsActive 
                FROM Modifiers 
                " + (includeInactive ? "" : "WHERE IsActive = 1 ") + @"
                ORDER BY Id ASC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var adapter = new SQLiteDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataRow GetModifierById(int id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Id, Name, Price, IsActive FROM Modifiers WHERE Id = @Id;";

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

        public int InsertModifier(string name, decimal price, int isActive = 1)
        {
            string sql = @"
                INSERT INTO Modifiers (Name, Price, IsActive)
                VALUES (@Name, @Price, @IsActive);
                SELECT last_insert_rowid();";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public bool UpdateModifier(int id, string name, decimal price, int isActive)
        {
            string sql = "UPDATE Modifiers SET Name = @Name, Price = @Price, IsActive = @IsActive WHERE Id = @Id;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteModifier(int id)
        {
            // Xóa liên kết ProductModifiers trước rồi xóa Modifier
            using (var conn = SqliteHelper.GetConnection())
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    using (var cmd1 = new SQLiteCommand("DELETE FROM ProductModifiers WHERE ModifierId = @Id;", conn, trans))
                    {
                        cmd1.Parameters.AddWithValue("@Id", id);
                        cmd1.ExecuteNonQuery();
                    }

                    int affected;
                    using (var cmd2 = new SQLiteCommand("DELETE FROM Modifiers WHERE Id = @Id;", conn, trans))
                    {
                        cmd2.Parameters.AddWithValue("@Id", id);
                        affected = cmd2.ExecuteNonQuery();
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
    }
}
