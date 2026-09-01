using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace POS.DAL.Helpers
{
    public static class SqliteHelper
    {
        // Đường dẫn file DB nằm cùng thư mục chạy ứng dụng .exe hoặc LocalAppData
        private static readonly string DbPath = GetDatabasePath();

        private static string GetDatabasePath()
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string testFile = Path.Combine(baseDir, ".test_perm");
                File.WriteAllText(testFile, "1");
                File.Delete(testFile);
                return Path.Combine(baseDir, "pos_data.db");
            }
            catch
            {
                string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FnBLocalPOS");
                if (!Directory.Exists(appData))
                {
                    Directory.CreateDirectory(appData);
                }
                return Path.Combine(appData, "pos_data.db");
            }
        }

        // Chuỗi kết nối tối ưu hóa tốc độ cho môi trường Local (Bật Pooling và tăng tốc độ đọc ghi)
        public static string ConnectionString => $"Data Source={DbPath};Version=3;Pooling=True;Max Pool Size=100;Journal Mode=WAL;Synchronous=Normal;";

        // Hàm trả về một kết nối đã được mở sẵn (Dùng cho các Repository truy vấn dữ liệu)
        public static SQLiteConnection GetConnection()
        {
            if (!File.Exists(DbPath))
            {
                SQLiteConnection.CreateFile(DbPath);
            }
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // Hàm tiện ích thực thi câu lệnh SQL nhanh (Không trả về dữ liệu như INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
