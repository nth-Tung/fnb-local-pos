namespace POS.UI.Forms
{
    partial class FrmTableFloor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnQuickTakeaway = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpAreaTabs = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTables = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottomActions = new System.Windows.Forms.Panel();
            this.btnQuickPay = new System.Windows.Forms.Button();
            this.btnPrintPreReceipt = new System.Windows.Forms.Button();
            this.btnMergeTable = new System.Windows.Forms.Button();
            this.btnMoveTable = new System.Windows.Forms.Button();
            this.btnEnterTable = new System.Windows.Forms.Button();
            this.lblSelectedTableInfo = new System.Windows.Forms.Label();
            this.tmrAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlBottomActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlTop.Controls.Add(this.btnLogout);
            this.pnlTop.Controls.Add(this.btnAdmin);
            this.pnlTop.Controls.Add(this.btnQuickTakeaway);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.lblSummary);
            this.pnlTop.Controls.Add(this.lblStaff);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1184, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1072, 14);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 36);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "🚪 Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(966, 14);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 36);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "⚙️ Quản Trị";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnQuickTakeaway
            // 
            this.btnQuickTakeaway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickTakeaway.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnQuickTakeaway.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTakeaway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTakeaway.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickTakeaway.ForeColor = System.Drawing.Color.White;
            this.btnQuickTakeaway.Location = new System.Drawing.Point(770, 14);
            this.btnQuickTakeaway.Name = "btnQuickTakeaway";
            this.btnQuickTakeaway.Size = new System.Drawing.Size(185, 36);
            this.btnQuickTakeaway.TabIndex = 4;
            this.btnQuickTakeaway.Text = "🚀 BÁN MANG ĐI (F1)";
            this.btnQuickTakeaway.UseVisualStyleBackColor = false;
            this.btnQuickTakeaway.Click += new System.EventHandler(this.btnQuickTakeaway_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(670, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Tải lại";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSummary.Location = new System.Drawing.Point(230, 36);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(134, 19);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "📊 Đang tải thống kê...";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblStaff.Location = new System.Drawing.Point(230, 12);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(95, 17);
            this.lblStaff.TabIndex = 1;
            this.lblStaff.Text = "👤 Thu ngân: ...";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🍽️ SƠ ĐỒ BÀN & KHU";
            // 
            // flpAreaTabs
            // 
            this.flpAreaTabs.BackColor = System.Drawing.Color.White;
            this.flpAreaTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAreaTabs.Location = new System.Drawing.Point(0, 65);
            this.flpAreaTabs.Name = "flpAreaTabs";
            this.flpAreaTabs.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.flpAreaTabs.Size = new System.Drawing.Size(1184, 60);
            this.flpAreaTabs.TabIndex = 1;
            // 
            // flpTables
            // 
            this.flpTables.AutoScroll = true;
            this.flpTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.flpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTables.Location = new System.Drawing.Point(0, 125);
            this.flpTables.Name = "flpTables";
            this.flpTables.Padding = new System.Windows.Forms.Padding(15);
            this.flpTables.Size = new System.Drawing.Size(1184, 535);
            this.flpTables.TabIndex = 2;
            // 
            // pnlBottomActions
            // 
            this.pnlBottomActions.BackColor = System.Drawing.Color.White;
            this.pnlBottomActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottomActions.Controls.Add(this.btnQuickPay);
            this.pnlBottomActions.Controls.Add(this.btnPrintPreReceipt);
            this.pnlBottomActions.Controls.Add(this.btnMergeTable);
            this.pnlBottomActions.Controls.Add(this.btnMoveTable);
            this.pnlBottomActions.Controls.Add(this.btnEnterTable);
            this.pnlBottomActions.Controls.Add(this.lblSelectedTableInfo);
            this.pnlBottomActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomActions.Location = new System.Drawing.Point(0, 660);
            this.pnlBottomActions.Name = "pnlBottomActions";
            this.pnlBottomActions.Size = new System.Drawing.Size(1184, 70);
            this.pnlBottomActions.TabIndex = 3;
            // 
            // btnQuickPay
            // 
            this.btnQuickPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuickPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnQuickPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickPay.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickPay.ForeColor = System.Drawing.Color.White;
            this.btnQuickPay.Location = new System.Drawing.Point(1030, 13);
            this.btnQuickPay.Name = "btnQuickPay";
            this.btnQuickPay.Size = new System.Drawing.Size(140, 42);
            this.btnQuickPay.TabIndex = 5;
            this.btnQuickPay.Text = "💳 Thanh Toán";
            this.btnQuickPay.UseVisualStyleBackColor = false;
            this.btnQuickPay.Click += new System.EventHandler(this.btnQuickPay_Click);
            // 
            // btnPrintPreReceipt
            // 
            this.btnPrintPreReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintPreReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(138)))), ((int)(((byte)(4)))));
            this.btnPrintPreReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPreReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPreReceipt.ForeColor = System.Drawing.Color.White;
            this.btnPrintPreReceipt.Location = new System.Drawing.Point(895, 13);
            this.btnPrintPreReceipt.Name = "btnPrintPreReceipt";
            this.btnPrintPreReceipt.Size = new System.Drawing.Size(125, 42);
            this.btnPrintPreReceipt.TabIndex = 4;
            this.btnPrintPreReceipt.Text = "🧾 In Tạm Tính";
            this.btnPrintPreReceipt.UseVisualStyleBackColor = false;
            this.btnPrintPreReceipt.Click += new System.EventHandler(this.btnPrintPreReceipt_Click);
            // 
            // btnMergeTable
            // 
            this.btnMergeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMergeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.btnMergeTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMergeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMergeTable.ForeColor = System.Drawing.Color.White;
            this.btnMergeTable.Location = new System.Drawing.Point(775, 13);
            this.btnMergeTable.Name = "btnMergeTable";
            this.btnMergeTable.Size = new System.Drawing.Size(110, 42);
            this.btnMergeTable.TabIndex = 3;
            this.btnMergeTable.Text = "➕ Gộp Bàn";
            this.btnMergeTable.UseVisualStyleBackColor = false;
            this.btnMergeTable.Click += new System.EventHandler(this.btnMergeTable_Click);
            // 
            // btnMoveTable
            // 
            this.btnMoveTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.btnMoveTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveTable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveTable.ForeColor = System.Drawing.Color.White;
            this.btnMoveTable.Location = new System.Drawing.Point(650, 13);
            this.btnMoveTable.Name = "btnMoveTable";
            this.btnMoveTable.Size = new System.Drawing.Size(115, 42);
            this.btnMoveTable.TabIndex = 2;
            this.btnMoveTable.Text = "🔄 Chuyển Bàn";
            this.btnMoveTable.UseVisualStyleBackColor = false;
            this.btnMoveTable.Click += new System.EventHandler(this.btnMoveTable_Click);
            // 
            // btnEnterTable
            // 
            this.btnEnterTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnterTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnEnterTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnterTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnterTable.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterTable.ForeColor = System.Drawing.Color.White;
            this.btnEnterTable.Location = new System.Drawing.Point(475, 13);
            this.btnEnterTable.Name = "btnEnterTable";
            this.btnEnterTable.Size = new System.Drawing.Size(165, 42);
            this.btnEnterTable.TabIndex = 1;
            this.btnEnterTable.Text = "🍽️ Vào Bàn / Gọi Món";
            this.btnEnterTable.UseVisualStyleBackColor = false;
            this.btnEnterTable.Click += new System.EventHandler(this.btnEnterTable_Click);
            // 
            // lblSelectedTableInfo
            // 
            this.lblSelectedTableInfo.AutoSize = true;
            this.lblSelectedTableInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTableInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSelectedTableInfo.Location = new System.Drawing.Point(15, 25);
            this.lblSelectedTableInfo.Name = "lblSelectedTableInfo";
            this.lblSelectedTableInfo.Size = new System.Drawing.Size(262, 19);
            this.lblSelectedTableInfo.TabIndex = 0;
            this.lblSelectedTableInfo.Text = "👉 Vui lòng chọn một bàn trên sơ đồ";
            // 
            // tmrAutoRefresh
            // 
            this.tmrAutoRefresh.Interval = 10000;
            this.tmrAutoRefresh.Tick += new System.EventHandler(this.tmrAutoRefresh_Tick);
            // 
            // FrmTableFloor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1184, 730);
            this.Controls.Add(this.flpTables);
            this.Controls.Add(this.pnlBottomActions);
            this.Controls.Add(this.flpAreaTabs);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FrmTableFloor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sơ Đồ Bàn - F&B POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTableFloor_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottomActions.ResumeLayout(false);
            this.pnlBottomActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnQuickTakeaway;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel flpAreaTabs;
        private System.Windows.Forms.FlowLayoutPanel flpTables;
        private System.Windows.Forms.Panel pnlBottomActions;
        private System.Windows.Forms.Label lblSelectedTableInfo;
        private System.Windows.Forms.Button btnEnterTable;
        private System.Windows.Forms.Button btnMoveTable;
        private System.Windows.Forms.Button btnMergeTable;
        private System.Windows.Forms.Button btnPrintPreReceipt;
        private System.Windows.Forms.Button btnQuickPay;
        private System.Windows.Forms.Timer tmrAutoRefresh;
    }
}
