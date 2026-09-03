namespace POS.UI.Forms
{
    partial class FrmAdminShell
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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnGoToPOS = new System.Windows.Forms.Button();
            this.lblAdminUser = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavInventory = new System.Windows.Forms.Button();
            this.btnNavTables = new System.Windows.Forms.Button();
            this.btnNavMenu = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlTopBar.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTopBar.Controls.Add(this.btnLogout);
            this.pnlTopBar.Controls.Add(this.btnGoToPOS);
            this.pnlTopBar.Controls.Add(this.lblAdminUser);
            this.pnlTopBar.Controls.Add(this.lblBrand);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1264, 60);
            this.pnlTopBar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1145, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(107, 36);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnGoToPOS
            // 
            this.btnGoToPOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnGoToPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToPOS.FlatAppearance.BorderSize = 0;
            this.btnGoToPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToPOS.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnGoToPOS.ForeColor = System.Drawing.Color.White;
            this.btnGoToPOS.Location = new System.Drawing.Point(920, 12);
            this.btnGoToPOS.Name = "btnGoToPOS";
            this.btnGoToPOS.Size = new System.Drawing.Size(210, 36);
            this.btnGoToPOS.TabIndex = 2;
            this.btnGoToPOS.Text = "🚀 BÁN HÀNG (POS)";
            this.btnGoToPOS.UseVisualStyleBackColor = false;
            this.btnGoToPOS.Click += new System.EventHandler(this.btnGoToPOS_Click);
            // 
            // lblAdminUser
            // 
            this.lblAdminUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminUser.AutoSize = true;
            this.lblAdminUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblAdminUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblAdminUser.Location = new System.Drawing.Point(670, 20);
            this.lblAdminUser.Name = "lblAdminUser";
            this.lblAdminUser.Size = new System.Drawing.Size(200, 19);
            this.lblAdminUser.TabIndex = 1;
            this.lblAdminUser.Text = "👤 Quản trị viên: Quản Lý Tổng";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblBrand.Location = new System.Drawing.Point(18, 16);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(347, 25);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "🏢 F&B LOCAL POS - KHU VỰC QUẢN TRỊ";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.btnNavSettings);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavInventory);
            this.pnlSidebar.Controls.Add(this.btnNavTables);
            this.pnlSidebar.Controls.Add(this.btnNavMenu);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSidebar.Size = new System.Drawing.Size(220, 621);
            this.pnlSidebar.TabIndex = 1;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavSettings.Location = new System.Drawing.Point(10, 275);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavSettings.Size = new System.Drawing.Size(200, 47);
            this.btnNavSettings.TabIndex = 6;
            this.btnNavSettings.Text = "⚙️ Cài Đặt Hệ Thống";
            this.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSettings.UseVisualStyleBackColor = true;
            this.btnNavSettings.Click += new System.EventHandler(this.btnNavSettings_Click);
            // 
            // btnNavReports
            // 
            this.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavReports.FlatAppearance.BorderSize = 0;
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavReports.Location = new System.Drawing.Point(10, 228);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavReports.Size = new System.Drawing.Size(200, 47);
            this.btnNavReports.TabIndex = 5;
            this.btnNavReports.Text = "📈 Báo Cáo & Ca";
            this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReports.UseVisualStyleBackColor = true;
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);
            // 
            // btnNavInventory
            // 
            this.btnNavInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavInventory.FlatAppearance.BorderSize = 0;
            this.btnNavInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavInventory.Location = new System.Drawing.Point(10, 181);
            this.btnNavInventory.Name = "btnNavInventory";
            this.btnNavInventory.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavInventory.Size = new System.Drawing.Size(200, 47);
            this.btnNavInventory.TabIndex = 4;
            this.btnNavInventory.Text = "📦 Kho & Định Lượng";
            this.btnNavInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavInventory.UseVisualStyleBackColor = true;
            this.btnNavInventory.Click += new System.EventHandler(this.btnNavInventory_Click);
            // 
            // btnNavTables
            // 
            this.btnNavTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavTables.FlatAppearance.BorderSize = 0;
            this.btnNavTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTables.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavTables.Location = new System.Drawing.Point(10, 134);
            this.btnNavTables.Name = "btnNavTables";
            this.btnNavTables.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavTables.Size = new System.Drawing.Size(200, 47);
            this.btnNavTables.TabIndex = 3;
            this.btnNavTables.Text = "🍽️ Sơ Đồ Bàn";
            this.btnNavTables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTables.UseVisualStyleBackColor = true;
            this.btnNavTables.Click += new System.EventHandler(this.btnNavTables_Click);
            // 
            // btnNavMenu
            // 
            this.btnNavMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavMenu.FlatAppearance.BorderSize = 0;
            this.btnNavMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavMenu.Location = new System.Drawing.Point(10, 87);
            this.btnNavMenu.Name = "btnNavMenu";
            this.btnNavMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavMenu.Size = new System.Drawing.Size(200, 47);
            this.btnNavMenu.TabIndex = 2;
            this.btnNavMenu.Text = "☕ Thực Đơn & Giá";
            this.btnNavMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMenu.UseVisualStyleBackColor = true;
            this.btnNavMenu.Click += new System.EventHandler(this.btnNavMenu_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(10, 40);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(200, 47);
            this.btnNavDashboard.TabIndex = 1;
            this.btnNavDashboard.Text = "📊 Tổng Quan";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(10, 10);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(200, 30);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "HỆ THỐNG QUẢN LÝ";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 60);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1044, 621);
            this.pnlMainContent.TabIndex = 2;
            // 
            // FrmAdminShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAdminShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị hệ thống POS F&B";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAdminShell_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblAdminUser;
        private System.Windows.Forms.Button btnGoToPOS;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavMenu;
        private System.Windows.Forms.Button btnNavTables;
        private System.Windows.Forms.Button btnNavInventory;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}
