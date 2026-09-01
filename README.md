# F&B Local POS - Hệ Thống Bán Hàng Tại Quầy Quán Cà Phê & Fast Food

Hệ thống POS bán hàng tại quầy (Counter-Service) hiệu suất cao, tối ưu 100% cho thao tác cảm ứng và chuột tốc độ cao trên Windows Forms (.NET Framework 4.7.2 & SQLite).

## 📁 Cấu Trúc Thư Mục Repository

- **`src/`**: Chứa toàn bộ mã nguồn của hệ thống theo Kiến trúc 3 lớp:
  - **`src/POS.UI/`**: Tầng Giao diện người dùng (Windows Forms & Dialogs độc lập).
  - **`src/POS.BLL/`**: Tầng Xử lý nghiệp vụ, tính toán chi phí & DTOs định kiểu mạnh.
  - **`src/POS.DAL/`**: Tầng Truy xuất dữ liệu SQLite, Database Transactions & Seed Data.
- **`docs/`**: Chứa tài liệu hướng dẫn kỹ thuật & quy chuẩn coding:
  - **[CODING_STANDARDS_AND_CONVENTIONS.md](docs/CODING_STANDARDS_AND_CONVENTIONS.md)**: Quy chuẩn thiết kế và Coding Conventions bắt buộc.
- **`packages/`**: Thư viện phụ thuộc NuGet.
- **`POSApp.sln`**: Visual Studio Solution chính.

## 🚀 Hướng Dẫn Chạy Ứng Dụng

1. Mở file `POSApp.sln` bằng Visual Studio 2019/2022.
2. Thiết lập `POS.UI` làm **Startup Project**.
3. Bấm **F5** (hoặc `Ctrl + F5`) để biên dịch và chạy ứng dụng.
4. Cơ sở dữ liệu SQLite (`pos_data.db`) cùng thực đơn mẫu phong phú sẽ tự động được khởi tạo trong lần chạy đầu tiên.
