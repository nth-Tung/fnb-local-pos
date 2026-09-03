using System;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmModifierEditDialog : Form
    {
        private readonly ProductManagementService _productService = new ProductManagementService();
        public ModifierDto Modifier { get; private set; }

        public FrmModifierEditDialog(ModifierDto modifier = null)
        {
            InitializeComponent();
            Modifier = modifier ?? new ModifierDto { Id = 0, Price = 5000, IsActive = true };
        }

        private void FrmModifierEditDialog_Load(object sender, EventArgs e)
        {
            if (Modifier.Id > 0)
            {
                lblTitle.Text = "🧋 CHỈNH SỬA TOPPING";
                Text = "Chỉnh sửa Topping";
                txtName.Text = Modifier.Name;
                txtPrice.Text = Modifier.Price.ToString("N0");
                chkActive.Checked = Modifier.IsActive;
            }
            else
            {
                lblTitle.Text = "🧋 THÊM TOPPING MỚI";
                Text = "Thêm Topping mới";
                txtName.Text = string.Empty;
                txtPrice.Text = "5,000";
                chkActive.Checked = true;
            }

            txtName.Focus();
            txtName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string cleanPrice = txtPrice.Text.Replace(",", "").Replace(".", "").Replace("đ", "").Trim();
            if (!decimal.TryParse(cleanPrice, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá bán Topping không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                txtPrice.SelectAll();
                return;
            }

            Modifier.Name = txtName.Text.Trim();
            Modifier.Price = price;
            Modifier.IsActive = chkActive.Checked;

            if (_productService.SaveModifier(Modifier, out string error))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
        }
    }
}
