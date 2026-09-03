namespace POS.UI
{
    partial class FrmCounterSale
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTableBadge = new System.Windows.Forms.Label();
            this.btnSaveTable = new System.Windows.Forms.Button();
            this.btnBackToFloor = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.btnBackToAdmin = new System.Windows.Forms.Button();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblCashier = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlBottomActions = new System.Windows.Forms.Panel();
            this.pnlFunctionButtons = new System.Windows.Forms.Panel();
            this.btnReprintBill = new System.Windows.Forms.Button();
            this.btnOpenDrawer = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.pnlPaymentActions = new System.Windows.Forms.Panel();
            this.btnTransferQR = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.pnlLeftCart = new System.Windows.Forms.Panel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCartQtyAdjust = new System.Windows.Forms.Panel();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnIncreaseQty = new System.Windows.Forms.Button();
            this.btnDecreaseQty = new System.Windows.Forms.Button();
            this.pnlCartSummary = new System.Windows.Forms.Panel();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblGrandTotalTitle = new System.Windows.Forms.Label();
            this.btnSetDiscount = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDiscountTitle = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblSubTotalTitle = new System.Windows.Forms.Label();
            this.pnlCartHeader = new System.Windows.Forms.Panel();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.lblCartHeader = new System.Windows.Forms.Label();
            this.pnlRightMenu = new System.Windows.Forms.Panel();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlTopBar.SuspendLayout();
            this.pnlBottomActions.SuspendLayout();
            this.pnlFunctionButtons.SuspendLayout();
            this.pnlPaymentActions.SuspendLayout();
            this.pnlLeftCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlCartQtyAdjust.SuspendLayout();
            this.pnlCartSummary.SuspendLayout();
            this.pnlCartHeader.SuspendLayout();
            this.pnlRightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlTopBar.Controls.Add(this.btnBackToFloor);
            this.pnlTopBar.Controls.Add(this.btnSaveTable);
            this.pnlTopBar.Controls.Add(this.lblTableBadge);
            this.pnlTopBar.Controls.Add(this.btnLogout);
            this.pnlTopBar.Controls.Add(this.lblClock);
            this.pnlTopBar.Controls.Add(this.btnBackToAdmin);
            this.pnlTopBar.Controls.Add(this.lblOrderNumber);
            this.pnlTopBar.Controls.Add(this.lblCashier);
            this.pnlTopBar.Controls.Add(this.lblBrand);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1264, 55);
            this.pnlTopBar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1110, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(142, 35);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "🚪 Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblClock.Location = new System.Drawing.Point(920, 18);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(158, 19);
            this.lblClock.TabIndex = 3;
            this.lblClock.Text = "⏰ 00:00:00 - 00/00/00";
            // 
            // lblTableBadge
            // 
            this.lblTableBadge.AutoSize = true;
            this.lblTableBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblTableBadge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTableBadge.ForeColor = System.Drawing.Color.White;
            this.lblTableBadge.Location = new System.Drawing.Point(400, 15);
            this.lblTableBadge.Name = "lblTableBadge";
            this.lblTableBadge.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTableBadge.Size = new System.Drawing.Size(92, 25);
            this.lblTableBadge.TabIndex = 6;
            this.lblTableBadge.Text = "📍 Bàn: ...";
            this.lblTableBadge.Visible = false;
            // 
            // btnSaveTable
            // 
            this.btnSaveTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnSaveTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveTable.FlatAppearance.BorderSize = 0;
            this.btnSaveTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTable.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveTable.ForeColor = System.Drawing.Color.White;
            this.btnSaveTable.Location = new System.Drawing.Point(595, 10);
            this.btnSaveTable.Name = "btnSaveTable";
            this.btnSaveTable.Size = new System.Drawing.Size(145, 35);
            this.btnSaveTable.TabIndex = 7;
            this.btnSaveTable.Text = "💾 LƯU BÀN (F3)";
            this.btnSaveTable.UseVisualStyleBackColor = false;
            this.btnSaveTable.Visible = false;
            this.btnSaveTable.Click += new System.EventHandler(this.btnSaveTable_Click);
            // 
            // btnBackToFloor
            // 
            this.btnBackToFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToFloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnBackToFloor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToFloor.FlatAppearance.BorderSize = 0;
            this.btnBackToFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToFloor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBackToFloor.ForeColor = System.Drawing.Color.White;
            this.btnBackToFloor.Location = new System.Drawing.Point(746, 10);
            this.btnBackToFloor.Name = "btnBackToFloor";
            this.btnBackToFloor.Size = new System.Drawing.Size(155, 35);
            this.btnBackToFloor.TabIndex = 8;
            this.btnBackToFloor.Text = "🍽️ SƠ ĐỒ BÀN";
            this.btnBackToFloor.UseVisualStyleBackColor = false;
            this.btnBackToFloor.Click += new System.EventHandler(this.btnBackToFloor_Click);
            // 
            // btnBackToAdmin
            // 
            this.btnBackToAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnBackToAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToAdmin.FlatAppearance.BorderSize = 0;
            this.btnBackToAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBackToAdmin.ForeColor = System.Drawing.Color.White;
            this.btnBackToAdmin.Location = new System.Drawing.Point(746, 10);
            this.btnBackToAdmin.Name = "btnBackToAdmin";
            this.btnBackToAdmin.Size = new System.Drawing.Size(155, 35);
            this.btnBackToAdmin.TabIndex = 5;
            this.btnBackToAdmin.Text = "⬅️ Về Quản Trị";
            this.btnBackToAdmin.UseVisualStyleBackColor = false;
            this.btnBackToAdmin.Click += new System.EventHandler(this.btnBackToAdmin_Click);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblOrderNumber.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblOrderNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(191)))), ((int)(((byte)(36)))));
            this.lblOrderNumber.Location = new System.Drawing.Point(470, 15);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblOrderNumber.Size = new System.Drawing.Size(96, 25);
            this.lblOrderNumber.TabIndex = 2;
            this.lblOrderNumber.Text = "📋 HD-001";
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblCashier.Location = new System.Drawing.Point(235, 18);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(122, 19);
            this.lblCashier.TabIndex = 1;
            this.lblCashier.Text = "👤 Nguyễn Văn A";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblBrand.Location = new System.Drawing.Point(14, 16);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(183, 21);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "☕ F&&B POS COUNTER";
            // 
            // pnlBottomActions
            // 
            this.pnlBottomActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBottomActions.Controls.Add(this.pnlFunctionButtons);
            this.pnlBottomActions.Controls.Add(this.pnlPaymentActions);
            this.pnlBottomActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomActions.Location = new System.Drawing.Point(0, 681);
            this.pnlBottomActions.Name = "pnlBottomActions";
            this.pnlBottomActions.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBottomActions.Size = new System.Drawing.Size(1264, 100);
            this.pnlBottomActions.TabIndex = 1;
            // 
            // pnlFunctionButtons
            // 
            this.pnlFunctionButtons.Controls.Add(this.btnReprintBill);
            this.pnlFunctionButtons.Controls.Add(this.btnOpenDrawer);
            this.pnlFunctionButtons.Controls.Add(this.btnCancelOrder);
            this.pnlFunctionButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFunctionButtons.Location = new System.Drawing.Point(406, 6);
            this.pnlFunctionButtons.Name = "pnlFunctionButtons";
            this.pnlFunctionButtons.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlFunctionButtons.Size = new System.Drawing.Size(852, 88);
            this.pnlFunctionButtons.TabIndex = 1;
            // 
            // btnReprintBill
            // 
            this.btnReprintBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnReprintBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReprintBill.FlatAppearance.BorderSize = 0;
            this.btnReprintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprintBill.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReprintBill.ForeColor = System.Drawing.Color.White;
            this.btnReprintBill.Location = new System.Drawing.Point(340, 4);
            this.btnReprintBill.Name = "btnReprintBill";
            this.btnReprintBill.Size = new System.Drawing.Size(155, 80);
            this.btnReprintBill.TabIndex = 2;
            this.btnReprintBill.Text = "🖨 IN LẠI BILL\n(F5)";
            this.btnReprintBill.UseVisualStyleBackColor = false;
            this.btnReprintBill.Click += new System.EventHandler(this.btnReprintBill_Click);
            // 
            // btnOpenDrawer
            // 
            this.btnOpenDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnOpenDrawer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDrawer.FlatAppearance.BorderSize = 0;
            this.btnOpenDrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDrawer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOpenDrawer.ForeColor = System.Drawing.Color.White;
            this.btnOpenDrawer.Location = new System.Drawing.Point(170, 4);
            this.btnOpenDrawer.Name = "btnOpenDrawer";
            this.btnOpenDrawer.Size = new System.Drawing.Size(160, 80);
            this.btnOpenDrawer.TabIndex = 1;
            this.btnOpenDrawer.Text = "🗄 MỞ KÉT TIỀN\n(F4)";
            this.btnOpenDrawer.UseVisualStyleBackColor = false;
            this.btnOpenDrawer.Click += new System.EventHandler(this.btnOpenDrawer_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnCancelOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelOrder.FlatAppearance.BorderSize = 0;
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(6, 4);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(155, 80);
            this.btnCancelOrder.TabIndex = 0;
            this.btnCancelOrder.Text = "❌ HỦY ĐƠN\n(F3)";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // pnlPaymentActions
            // 
            this.pnlPaymentActions.Controls.Add(this.btnTransferQR);
            this.pnlPaymentActions.Controls.Add(this.btnCash);
            this.pnlPaymentActions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPaymentActions.Location = new System.Drawing.Point(6, 6);
            this.pnlPaymentActions.Name = "pnlPaymentActions";
            this.pnlPaymentActions.Size = new System.Drawing.Size(400, 88);
            this.pnlPaymentActions.TabIndex = 0;
            // 
            // btnTransferQR
            // 
            this.btnTransferQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTransferQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferQR.FlatAppearance.BorderSize = 0;
            this.btnTransferQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferQR.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnTransferQR.ForeColor = System.Drawing.Color.White;
            this.btnTransferQR.Location = new System.Drawing.Point(203, 4);
            this.btnTransferQR.Name = "btnTransferQR";
            this.btnTransferQR.Size = new System.Drawing.Size(193, 80);
            this.btnTransferQR.TabIndex = 1;
            this.btnTransferQR.Text = "📱 CHUYỂN KHOẢN QR\n(F2)";
            this.btnTransferQR.UseVisualStyleBackColor = false;
            this.btnTransferQR.Click += new System.EventHandler(this.btnTransferQR_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCash.FlatAppearance.BorderSize = 0;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(3, 4);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(194, 80);
            this.btnCash.TabIndex = 0;
            this.btnCash.Text = "💵 TIỀN MẶT\n(F1)";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // pnlLeftCart
            // 
            this.pnlLeftCart.BackColor = System.Drawing.Color.White;
            this.pnlLeftCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftCart.Controls.Add(this.dgvCart);
            this.pnlLeftCart.Controls.Add(this.pnlCartQtyAdjust);
            this.pnlLeftCart.Controls.Add(this.pnlCartSummary);
            this.pnlLeftCart.Controls.Add(this.pnlCartHeader);
            this.pnlLeftCart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftCart.Location = new System.Drawing.Point(0, 55);
            this.pnlLeftCart.Name = "pnlLeftCart";
            this.pnlLeftCart.Size = new System.Drawing.Size(406, 626);
            this.pnlLeftCart.TabIndex = 2;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AllowUserToResizeRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle43.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colItemKey,
            this.colName,
            this.colQty,
            this.colUnitPrice,
            this.colTotal});
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(105)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle44;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvCart.Location = new System.Drawing.Point(0, 42);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCart.RowsDefaultCellStyle = dataGridViewCellStyle45;
            this.dgvCart.RowTemplate.Height = 36;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(404, 386);
            this.dgvCart.TabIndex = 1;
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colItemKey
            // 
            this.colItemKey.HeaderText = "ItemKey";
            this.colItemKey.Name = "colItemKey";
            this.colItemKey.ReadOnly = true;
            this.colItemKey.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Tên món";
            this.colName.MinimumWidth = 130;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "SL";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 45;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "Giá";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 80;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Tổng";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 90;
            // 
            // pnlCartQtyAdjust
            // 
            this.pnlCartQtyAdjust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlCartQtyAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCartQtyAdjust.Controls.Add(this.btnRemoveItem);
            this.pnlCartQtyAdjust.Controls.Add(this.btnIncreaseQty);
            this.pnlCartQtyAdjust.Controls.Add(this.btnDecreaseQty);
            this.pnlCartQtyAdjust.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartQtyAdjust.Location = new System.Drawing.Point(0, 428);
            this.pnlCartQtyAdjust.Name = "pnlCartQtyAdjust";
            this.pnlCartQtyAdjust.Size = new System.Drawing.Size(404, 48);
            this.pnlCartQtyAdjust.TabIndex = 2;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnRemoveItem.Location = new System.Drawing.Point(268, 5);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(126, 36);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "🗑 Xóa món";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnIncreaseQty
            // 
            this.btnIncreaseQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnIncreaseQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncreaseQty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnIncreaseQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIncreaseQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnIncreaseQty.Location = new System.Drawing.Point(138, 5);
            this.btnIncreaseQty.Name = "btnIncreaseQty";
            this.btnIncreaseQty.Size = new System.Drawing.Size(120, 36);
            this.btnIncreaseQty.TabIndex = 1;
            this.btnIncreaseQty.Text = "[ + ] Tăng";
            this.btnIncreaseQty.UseVisualStyleBackColor = false;
            this.btnIncreaseQty.Click += new System.EventHandler(this.btnIncreaseQty_Click);
            // 
            // btnDecreaseQty
            // 
            this.btnDecreaseQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnDecreaseQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecreaseQty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDecreaseQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecreaseQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDecreaseQty.Location = new System.Drawing.Point(8, 5);
            this.btnDecreaseQty.Name = "btnDecreaseQty";
            this.btnDecreaseQty.Size = new System.Drawing.Size(120, 36);
            this.btnDecreaseQty.TabIndex = 0;
            this.btnDecreaseQty.Text = "[ - ] Giảm";
            this.btnDecreaseQty.UseVisualStyleBackColor = false;
            this.btnDecreaseQty.Click += new System.EventHandler(this.btnDecreaseQty_Click);
            // 
            // pnlCartSummary
            // 
            this.pnlCartSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlCartSummary.Controls.Add(this.lblGrandTotal);
            this.pnlCartSummary.Controls.Add(this.lblGrandTotalTitle);
            this.pnlCartSummary.Controls.Add(this.btnSetDiscount);
            this.pnlCartSummary.Controls.Add(this.lblDiscount);
            this.pnlCartSummary.Controls.Add(this.lblDiscountTitle);
            this.pnlCartSummary.Controls.Add(this.lblSubTotal);
            this.pnlCartSummary.Controls.Add(this.lblSubTotalTitle);
            this.pnlCartSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartSummary.Location = new System.Drawing.Point(0, 476);
            this.pnlCartSummary.Name = "pnlCartSummary";
            this.pnlCartSummary.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlCartSummary.Size = new System.Drawing.Size(404, 148);
            this.pnlCartSummary.TabIndex = 3;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(180, 95);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(212, 35);
            this.lblGrandTotal.TabIndex = 6;
            this.lblGrandTotal.Text = "0 đ";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGrandTotalTitle
            // 
            this.lblGrandTotalTitle.AutoSize = true;
            this.lblGrandTotalTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGrandTotalTitle.Location = new System.Drawing.Point(8, 102);
            this.lblGrandTotalTitle.Name = "lblGrandTotalTitle";
            this.lblGrandTotalTitle.Size = new System.Drawing.Size(115, 25);
            this.lblGrandTotalTitle.TabIndex = 5;
            this.lblGrandTotalTitle.Text = "TỔNG TIỀN:";
            // 
            // btnSetDiscount
            // 
            this.btnSetDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnSetDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetDiscount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSetDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDiscount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSetDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSetDiscount.Location = new System.Drawing.Point(80, 48);
            this.btnSetDiscount.Name = "btnSetDiscount";
            this.btnSetDiscount.Size = new System.Drawing.Size(70, 26);
            this.btnSetDiscount.TabIndex = 4;
            this.btnSetDiscount.Text = "✏ Nhập";
            this.btnSetDiscount.UseVisualStyleBackColor = false;
            this.btnSetDiscount.Click += new System.EventHandler(this.btnSetDiscount_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblDiscount.Location = new System.Drawing.Point(200, 50);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(192, 22);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "0 đ";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountTitle
            // 
            this.lblDiscountTitle.AutoSize = true;
            this.lblDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblDiscountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDiscountTitle.Location = new System.Drawing.Point(8, 51);
            this.lblDiscountTitle.Name = "lblDiscountTitle";
            this.lblDiscountTitle.Size = new System.Drawing.Size(66, 19);
            this.lblDiscountTitle.TabIndex = 2;
            this.lblDiscountTitle.Text = "Giảm giá:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSubTotal.Location = new System.Drawing.Point(200, 15);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(192, 22);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "0 đ";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubTotalTitle
            // 
            this.lblSubTotalTitle.AutoSize = true;
            this.lblSubTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSubTotalTitle.Location = new System.Drawing.Point(8, 16);
            this.lblSubTotalTitle.Name = "lblSubTotalTitle";
            this.lblSubTotalTitle.Size = new System.Drawing.Size(66, 19);
            this.lblSubTotalTitle.TabIndex = 0;
            this.lblSubTotalTitle.Text = "Tạm tính:";
            // 
            // pnlCartHeader
            // 
            this.pnlCartHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlCartHeader.Controls.Add(this.btnClearCart);
            this.pnlCartHeader.Controls.Add(this.lblCartHeader);
            this.pnlCartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCartHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlCartHeader.Name = "pnlCartHeader";
            this.pnlCartHeader.Size = new System.Drawing.Size(404, 42);
            this.pnlCartHeader.TabIndex = 0;
            // 
            // btnClearCart
            // 
            this.btnClearCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.FlatAppearance.BorderSize = 0;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(315, 6);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(82, 30);
            this.btnClearCart.TabIndex = 1;
            this.btnClearCart.Text = "🗑 Xóa hết";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // lblCartHeader
            // 
            this.lblCartHeader.AutoSize = true;
            this.lblCartHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCartHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblCartHeader.Location = new System.Drawing.Point(8, 11);
            this.lblCartHeader.Name = "lblCartHeader";
            this.lblCartHeader.Size = new System.Drawing.Size(202, 19);
            this.lblCartHeader.TabIndex = 0;
            this.lblCartHeader.Text = "🛒 DANH SÁCH MÓN CHỌN";
            // 
            // pnlRightMenu
            // 
            this.pnlRightMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlRightMenu.Controls.Add(this.flpProducts);
            this.pnlRightMenu.Controls.Add(this.flpCategories);
            this.pnlRightMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightMenu.Location = new System.Drawing.Point(406, 55);
            this.pnlRightMenu.Name = "pnlRightMenu";
            this.pnlRightMenu.Padding = new System.Windows.Forms.Padding(6);
            this.pnlRightMenu.Size = new System.Drawing.Size(858, 626);
            this.pnlRightMenu.TabIndex = 3;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(6, 71);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(6);
            this.flpProducts.Size = new System.Drawing.Size(846, 549);
            this.flpProducts.TabIndex = 1;
            // 
            // flpCategories
            // 
            this.flpCategories.AutoScroll = true;
            this.flpCategories.BackColor = System.Drawing.Color.White;
            this.flpCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCategories.Location = new System.Drawing.Point(6, 6);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Padding = new System.Windows.Forms.Padding(6);
            this.flpCategories.Size = new System.Drawing.Size(846, 65);
            this.flpCategories.TabIndex = 0;
            this.flpCategories.WrapContents = false;
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // FrmCounterSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1264, 781);
            this.Controls.Add(this.pnlRightMenu);
            this.Controls.Add(this.pnlLeftCart);
            this.Controls.Add(this.pnlBottomActions);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "FrmCounterSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F&B POS - Bán Hàng Tại Quầy (Counter-Service)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCounterSale_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCounterSale_KeyDown);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlBottomActions.ResumeLayout(false);
            this.pnlFunctionButtons.ResumeLayout(false);
            this.pnlPaymentActions.ResumeLayout(false);
            this.pnlLeftCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlCartQtyAdjust.ResumeLayout(false);
            this.pnlCartSummary.ResumeLayout(false);
            this.pnlCartSummary.PerformLayout();
            this.pnlCartHeader.ResumeLayout(false);
            this.pnlCartHeader.PerformLayout();
            this.pnlRightMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBackToAdmin;
        private System.Windows.Forms.Panel pnlBottomActions;
        private System.Windows.Forms.Panel pnlPaymentActions;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnTransferQR;
        private System.Windows.Forms.Panel pnlFunctionButtons;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnOpenDrawer;
        private System.Windows.Forms.Button btnReprintBill;
        private System.Windows.Forms.Panel pnlLeftCart;
        private System.Windows.Forms.Panel pnlCartHeader;
        private System.Windows.Forms.Label lblCartHeader;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlCartQtyAdjust;
        private System.Windows.Forms.Button btnDecreaseQty;
        private System.Windows.Forms.Button btnIncreaseQty;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Panel pnlCartSummary;
        private System.Windows.Forms.Label lblSubTotalTitle;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscountTitle;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Button btnSetDiscount;
        private System.Windows.Forms.Label lblGrandTotalTitle;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Panel pnlRightMenu;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblTableBadge;
        private System.Windows.Forms.Button btnSaveTable;
        private System.Windows.Forms.Button btnBackToFloor;
    }
}
