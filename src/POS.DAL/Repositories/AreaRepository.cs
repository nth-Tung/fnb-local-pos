using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL.Repositories
{
    public class AreaRepository
    {
        public DataTable GetAllAreas(bool includeInactive = false)
        {
            string sql = @"
                SELECT a.Id, a.Name, a.SortOrder, a.IsActive,
                       COUNT(t.Id) AS TableCount,
                       SUM(CASE WHEN t.Status IN ('OCCUPIED', 'PRINTED') THEN 1 ELSE 0 END) AS OccupiedCount
                FROM Areas a
                LEFT JOIN Tables t ON a.Id = t.AreaId AND t.IsActive = 1
                WHERE (@IncludeInactive = 1 OR a.IsActive = 1)
                GROUP BY a.Id, a.Name, a.SortOrder, a.IsActive
                ORDER BY a.SortOrder ASC, a.Id ASC;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@IncludeInactive", includeInactive ? 1 : 0);
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataRow GetAreaById(int id)
        {
            string sql = "SELECT * FROM Areas WHERE Id = @Id LIMIT 1;";
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

        public bool InsertArea(string name, int sortOrder, bool isActive, out int newId)
        {
            newId = 0;
            string sql = @"
                INSERT INTO Areas (Name, SortOrder, IsActive) 
                VALUES (@Name, @SortOrder, @IsActive);
                SELECT last_insert_rowid();";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name.Trim());
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

        public bool UpdateArea(int id, string name, int sortOrder, bool isActive)
        {
            string sql = @"
                UPDATE Areas 
                SET Name = @Name, SortOrder = @SortOrder, IsActive = @IsActive 
                WHERE Id = @Id;";

            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name.Trim());
                cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                cmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool HasTables(int areaId)
        {
            string sql = "SELECT COUNT(*) FROM Tables WHERE AreaId = @AreaId;";
            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@AreaId", areaId);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool DeleteArea(int id, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (HasTables(id))
            {
                errorMessage = "Không thể xóa khu vực đang chứa bàn! Vui lòng xóa hoặc di chuyển các bàn sang khu vực khác trước.";
                return false;
            }

            string sql = "DELETE FROM Areas WHERE Id = @Id;";
            using (var conn = SqliteHelper.GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
