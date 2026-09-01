namespace POS.UI.Dialogs
{
    partial class FrmDiscountDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTypeSelect = new System.Windows.Forms.Panel();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.rdoPercent = new System.Windows.Forms.RadioButton();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.pnlQuickButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPct0 = new System.Windows.Forms.Button();
            this.btnPct5 = new System.Windows.Forms.Button();
            this.btnPct10 = new System.Windows.Forms.Button();
            this.btnPct15 = new System.Windows.Forms.Button();
            this.btnPct20 = new System.Windows.Forms.Button();
            this.btnPct50 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlTypeSelect.SuspendLayout();
            this.pnlQuickButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(384, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏷️ CHIẾT KHẤU / GIẢM GIÁ";
            // 
            // pnlTypeSelect
            // 
            this.pnlTypeSelect.Controls.Add(this.rdoCash);
            this.pnlTypeSelect.Controls.Add(this.rdoPercent);
            this.pnlTypeSelect.Location = new System.Drawing.Point(18, 62);
            this.pnlTypeSelect.Name = "pnlTypeSelect";
            this.pnlTypeSelect.Size = new System.Drawing.Size(348, 38);
            this.pnlTypeSelect.TabIndex = 1;
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoCash.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.rdoCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.rdoCash.Location = new System.Drawing.Point(180, 7);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(133, 23);
            this.rdoCash.TabIndex = 1;
            this.rdoCash.Text = "💵 Tiền mặt (VNĐ)";
            this.rdoCash.UseVisualStyleBackColor = true;
            this.rdoCash.CheckedChanged += new System.EventHandler(this.DiscountType_CheckedChanged);
            // 
            // rdoPercent
            // 
            this.rdoPercent.AutoSize = true;
            this.rdoPercent.Checked = true;
            this.rdoPercent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoPercent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.rdoPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.rdoPercent.Location = new System.Drawing.Point(12, 7);
            this.rdoPercent.Name = "rdoPercent";
            this.rdoPercent.Size = new System.Drawing.Size(122, 23);
            this.rdoPercent.TabIndex = 0;
            this.rdoPercent.TabStop = true;
            this.rdoPercent.Text = "📊 Theo tỷ lệ (%)";
            this.rdoPercent.UseVisualStyleBackColor = true;
            this.rdoPercent.CheckedChanged += new System.EventHandler(this.DiscountType_CheckedChanged);
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPrompt.Location = new System.Drawing.Point(18, 110);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(161, 19);
            this.lblPrompt.TabIndex = 2;
            this.lblPrompt.Text = "Nhập tỷ lệ giảm giá (%):";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtValue.Location = new System.Drawing.Point(18, 134);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(348, 32);
            this.txtValue.TabIndex = 3;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlQuickButtons
            // 
            this.pnlQuickButtons.Controls.Add(this.btnPct0);
            this.pnlQuickButtons.Controls.Add(this.btnPct5);
            this.pnlQuickButtons.Controls.Add(this.btnPct10);
            this.pnlQuickButtons.Controls.Add(this.btnPct15);
            this.pnlQuickButtons.Controls.Add(this.btnPct20);
            this.pnlQuickButtons.Controls.Add(this.btnPct50);
            this.pnlQuickButtons.Location = new System.Drawing.Point(18, 178);
            this.pnlQuickButtons.Name = "pnlQuickButtons";
            this.pnlQuickButtons.Size = new System.Drawing.Size(348, 85);
            this.pnlQuickButtons.TabIndex = 4;
            // 
            // btnPct0
            // 
            this.btnPct0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPct0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPct0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct0.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPct0.Location = new System.Drawing.Point(3, 3);
            this.btnPct0.Name = "btnPct0";
            this.btnPct0.Size = new System.Drawing.Size(108, 35);
            this.btnPct0.TabIndex = 0;
            this.btnPct0.Text = "0% (Bỏ giảm)";
            this.btnPct0.UseVisualStyleBackColor = false;
            this.btnPct0.Click += new System.EventHandler(this.QuickButton_Click);
            // 
            // btnPct5
            // 
            this.btnPct5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPct5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPct5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPct5.Location = new System.Drawing.Point(117, 3);
            this.btnPct5.Name = "btnPct5";
            this.btnPct5.Size = new System.Drawing.Size(108, 35);
            this.btnPct5.TabIndex = 1;
            this.btnPct5.Text = "5%";
            this.btnPct5.UseVisualStyleBackColor = false;
            this.btnPct5.Click += new System.EventHandler(this.QuickButton_Click);
            // 
            // btnPct10
            // 
            this.btnPct10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPct10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPct10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPct10.Location = new System.Drawing.Point(231, 3);
            this.btnPct10.Name = "btnPct10";
            this.btnPct10.Size = new System.Drawing.Size(108, 35);
            this.btnPct10.TabIndex = 2;
            this.btnPct10.Text = "10%";
            this.btnPct10.UseVisualStyleBackColor = false;
            this.btnPct10.Click += new System.EventHandler(this.QuickButton_Click);
            // 
            // btnPct15
            // 
            this.btnPct15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPct15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct15.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPct15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPct15.Location = new System.Drawing.Point(3, 44);
            this.btnPct15.Name = "btnPct15";
            this.btnPct15.Size = new System.Drawing.Size(108, 35);
            this.btnPct15.TabIndex = 3;
            this.btnPct15.Text = "15%";
            this.btnPct15.UseVisualStyleBackColor = false;
            this.btnPct15.Click += new System.EventHandler(this.QuickButton_Click);
            // 
            // btnPct20
            // 
            this.btnPct20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPct20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct20.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPct20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct20.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPct20.Location = new System.Drawing.Point(117, 44);
            this.btnPct20.Name = "btnPct20";
            this.btnPct20.Size = new System.Drawing.Size(108, 35);
            this.btnPct20.TabIndex = 4;
            this.btnPct20.Text = "20%";
            this.btnPct20.UseVisualStyleBackColor = false;
            this.btnPct20.Click += new System.EventHandler(this.QuickButton_Click);
            // 
            // btnPct50
            // 
            this.btnPct50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPct50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPct50.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPct50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPct50.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPct50.Location = new System.Drawing.Point(231, 44);
            this.btnPct50.Name = "btnPct50";
            this.btnPct50.Size = new System.Drawing.Size(108, 35);
            this.btnPct50.TabIndex = 5;
            this.btnPct50.Text = "50%";
            this.btnPct50.UseVisualStyleBackColor = false;
            this.btnPct50.Click += new System.EventHandler(this.QuickButton_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(148, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 38);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "✅ Đồng ý";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancel.Location = new System.Drawing.Point(261, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNote.Location = new System.Drawing.Point(18, 290);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(102, 15);
            this.lblNote.TabIndex = 7;
            this.lblNote.Text = "* Giảm giá áp dụng";
            // 
            // FrmDiscountDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 332);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pnlQuickButtons);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.pnlTypeSelect);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDiscountDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập chiết khấu";
            this.Load += new System.EventHandler(this.FrmDiscountDialog_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlTypeSelect.ResumeLayout(false);
            this.pnlTypeSelect.PerformLayout();
            this.pnlQuickButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTypeSelect;
        private System.Windows.Forms.RadioButton rdoCash;
        private System.Windows.Forms.RadioButton rdoPercent;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.FlowLayoutPanel pnlQuickButtons;
        private System.Windows.Forms.Button btnPct0;
        private System.Windows.Forms.Button btnPct5;
        private System.Windows.Forms.Button btnPct10;
        private System.Windows.Forms.Button btnPct15;
        private System.Windows.Forms.Button btnPct20;
        private System.Windows.Forms.Button btnPct50;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;
    }
}
