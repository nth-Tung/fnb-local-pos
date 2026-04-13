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
    public partial class AdminManagementForm : Form
    {
        private TabControl tabControlMain;
        private TabPage tabDashboard, tabProducts, tabReports, tabStaff;
        private Panel panelHeader;
        private DataGridView dgvProducts;
        private Label lblTotalRevenue, lblTotalOrders, lblTotalProducts;

        public AdminManagementForm()
        {
            SetupUI();
            LoadDashboardStats();
            LoadProductData();
            this.Text = "Hệ thống Quản trị POS - Dashboard";
            this.Size = new Size(1100, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetupUI()
        {
            this.BackColor = Color.FromArgb(242, 245, 249);
            this.Font = new Font("Segoe UI", 10);

            // 1. Header
            panelHeader = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(52, 73, 94) };
            Label lblTitle = new Label
            {
                Text = "TRUNG TÂM QUẢN TRỊ HỆ THỐNG",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 0, 0, 0)
            };
            panelHeader.Controls.Add(lblTitle);

            // 2. TabControl Main
            tabControlMain = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11) };

            tabDashboard = new TabPage("Bảng điều khiển");
            tabProducts = new TabPage("Quản lý Sản phẩm");
            tabReports = new TabPage("Báo cáo Doanh thu");
            tabStaff = new TabPage("Nhân viên");

            SetupDashboardTab();
            SetupProductTab();
            SetupReportTab();

            tabControlMain.TabPages.Add(tabDashboard);
            tabControlMain.TabPages.Add(tabProducts);
            tabControlMain.TabPages.Add(tabReports);
            tabControlMain.TabPages.Add(tabStaff);

            this.Controls.Add(tabControlMain);
            this.Controls.Add(panelHeader);
        }

        private void SetupDashboardTab()
        {
            FlowLayoutPanel flowStats = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 180, Padding = new Padding(20) };

            // Các thẻ thống kê nhanh
            flowStats.Controls.Add(CreateStatCard("DOANH THU HÔM NAY", "12,500,000đ", Color.FromArgb(46, 204, 113)));
            flowStats.Controls.Add(CreateStatCard("TỔNG ĐƠN HÀNG", "48", Color.FromArgb(52, 152, 219)));
            flowStats.Controls.Add(CreateStatCard("SẢN PHẨM SẮP HẾT", "5", Color.FromArgb(231, 76, 60)));

            // Khu vực biểu đồ giả định (GDI+)
            Panel panelChart = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(20) };
            panelChart.Paint += (s, e) => {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawString("Biểu đồ tăng trưởng doanh thu (7 ngày qua)", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Gray, 20, 20);

                // Vẽ trục tọa độ và các cột giả lập
                Pen axisPen = new Pen(Color.LightGray, 2);
                g.DrawLine(axisPen, 50, 350, 600, 350); // Trục X
                g.DrawLine(axisPen, 50, 100, 50, 350);  // Trục Y

                int[] values = { 120, 150, 180, 140, 210, 250, 230 };
                for (int i = 0; i < values.Length; i++)
                {
                    g.FillRectangle(Brushes.SkyBlue, 70 + (i * 70), 350 - values[i], 40, values[i]);
                    g.DrawString($"T{i + 2}", this.Font, Brushes.Black, 75 + (i * 70), 360);
                }
            };

            tabDashboard.Controls.Add(panelChart);
            tabDashboard.Controls.Add(flowStats);
        }

        private Panel CreateStatCard(string title, string value, Color accentColor)
        {
            Panel card = new Panel { Width = 300, Height = 120, BackColor = Color.White, Margin = new Padding(0, 0, 20, 0) };
            card.Paint += (s, e) => {
                e.Graphics.FillRectangle(new SolidBrush(accentColor), 0, 0, 10, card.Height);
            };

            Label lblT = new Label { Text = title, Location = new Point(25, 20), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.Gray };
            Label lblV = new Label { Text = value, Location = new Point(25, 55), AutoSize = true, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = accentColor };

            card.Controls.Add(lblT);
            card.Controls.Add(lblV);
            return card;
        }

        private void SetupProductTab()
        {
            // Toolbar quản lý
            Panel pnlTools = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(10) };
            Button btnAdd = new Button { Text = "+ Thêm sản phẩm", Dock = DockStyle.Left, Width = 150, BackColor = Color.FromArgb(46, 204, 113), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button btnEdit = new Button { Text = "Sửa", Dock = DockStyle.Left, Width = 100, BackColor = Color.FromArgb(52, 152, 219), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Margin = new Padding(10, 0, 0, 0) };
            Button btnDel = new Button { Text = "Xóa", Dock = DockStyle.Left, Width = 100, BackColor = Color.FromArgb(231, 76, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            pnlTools.Controls.Add(btnDel);
            pnlTools.Controls.Add(btnEdit);
            pnlTools.Controls.Add(btnAdd);

            dgvProducts = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };

            tabProducts.Controls.Add(dgvProducts);
            tabProducts.Controls.Add(pnlTools);
        }

        private void SetupReportTab()
        {
            ListView lvHistory = new ListView
            {
                Dock = DockStyle.Fill,
                View = System.Windows.Forms.View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10)
            };
            lvHistory.Columns.Add("Thời gian", 180);
            lvHistory.Columns.Add("Mã đơn", 100);
            lvHistory.Columns.Add("Nhân viên", 150);
            lvHistory.Columns.Add("Tổng tiền", 120);
            lvHistory.Columns.Add("Trạng thái", 120);

            // Mock data đơn hàng
            lvHistory.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString("HH:mm dd/MM"), "INV001", "admin", "150,000đ", "Thành công" }));
            lvHistory.Items.Add(new ListViewItem(new[] { DateTime.Now.AddMinutes(-20).ToString("HH:mm dd/MM"), "INV002", "admin", "85,000đ", "Thành công" }));

            tabReports.Controls.Add(lvHistory);
        }

        private void LoadDashboardStats() { /* Logic lấy data từ DB */ }

        private void LoadProductData()
        {
            // Giả lập data nạp vào Grid
            var dt = new System.Data.DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Tên sản phẩm");
            dt.Columns.Add("Danh mục");
            dt.Columns.Add("Giá bán");
            dt.Columns.Add("Tồn kho");

            dt.Rows.Add("P001", "Cà phê sữa", "Cà phê", "29.000", "50");
            dt.Rows.Add("P002", "Trà sữa trân châu", "Trà sữa", "39.000", "20");
            dt.Rows.Add("P003", "Bánh mì JK", "Thức ăn", "25.000", "15");

            dgvProducts.DataSource = dt;
        }
    }
}
