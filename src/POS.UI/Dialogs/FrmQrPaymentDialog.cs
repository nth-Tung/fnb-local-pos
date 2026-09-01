using System;
using System.Windows.Forms;

namespace POS.UI.Dialogs
{
    public partial class FrmQrPaymentDialog : Form
    {
        public decimal OrderTotal { get; }
        public string OrderNumber { get; }

        public FrmQrPaymentDialog(decimal orderTotal, string orderNumber = "")
        {
            InitializeComponent();
            OrderTotal = Math.Max(0, orderTotal);
            OrderNumber = orderNumber;
        }

        private void FrmQrPaymentDialog_Load(object sender, EventArgs e)
        {
            lblAmount.Text = OrderTotal.ToString("N0") + " đ";
            lblOrderNo.Text = string.IsNullOrEmpty(OrderNumber)
                ? "Nội dung CK: Thanh toán POS"
                : $"Nội dung CK: {OrderNumber}";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
