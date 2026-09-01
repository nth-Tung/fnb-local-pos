# QUY CHUẨN THIẾT KẾ VÀ CODING CONVENTIONS DỰ ÁN F&B LOCAL POS

> **Tài liệu chuẩn hóa kiến trúc, quy chuẩn lập trình và hướng dẫn phát triển phần mềm**  
> **Dự án**: F&B Local POS (Hệ thống quản lý bán hàng quán Cà phê & Fast Food)  
> **Nền tảng**: .NET Framework 4.7.2 / Windows Forms / C# 7.3+ / SQLite  

---

## MỤC LỤC

1. [Tổng Quan Kiến Trúc 3 Lớp (3-Tier Architecture)](#1-tổng-quan-kiến-trúc-3-lớp-3-tier-architecture)
2. [Cấu Trúc Thư Mục Chuẩn (Project & Folder Structure)](#2-cấu-trúc-thư-mục-chuẩn-project--folder-structure)
3. [Quy Tắc Tầng Giao Diện (Presentation Layer - POS.UI)](#3-quy-tắc-tầng-giao-diện-presentation-layer---posui)
4. [Quy Tắc Tầng Nghiệp Vụ (Business Logic Layer - POS.BLL)](#4-quy-tắc-tầng-nghiệp-vụ-business-logic-layer---posbll)
5. [Quy Tắc Tầng Truy Cập Dữ Liệu (Data Access Layer - POS.DAL)](#5-quy-tắc-tầng-truy-cập-dữ-liệu-data-access-layer---posdal)
6. [Quy Chuẩn Đối Tượng Truyền Dữ Liệu (DTOs & Models)](#6-quy-chuẩn-đối-tượng-truyền-dữ-liệu-dtos--models)
7. [Quy Ước Đặt Tên (Naming Conventions)](#7-quy-ước-đặt-tên-naming-conventions)
8. [Quy Tắc Xử Lý Ngoại Lệ (Exception Handling)](#8-quy-tắc-xử-lý-ngoại-lệ-exception-handling)
9. [Nguyên Tắc Clean Code & Single Responsibility (SRP)](#9-nguyên-tắc-clean-code--single-responsibility-srp)

---

## 1. TỔNG QUAN KIẾN TRÚC 3 LỚP (3-TIER ARCHITECTURE)

Dự án áp dụng mô hình phân lớp nghiêm ngặt theo **Kiến trúc 3 lớp chuẩn doanh nghiệp**:

```
+-------------------------------------------------------------------------+
|                      POS.UI (Presentation Layer)                        |
|   - Forms (Giao diện chính: Bán hàng, Báo cáo, Quản lý)                |
|   - Dialogs (Hộp thoại popup: Giảm giá, Tiền mặt, QR, Nhập liệu)        |
|   - UserControls (Các khối giao diện tùy biến)                          |
+-------------------------------------------------------------------------+
                                     │ (Chỉ gọi BLL)
                                     ▼
+-------------------------------------------------------------------------+
|                      POS.BLL (Business Logic Layer)                     |
|   - DTOs (Data Transfer Objects định kiểu mạnh)                         |
|   - Services (Xử lý nghiệp vụ: Tính tiền, Khuyến mãi, Validate)        |
|   - Business Validations & Rules                                        |
+-------------------------------------------------------------------------+
                                     │ (Chỉ gọi DAL)
                                     ▼
+-------------------------------------------------------------------------+
|                      POS.DAL (Data Access Layer)                        |
|   - Helpers (SqliteHelper quản lý Connection, Pooling, Transaction)     |
|   - Repositories (Truy vấn SQL, Thực thi Parameterized Query)           |
|   - DatabaseInitializer (Tạo bảng SQLite & nạp Seed Data)               |
+-------------------------------------------------------------------------+
                                     │
                                     ▼
                        [ Cơ sở dữ liệu SQLite: pos_data.db ]
```

### Nguyên tắc luồng phụ thuộc (Dependency Rule):
- **`POS.UI`** tham chiếu đến `POS.BLL` (và `POS.DAL` nếu cần Entity).
- **`POS.BLL`** chỉ tham chiếu đến `POS.DAL`.
- **`POS.DAL`** là tầng dưới cùng, độc lập, không tham chiếu ngược lên BLL hoặc UI.
- **Tuyệt đối cấm** tầng UI gọi trực tiếp các câu lệnh SQL hoặc mở kết nối SQLite.

---

## 2. CẤU TRÚC THƯ MỤC CHUẨN (PROJECT & FOLDER STRUCTURE)

```
fnb-local-pos/
├── docs/                                   <-- Toàn bộ tài liệu kỹ thuật & quy chuẩn
│   ├── CODING_STANDARDS_AND_CONVENTIONS.md
│   └── README.md
│
├── packages/                               <-- Thư mục chứa thư viện NuGet
│
├── src/                                    <-- Toàn bộ mã nguồn dự án
│   ├── POS.DAL/                            <-- Tầng Data Access Layer
│   │   ├── DatabaseInitializer.cs         <-- Khởi tạo Schema & Seed data
│   │   ├── Helpers/
│   │   │   └── SqliteHelper.cs            <-- Quản lý chuỗi kết nối & SQLiteConnection
│   │   └── Repositories/
│   │       ├── OrderRepository.cs         <-- Truy vấn & lưu hóa đơn
│   │       └── ProductRepository.cs       <-- Truy vấn thực đơn, danh mục, topping
│   │
│   ├── POS.BLL/                            <-- Tầng Business Logic Layer
│   │   ├── DTOs/
│   │   │   ├── CartItemDto.cs             <-- DTO dòng món trong giỏ hàng
│   │   │   └── OrderSummaryDto.cs         <-- DTO kết quả tính toán chi phí
│   │   └── Services/
│   │       ├── OrderService.cs            <-- Nghiệp vụ đơn hàng & thanh toán
│   │       └── ProductService.cs          <-- Nghiệp vụ thực đơn & danh mục
│   │
│   └── POS.UI/                             <-- Tầng Presentation Layer (WinForms)
│       ├── Program.cs                     <-- Điểm khởi chạy ứng dụng
│       ├── FrmCounterSale.cs              <-- Màn hình bán hàng chính tại quầy
│       ├── FrmCounterSale.Designer.cs
│       ├── FrmCounterSale.resx
│       └── Dialogs/                       <-- Toàn bộ các popup / modal độc lập
│           ├── FrmDiscountDialog.cs       <-- Hộp thoại nhập chiết khấu / giảm giá
│           ├── FrmCashPaymentDialog.cs    <-- Hộp thoại thanh toán tiền mặt & thối tiền
│           └── FrmQrPaymentDialog.cs      <-- Hộp thoại thanh toán VietQR
│
├── POSApp.sln                              <-- Visual Studio Solution
└── README.md
```

---

## 3. QUY TẮC TẦNG GIAO DIỆN (PRESENTATION LAYER - POS.UI)

### 3.1. Trách nhiệm duy nhất của UI:
1. **Hiển thị dữ liệu** lấy từ BLL lên các Control (Grid, FlowLayoutPanel, Label, Button).
2. **Thu thập dữ liệu người dùng** (sự kiện Click, TextChanged, KeyDown).
3. **Ánh xạ Control -> DTO** và truyền xuống tầng BLL.
4. **Gọi BLL** để thực hiện logic và nhận kết quả trả về hiển thị thông báo.

### 3.2. Những điều TUYỆT ĐỐI CẤM tại tầng UI:
- ❌ **CẤM viết Anonymous inline Form**: Tuyệt đối không dùng `using (var dlg = new Form()) { ... }` và căn pixel bằng tay (`Location = new Point(x, y)`). Mọi hộp thoại popup phải là một Form độc lập đặt trong `POS.UI/Dialogs/`.
- ❌ **CẤM tính toán nghiệp vụ trong Form.cs**: Không tự tính thuế, giảm giá, tổng tiền, tiền thừa trong Form. Phải gọi hàm `Service.Calculate...()` của BLL.
- ❌ **CẤM viết câu lệnh SQL**: Không viết bất kỳ câu lệnh `SELECT`, `INSERT`, `UPDATE`, `DELETE` nào trong Form.

### 3.3. Quy tắc thiết kế giao diện cảm ứng (Touch-Friendly POS):
- **Responsive Layout**: Luôn dùng `Dock`, `TableLayoutPanel`, `FlowLayoutPanel` kết hợp `Padding` và `Margin` để tự co giãn trên mọi kích thước màn hình máy POS (1024x768, 1366x768, 1920x1080).
- **Kích thước nút bấm**: Nút bấm trên màn hình cảm ứng tối thiểu đạt chiều cao **40px - 48px** cho nút phụ, **80px - 110px** cho nút món ăn và nút thanh toán.
- **Bắt phím tắt (Hotkeys)**: Hỗ trợ phím chức năng thu ngân F1 (Tiền mặt), F2 (QR), F3 (Hủy), F4 (Mở két), F5 (In bill), `+` / `-` (Tăng/giảm SL).

---

## 4. QUY TẮC TẦNG NGHIỆP VỤ (BUSINESS LOGIC LAYER - POS.BLL)

### 4.1. Trách nhiệm của BLL:
1. **Kiểm tra tính hợp lệ nghiệp vụ (Business Validation)**: Kiểm tra giỏ hàng có rỗng không, số lượng món > 0, đơn giá >= 0, thông tin thu ngân hợp lệ.
2. **Thực hiện mọi phép tính toán (Calculations)**: Tính tổng tiền thô (`RawTotal`), tính tiền giảm giá theo % hoặc tiền mặt (`DiscountAmount`), chặn giảm giá không vượt quá 100% hoặc tổng tiền hàng, tính tổng tiền thực trả (`FinalTotal`).
3. **Điều phối quy trình (Orchestration)**: Đóng gói thông tin, sinh mã đơn hàng, gọi repository lưu trữ trong Database Transaction.

### 4.2. Chuẩn thiết kế Service:
- Mọi phương thức tính toán phải độc lập, không phụ thuộc vào trạng thái Form để có thể viết **Unit Test** dễ dàng.
- Ví dụ hàm tính toán chuẩn:
```csharp
public OrderSummaryDto CalculateOrderSummary(List<CartItemDto> cartItems, decimal discountValue, bool isPercentDiscount)
```

---

## 5. QUY TẮC TẦNG TRUY CẬP DỮ LIỆU (DATA ACCESS LAYER - POS.DAL)

### 5.1. Quản lý Kết Nối & Tài Nguyên (Connection Management):
- Luôn mở kết nối thông qua `SqliteHelper.GetConnection()`.
- Bắt buộc dùng khối `using` cho mọi đối tượng `SQLiteConnection`, `SQLiteCommand`, `SQLiteDataAdapter`, `SQLiteTransaction` để giải phóng bộ nhớ và tránh khóa file CSDL (Database Locking).

### 5.2. Chống SQL Injection 100%:
- **TUYỆT ĐỐI CẤM** cộng chuỗi SQL (`"SELECT * FROM Users WHERE Name = '" + name + "'"`).
- **BẮT BUỘC** dùng tham số Parameterized Query:
```csharp
string sql = "SELECT * FROM Products WHERE CategoryId = @CategoryId AND IsActive = 1;";
using (var cmd = new SQLiteCommand(sql, conn))
{
    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
    // ...
}
```

### 5.3. Sử dụng Database Transaction cho thao tác nhiều bảng:
- Mọi nghiệp vụ ghi dữ liệu liên quan từ 2 bảng trở lên (ví dụ: tạo `Orders` và thêm nhiều dòng `OrderDetails`) bắt buộc phải bọc trong `conn.BeginTransaction()`.
- Commit khi hoàn tất toàn bộ, Rollback ngay lập tức nếu xảy ra Exception.

---

## 6. QUY CHUẨN ĐỐI TƯỢNG TRUYỀN DỮ LIỆU (DTOS & MODELS)

1. **Strongly-Typed 100%**: Mọi dữ liệu luân chuyển giữa `POS.UI` -> `POS.BLL` -> `POS.DAL` phải được đóng gói vào các Class DTO rõ ràng.
2. **CẤM lạm dụng `Dictionary<string, object>` hoặc `dynamic`**: Dùng Dictionary rất dễ gây lỗi chính tả tên Key ở thời điểm Runtime (`Runtime Typo Error`) và khó bảo trì.
3. **Đặt tên DTO**: Tên class luôn kết thúc bằng hậu tố `Dto` (ví dụ: `CartItemDto`, `OrderSummaryDto`, `ProductDto`, `OrderCreateDto`).
4. **Vị trí**: Lưu trữ trong thư mục `POS.BLL/DTOs/`.

---

## 7. QUY ƯỚC ĐẶT TÊN (NAMING CONVENTIONS)

| Đối tượng | Quy ước | Ví dụ |
| :--- | :--- | :--- |
| **Class, Interface, Struct, Enum** | PascalCase | `OrderService`, `ProductRepository`, `CartItemDto` |
| **Interface** | `I` + PascalCase | `IOrderService`, `IProductRepository` |
| **Method, Public Property** | PascalCase | `CalculateOrderSummary()`, `ProcessPayment()`, `FinalTotal` |
| **Private Field** | `_` + camelCase | `_orderService`, `_dtProducts`, `_discountValue` |
| **Method Parameter, Local Variable** | camelCase | `cartItems`, `discountValue`, `employeeName`, `rawTotal` |
| **Constant** | UPPER_SNAKE_CASE hoặc PascalCase | `DEFAULT_TAX_RATE`, `MaxDiscountPercent` |

### Tiền tố chuẩn cho Windows Forms Controls:
| Loại Control | Tiền tố | Ví dụ |
| :--- | :--- | :--- |
| **Form** | `Frm...` | `FrmCounterSale`, `FrmDiscountDialog` |
| **Panel** | `pnl...` | `pnlTopBar`, `pnlLeftCart`, `pnlBottomActions` |
| **FlowLayoutPanel** | `flp...` | `flpCategories`, `flpProducts`, `flpQuickCash` |
| **Button** | `btn...` | `btnCash`, `btnTransferQR`, `btnIncreaseQty`, `btnOk` |
| **Label** | `lbl...` | `lblGrandTotal`, `lblClock`, `lblCashier` |
| **TextBox** | `txt...` | `txtCashGiven`, `txtValue`, `txtSearch` |
| **DataGridView** | `dgv...` | `dgvCart`, `dgvOrderHistory` |
| **RadioButton** | `rdo...` | `rdoPercent`, `rdoCash` |
| **CheckBox** | `chk...` | `chkIsActive`, `chkPrintReceipt` |
| **ComboBox** | `cbo...` | `cboCategories`, `cboStaff` |
| **Timer** | `...Timer` hoặc `tmr...` | `clockTimer`, `tmrAutoRefresh` |

---

## 8. QUY TẮC XỬ LÝ NGOẠI LỆ (EXCEPTION HANDLING)

1. **Tầng DAL**: Bắt lỗi cấp thấp (SQLiteException, IO), Rollback transaction nếu có, sau đó ném lỗi lên kèm thông điệp ngữ cảnh rõ ràng.
2. **Tầng BLL**: Kiểm tra điều kiện tiên quyết và ném `ArgumentException` / `InvalidOperationException` kèm thông điệp nghiệp vụ bằng tiếng Việt dễ hiểu.
3. **Tầng UI**: Bọc các lời gọi BLL trong khối `try ... catch (Exception ex)` tại các sự kiện người dùng (Click, Load) và hiển thị qua `MessageBox.Show(..., MessageBoxIcon.Error/Warning)` thân thiện.
4. **CẤM nuốt lỗi (Silent Catch)**: Tuyệt đối không viết `catch {}` rỗng mà không ghi log hoặc không thông báo cho người dùng.

---

## 9. NGUYÊN TẮC CLEAN CODE & SINGLE RESPONSIBILITY (SRP)

- **Single Responsibility**: Mỗi hàm/class chỉ đảm nhận 1 nhiệm vụ duy nhất.
- **Độ dài hàm**: Cố gắng giữ mỗi hàm dưới **40 dòng code**. Nếu hàm quá dài, hãy bóc tách thành các hàm phụ trợ (`private`).
- **DRY (Don't Repeat Yourself)**: Không copy-paste code logic hoặc giao diện qua lại giữa các Form. Hãy tạo hàm tiện ích hoặc Form Dialog dùng chung.
- **Comment có ý nghĩa**: Viết ghi chú giải thích **TẠI SAO (Why)** làm như vậy đối với các logic nghiệp vụ phức tạp, thay vì chỉ giải thích cái mã đang làm (What).
