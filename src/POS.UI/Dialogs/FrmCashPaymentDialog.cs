using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS.UI.Dialogs
{
    public partial class FrmCashPaymentDialog : Form
    {
        public decimal OrderTotal { get; }
        public decimal CashGiven { get; private set; }
        public decimal ChangeAmount { get; private set; }

        public FrmCashPaymentDialog(decimal orderTotal)
        {
            InitializeComponent();
            OrderTotal = Math.Max(0, orderTotal);
        }

        private void FrmCashPaymentDialog_Load(object sender, EventArgs e)
        {
            lblMustPay.Text = OrderTotal.ToString("N0") + " đ";
            txtCashGiven.Text = OrderTotal.ToString("N0");
            CalculateChange();

            txtCashGiven.SelectAll();
            txtCashGiven.Focus();
        }

        private void txtCashGiven_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            string cleanText = txtCashGiven.Text.Replace(",", "").Replace(".", "").Replace("đ", "").Trim();

            if (decimal.TryParse(cleanText, out decimal given))
            {
                CashGiven = given;
                ChangeAmount = CashGiven - OrderTotal;

                if (ChangeAmount >= 0)
                {
                    lblChange.Text = ChangeAmount.ToString("N0") + " đ";
                    lblChange.ForeColor = Color.FromArgb(37, 99, 235); // Blue
                    lblChangeTitle.Text = "Tiền thối lại:";
                    btnConfirm.Enabled = true;
                    btnConfirm.BackColor = Color.FromArgb(22, 163, 74); // Green
                }
                else
                {
                    lblChange.Text = $"Thiếu {Math.Abs(ChangeAmount):N0} đ";
                    lblChange.ForeColor = Color.FromArgb(220, 38, 38); // Red
                    lblChangeTitle.Text = "Chưa đủ tiền:";
                    btnConfirm.Enabled = false;
                    btnConfirm.BackColor = Color.FromArgb(148, 163, 184); // Gray
                }
            }
            else
            {
                CashGiven = 0;
                ChangeAmount = -OrderTotal;
                lblChange.Text = $"Thiếu {OrderTotal:N0} đ";
                lblChange.ForeColor = Color.FromArgb(220, 38, 38);
                btnConfirm.Enabled = false;
                btnConfirm.BackColor = Color.FromArgb(148, 163, 184);
            }
        }

        private void DenominationButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn == btnExact)
                {
                    txtCashGiven.Text = OrderTotal.ToString("N0");
                }
                else
                {
                    string text = btn.Text.Replace("đ", "").Replace(",", "").Trim();
                    if (decimal.TryParse(text, out decimal denom))
                    {
                        txtCashGiven.Text = denom.ToString("N0");
                    }
                }
                txtCashGiven.Focus();
                txtCashGiven.SelectAll();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CashGiven < OrderTotal)
            {
                MessageBox.Show("Số tiền khách đưa chưa đủ để thanh toán đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashGiven.Focus();
                txtCashGiven.SelectAll();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
