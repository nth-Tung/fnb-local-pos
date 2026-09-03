namespace POS.UI.Pages
{
    partial class UcMenuManagement
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
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlProductActions = new System.Windows.Forms.Panel();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnToggleProduct = new System.Windows.Forms.Button();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.pnlProductFilter = new System.Windows.Forms.Panel();
            this.btnRefreshProducts = new System.Windows.Forms.Button();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.txtSearchProduct = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.pnlCategoryActions = new System.Windows.Forms.Panel();
            this.btnRefreshCategories = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.tabModifiers = new System.Windows.Forms.TabPage();
            this.dgvModifiers = new System.Windows.Forms.DataGridView();
            this.pnlModifierActions = new System.Windows.Forms.Panel();
            this.btnRefreshModifiers = new System.Windows.Forms.Button();
            this.btnDeleteModifier = new System.Windows.Forms.Button();
            this.btnEditModifier = new System.Windows.Forms.Button();
            this.btnAddModifier = new System.Windows.Forms.Button();
            this.tabMenu.SuspendLayout();
            this.tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlProductActions.SuspendLayout();
            this.pnlProductFilter.SuspendLayout();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.pnlCategoryActions.SuspendLayout();
            this.tabModifiers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModifiers)).BeginInit();
            this.pnlModifierActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabProducts);
            this.tabMenu.Controls.Add(this.tabCategories);
            this.tabMenu.Controls.Add(this.tabModifiers);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabMenu.ItemSize = new System.Drawing.Size(200, 36);
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(960, 620);
            this.tabMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMenu.TabIndex = 0;
            this.tabMenu.SelectedIndexChanged += new System.EventHandler(this.tabMenu_SelectedIndexChanged);
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabProducts.Controls.Add(this.dgvProducts);
            this.tabProducts.Controls.Add(this.pnlProductActions);
            this.tabProducts.Controls.Add(this.pnlProductFilter);
            this.tabProducts.Location = new System.Drawing.Point(4, 40);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(10);
            this.tabProducts.Size = new System.Drawing.Size(952, 576);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "☕ Món Ăn & Đồ Uống";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(10, 65);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 34;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(932, 451);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            this.dgvProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProducts_CellFormatting);
            // 
            // pnlProductActions
            // 
            this.pnlProductActions.BackColor = System.Drawing.Color.White;
            this.pnlProductActions.Controls.Add(this.btnDeleteProduct);
            this.pnlProductActions.Controls.Add(this.btnToggleProduct);
            this.pnlProductActions.Controls.Add(this.btnEditProduct);
            this.pnlProductActions.Controls.Add(this.btnAddProduct);
            this.pnlProductActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProductActions.Location = new System.Drawing.Point(10, 516);
            this.pnlProductActions.Name = "pnlProductActions";
            this.pnlProductActions.Size = new System.Drawing.Size(932, 50);
            this.pnlProductActions.TabIndex = 2;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDeleteProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnDeleteProduct.Location = new System.Drawing.Point(812, 7);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(110, 36);
            this.btnDeleteProduct.TabIndex = 3;
            this.btnDeleteProduct.Text = "🗑️ Xóa món";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnToggleProduct
            // 
            this.btnToggleProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnToggleProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnToggleProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnToggleProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnToggleProduct.Location = new System.Drawing.Point(268, 7);
            this.btnToggleProduct.Name = "btnToggleProduct";
            this.btnToggleProduct.Size = new System.Drawing.Size(185, 36);
            this.btnToggleProduct.TabIndex = 2;
            this.btnToggleProduct.Text = "🚫 Tạm ngưng / Mở bán";
            this.btnToggleProduct.UseVisualStyleBackColor = false;
            this.btnToggleProduct.Click += new System.EventHandler(this.btnToggleProduct_Click);
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnEditProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnEditProduct.Location = new System.Drawing.Point(145, 7);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(117, 36);
            this.btnEditProduct.TabIndex = 1;
            this.btnEditProduct.Text = "✏️ Sửa món";
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(5, 7);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(134, 36);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "➕ Thêm món mới";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // pnlProductFilter
            // 
            this.pnlProductFilter.BackColor = System.Drawing.Color.White;
            this.pnlProductFilter.Controls.Add(this.btnRefreshProducts);
            this.pnlProductFilter.Controls.Add(this.cboFilterStatus);
            this.pnlProductFilter.Controls.Add(this.lblFilterStatus);
            this.pnlProductFilter.Controls.Add(this.cboFilterCategory);
            this.pnlProductFilter.Controls.Add(this.lblFilterCategory);
            this.pnlProductFilter.Controls.Add(this.txtSearchProduct);
            this.pnlProductFilter.Controls.Add(this.lblSearch);
            this.pnlProductFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductFilter.Location = new System.Drawing.Point(10, 10);
            this.pnlProductFilter.Name = "pnlProductFilter";
            this.pnlProductFilter.Size = new System.Drawing.Size(932, 55);
            this.pnlProductFilter.TabIndex = 0;
            // 
            // btnRefreshProducts
            // 
            this.btnRefreshProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefreshProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshProducts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefreshProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefreshProducts.Location = new System.Drawing.Point(820, 13);
            this.btnRefreshProducts.Name = "btnRefreshProducts";
            this.btnRefreshProducts.Size = new System.Drawing.Size(95, 29);
            this.btnRefreshProducts.TabIndex = 6;
            this.btnRefreshProducts.Text = "🔄 Làm mới";
            this.btnRefreshProducts.UseVisualStyleBackColor = false;
            this.btnRefreshProducts.Click += new System.EventHandler(this.btnRefreshProducts_Click);
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(670, 15);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(135, 25);
            this.cboFilterStatus.TabIndex = 5;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFilterStatus.Location = new System.Drawing.Point(595, 18);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(69, 17);
            this.lblFilterStatus.TabIndex = 4;
            this.lblFilterStatus.Text = "Trạng thái:";
            // 
            // cboFilterCategory
            // 
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(395, 15);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(185, 25);
            this.cboFilterCategory.TabIndex = 3;
            this.cboFilterCategory.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFilterCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFilterCategory.Location = new System.Drawing.Point(320, 18);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(69, 17);
            this.lblFilterCategory.TabIndex = 2;
            this.lblFilterCategory.Text = "Danh mục:";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchProduct.Location = new System.Drawing.Point(85, 15);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.Size = new System.Drawing.Size(215, 24);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblSearch.Location = new System.Drawing.Point(15, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(63, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // tabCategories
            // 
            this.tabCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.pnlCategoryActions);
            this.tabCategories.Location = new System.Drawing.Point(4, 40);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(10);
            this.tabCategories.Size = new System.Drawing.Size(952, 576);
            this.tabCategories.TabIndex = 1;
            this.tabCategories.Text = "📁 Nhóm Danh Mục";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(10, 10);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowTemplate.Height = 34;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(932, 506);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            this.dgvCategories.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCategories_CellFormatting);
            // 
            // pnlCategoryActions
            // 
            this.pnlCategoryActions.BackColor = System.Drawing.Color.White;
            this.pnlCategoryActions.Controls.Add(this.btnRefreshCategories);
            this.pnlCategoryActions.Controls.Add(this.btnDeleteCategory);
            this.pnlCategoryActions.Controls.Add(this.btnEditCategory);
            this.pnlCategoryActions.Controls.Add(this.btnAddCategory);
            this.pnlCategoryActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCategoryActions.Location = new System.Drawing.Point(10, 516);
            this.pnlCategoryActions.Name = "pnlCategoryActions";
            this.pnlCategoryActions.Size = new System.Drawing.Size(932, 50);
            this.pnlCategoryActions.TabIndex = 1;
            // 
            // btnRefreshCategories
            // 
            this.btnRefreshCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefreshCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshCategories.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefreshCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefreshCategories.Location = new System.Drawing.Point(315, 7);
            this.btnRefreshCategories.Name = "btnRefreshCategories";
            this.btnRefreshCategories.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshCategories.TabIndex = 3;
            this.btnRefreshCategories.Text = "🔄 Làm mới";
            this.btnRefreshCategories.UseVisualStyleBackColor = false;
            this.btnRefreshCategories.Click += new System.EventHandler(this.btnRefreshCategories_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDeleteCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnDeleteCategory.Location = new System.Drawing.Point(801, 7);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(120, 36);
            this.btnDeleteCategory.TabIndex = 2;
            this.btnDeleteCategory.Text = "🗑️ Xóa nhóm";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnEditCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnEditCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnEditCategory.Location = new System.Drawing.Point(175, 7);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(130, 36);
            this.btnEditCategory.TabIndex = 1;
            this.btnEditCategory.Text = "✏️ Sửa danh mục";
            this.btnEditCategory.UseVisualStyleBackColor = false;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCategory.FlatAppearance.BorderSize = 0;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(5, 7);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(160, 36);
            this.btnAddCategory.TabIndex = 0;
            this.btnAddCategory.Text = "➕ Thêm danh mục";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // tabModifiers
            // 
            this.tabModifiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabModifiers.Controls.Add(this.dgvModifiers);
            this.tabModifiers.Controls.Add(this.pnlModifierActions);
            this.tabModifiers.Location = new System.Drawing.Point(4, 40);
            this.tabModifiers.Name = "tabModifiers";
            this.tabModifiers.Padding = new System.Windows.Forms.Padding(10);
            this.tabModifiers.Size = new System.Drawing.Size(952, 576);
            this.tabModifiers.TabIndex = 2;
            this.tabModifiers.Text = "🧋 Topping & Món Kèm";
            // 
            // dgvModifiers
            // 
            this.dgvModifiers.AllowUserToAddRows = false;
            this.dgvModifiers.AllowUserToDeleteRows = false;
            this.dgvModifiers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModifiers.BackgroundColor = System.Drawing.Color.White;
            this.dgvModifiers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvModifiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModifiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModifiers.Location = new System.Drawing.Point(10, 10);
            this.dgvModifiers.MultiSelect = false;
            this.dgvModifiers.Name = "dgvModifiers";
            this.dgvModifiers.ReadOnly = true;
            this.dgvModifiers.RowHeadersVisible = false;
            this.dgvModifiers.RowTemplate.Height = 34;
            this.dgvModifiers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModifiers.Size = new System.Drawing.Size(932, 506);
            this.dgvModifiers.TabIndex = 0;
            this.dgvModifiers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModifiers_CellDoubleClick);
            this.dgvModifiers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvModifiers_CellFormatting);
            // 
            // pnlModifierActions
            // 
            this.pnlModifierActions.BackColor = System.Drawing.Color.White;
            this.pnlModifierActions.Controls.Add(this.btnRefreshModifiers);
            this.pnlModifierActions.Controls.Add(this.btnDeleteModifier);
            this.pnlModifierActions.Controls.Add(this.btnEditModifier);
            this.pnlModifierActions.Controls.Add(this.btnAddModifier);
            this.pnlModifierActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModifierActions.Location = new System.Drawing.Point(10, 516);
            this.pnlModifierActions.Name = "pnlModifierActions";
            this.pnlModifierActions.Size = new System.Drawing.Size(932, 50);
            this.pnlModifierActions.TabIndex = 1;
            // 
            // btnRefreshModifiers
            // 
            this.btnRefreshModifiers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefreshModifiers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshModifiers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnRefreshModifiers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshModifiers.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefreshModifiers.Location = new System.Drawing.Point(315, 7);
            this.btnRefreshModifiers.Name = "btnRefreshModifiers";
            this.btnRefreshModifiers.Size = new System.Drawing.Size(100, 36);
            this.btnRefreshModifiers.TabIndex = 3;
            this.btnRefreshModifiers.Text = "🔄 Làm mới";
            this.btnRefreshModifiers.UseVisualStyleBackColor = false;
            this.btnRefreshModifiers.Click += new System.EventHandler(this.btnRefreshModifiers_Click);
            // 
            // btnDeleteModifier
            // 
            this.btnDeleteModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDeleteModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnDeleteModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteModifier.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnDeleteModifier.Location = new System.Drawing.Point(801, 7);
            this.btnDeleteModifier.Name = "btnDeleteModifier";
            this.btnDeleteModifier.Size = new System.Drawing.Size(120, 36);
            this.btnDeleteModifier.TabIndex = 2;
            this.btnDeleteModifier.Text = "🗑️ Xóa Topping";
            this.btnDeleteModifier.UseVisualStyleBackColor = false;
            this.btnDeleteModifier.Click += new System.EventHandler(this.btnDeleteModifier_Click);
            // 
            // btnEditModifier
            // 
            this.btnEditModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnEditModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnEditModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditModifier.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnEditModifier.Location = new System.Drawing.Point(175, 7);
            this.btnEditModifier.Name = "btnEditModifier";
            this.btnEditModifier.Size = new System.Drawing.Size(130, 36);
            this.btnEditModifier.TabIndex = 1;
            this.btnEditModifier.Text = "✏️ Sửa Topping";
            this.btnEditModifier.UseVisualStyleBackColor = false;
            this.btnEditModifier.Click += new System.EventHandler(this.btnEditModifier_Click);
            // 
            // btnAddModifier
            // 
            this.btnAddModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAddModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddModifier.FlatAppearance.BorderSize = 0;
            this.btnAddModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddModifier.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddModifier.ForeColor = System.Drawing.Color.White;
            this.btnAddModifier.Location = new System.Drawing.Point(5, 7);
            this.btnAddModifier.Name = "btnAddModifier";
            this.btnAddModifier.Size = new System.Drawing.Size(160, 36);
            this.btnAddModifier.TabIndex = 0;
            this.btnAddModifier.Text = "➕ Thêm Topping";
            this.btnAddModifier.UseVisualStyleBackColor = false;
            this.btnAddModifier.Click += new System.EventHandler(this.btnAddModifier_Click);
            // 
            // UcMenuManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.tabMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcMenuManagement";
            this.Size = new System.Drawing.Size(960, 620);
            this.tabMenu.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlProductActions.ResumeLayout(false);
            this.pnlProductFilter.ResumeLayout(false);
            this.pnlProductFilter.PerformLayout();
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.pnlCategoryActions.ResumeLayout(false);
            this.tabModifiers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModifiers)).EndInit();
            this.pnlModifierActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabModifiers;
        private System.Windows.Forms.Panel pnlProductFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchProduct;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Button btnRefreshProducts;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlProductActions;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnToggleProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel pnlCategoryActions;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnRefreshCategories;
        private System.Windows.Forms.DataGridView dgvModifiers;
        private System.Windows.Forms.Panel pnlModifierActions;
        private System.Windows.Forms.Button btnAddModifier;
        private System.Windows.Forms.Button btnEditModifier;
        private System.Windows.Forms.Button btnDeleteModifier;
        private System.Windows.Forms.Button btnRefreshModifiers;
    }
}
