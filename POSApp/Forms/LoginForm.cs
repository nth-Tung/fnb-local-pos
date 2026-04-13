using POS.Services;
using System;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class LoginForm: Form
    {
        private TextBox lastFocused;
        private AccountService accountService;
        public LoginForm()
        {
            InitializeComponent();
            accountService = new AccountService();
            lastFocused = txtUsername;

            txtUsername.Enter += (s, e) => lastFocused = txtUsername;
            txtPassword.Enter += (s, e) => lastFocused = txtPassword;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var account = accountService.Login(txtUsername.Text, txtPassword.Text);

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (account != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainPOSForm frm = new MainPOSForm(txtUsername.Text);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
            }
        }

        private void Numpad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox target = lastFocused;

            if (btn.Text == "C")
                target.Clear();
            else if (btn.Text == "←")
            {
                if (target.Text.Length > 0)
                    target.Text = target.Text.Substring(0, target.Text.Length - 1);
            }
            else
                target.AppendText(btn.Text);

            target.Focus();
        }
    }
}
