using System;
using System.Drawing;
using System.Windows.Forms;
using POS.UI.Navigation;
using POS.UI.Pages;
using POS.UI.Session;

namespace POS.UI.Forms
{
    public partial class FrmAdminShell : Form, INavigatableForm
    {
        private Button _currentActiveBtn;
        private string _initialPage;

        public FrmAdminShell(string initialPage = "Dashboard")
        {
            InitializeComponent();
            _initialPage = initialPage;
        }

        private void FrmAdminShell_Load(object sender, EventArgs e)
        {
            lblAdminUser.Text = $"👤 Quản trị viên: {UserSession.Current.FullName}";

            if (_initialPage == "Menu")
            {
                btnNavMenu_Click(btnNavMenu, EventArgs.Empty);
            }
            else if (_initialPage == "Tables")
            {
                btnNavTables_Click(btnNavTables, EventArgs.Empty);
            }
            else
            {
                btnNavDashboard_Click(btnNavDashboard, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Chuyển đổi trang con theo mô hình Transient Lifecycle (Chống rò rỉ bộ nhớ 100%)
        /// </summary>
        public void NavigateTo(Func<UserControl> pageFactory, Button targetBtn)
        {
            // 1. Dọn dẹp và giải phóng triệt để trang cũ khỏi bộ nhớ
            if (pnlMainContent.Controls.Count > 0)
            {
                var oldControl = pnlMainContent.Controls[0];
                if (oldControl is IViewPage viewPage)
                {
                    viewPage.OnPageDeactivated();
                }

                pnlMainContent.Controls.Clear();
                oldControl.Dispose(); // <<-- GIẢI PHÓNG TOÀN BỘ GDI HANDLES VÀ RAM CŨ
            }

            // 2. Cập nhật giao diện nút Sidebar đang active
            HighlightSidebarButton(targetBtn);

            // 3. Tạo mới trang và nhúng vào Shell
            UserControl newPage = pageFactory();
            newPage.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(newPage);

            if (newPage is IViewPage newViewPage)
            {
                newViewPage.OnPageActivated();
                Text = $"Quản trị hệ thống POS F&B - {newViewPage.PageTitle}";
            }
        }

        private void HighlightSidebarButton(Button activeBtn)
        {
            // Reset màu các nút trên Sidebar
            btnNavDashboard.BackColor = Color.FromArgb(30, 41, 59);
            btnNavDashboard.ForeColor = Color.FromArgb(203, 213, 225);

            btnNavMenu.BackColor = Color.FromArgb(30, 41, 59);
            btnNavMenu.ForeColor = Color.FromArgb(203, 213, 225);

            btnNavTables.BackColor = Color.FromArgb(30, 41, 59);
            btnNavTables.ForeColor = Color.FromArgb(203, 213, 225);

            btnNavInventory.BackColor = Color.FromArgb(30, 41, 59);
            btnNavInventory.ForeColor = Color.FromArgb(203, 213, 225);

            btnNavReports.BackColor = Color.FromArgb(30, 41, 59);
            btnNavReports.ForeColor = Color.FromArgb(203, 213, 225);

            btnNavSettings.BackColor = Color.FromArgb(30, 41, 59);
            btnNavSettings.ForeColor = Color.FromArgb(203, 213, 225);

            // Tô màu nổi bật cho nút được chọn
            if (activeBtn != null)
            {
                activeBtn.BackColor = Color.FromArgb(14, 165, 233);
                activeBtn.ForeColor = Color.White;
                _currentActiveBtn = activeBtn;
            }
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            NavigateTo(() =>
            {
                var uc = new UcDashboard();
                uc.OnRequestNavigate = (pageKey) =>
                {
                    if (pageKey == "Menu") btnNavMenu_Click(btnNavMenu, EventArgs.Empty);
                    if (pageKey == "Tables") btnNavTables_Click(btnNavTables, EventArgs.Empty);
                };
                return uc;
            }, btnNavDashboard);
        }

        private void btnNavMenu_Click(object sender, EventArgs e)
        {
            NavigateTo(() => new UcMenuManagement(), btnNavMenu);
        }

        private void btnNavTables_Click(object sender, EventArgs e)
        {
            NavigateTo(() => new UcTableManagement(), btnNavTables);
        }

        private void btnNavInventory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mô-đun 'Quản lý Kho & Định lượng (BOM)' đang được xây dựng ở Giai đoạn tiếp theo!", "Khu vực Kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mô-đun 'Báo cáo Doanh thu & Quản lý Ca' đang được xây dựng ở Giai đoạn tiếp theo!", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNavSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mô-đun 'Cài đặt Hệ thống (Máy in, Cửa hàng)' đang được xây dựng ở Giai đoạn tiếp theo!", "Cài đặt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoToPOS_Click(object sender, EventArgs e)
        {
            // Mở màn hình Bán hàng (Ẩn Admin Shell để bảo lưu Session ca làm việc)
            NavigationManager.ShowPosScreen(fromAdmin: true);
        }

        private bool _isClosingFromNavigation = false;

        public void PrepareForClose()
        {
            _isClosingFromNavigation = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            NavigationManager.Logout(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_isClosingFromNavigation)
            {
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing && UserSession.Current.IsLoggedIn)
            {
                // Nếu người dùng bấm dấu X góc trên phải của Form Admin Shell
                NavigationManager.ExitApp();
            }
        }
    }
}
