namespace POS.UI.Forms
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlPresets = new System.Windows.Forms.Panel();
            this.lblPresetsTitle = new System.Windows.Forms.Label();
            this.btnQuickCashier = new System.Windows.Forms.Button();
            this.btnQuickAdmin = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlPresets.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTop.Controls.Add(this.lblSubTitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(434, 85);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSubTitle.Location = new System.Drawing.Point(18, 48);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(258, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "HỆ THỐNG BÁN HÀNG & QUẢN TRỊ NỘI BỘ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "☕ F&B LOCAL POS";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblUsername.Location = new System.Drawing.Point(30, 110);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(105, 19);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.Location = new System.Drawing.Point(30, 135);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(374, 29);
            this.txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPassword.Location = new System.Drawing.Point(30, 180);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 19);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(30, 205);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(374, 29);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 255);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(260, 44);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "🔑 ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnExit.Location = new System.Drawing.Point(304, 255);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 44);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlPresets
            // 
            this.pnlPresets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlPresets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPresets.Controls.Add(this.lblPresetsTitle);
            this.pnlPresets.Controls.Add(this.btnQuickCashier);
            this.pnlPresets.Controls.Add(this.btnQuickAdmin);
            this.pnlPresets.Location = new System.Drawing.Point(30, 320);
            this.pnlPresets.Name = "pnlPresets";
            this.pnlPresets.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPresets.Size = new System.Drawing.Size(374, 110);
            this.pnlPresets.TabIndex = 7;
            // 
            // lblPresetsTitle
            // 
            this.lblPresetsTitle.AutoSize = true;
            this.lblPresetsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPresetsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPresetsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPresetsTitle.Name = "lblPresetsTitle";
            this.lblPresetsTitle.Size = new System.Drawing.Size(211, 15);
            this.lblPresetsTitle.TabIndex = 0;
            this.lblPresetsTitle.Text = "⚡ ĐĂNG NHẬP NHANH (MÔ PHỎNG):";
            // 
            // btnQuickCashier
            // 
            this.btnQuickCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnQuickCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickCashier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(239)))), ((int)(((byte)(172)))));
            this.btnQuickCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickCashier.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.btnQuickCashier.Location = new System.Drawing.Point(10, 35);
            this.btnQuickCashier.Name = "btnQuickCashier";
            this.btnQuickCashier.Size = new System.Drawing.Size(350, 32);
            this.btnQuickCashier.TabIndex = 1;
            this.btnQuickCashier.Text = "👤 Thu Ngân (Vào thẳng quầy bán POS)";
            this.btnQuickCashier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickCashier.UseVisualStyleBackColor = false;
            this.btnQuickCashier.Click += new System.EventHandler(this.btnQuickCashier_Click);
            // 
            // btnQuickAdmin
            // 
            this.btnQuickAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.btnQuickAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickAdmin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(211)))), ((int)(((byte)(252)))));
            this.btnQuickAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnQuickAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(105)))), ((int)(((byte)(161)))));
            this.btnQuickAdmin.Location = new System.Drawing.Point(10, 70);
            this.btnQuickAdmin.Name = "btnQuickAdmin";
            this.btnQuickAdmin.Size = new System.Drawing.Size(350, 32);
            this.btnQuickAdmin.TabIndex = 2;
            this.btnQuickAdmin.Text = "👑 Quản Lý (Vào trang Quản trị Dashboard)";
            this.btnQuickAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickAdmin.UseVisualStyleBackColor = false;
            this.btnQuickAdmin.Click += new System.EventHandler(this.btnQuickAdmin_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(434, 450);
            this.Controls.Add(this.pnlPresets);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống POS";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlPresets.ResumeLayout(false);
            this.pnlPresets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlPresets;
        private System.Windows.Forms.Label lblPresetsTitle;
        private System.Windows.Forms.Button btnQuickCashier;
        private System.Windows.Forms.Button btnQuickAdmin;
    }
}
