using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS.UI.Dialogs
{
    public partial class FrmDiscountDialog : Form
    {
        public decimal DiscountValue { get; private set; }
        public bool IsPercentDiscount { get; private set; }

        private readonly decimal _subTotal;

        public FrmDiscountDialog(decimal currentDiscount = 0, bool isPercent = true, decimal subTotal = 0)
        {
            InitializeComponent();
            DiscountValue = currentDiscount;
            IsPercentDiscount = isPercent;
            _subTotal = subTotal;
        }

        private void FrmDiscountDialog_Load(object sender, EventArgs e)
        {
            if (IsPercentDiscount)
            {
                rdoPercent.Checked = true;
                txtValue.Text = DiscountValue > 0 ? DiscountValue.ToString("0.##") : "0";
            }
            else
            {
                rdoCash.Checked = true;
                txtValue.Text = DiscountValue > 0 ? DiscountValue.ToString("N0") : "0";
            }

            UpdateUIForMode();
            txtValue.SelectAll();
            txtValue.Focus();
        }

        private void DiscountType_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUIForMode();
        }

        private void UpdateUIForMode()
        {
            if (rdoPercent.Checked)
            {
                lblPrompt.Text = "Nhập tỷ lệ giảm giá (%):";
                pnlQuickButtons.Visible = true;
                lblNote.Text = _subTotal > 0 ? $"* Tạm tính: {_subTotal:N0} đ" : string.Empty;
            }
            else
            {
                lblPrompt.Text = "Nhập số tiền giảm trực tiếp (VNĐ):";
                pnlQuickButtons.Visible = false;
                lblNote.Text = _subTotal > 0 ? $"* Tạm tính: {_subTotal:N0} đ" : string.Empty;
            }
        }

        private void QuickButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                string text = btn.Text.Replace("%", "").Replace("(Bỏ giảm)", "").Trim();
                if (decimal.TryParse(text, out decimal val))
                {
                    txtValue.Text = val.ToString("0.##");
                    rdoPercent.Checked = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string input = txtValue.Text.Replace(",", "").Replace(".", "").Replace("%", "").Replace("đ", "").Trim();

            if (string.IsNullOrEmpty(input) || input == "0")
            {
                DiscountValue = 0;
                IsPercentDiscount = false;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (!decimal.TryParse(input, out decimal val) || val < 0)
            {
                MessageBox.Show("Giá trị chiết khấu / giảm giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValue.Focus();
                txtValue.SelectAll();
                return;
            }

            if (rdoPercent.Checked)
            {
                if (val > 100)
                {
                    MessageBox.Show("Tỷ lệ giảm giá không được vượt quá 100%!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValue.Focus();
                    txtValue.SelectAll();
                    return;
                }
                DiscountValue = val;
                IsPercentDiscount = true;
            }
            else
            {
                if (_subTotal > 0 && val > _subTotal)
                {
                    MessageBox.Show($"Số tiền giảm ({val:N0} đ) không được lớn hơn tổng tiền hàng ({_subTotal:N0} đ)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValue.Focus();
                    txtValue.SelectAll();
                    return;
                }
                DiscountValue = val;
                IsPercentDiscount = false;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
