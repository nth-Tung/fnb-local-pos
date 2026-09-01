namespace POS.UI.Dialogs
{
    partial class FrmCashPaymentDialog
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblMustPayTitle = new System.Windows.Forms.Label();
            this.lblMustPay = new System.Windows.Forms.Label();
            this.lblCashGivenTitle = new System.Windows.Forms.Label();
            this.txtCashGiven = new System.Windows.Forms.TextBox();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.flpDenominations = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExact = new System.Windows.Forms.Button();
            this.btn50k = new System.Windows.Forms.Button();
            this.btn100k = new System.Windows.Forms.Button();
            this.btn200k = new System.Windows.Forms.Button();
            this.btn500k = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.flpDenominations.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(434, 52);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(14, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(242, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "💵 THANH TOÁN TIỀN MẶT";
            // 
            // lblMustPayTitle
            // 
            this.lblMustPayTitle.AutoSize = true;
            this.lblMustPayTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblMustPayTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblMustPayTitle.Location = new System.Drawing.Point(20, 68);
            this.lblMustPayTitle.Name = "lblMustPayTitle";
            this.lblMustPayTitle.Size = new System.Drawing.Size(124, 19);
            this.lblMustPayTitle.TabIndex = 1;
            this.lblMustPayTitle.Text = "Khách cần trả (VNĐ):";
            // 
            // lblMustPay
            // 
            this.lblMustPay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMustPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblMustPay.Location = new System.Drawing.Point(150, 60);
            this.lblMustPay.Name = "lblMustPay";
            this.lblMustPay.Size = new System.Drawing.Size(264, 32);
            this.lblMustPay.TabIndex = 2;
            this.lblMustPay.Text = "0 đ";
            this.lblMustPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCashGivenTitle
            // 
            this.lblCashGivenTitle.AutoSize = true;
            this.lblCashGivenTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCashGivenTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblCashGivenTitle.Location = new System.Drawing.Point(20, 108);
            this.lblCashGivenTitle.Name = "lblCashGivenTitle";
            this.lblCashGivenTitle.Size = new System.Drawing.Size(107, 19);
            this.lblCashGivenTitle.TabIndex = 3;
            this.lblCashGivenTitle.Text = "Tiền khách đưa:";
            // 
            // txtCashGiven
            // 
            this.txtCashGiven.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtCashGiven.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtCashGiven.Location = new System.Drawing.Point(20, 132);
            this.txtCashGiven.Name = "txtCashGiven";
            this.txtCashGiven.Size = new System.Drawing.Size(394, 36);
            this.txtCashGiven.TabIndex = 4;
            this.txtCashGiven.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashGiven.TextChanged += new System.EventHandler(this.txtCashGiven_TextChanged);
            // 
            // lblChangeTitle
            // 
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblChangeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblChangeTitle.Location = new System.Drawing.Point(20, 182);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(89, 19);
            this.lblChangeTitle.TabIndex = 5;
            this.lblChangeTitle.Text = "Tiền thối lại:";
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblChange.Location = new System.Drawing.Point(120, 175);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(294, 30);
            this.lblChange.TabIndex = 6;
            this.lblChange.Text = "0 đ";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flpDenominations
            // 
            this.flpDenominations.Controls.Add(this.btnExact);
            this.flpDenominations.Controls.Add(this.btn50k);
            this.flpDenominations.Controls.Add(this.btn100k);
            this.flpDenominations.Controls.Add(this.btn200k);
            this.flpDenominations.Controls.Add(this.btn500k);
            this.flpDenominations.Location = new System.Drawing.Point(20, 220);
            this.flpDenominations.Name = "flpDenominations";
            this.flpDenominations.Size = new System.Drawing.Size(394, 95);
            this.flpDenominations.TabIndex = 7;
            // 
            // btnExact
            // 
            this.btnExact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnExact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnExact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExact.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExact.Location = new System.Drawing.Point(3, 3);
            this.btnExact.Name = "btnExact";
            this.btnExact.Size = new System.Drawing.Size(124, 40);
            this.btnExact.TabIndex = 0;
            this.btnExact.Text = "🎯 Đủ tiền";
            this.btnExact.UseVisualStyleBackColor = false;
            this.btnExact.Click += new System.EventHandler(this.DenominationButton_Click);
            // 
            // btn50k
            // 
            this.btn50k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btn50k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn50k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btn50k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn50k.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn50k.Location = new System.Drawing.Point(133, 3);
            this.btn50k.Name = "btn50k";
            this.btn50k.Size = new System.Drawing.Size(124, 40);
            this.btn50k.TabIndex = 1;
            this.btn50k.Text = "50,000 đ";
            this.btn50k.UseVisualStyleBackColor = false;
            this.btn50k.Click += new System.EventHandler(this.DenominationButton_Click);
            // 
            // btn100k
            // 
            this.btn100k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btn100k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn100k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btn100k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn100k.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn100k.Location = new System.Drawing.Point(263, 3);
            this.btn100k.Name = "btn100k";
            this.btn100k.Size = new System.Drawing.Size(124, 40);
            this.btn100k.TabIndex = 2;
            this.btn100k.Text = "100,000 đ";
            this.btn100k.UseVisualStyleBackColor = false;
            this.btn100k.Click += new System.EventHandler(this.DenominationButton_Click);
            // 
            // btn200k
            // 
            this.btn200k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btn200k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn200k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btn200k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn200k.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn200k.Location = new System.Drawing.Point(3, 49);
            this.btn200k.Name = "btn200k";
            this.btn200k.Size = new System.Drawing.Size(124, 40);
            this.btn200k.TabIndex = 3;
            this.btn200k.Text = "200,000 đ";
            this.btn200k.UseVisualStyleBackColor = false;
            this.btn200k.Click += new System.EventHandler(this.DenominationButton_Click);
            // 
            // btn500k
            // 
            this.btn500k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btn500k.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn500k.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btn500k.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn500k.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn500k.Location = new System.Drawing.Point(133, 49);
            this.btn500k.Name = "btn500k";
            this.btn500k.Size = new System.Drawing.Size(124, 40);
            this.btn500k.TabIndex = 4;
            this.btn500k.Text = "500,000 đ";
            this.btn500k.UseVisualStyleBackColor = false;
            this.btn500k.Click += new System.EventHandler(this.DenominationButton_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(20, 330);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(394, 46);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "✅ HOÀN TẤT THANH TOÁN (Enter)";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCancel.Location = new System.Drawing.Point(145, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy bỏ (Esc)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmCashPaymentDialog
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 430);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.flpDenominations);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lblChangeTitle);
            this.Controls.Add(this.txtCashGiven);
            this.Controls.Add(this.lblCashGivenTitle);
            this.Controls.Add(this.lblMustPay);
            this.Controls.Add(this.lblMustPayTitle);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCashPaymentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán tiền mặt";
            this.Load += new System.EventHandler(this.FrmCashPaymentDialog_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.flpDenominations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblMustPayTitle;
        private System.Windows.Forms.Label lblMustPay;
        private System.Windows.Forms.Label lblCashGivenTitle;
        private System.Windows.Forms.TextBox txtCashGiven;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.FlowLayoutPanel flpDenominations;
        private System.Windows.Forms.Button btnExact;
        private System.Windows.Forms.Button btn50k;
        private System.Windows.Forms.Button btn100k;
        private System.Windows.Forms.Button btn200k;
        private System.Windows.Forms.Button btn500k;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
