namespace POS.UI.Pages
{
    partial class UcDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.lblSubWelcome = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.flpShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuickPOS = new System.Windows.Forms.Button();
            this.btnQuickMenu = new System.Windows.Forms.Button();
            this.btnQuickTables = new System.Windows.Forms.Button();
            this.btnQuickInventory = new System.Windows.Forms.Button();
            this.pnlBanner.SuspendLayout();
            this.flpShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.pnlBanner.Controls.Add(this.lblSubWelcome);
            this.pnlBanner.Controls.Add(this.lblWelcome);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(20, 20);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBanner.Size = new System.Drawing.Size(920, 100);
            this.pnlBanner.TabIndex = 0;
            // 
            // lblSubWelcome
            // 
            this.lblSubWelcome.AutoSize = true;
            this.lblSubWelcome.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(53)))), ((int)(((byte)(15)))));
            this.lblSubWelcome.Location = new System.Drawing.Point(20, 52);
            this.lblSubWelcome.Name = "lblSubWelcome";
            this.lblSubWelcome.Size = new System.Drawing.Size(462, 19);
            this.lblSubWelcome.TabIndex = 1;
            this.lblSubWelcome.Text = "Hệ thống POS bán hàng & Quản lý vận hành F&B Local (Chạy Offline 100%).";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.lblWelcome.Location = new System.Drawing.Point(18, 16);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(409, 28);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "👋 CHÀO MỪNG BẠN ĐẾN VỚI HỆ THỐNG!";
            // 
            // flpShortcuts
            // 
            this.flpShortcuts.AutoScroll = true;
            this.flpShortcuts.Controls.Add(this.btnQuickPOS);
            this.flpShortcuts.Controls.Add(this.btnQuickMenu);
            this.flpShortcuts.Controls.Add(this.btnQuickTables);
            this.flpShortcuts.Controls.Add(this.btnQuickInventory);
            this.flpShortcuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpShortcuts.Location = new System.Drawing.Point(20, 120);
            this.flpShortcuts.Name = "flpShortcuts";
            this.flpShortcuts.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.flpShortcuts.Size = new System.Drawing.Size(920, 480);
            this.flpShortcuts.TabIndex = 1;
            // 
            // btnQuickPOS
            // 
            this.btnQuickPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnQuickPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickPOS.FlatAppearance.BorderSize = 0;
            this.btnQuickPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickPOS.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnQuickPOS.ForeColor = System.Drawing.Color.White;
            this.btnQuickPOS.Location = new System.Drawing.Point(3, 28);
            this.btnQuickPOS.Margin = new System.Windows.Forms.Padding(3, 3, 20, 20);
            this.btnQuickPOS.Name = "btnQuickPOS";
            this.btnQuickPOS.Padding = new System.Windows.Forms.Padding(15);
            this.btnQuickPOS.Size = new System.Drawing.Size(270, 130);
            this.btnQuickPOS.TabIndex = 0;
            this.btnQuickPOS.Text = "🚀 BÁN HÀNG TẠI QUẦY\r\n\r\n[ Mở màn hình POS ]";
            this.btnQuickPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickPOS.UseVisualStyleBackColor = false;
            this.btnQuickPOS.Click += new System.EventHandler(this.btnQuickPOS_Click);
            // 
            // btnQuickMenu
            // 
            this.btnQuickMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnQuickMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickMenu.FlatAppearance.BorderSize = 0;
            this.btnQuickMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickMenu.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnQuickMenu.ForeColor = System.Drawing.Color.White;
            this.btnQuickMenu.Location = new System.Drawing.Point(296, 28);
            this.btnQuickMenu.Margin = new System.Windows.Forms.Padding(3, 3, 20, 20);
            this.btnQuickMenu.Name = "btnQuickMenu";
            this.btnQuickMenu.Padding = new System.Windows.Forms.Padding(15);
            this.btnQuickMenu.Size = new System.Drawing.Size(270, 130);
            this.btnQuickMenu.TabIndex = 1;
            this.btnQuickMenu.Text = "☕ QUẢN LÝ THỰC ĐƠN\r\n\r\n[ Món, Giá & Topping ]";
            this.btnQuickMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickMenu.UseVisualStyleBackColor = false;
            this.btnQuickMenu.Click += new System.EventHandler(this.btnQuickMenu_Click);
            // 
            // btnQuickTables
            // 
            this.btnQuickTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnQuickTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTables.FlatAppearance.BorderSize = 0;
            this.btnQuickTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTables.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnQuickTables.ForeColor = System.Drawing.Color.White;
            this.btnQuickTables.Location = new System.Drawing.Point(589, 28);
            this.btnQuickTables.Margin = new System.Windows.Forms.Padding(3, 3, 20, 20);
            this.btnQuickTables.Name = "btnQuickTables";
            this.btnQuickTables.Padding = new System.Windows.Forms.Padding(15);
            this.btnQuickTables.Size = new System.Drawing.Size(270, 130);
            this.btnQuickTables.TabIndex = 2;
            this.btnQuickTables.Text = "🍽️ SƠ ĐỒ BÀN\r\n\r\n[ Quản lý theo khu vực ]";
            this.btnQuickTables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickTables.UseVisualStyleBackColor = false;
            this.btnQuickTables.Click += new System.EventHandler(this.btnQuickTables_Click);
            // 
            // btnQuickInventory
            // 
            this.btnQuickInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnQuickInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickInventory.FlatAppearance.BorderSize = 0;
            this.btnQuickInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickInventory.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnQuickInventory.ForeColor = System.Drawing.Color.White;
            this.btnQuickInventory.Location = new System.Drawing.Point(3, 181);
            this.btnQuickInventory.Margin = new System.Windows.Forms.Padding(3, 3, 20, 20);
            this.btnQuickInventory.Name = "btnQuickInventory";
            this.btnQuickInventory.Padding = new System.Windows.Forms.Padding(15);
            this.btnQuickInventory.Size = new System.Drawing.Size(270, 130);
            this.btnQuickInventory.TabIndex = 3;
            this.btnQuickInventory.Text = "📦 KHO & ĐỊNH LƯỢNG\r\n\r\n[ Tự động trừ nguyên liệu ]";
            this.btnQuickInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuickInventory.UseVisualStyleBackColor = false;
            this.btnQuickInventory.Click += new System.EventHandler(this.btnQuickInventory_Click);
            // 
            // UcDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.flpShortcuts);
            this.Controls.Add(this.pnlBanner);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcDashboard";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(960, 620);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.flpShortcuts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBanner;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubWelcome;
        private System.Windows.Forms.FlowLayoutPanel flpShortcuts;
        private System.Windows.Forms.Button btnQuickPOS;
        private System.Windows.Forms.Button btnQuickMenu;
        private System.Windows.Forms.Button btnQuickTables;
        private System.Windows.Forms.Button btnQuickInventory;
    }
}
