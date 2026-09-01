using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;
using POS.UI.Dialogs;

namespace POS.UI
{
    public partial class FrmCounterSale : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly OrderService _orderService = new OrderService();
        private readonly PrintService _printService = new PrintService();

        private DataTable _dtProducts;
        private DataTable _dtCategories;
        private int _selectedCategoryId = 0; // 0 = Tất cả
        private Button _activeCategoryBtn = null;

        private string _currentCashier = "Nguyễn Văn A";
        private decimal _discountValue = 0;
        private bool _isPercentDiscount = false;

        // Lưu thông tin hóa đơn vừa thanh toán gần nhất để in lại bill
        private string _lastOrderNumber = string.Empty;
        private decimal _lastOrderTotal = 0;
        private OrderSummaryDto _lastSummary = null;
        private string _lastPaymentMethod = string.Empty;
        private DateTime _lastOrderTime = DateTime.MinValue;
        private List<CartItemDto> _lastCartItems = new List<CartItemDto>();
        private List<string> _lastOrderItemsText = new List<string>();

        public FrmCounterSale()
        {
            InitializeComponent();
        }

        private void FrmCounterSale_Load(object sender, EventArgs e)
        {
            try
            {
                // Cập nhật đồng hồ và nhân viên
                lblCashier.Text = $"👤 Nhân viên: {_currentCashier}";
                lblClock.Text = "⏰ " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");

                // Sinh trước mã hóa đơn hiển thị
                RefreshNextOrderNumber();

                // Nạp danh mục và thực đơn
                LoadCategories();
                LoadProducts();

                // Cập nhật lại giỏ hàng
                UpdateCartSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo màn hình bán hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 1. Tải và Vẽ Danh Mục & Món Ăn (Dynamic UI Render)

        private void RefreshNextOrderNumber()
        {
            try
            {
                string nextOrderNo = _orderService.GetNextOrderNumber();
                lblOrderNumber.Text = $"📋 Đơn: {nextOrderNo}";
            }
            catch
            {
                lblOrderNumber.Text = $"📋 Đơn: HD-{DateTime.Now:yyyyMMdd}-001";
            }
        }

        private void LoadCategories()
        {
            flpCategories.SuspendLayout();
            flpCategories.Controls.Clear();

            // Nút "Tất cả" mặc định
            Button btnAll = CreateCategoryButton(0, "✨ Tất cả");
            flpCategories.Controls.Add(btnAll);
            SetActiveCategoryButton(btnAll);

            try
            {
                _dtCategories = _productService.GetCategories();
                if (_dtCategories != null)
                {
                    foreach (DataRow row in _dtCategories.Rows)
                    {
                        int catId = Convert.ToInt32(row["Id"]);
                        string catName = row["Name"].ToString();
                        Button btnCat = CreateCategoryButton(catId, catName);
                        flpCategories.Controls.Add(btnCat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh mục: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            flpCategories.ResumeLayout();
        }

        private Button CreateCategoryButton(int categoryId, string text)
        {
            Button btn = new Button
            {
                Text = text,
                Tag = categoryId,
                Height = 48,
                AutoSize = true,
                MinimumSize = new Size(115, 48),
                Margin = new Padding(4, 2, 4, 2),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(30, 41, 59),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btn.FlatAppearance.BorderSize = 1;

            btn.Click += CategoryButton_Click;
            return btn;
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int catId)
            {
                _selectedCategoryId = catId;
                SetActiveCategoryButton(btn);
                FilterProducts();
            }
        }

        private void SetActiveCategoryButton(Button activeBtn)
        {
            if (_activeCategoryBtn != null)
            {
                _activeCategoryBtn.BackColor = Color.FromArgb(241, 245, 249);
                _activeCategoryBtn.ForeColor = Color.FromArgb(30, 41, 59);
                _activeCategoryBtn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            }

            _activeCategoryBtn = activeBtn;
            if (_activeCategoryBtn != null)
            {
                _activeCategoryBtn.BackColor = Color.FromArgb(37, 99, 235); // Blue Primary
                _activeCategoryBtn.ForeColor = Color.White;
                _activeCategoryBtn.FlatAppearance.BorderColor = Color.FromArgb(29, 78, 216);
            }
        }

        private void LoadProducts()
        {
            try
            {
                _dtProducts = _productService.GetActiveMenu();
                FilterProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách món: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FilterProducts()
        {
            flpProducts.SuspendLayout();
            flpProducts.Controls.Clear();

            if (_dtProducts != null)
            {
                foreach (DataRow row in _dtProducts.Rows)
                {
                    int catId = Convert.ToInt32(row["CategoryId"]);
                    if (_selectedCategoryId == 0 || catId == _selectedCategoryId)
                    {
                        int prodId = Convert.ToInt32(row["Id"]);
                        string prodName = row["Name"].ToString();
                        decimal price = Convert.ToDecimal(row["Price"]);
                        string prodType = row.Table.Columns.Contains("ProductType") ? row["ProductType"].ToString() : "SINGLE";

                        Button btnProd = CreateProductButton(prodId, prodName, price, prodType);
                        flpProducts.Controls.Add(btnProd);
                    }
                }
            }

            flpProducts.ResumeLayout();
        }

        private Button CreateProductButton(int productId, string name, decimal price, string productType)
        {
            Button btn = new Button
            {
                Size = new Size(150, 115),
                Margin = new Padding(6),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = new ProductItemInfo { Id = productId, Name = name, Price = price, ProductType = productType }
            };

            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btn.FlatAppearance.BorderSize = 1;

            // Hiển thị tên món và giá tiền 2 dòng rõ nét
            string typeBadge = productType == "COMBO" ? " [COMBO]" : "";
            btn.Text = $"{name}{typeBadge}\n\n{price:N0} đ";
            btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.ForeColor = Color.FromArgb(15, 23, 42);

            // Hover effect
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(239, 246, 255);
                btn.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.White;
                btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            };

            btn.Click += ProductButton_Click;
            return btn;
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is ProductItemInfo item)
            {
                AddProductToCart(item.Id, item.Name, item.Price);
            }
        }

        #endregion

        #region 2. Quản Lý Giỏ Hàng (Cart Zone)

        private void AddProductToCart(int productId, string productName, decimal unitPrice)
        {
            // Kiểm tra xem món đã có trong giỏ chưa
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["colProductId"].Value != null && Convert.ToInt32(row.Cells["colProductId"].Value) == productId)
                {
                    int currentQty = Convert.ToInt32(row.Cells["colQty"].Value);
                    row.Cells["colQty"].Value = currentQty + 1;
                    row.Cells["colTotal"].Value = (currentQty + 1) * unitPrice;

                    row.Selected = true;
                    dgvCart.CurrentCell = row.Cells["colName"];
                    UpdateCartSummary();
                    return;
                }
            }

            // Nếu chưa có, thêm dòng mới vào giỏ hàng
            string itemKey = "ITEM_" + Guid.NewGuid().ToString("N");
            int rowIndex = dgvCart.Rows.Add(productId, itemKey, productName, 1, unitPrice, unitPrice);

            dgvCart.Rows[rowIndex].Selected = true;
            dgvCart.CurrentCell = dgvCart.Rows[rowIndex].Cells["colName"];

            UpdateCartSummary();
        }

        private void btnIncreaseQty_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCart.SelectedRows[0];
                int currentQty = Convert.ToInt32(row.Cells["colQty"].Value);
                decimal unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);

                int newQty = currentQty + 1;
                row.Cells["colQty"].Value = newQty;
                row.Cells["colTotal"].Value = newQty * unitPrice;

                UpdateCartSummary();
            }
        }

        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCart.SelectedRows[0];
                int currentQty = Convert.ToInt32(row.Cells["colQty"].Value);
                decimal unitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value);

                if (currentQty > 1)
                {
                    int newQty = currentQty - 1;
                    row.Cells["colQty"].Value = newQty;
                    row.Cells["colTotal"].Value = newQty * unitPrice;
                }
                else
                {
                    // Nếu số lượng = 1, bấm giảm sẽ xóa món khỏi giỏ
                    dgvCart.Rows.Remove(row);
                }

                UpdateCartSummary();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                dgvCart.Rows.Remove(dgvCart.SelectedRows[0]);
                UpdateCartSummary();
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ món trong giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dgvCart.Rows.Clear();
                _discountValue = 0;
                _isPercentDiscount = false;
                UpdateCartSummary();
            }
        }

        private void btnSetDiscount_Click(object sender, EventArgs e)
        {
            var cartItems = GetCartItems();
            var summary = _orderService.CalculateOrderSummary(cartItems, 0, false);

            using (var dlg = new FrmDiscountDialog(_discountValue, _isPercentDiscount, summary.RawTotal))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _discountValue = dlg.DiscountValue;
                    _isPercentDiscount = dlg.IsPercentDiscount;
                    UpdateCartSummary();
                }
            }
        }

        // Trích xuất danh sách CartItemDto từ giao diện DataGridView
        private List<CartItemDto> GetCartItems()
        {
            var list = new List<CartItemDto>();
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["colProductId"].Value != null)
                {
                    list.Add(new CartItemDto
                    {
                        ProductId = Convert.ToInt32(row.Cells["colProductId"].Value),
                        ProductName = row.Cells["colName"].Value?.ToString() ?? string.Empty,
                        Quantity = Convert.ToInt32(row.Cells["colQty"].Value),
                        UnitPrice = Convert.ToDecimal(row.Cells["colUnitPrice"].Value),
                        ItemKey = row.Cells["colItemKey"].Value?.ToString()
                    });
                }
            }
            return list;
        }

        private void UpdateCartSummary()
        {
            var cartItems = GetCartItems();
            // Gọi BLL tính toán tổng tiền, chiết khấu
            var summary = _orderService.CalculateOrderSummary(cartItems, _discountValue, _isPercentDiscount);

            lblSubTotal.Text = summary.RawTotal.ToString("N0") + " đ";
            lblDiscount.Text = _discountValue > 0
                ? (_isPercentDiscount ? $"{_discountValue}% (-{summary.DiscountAmount:N0} đ)" : $"-{summary.DiscountAmount:N0} đ")
                : "0 đ";
            lblGrandTotal.Text = summary.FinalTotal.ToString("N0") + " đ";
        }

        #endregion

        #region 3. Thanh Toán & Chức Năng (Payment & Actions)

        private void btnCash_Click(object sender, EventArgs e)
        {
            ExecutePayment("CASH");
        }

        private void btnTransferQR_Click(object sender, EventArgs e)
        {
            ExecutePayment("BANK_TRANSFER");
        }

        private void ExecutePayment(string paymentMethod)
        {
            var cartItems = GetCartItems();
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng chọn món trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Nhận kết quả tính toán chi phí chính xác từ BLL
            var summary = _orderService.CalculateOrderSummary(cartItems, _discountValue, _isPercentDiscount);

            // 2. Xử lý hiển thị hộp thoại xác nhận thanh toán theo từng hình thức (Sử dụng Dialog Forms tái sử dụng)
            if (paymentMethod == "BANK_TRANSFER")
            {
                string orderNo = lblOrderNumber.Text.Replace("📋 Đơn: ", "").Trim();
                using (var dlg = new FrmQrPaymentDialog(summary.FinalTotal, orderNo))
                {
                    if (dlg.ShowDialog(this) != DialogResult.OK) return;
                }
            }
            else if (paymentMethod == "CASH")
            {
                using (var dlg = new FrmCashPaymentDialog(summary.FinalTotal))
                {
                    if (dlg.ShowDialog(this) != DialogResult.OK) return;
                }
            }

            // 3. Gọi BLL xử lý lưu trữ đơn hàng
            try
            {
                bool success = _orderService.ProcessPayment(
                    _currentCashier,
                    paymentMethod,
                    _discountValue,
                    _isPercentDiscount,
                    cartItems,
                    out decimal finalTotal,
                    out string generatedOrderNo
                );

                if (success)
                {
                    // Lưu lại thông tin để in lại bill
                    _lastOrderNumber = generatedOrderNo;
                    _lastOrderTotal = finalTotal;
                    _lastSummary = summary;
                    _lastPaymentMethod = paymentMethod == "CASH" ? "Tiền mặt" : "Chuyển khoản QR";
                    _lastOrderTime = DateTime.Now;
                    _lastCartItems = new List<CartItemDto>(cartItems);
                    _lastOrderItemsText = cartItems.Select(x => $"{x.ProductName,-22} x{x.Quantity} {(x.LineTotal):N0}đ").ToList();

                    // Gửi lệnh in hóa đơn ESC/POS trực tiếp tới máy in nhiệt qua Template Method Pattern
                    _printService.PrintOrderInvoice(
                        generatedOrderNo,
                        _currentCashier,
                        paymentMethod == "CASH" ? "Tien mat" : "Chuyen khoan QR",
                        cartItems,
                        summary
                    );

                    MessageBox.Show(
                        $"✅ THANH TOÁN THÀNH CÔNG!\n\n" +
                        $"📋 Mã hóa đơn: {generatedOrderNo}\n" +
                        $"💰 Tổng tiền: {finalTotal:N0} đ\n" +
                        $"💳 Hình thức: {(paymentMethod == "CASH" ? "Tiền mặt" : "Chuyển khoản QR")}\n" +
                        $"👤 Thu ngân: {_currentCashier}\n\n" +
                        $"Hóa đơn đã được lưu vào CSDL và gửi lệnh in bill tự động cắt giấy.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Làm mới giỏ hàng và cập nhật mã hóa đơn mới
                    dgvCart.Rows.Clear();
                    _discountValue = 0;
                    _isPercentDiscount = false;
                    UpdateCartSummary();
                    RefreshNextOrderNumber();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Hủy đơn hàng đang chọn và xóa giỏ hàng?", "Hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    dgvCart.Rows.Clear();
                    _discountValue = 0;
                    _isPercentDiscount = false;
                    UpdateCartSummary();
                }
            }
        }

        private void btnOpenDrawer_Click(object sender, EventArgs e)
        {
            // Kích xung ESC/POS mở két tiền thu ngân qua cổng RJ11 máy in nhiệt
            bool sent = _printService.OpenCashDrawer();
            MessageBox.Show(
                sent ? "🔔 Đã gửi lệnh mở két tiền (Cash Drawer Opened)!" : "🔔 Đã kích hoạt lệnh mở két tiền thu ngân!",
                "Két tiền",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnReprintBill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_lastOrderNumber))
            {
                MessageBox.Show("Chưa có hóa đơn nào được thanh toán trong phiên làm việc này để in lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gửi lại lệnh in ESC/POS nếu có danh sách món
            if (_lastCartItems != null && _lastCartItems.Count > 0 && _lastSummary != null)
            {
                _printService.PrintOrderInvoice(
                    _lastOrderNumber,
                    _currentCashier,
                    _lastPaymentMethod,
                    _lastCartItems,
                    _lastSummary
                );
            }

            string billContent =
                "========================================\n" +
                "           F&B LOCAL STORE              \n" +
                "         HÓA ĐƠN BÁN HÀNG (IN LẠI)      \n" +
                "========================================\n" +
                $"Số HĐ: {_lastOrderNumber}\n" +
                $"Thời gian: {_lastOrderTime:dd/MM/yyyy HH:mm:ss}\n" +
                $"Thu ngân: {_currentCashier}\n" +
                $"Hình thức: {_lastPaymentMethod}\n" +
                "----------------------------------------\n" +
                string.Join("\n", _lastOrderItemsText) + "\n" +
                "----------------------------------------\n" +
                $"TỔNG TIỀN: {_lastOrderTotal:N0} đ\n" +
                "========================================\n" +
                "       CẢM ƠN QUÝ KHÁCH & HẸN GẶP LẠI!   \n";

            MessageBox.Show(billContent, $"In lại hóa đơn - {_lastOrderNumber}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất hoặc đóng ứng dụng POS?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = "⏰ " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        private void FrmCounterSale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnCash.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnTransferQR.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnCancelOrder.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnOpenDrawer.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnReprintBill.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                btnIncreaseQty.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                btnDecreaseQty.PerformClick();
                e.Handled = true;
            }
        }

        #endregion

        // Lớp phụ trợ lưu dữ liệu món ăn trong Tag của Button
        private class ProductItemInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ProductType { get; set; }
        }
    }
}
