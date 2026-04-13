using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Icon { get; set; }
    }

    public partial class MainPOSForm : Form
    {
        // UI Components
        private Panel panelHeader, panelSideMenu, panelCart, panelSearch;
        private FlowLayoutPanel flowProducts;
        private Label lblTotal, lblClock, lblUser, lblChangeAmount;
        private TextBox txtSearch, txtCustomerMoney;
        private Button btnCheckout, btnClearCart, btnDeleteSelected;
        private ListView lvCart;
        private System.Windows.Forms.Timer timerClock;

        // Data
        private List<Product> allProducts;
        private string currentUser;
        private decimal currentTotal = 0;

        public MainPOSForm(string username)
        {
            this.currentUser = username;
            InitializeData();
            SetupUI();

            this.Text = "Hệ thống Bán hàng Chuyên nghiệp";
            this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.F12) ProcessPayment(); };

            // Khởi động đồng hồ
            timerClock = new System.Windows.Forms.Timer { Interval = 1000 };
            timerClock.Tick += (s, e) => lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timerClock.Start();
        }

        private void InitializeData()
        {
            allProducts = new List<Product>
            {
                new Product { Name = "Cà phê sữa", Price = 29000, Category = "Cà phê", Icon = "☕" },
                new Product { Name = "Bạc xỉu", Price = 35000, Category = "Cà phê", Icon = "☕" },
                new Product { Name = "Espresso", Price = 25000, Category = "Cà phê", Icon = "☕" },
                new Product { Name = "Trà đào cam sả", Price = 45000, Category = "Trà sữa", Icon = "🍵" },
                new Product { Name = "Trà vải", Price = 40000, Category = "Trà sữa", Icon = "🍵" },
                new Product { Name = "Trà sữa trân châu", Price = 39000, Category = "Trà sữa", Icon = "🧋" },
                new Product { Name = "Bánh mì JK", Price = 25000, Category = "Thức ăn", Icon = "🥪" },
                new Product { Name = "Croissant", Price = 30000, Category = "Thức ăn", Icon = "🥐" },
                new Product { Name = "Bánh Cheese", Price = 45000, Category = "Tráng miệng", Icon = "🍰" },
                new Product { Name = "Flan Gato", Price = 22000, Category = "Tráng miệng", Icon = "🍮" }
            };
        }

        private void SetupUI()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Font = new Font("Segoe UI", 10);

            // 1. Header Area
            panelHeader = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(41, 128, 185) };
            lblUser = new Label { Text = $"👤 {currentUser}", ForeColor = Color.White, Location = new Point(20, 15), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            lblClock = new Label { Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ForeColor = Color.White, Dock = DockStyle.Right, TextAlign = ContentAlignment.MiddleCenter, Width = 250, Font = new Font("Segoe UI", 12) };
            panelHeader.Controls.Add(lblUser);
            panelHeader.Controls.Add(lblClock);

            // 2. Sidebar
            panelSideMenu = new Panel { Dock = DockStyle.Left, Width = 180, BackColor = Color.FromArgb(44, 62, 80) };
            SetupSidebar();

            // 3. Cart Panel (Right)
            panelCart = new Panel { Dock = DockStyle.Right, Width = 450, BackColor = Color.White, Padding = new Padding(10) };
            SetupCartUI();

            // 4. Search & Product Area (Center)
            Panel panelCenter = new Panel { Dock = DockStyle.Fill };

            panelSearch = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(15, 10, 15, 10) };
            txtSearch = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 14) };
            txtSearch.TextChanged += (s, e) => DisplayProducts(txtSearch.Text);
            panelSearch.Controls.Add(txtSearch);

            flowProducts = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };

            panelCenter.Controls.Add(flowProducts);
            panelCenter.Controls.Add(panelSearch);

            this.Controls.Add(panelCenter);
            this.Controls.Add(panelCart);
            this.Controls.Add(panelSideMenu);
            this.Controls.Add(panelHeader);

            DisplayProducts();
        }

        private void SetupSidebar()
        {
            string[] categories = { "Tất cả", "Cà phê", "Trà sữa", "Thức ăn", "Tráng miệng" };

            // Nút Admin & Logout ở đáy
            Panel pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 120 };
            Button btnAdmin = CreateNavButton("⚙ QUẢN LÝ", Color.FromArgb(52, 152, 219));
            btnAdmin.Click += (s, e) => {
                // MỞ MÀN HÌNH QUẢN LÝ ADMIN
                AdminManagementForm adminForm = new AdminManagementForm();
                adminForm.ShowDialog();
            };

            Button btnLogout = CreateNavButton("⬅ ĐĂNG XUẤT", Color.FromArgb(231, 76, 60));
            btnLogout.Click += (s, e) => { this.Close(); };
            pnlBottom.Controls.Add(btnAdmin);
            pnlBottom.Controls.Add(btnLogout);
            btnAdmin.Dock = DockStyle.Top;
            btnLogout.Dock = DockStyle.Bottom;
            panelSideMenu.Controls.Add(pnlBottom);

            // Danh mục sản phẩm
            foreach (var cat in categories.Reverse())
            {
                Button btn = CreateNavButton(cat, Color.Transparent);
                btn.Click += (s, e) => DisplayProducts("", cat == "Tất cả" ? "" : cat);
                panelSideMenu.Controls.Add(btn);
            }
        }

        private Button CreateNavButton(string text, Color bg)
        {
            Button btn = new Button
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 55,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = bg,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void SetupCartUI()
        {
            Label lblTitle = new Label { Text = "ĐƠN HÀNG HIỆN TẠI", Dock = DockStyle.Top, Height = 40, Font = new Font("Segoe UI", 14, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };

            lvCart = new ListView
            {
                Dock = DockStyle.Fill,
                View = System.Windows.Forms.View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 11)
            };
            lvCart.Columns.Add("Sản phẩm", 180);
            lvCart.Columns.Add("SL", 50, HorizontalAlignment.Center);
            lvCart.Columns.Add("Đơn giá", 90, HorizontalAlignment.Right);
            lvCart.Columns.Add("Tổng", 100, HorizontalAlignment.Right);

            // Điều khiển giỏ hàng
            Panel pnlCartControls = new Panel { Dock = DockStyle.Bottom, Height = 50, Padding = new Padding(0, 5, 0, 5) };
            btnDeleteSelected = new Button { Text = "Xóa món", Dock = DockStyle.Left, Width = 100, BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDeleteSelected.Click += (s, e) => { if (lvCart.SelectedItems.Count > 0) { lvCart.Items.Remove(lvCart.SelectedItems[0]); UpdateTotal(); } };
            btnClearCart = new Button { Text = "Xóa tất cả", Dock = DockStyle.Right, Width = 100, BackColor = Color.Gray, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnClearCart.Click += (s, e) => { lvCart.Items.Clear(); UpdateTotal(); };
            pnlCartControls.Controls.Add(btnDeleteSelected);
            pnlCartControls.Controls.Add(btnClearCart);

            // Khu vực tính tiền
            Panel pnlPayment = new Panel { Dock = DockStyle.Bottom, Height = 220, BackColor = Color.FromArgb(249, 249, 249), Padding = new Padding(10) };
            lblTotal = new Label { Text = "TỔNG: 0 VNĐ", Dock = DockStyle.Top, Height = 40, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.Red, TextAlign = ContentAlignment.MiddleRight };

            Label lblPay = new Label { Text = "Tiền khách đưa:", Location = new Point(10, 60), AutoSize = true };
            txtCustomerMoney = new TextBox { Location = new Point(150, 55), Width = 260, Font = new Font("Segoe UI", 12), TextAlign = HorizontalAlignment.Right };
            txtCustomerMoney.TextChanged += (s, e) => CalculateChange();

            Label lblChange = new Label { Text = "Tiền thối lại:", Location = new Point(10, 100), AutoSize = true };
            lblChangeAmount = new Label { Text = "0 VNĐ", Location = new Point(150, 100), Width = 260, Font = new Font("Segoe UI", 12, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight };

            btnCheckout = new Button
            {
                Text = "THANH TOÁN (F12)",
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCheckout.Click += (s, e) => ProcessPayment();

            pnlPayment.Controls.Add(btnCheckout);
            pnlPayment.Controls.Add(lblChangeAmount);
            pnlPayment.Controls.Add(lblChange);
            pnlPayment.Controls.Add(txtCustomerMoney);
            pnlPayment.Controls.Add(lblPay);
            pnlPayment.Controls.Add(lblTotal);

            panelCart.Controls.Add(lvCart);
            panelCart.Controls.Add(pnlCartControls);
            panelCart.Controls.Add(lblTitle);
            panelCart.Controls.Add(pnlPayment);
        }

        private void DisplayProducts(string search = "", string category = "")
        {
            flowProducts.Controls.Clear();
            var filtered = allProducts.Where(p =>
                (string.IsNullOrEmpty(search) || p.Name.ToLower().Contains(search.ToLower())) &&
                (string.IsNullOrEmpty(category) || p.Category == category)
            );

            foreach (var p in filtered)
            {
                Button btn = new Button
                {
                    Width = 140,
                    Height = 160,
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(8),
                    Cursor = Cursors.Hand,
                    Text = $"{p.Icon}\n\n{p.Name}\n{p.Price:N0}đ",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.Click += (s, e) => AddToCart(p);
                flowProducts.Controls.Add(btn);
            }
        }

        private void AddToCart(Product p)
        {
            foreach (ListViewItem item in lvCart.Items)
            {
                if (item.Text == p.Name)
                {
                    int qty = int.Parse(item.SubItems[1].Text) + 1;
                    item.SubItems[1].Text = qty.ToString();
                    item.SubItems[3].Text = (qty * p.Price).ToString("N0") + "đ";
                    UpdateTotal();
                    return;
                }
            }

            ListViewItem newItem = new ListViewItem(p.Name);
            newItem.SubItems.Add("1");
            newItem.SubItems.Add(p.Price.ToString("N0") + "đ");
            newItem.SubItems.Add(p.Price.ToString("N0") + "đ");
            lvCart.Items.Add(newItem);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            currentTotal = 0;
            foreach (ListViewItem item in lvCart.Items)
            {
                string val = item.SubItems[3].Text.Replace("đ", "").Replace(",", "").Replace(".", "");
                currentTotal += decimal.Parse(val);
            }
            lblTotal.Text = $"TỔNG: {currentTotal:N0} VNĐ";
            CalculateChange();
        }

        private void CalculateChange()
        {
            if (decimal.TryParse(txtCustomerMoney.Text.Replace(",", "").Replace(".", ""), out decimal paid))
            {
                decimal change = paid - currentTotal;
                lblChangeAmount.Text = (change >= 0 ? change.ToString("N0") : "0") + " VNĐ";
                lblChangeAmount.ForeColor = change >= 0 ? Color.DarkGreen : Color.Red;
            }
            else
            {
                lblChangeAmount.Text = "0 VNĐ";
            }
        }

        private void ProcessPayment()
        {
            if (lvCart.Items.Count == 0) return;

            decimal paid = 0;
            decimal.TryParse(txtCustomerMoney.Text, out paid);

            if (paid < currentTotal)
            {
                MessageBox.Show("Tiền khách đưa chưa đủ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Giả lập in hóa đơn và hoàn tất
            MessageBox.Show($"THANH TOÁN THÀNH CÔNG!\nTổng tiền: {currentTotal:N0}đ\nTiền thừa: {lblChangeAmount.Text}",
                            "Hóa đơn POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lvCart.Items.Clear();
            txtCustomerMoney.Clear();
            UpdateTotal();
        }
    }
}
