namespace POS.UI.Pages
{
    partial class UcTableManagement
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.pnlTablesTop = new System.Windows.Forms.Panel();
            this.btnRefreshTables = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnEditTable = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.cboFilterArea = new System.Windows.Forms.ComboBox();
            this.lblFilterArea = new System.Windows.Forms.Label();
            this.tabAreas = new System.Windows.Forms.TabPage();
            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.pnlAreasTop = new System.Windows.Forms.Panel();
            this.btnRefreshAreas = new System.Windows.Forms.Button();
            this.btnDeleteArea = new System.Windows.Forms.Button();
            this.btnEditArea = new System.Windows.Forms.Button();
            this.btnAddArea = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.pnlTablesTop.SuspendLayout();
            this.tabAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            this.pnlAreasTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabTables);
            this.tabControlMain.Controls.Add(this.tabAreas);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(950, 650);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.dgvTables);
            this.tabTables.Controls.Add(this.pnlTablesTop);
            this.tabTables.Location = new System.Drawing.Point(4, 28);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabTables.Size = new System.Drawing.Size(942, 618);
            this.tabTables.TabIndex = 0;
            this.tabTables.Text = "🍽️ Danh Sách Bàn / Phòng";
            this.tabTables.UseVisualStyleBackColor = true;
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AllowUserToResizeRows = false;
            this.dgvTables.BackgroundColor = System.Drawing.Color.White;
            this.dgvTables.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTables.ColumnHeadersHeight = 35;
            this.dgvTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTables.EnableHeadersVisualStyles = false;
            this.dgvTables.Location = new System.Drawing.Point(3, 63);
            this.dgvTables.MultiSelect = false;
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowHeadersVisible = false;
            this.dgvTables.RowTemplate.Height = 32;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTables.Size = new System.Drawing.Size(936, 552);
            this.dgvTables.TabIndex = 1;
            // 
            // pnlTablesTop
            // 
            this.pnlTablesTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlTablesTop.Controls.Add(this.btnRefreshTables);
            this.pnlTablesTop.Controls.Add(this.btnDeleteTable);
            this.pnlTablesTop.Controls.Add(this.btnEditTable);
            this.pnlTablesTop.Controls.Add(this.btnAddTable);
            this.pnlTablesTop.Controls.Add(this.cboFilterArea);
            this.pnlTablesTop.Controls.Add(this.lblFilterArea);
            this.pnlTablesTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTablesTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTablesTop.Name = "pnlTablesTop";
            this.pnlTablesTop.Size = new System.Drawing.Size(936, 60);
            this.pnlTablesTop.TabIndex = 0;
            // 
            // btnRefreshTables
            // 
            this.btnRefreshTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefreshTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTables.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRefreshTables.Location = new System.Drawing.Point(740, 13);
            this.btnRefreshTables.Name = "btnRefreshTables";
            this.btnRefreshTables.Size = new System.Drawing.Size(85, 34);
            this.btnRefreshTables.TabIndex = 5;
            this.btnRefreshTables.Text = "🔄 Tải lại";
            this.btnRefreshTables.UseVisualStyleBackColor = false;
            this.btnRefreshTables.Click += new System.EventHandler(this.btnRefreshTables_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDeleteTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTable.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTable.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTable.Location = new System.Drawing.Point(645, 13);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(85, 34);
            this.btnDeleteTable.TabIndex = 4;
            this.btnDeleteTable.Text = "🗑️ Xóa";
            this.btnDeleteTable.UseVisualStyleBackColor = false;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);
            // 
            // btnEditTable
            // 
            this.btnEditTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnEditTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTable.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTable.ForeColor = System.Drawing.Color.White;
            this.btnEditTable.Location = new System.Drawing.Point(550, 13);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(85, 34);
            this.btnEditTable.TabIndex = 3;
            this.btnEditTable.Text = "✏️ Sửa";
            this.btnEditTable.UseVisualStyleBackColor = false;
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAddTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTable.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTable.ForeColor = System.Drawing.Color.White;
            this.btnAddTable.Location = new System.Drawing.Point(425, 13);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(115, 34);
            this.btnAddTable.TabIndex = 2;
            this.btnAddTable.Text = "➕ Thêm Bàn";
            this.btnAddTable.UseVisualStyleBackColor = false;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // cboFilterArea
            // 
            this.cboFilterArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFilterArea.FormattingEnabled = true;
            this.cboFilterArea.Location = new System.Drawing.Point(125, 17);
            this.cboFilterArea.Name = "cboFilterArea";
            this.cboFilterArea.Size = new System.Drawing.Size(260, 25);
            this.cboFilterArea.TabIndex = 1;
            // 
            // lblFilterArea
            // 
            this.lblFilterArea.AutoSize = true;
            this.lblFilterArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblFilterArea.Location = new System.Drawing.Point(20, 20);
            this.lblFilterArea.Name = "lblFilterArea";
            this.lblFilterArea.Size = new System.Drawing.Size(99, 19);
            this.lblFilterArea.TabIndex = 0;
            this.lblFilterArea.Text = "Lọc theo khu:";
            // 
            // tabAreas
            // 
            this.tabAreas.Controls.Add(this.dgvAreas);
            this.tabAreas.Controls.Add(this.pnlAreasTop);
            this.tabAreas.Location = new System.Drawing.Point(4, 28);
            this.tabAreas.Name = "tabAreas";
            this.tabAreas.Padding = new System.Windows.Forms.Padding(3);
            this.tabAreas.Size = new System.Drawing.Size(942, 618);
            this.tabAreas.TabIndex = 1;
            this.tabAreas.Text = "📁 Khu Vực / Tầng";
            this.tabAreas.UseVisualStyleBackColor = true;
            // 
            // dgvAreas
            // 
            this.dgvAreas.AllowUserToAddRows = false;
            this.dgvAreas.AllowUserToDeleteRows = false;
            this.dgvAreas.AllowUserToResizeRows = false;
            this.dgvAreas.BackgroundColor = System.Drawing.Color.White;
            this.dgvAreas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAreas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAreas.ColumnHeadersHeight = 35;
            this.dgvAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAreas.EnableHeadersVisualStyles = false;
            this.dgvAreas.Location = new System.Drawing.Point(3, 63);
            this.dgvAreas.MultiSelect = false;
            this.dgvAreas.Name = "dgvAreas";
            this.dgvAreas.ReadOnly = true;
            this.dgvAreas.RowHeadersVisible = false;
            this.dgvAreas.RowTemplate.Height = 32;
            this.dgvAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAreas.Size = new System.Drawing.Size(936, 552);
            this.dgvAreas.TabIndex = 2;
            // 
            // pnlAreasTop
            // 
            this.pnlAreasTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlAreasTop.Controls.Add(this.btnRefreshAreas);
            this.pnlAreasTop.Controls.Add(this.btnDeleteArea);
            this.pnlAreasTop.Controls.Add(this.btnEditArea);
            this.pnlAreasTop.Controls.Add(this.btnAddArea);
            this.pnlAreasTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAreasTop.Location = new System.Drawing.Point(3, 3);
            this.pnlAreasTop.Name = "pnlAreasTop";
            this.pnlAreasTop.Size = new System.Drawing.Size(936, 60);
            this.pnlAreasTop.TabIndex = 1;
            // 
            // btnRefreshAreas
            // 
            this.btnRefreshAreas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnRefreshAreas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshAreas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAreas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshAreas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRefreshAreas.Location = new System.Drawing.Point(375, 13);
            this.btnRefreshAreas.Name = "btnRefreshAreas";
            this.btnRefreshAreas.Size = new System.Drawing.Size(85, 34);
            this.btnRefreshAreas.TabIndex = 4;
            this.btnRefreshAreas.Text = "🔄 Tải lại";
            this.btnRefreshAreas.UseVisualStyleBackColor = false;
            this.btnRefreshAreas.Click += new System.EventHandler(this.btnRefreshAreas_Click);
            // 
            // btnDeleteArea
            // 
            this.btnDeleteArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDeleteArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteArea.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteArea.ForeColor = System.Drawing.Color.White;
            this.btnDeleteArea.Location = new System.Drawing.Point(280, 13);
            this.btnDeleteArea.Name = "btnDeleteArea";
            this.btnDeleteArea.Size = new System.Drawing.Size(85, 34);
            this.btnDeleteArea.TabIndex = 3;
            this.btnDeleteArea.Text = "🗑️ Xóa";
            this.btnDeleteArea.UseVisualStyleBackColor = false;
            this.btnDeleteArea.Click += new System.EventHandler(this.btnDeleteArea_Click);
            // 
            // btnEditArea
            // 
            this.btnEditArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnEditArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditArea.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditArea.ForeColor = System.Drawing.Color.White;
            this.btnEditArea.Location = new System.Drawing.Point(185, 13);
            this.btnEditArea.Name = "btnEditArea";
            this.btnEditArea.Size = new System.Drawing.Size(85, 34);
            this.btnEditArea.TabIndex = 2;
            this.btnEditArea.Text = "✏️ Sửa";
            this.btnEditArea.UseVisualStyleBackColor = false;
            this.btnEditArea.Click += new System.EventHandler(this.btnEditArea_Click);
            // 
            // btnAddArea
            // 
            this.btnAddArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAddArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddArea.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddArea.ForeColor = System.Drawing.Color.White;
            this.btnAddArea.Location = new System.Drawing.Point(20, 13);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(145, 34);
            this.btnAddArea.TabIndex = 1;
            this.btnAddArea.Text = "➕ Thêm Khu Vực";
            this.btnAddArea.UseVisualStyleBackColor = false;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // UcTableManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcTableManagement";
            this.Size = new System.Drawing.Size(950, 650);
            this.tabControlMain.ResumeLayout(false);
            this.tabTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.pnlTablesTop.ResumeLayout(false);
            this.pnlTablesTop.PerformLayout();
            this.tabAreas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            this.pnlAreasTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabTables;
        private System.Windows.Forms.TabPage tabAreas;
        private System.Windows.Forms.Panel pnlTablesTop;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.Label lblFilterArea;
        private System.Windows.Forms.ComboBox cboFilterArea;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnEditTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnRefreshTables;
        private System.Windows.Forms.Panel pnlAreasTop;
        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.Button btnAddArea;
        private System.Windows.Forms.Button btnEditArea;
        private System.Windows.Forms.Button btnDeleteArea;
        private System.Windows.Forms.Button btnRefreshAreas;
    }
}
