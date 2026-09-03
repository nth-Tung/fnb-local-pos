using System;
using System.Collections.Generic;
using System.Data.SQLite;
using POS.DAL.Helpers;

namespace POS.DAL
{
    public static class DatabaseInitializer
    {
        public static void Run()
        {
            using (var conn = SqliteHelper.GetConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // 1. Script tạo bảng danh mục món ăn
                    string tblCategories = @"
                        CREATE TABLE IF NOT EXISTS Categories (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            IsActive INTEGER DEFAULT 1
                        );";

                    // 2. Script tạo bảng món ăn chính (SINGLE hoặc COMBO)
                    string tblProducts = @"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            CategoryId INTEGER,
                            Name TEXT NOT NULL,
                            Price DECIMAL NOT NULL,
                            ProductType TEXT NOT NULL, 
                            IsActive INTEGER DEFAULT 1,
                            FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
                        );";

                    // 3. Script tạo bảng Topping đi kèm (Dành cho Cà phê)
                    string tblModifiers = @"
                        CREATE TABLE IF NOT EXISTS Modifiers (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Price DECIMAL NOT NULL,
                            IsActive INTEGER DEFAULT 1
                        );";

                    // 4. Script tạo bảng liên kết Món ăn - Topping
                    string tblProductModifiers = @"
                        CREATE TABLE IF NOT EXISTS ProductModifiers (
                            ProductId INTEGER,
                            ModifierId INTEGER,
                            PRIMARY KEY (ProductId, ModifierId),
                            FOREIGN KEY(ProductId) REFERENCES Products(Id),
                            FOREIGN KEY(ModifierId) REFERENCES Modifiers(Id)
                        );";

                    // 5. Script tạo bảng chi tiết cấu trúc Combo (Dành cho Fast Food)
                    string tblComboDetails = @"
                        CREATE TABLE IF NOT EXISTS ComboDetails (
                            ComboId INTEGER,
                            ProductId INTEGER,
                            Quantity INTEGER DEFAULT 1,
                            PRIMARY KEY (ComboId, ProductId),
                            FOREIGN KEY(ComboId) REFERENCES Products(Id),
                            FOREIGN KEY(ProductId) REFERENCES Products(Id)
                        );";

                    // 6. Script tạo bảng Đơn hàng (Hóa đơn chính)
                    string tblOrders = @"
                        CREATE TABLE IF NOT EXISTS Orders (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderNumber TEXT NOT NULL,         -- Số hóa đơn dạng: HD-20260331-0001
                            TableId INTEGER DEFAULT NULL,       -- Liên kết với Bàn (NULL nếu là đơn bán mang đi)
                            OrderStatus TEXT DEFAULT 'PAID',   -- 'OPEN' (Đang ăn tại bàn), 'PAID' (Đã thanh toán), 'CANCELLED'
                            TotalAmount DECIMAL NOT NULL,       -- Tổng tiền sau giảm giá/thuế
                            DiscountAmount DECIMAL DEFAULT 0,   -- Số tiền được giảm giá
                            PaymentMethod TEXT NOT NULL,       -- 'CASH', 'BANK_TRANSFER' (QR Code)
                            CreatedAt DATETIME NOT NULL,       -- Thời gian tạo đơn
                            SettledAt DATETIME DEFAULT NULL,   -- Thời gian thanh toán thực tế
                            CreatedBy TEXT,                     -- Tên nhân viên thu ngân trực ca
                            Note TEXT                           -- Ghi chú hóa đơn
                        );";

                    // 7. Script tạo bảng Chi tiết đơn hàng (Món ăn + Topping + Combo)
                    string tblOrderDetails = @"
                        CREATE TABLE IF NOT EXISTS OrderDetails (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderId INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            UnitPrice DECIMAL NOT NULL,
                            ParentDetailId INTEGER DEFAULT NULL, -- Liên kết Topping với món chính
                            Note TEXT,                           -- Ghi chú cho bếp (Ví dụ: Ít đá, không hành)
                            FOREIGN KEY(OrderId) REFERENCES Orders(Id),
                            FOREIGN KEY(ProductId) REFERENCES Products(Id)
                        );";

                    // 8. Script tạo bảng Khu vực (Tầng, Không gian)
                    string tblAreas = @"
                        CREATE TABLE IF NOT EXISTS Areas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            SortOrder INTEGER DEFAULT 0,
                            IsActive INTEGER DEFAULT 1
                        );";

                    // 9. Script tạo bảng Bàn (Tables)
                    string tblTables = @"
                        CREATE TABLE IF NOT EXISTS Tables (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            AreaId INTEGER NOT NULL,
                            Name TEXT NOT NULL,
                            Capacity INTEGER DEFAULT 4,
                            Status TEXT DEFAULT 'EMPTY',       -- 'EMPTY', 'OCCUPIED', 'PRINTED'
                            CurrentOrderId INTEGER DEFAULT NULL,
                            SortOrder INTEGER DEFAULT 0,
                            IsActive INTEGER DEFAULT 1,
                            FOREIGN KEY(AreaId) REFERENCES Areas(Id),
                            FOREIGN KEY(CurrentOrderId) REFERENCES Orders(Id)
                        );";

                    // Thực thi các câu lệnh tạo bảng
                    using (var cmd = new SQLiteCommand(conn))
                    {
                        cmd.CommandText = tblCategories; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblProducts; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblModifiers; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblProductModifiers; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblComboDetails; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblOrders; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblOrderDetails; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblAreas; cmd.ExecuteNonQuery();
                        cmd.CommandText = tblTables; cmd.ExecuteNonQuery();

                        // Nâng cấp cột cho bảng Orders nếu DB cũ đã tồn tại
                        EnsureOrderColumns(conn);

                        // 1. Nạp dữ liệu danh mục & món ăn mẫu nếu chưa có
                        cmd.CommandText = "SELECT COUNT(*) FROM Categories;";
                        long catCount = (long)cmd.ExecuteScalar();
                        if (catCount == 0)
                        {
                            cmd.CommandText = @"
                                INSERT INTO Categories (Id, Name, IsActive) VALUES 
                                (1, 'Cà phê', 1),
                                (2, 'Trà & Trà sữa', 1),
                                (3, 'Đồ ăn vặt', 1),
                                (4, 'Combo', 1);";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"
                                INSERT INTO Products (Id, CategoryId, Name, Price, ProductType, IsActive) VALUES 
                                (1, 1, 'Cafe Đá', 29000, 'SINGLE', 1),
                                (2, 1, 'Cafe Sữa', 32000, 'SINGLE', 1),
                                (3, 1, 'Bạc Xỉu', 35000, 'SINGLE', 1),
                                (4, 1, 'Espresso', 30000, 'SINGLE', 1),
                                (5, 1, 'Cappuccino', 40000, 'SINGLE', 1),
                                (6, 2, 'Trà Sữa Trân Châu', 35000, 'SINGLE', 1),
                                (7, 2, 'Trà Đào Cam Sả', 38000, 'SINGLE', 1),
                                (8, 2, 'Trà Vải Nhiệt Đới', 38000, 'SINGLE', 1),
                                (9, 2, 'Matcha Latte', 42000, 'SINGLE', 1),
                                (10, 3, 'Gà Rán Giòn', 39000, 'SINGLE', 1),
                                (11, 3, 'Khoai Tây Chiên', 25000, 'SINGLE', 1),
                                (12, 3, 'Hamburger Bò', 45000, 'SINGLE', 1),
                                (13, 3, 'Bánh Mì Que', 20000, 'SINGLE', 1),
                                (14, 4, 'Combo Gà + Nước', 59000, 'COMBO', 1),
                                (15, 4, 'Combo Burger + Khoai + Nước', 75000, 'COMBO', 1),
                                (16, 4, 'Combo Cafe + Bánh', 49000, 'COMBO', 1);";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"
                                INSERT INTO Modifiers (Id, Name, Price, IsActive) VALUES 
                                (1, 'Trân châu đen', 5000, 1),
                                (2, 'Thạch đào', 5000, 1),
                                (3, 'Kem Cheese', 8000, 1),
                                (4, 'Thêm Shot Espresso', 10000, 1),
                                (5, 'Sốt Phô Mai', 7000, 1);";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"
                                INSERT INTO ProductModifiers (ProductId, ModifierId) VALUES 
                                (1, 4), (2, 4), (3, 4),
                                (6, 1), (6, 3),
                                (7, 2), (8, 2),
                                (10, 5), (11, 5);";
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Nạp dữ liệu Khu vực & Bàn mẫu nếu chưa có
                        cmd.CommandText = "SELECT COUNT(*) FROM Areas;";
                        long areaCount = (long)cmd.ExecuteScalar();
                        if (areaCount == 0)
                        {
                            cmd.CommandText = @"
                                INSERT INTO Areas (Id, Name, SortOrder, IsActive) VALUES 
                                (1, 'Tầng 1 (Máy lạnh)', 1, 1),
                                (2, 'Tầng 2 (Ban công)', 2, 1),
                                (3, 'Sân vườn (Ngoài trời)', 3, 1);";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"
                                INSERT INTO Tables (AreaId, Name, Capacity, Status, SortOrder, IsActive) VALUES 
                                (1, 'Bàn 01', 4, 'EMPTY', 1, 1),
                                (1, 'Bàn 02', 4, 'EMPTY', 2, 1),
                                (1, 'Bàn 03', 4, 'EMPTY', 3, 1),
                                (1, 'Bàn 04', 2, 'EMPTY', 4, 1),
                                (1, 'Bàn 05', 6, 'EMPTY', 5, 1),
                                (1, 'Bàn 06', 4, 'EMPTY', 6, 1),
                                (2, 'Bàn 07', 4, 'EMPTY', 1, 1),
                                (2, 'Bàn 08', 4, 'EMPTY', 2, 1),
                                (2, 'Bàn 09', 2, 'EMPTY', 3, 1),
                                (2, 'Bàn 10', 4, 'EMPTY', 4, 1),
                                (3, 'Bàn 11', 6, 'EMPTY', 1, 1),
                                (3, 'Bàn 12', 6, 'EMPTY', 2, 1),
                                (3, 'Bàn 13', 4, 'EMPTY', 3, 1),
                                (3, 'Bàn 14', 8, 'EMPTY', 4, 1);";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private static void EnsureOrderColumns(SQLiteConnection conn)
        {
            var cols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            using (var cmd = new SQLiteCommand("PRAGMA table_info(Orders);", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    cols.Add(reader["name"].ToString());
                }
            }

            if (!cols.Contains("TableId"))
            {
                using (var alter = new SQLiteCommand("ALTER TABLE Orders ADD COLUMN TableId INTEGER DEFAULT NULL;", conn))
                {
                    alter.ExecuteNonQuery();
                }
            }
            if (!cols.Contains("OrderStatus"))
            {
                using (var alter = new SQLiteCommand("ALTER TABLE Orders ADD COLUMN OrderStatus TEXT DEFAULT 'PAID';", conn))
                {
                    alter.ExecuteNonQuery();
                }
            }
            if (!cols.Contains("SettledAt"))
            {
                using (var alter = new SQLiteCommand("ALTER TABLE Orders ADD COLUMN SettledAt DATETIME DEFAULT NULL;", conn))
                {
                    alter.ExecuteNonQuery();
                }
            }
            if (!cols.Contains("Note"))
            {
                using (var alter = new SQLiteCommand("ALTER TABLE Orders ADD COLUMN Note TEXT DEFAULT NULL;", conn))
                {
                    alter.ExecuteNonQuery();
                }
            }
        }
    }
}
