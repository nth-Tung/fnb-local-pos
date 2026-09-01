using System;
using System.Data.SQLite;
using POS.DAL.Helpers; // Gọi Helper vào đây

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
                            TotalAmount DECIMAL NOT NULL,       -- Tổng tiền sau giảm giá/thuế
                            DiscountAmount DECIMAL DEFAULT 0,   -- Số tiền được giảm giá
                            PaymentMethod TEXT NOT NULL,       -- 'CASH', 'BANK_TRANSFER' (QR Code)
                            CreatedAt DATETIME NOT NULL,       -- Thời gian tạo đơn
                            CreatedBy TEXT                      -- Tên nhân viên thu ngân trực ca
                        );";

                    // 7. Script tạo bảng Chi tiết đơn hàng (Món ăn + Topping + Combo)
                    string tblOrderDetails = @"
                        CREATE TABLE IF NOT EXISTS OrderDetails (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderId INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            UnitPrice DECIMAL NOT NULL,
                            ParentDetailId INTEGER DEFAULT NULL, -- Liên kết Topping với món chính (Nếu món này là Topping, ParentDetailId sẽ trỏ về Id của ly nước chính)
                            Note TEXT,                           -- Ghi chú cho bếp (Ví dụ: Ít đá, không hành)
                            FOREIGN KEY(OrderId) REFERENCES Orders(Id),
                            FOREIGN KEY(ProductId) REFERENCES Products(Id)
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

                        // Kiểm tra nếu chưa có dữ liệu thì nạp dữ liệu mẫu ban đầu (Seed Data)
                        cmd.CommandText = "SELECT COUNT(*) FROM Categories;";
                        long catCount = (long)cmd.ExecuteScalar();
                        if (catCount == 0)
                        {
                            // 1. Nạp danh mục
                            cmd.CommandText = @"
                                INSERT INTO Categories (Id, Name, IsActive) VALUES 
                                (1, 'Cà phê', 1),
                                (2, 'Trà & Trà sữa', 1),
                                (3, 'Đồ ăn vặt', 1),
                                (4, 'Combo', 1);";
                            cmd.ExecuteNonQuery();

                            // 2. Nạp món ăn
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

                            // 3. Nạp Modifier (Topping)
                            cmd.CommandText = @"
                                INSERT INTO Modifiers (Id, Name, Price, IsActive) VALUES 
                                (1, 'Trân châu đen', 5000, 1),
                                (2, 'Thạch đào', 5000, 1),
                                (3, 'Kem Cheese', 8000, 1),
                                (4, 'Thêm Shot Espresso', 10000, 1),
                                (5, 'Sốt Phô Mai', 7000, 1);";
                            cmd.ExecuteNonQuery();

                            // 4. Nạp ProductModifiers
                            cmd.CommandText = @"
                                INSERT INTO ProductModifiers (ProductId, ModifierId) VALUES 
                                (1, 4), (2, 4), (3, 4),
                                (6, 1), (6, 3),
                                (7, 2), (8, 2),
                                (10, 5), (11, 5);";
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
    }
}
