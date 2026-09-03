using System;
using System.Windows.Forms;
using POS.UI.Navigation;
using POS.UI.Session;

namespace POS.UI.Pages
{
    public partial class UcDashboard : UserControl, IViewPage
    {
        public string PageTitle => "Tổng quan hệ thống";

        public Action<string> OnRequestNavigate { get; set; }

        public UcDashboard()
        {
            InitializeComponent();
        }

        public void OnPageActivated()
        {
            lblWelcome.Text = $"👋 CHÀO MỪNG {UserSession.Current.FullName.ToUpper()}!";
        }

        public void OnPageDeactivated()
        {
            // Dọn dẹp tài nguyên nếu có
        }

        private void btnQuickPOS_Click(object sender, EventArgs e)
        {
            NavigationManager.ShowPosScreen(fromAdmin: true);
        }

        private void btnQuickMenu_Click(object sender, EventArgs e)
        {
            OnRequestNavigate?.Invoke("Menu");
        }

        private void btnQuickTables_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Quản lý Sơ đồ Bàn & Khu vực' đang được xây dựng ở Giai đoạn tiếp theo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuickInventory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng 'Quản lý Kho & Định lượng (BOM)' đang được xây dựng ở Giai đoạn tiếp theo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
