using System;
using System.Windows.Forms;
using POS.UI.Navigation;
using POS.UI.Session;

namespace POS.UI.Forms
{
    public partial class FrmLogin : Form, INavigatableForm
    {
        private bool _isClosingFromNavigation = false;

        public void PrepareForClose()
        {
            _isClosingFromNavigation = true;
        }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "cashier";
            txtPassword.Text = "123456";
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Kiểm tra thông tin đăng nhập mẫu
            if (username.Equals("cashier", StringComparison.OrdinalIgnoreCase) && password == "123456")
            {
                // Thu ngân -> Nhảy thẳng vào màn hình bán hàng POS
                UserSession.Current.Login(1, "cashier", "Nguyễn Văn A (Thu ngân)", UserRole.Cashier);
                NavigationManager.ShowPosScreen(fromAdmin: false);
            }
            else if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "123456")
            {
                // Quản lý -> Vào trang Dashboard Quản trị
                UserSession.Current.Login(2, "admin", "Quản Lý Cửa Hàng", UserRole.Admin);
                NavigationManager.ShowAdminDashboard();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!\n\n(Tài khoản mẫu: 'cashier' / '123456' hoặc 'admin' / '123456')", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        private void btnQuickCashier_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "cashier";
            txtPassword.Text = "123456";
            btnLogin.PerformClick();
        }

        private void btnQuickAdmin_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "123456";
            btnLogin.PerformClick();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            NavigationManager.ExitApp();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (_isClosingFromNavigation)
            {
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing && !UserSession.Current.IsLoggedIn)
            {
                NavigationManager.ExitApp();
            }
        }
    }
}
