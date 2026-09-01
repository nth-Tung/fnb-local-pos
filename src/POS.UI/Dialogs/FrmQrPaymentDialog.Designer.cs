namespace POS.UI.Dialogs
{
    partial class FrmQrPaymentDialog
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
            this.pnlQrFrame = new System.Windows.Forms.Panel();
            this.lblBankInfo = new System.Windows.Forms.Label();
            this.lblQrIcon = new System.Windows.Forms.Label();
            this.lblAmountTitle = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlQrFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlTop.Controls.Add(this.lblHeader);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(414, 52);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(14, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(262, 23);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "📱 QUÉT MÃ VIETQR DỰNG SẴN";
            // 
            // pnlQrFrame
            // 
            this.pnlQrFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlQrFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQrFrame.Controls.Add(this.lblBankInfo);
            this.pnlQrFrame.Controls.Add(this.lblQrIcon);
            this.pnlQrFrame.Location = new System.Drawing.Point(82, 68);
            this.pnlQrFrame.Name = "pnlQrFrame";
            this.pnlQrFrame.Size = new System.Drawing.Size(250, 210);
            this.pnlQrFrame.TabIndex = 1;
            // 
            // lblBankInfo
            // 
            this.lblBankInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBankInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBankInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblBankInfo.Location = new System.Drawing.Point(0, 140);
            this.lblBankInfo.Name = "lblBankInfo";
            this.lblBankInfo.Size = new System.Drawing.Size(248, 68);
            this.lblBankInfo.TabIndex = 1;
            this.lblBankInfo.Text = "Ngân hàng: MB Bank\r\nSố TK: 0988888888\r\nChủ TK: FNB LOCAL STORE";
            this.lblBankInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQrIcon
            // 
            this.lblQrIcon.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblQrIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblQrIcon.Location = new System.Drawing.Point(3, 10);
            this.lblQrIcon.Name = "lblQrIcon";
            this.lblQrIcon.Size = new System.Drawing.Size(242, 125);
            this.lblQrIcon.TabIndex = 0;
            this.lblQrIcon.Text = "📲";
            this.lblQrIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountTitle
            // 
            this.lblAmountTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblAmountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblAmountTitle.Location = new System.Drawing.Point(20, 290);
            this.lblAmountTitle.Name = "lblAmountTitle";
            this.lblAmountTitle.Size = new System.Drawing.Size(374, 20);
            this.lblAmountTitle.TabIndex = 2;
            this.lblAmountTitle.Text = "Số tiền thanh toán:";
            this.lblAmountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblAmount.Location = new System.Drawing.Point(20, 315);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(374, 38);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "0 đ";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblOrderNo.Location = new System.Drawing.Point(20, 355);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(374, 18);
            this.lblOrderNo.TabIndex = 4;
            this.lblOrderNo.Text = "Nội dung chuyển khoản: HD-20260831-001";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(30, 385);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(354, 46);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "✅ ĐÃ NHẬN TIỀN (Xác nhận)";
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
            this.btnCancel.Location = new System.Drawing.Point(135, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy bỏ (Esc)";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmQrPaymentDialog
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 485);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblAmountTitle);
            this.Controls.Add(this.pnlQrFrame);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQrPaymentDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyển khoản VietQR";
            this.Load += new System.EventHandler(this.FrmQrPaymentDialog_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlQrFrame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlQrFrame;
        private System.Windows.Forms.Label lblQrIcon;
        private System.Windows.Forms.Label lblBankInfo;
        private System.Windows.Forms.Label lblAmountTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}
