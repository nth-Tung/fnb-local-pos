using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class LoginForma : Form
    {
        // Khai báo các thành phần giao diện
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Panel panelNumpad;
        private Label lblUsername;
        private Label lblPassword;

        public LoginForma()
        {
            InitializeComponent();
            SetupCustomUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // Xóa khung viền Windows chuẩn
            this.Size = new Size(450, 650);
            this.BackColor = Color.FromArgb(242, 245, 249);
        }

        private void SetupCustomUI()
        {
            // 1. Header Panel
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(41, 128, 185)
            };

            lblTitle = new Label
            {
                Text = "HỆ THỐNG POS",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 70
            };

            lblSubtitle = new Label
            {
                Text = "Vui lòng đăng nhập để bắt đầu",
                ForeColor = Color.FromArgb(200, 230, 250),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 40
            };
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);

            // 2. Input Fields
            lblUsername = CreateLabel("Tên đăng nhập / Mã NV:", 140);
            txtUsername = CreateTextBox(165);

            lblPassword = CreateLabel("Mật khẩu / PIN:", 225);
            txtPassword = CreateTextBox(250);
            txtPassword.PasswordChar = '●';

            // 3. Numpad (Quan trọng cho POS cảm ứng)
            panelNumpad = new Panel
            {
                Location = new Point(75, 310),
                Size = new Size(300, 240),
                BackColor = Color.Transparent
            };
            CreateNumpad();

            // 4. Action Buttons
            btnLogin = new Button
            {
                Text = "ĐĂNG NHẬP",
                Location = new Point(50, 570),
                Size = new Size(165, 50),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            btnExit = new Button
            {
                Text = "THOÁT",
                Location = new Point(235, 570),
                Size = new Size(165, 50),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Click += (s, e) => Application.Exit();

            // Thêm vào Form
            this.Controls.Add(panelHeader);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(panelNumpad);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);
        }

        private Label CreateLabel(string text, int top)
        {
            return new Label
            {
                Text = text,
                Location = new Point(50, top),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            };
        }

        private TextBox CreateTextBox(int top)
        {
            return new TextBox
            {
                Location = new Point(50, top),
                Width = 350,
                Height = 40,
                Font = new Font("Segoe UI", 14),
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        private void CreateNumpad()
        {
            string[] buttons = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "C", "0", "←" };
            int x = 0, y = 0;
            for (int i = 0; i < buttons.Length; i++)
            {
                Button btn = new Button
                {
                    Text = buttons[i],
                    Size = new Size(90, 50),
                    Location = new Point(x * 100, y * 60),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.Click += Numpad_Click;
                panelNumpad.Controls.Add(btn);

                x++;
                if (x > 2) { x = 0; y++; }
            }
        }

        private void Numpad_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox target = txtPassword.Focused ? txtPassword : txtUsername;

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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Logic kiểm tra đăng nhập giả định
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUsername.Text == "admin" && txtPassword.Text == "1234")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở Form Main của POS tại đây
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
            }
        }

        // Vẽ bo góc cho Form (GDI+)
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = GetRoundedRect(rect, 20))
            {
                this.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2f;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
