using System;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmAreaEditDialog : Form
    {
        private readonly TableService _tableService = new TableService();
        public AreaDto Area { get; private set; }

        public FrmAreaEditDialog() : this(null)
        {
        }

        public FrmAreaEditDialog(AreaDto area)
        {
            InitializeComponent();
            Area = area ?? new AreaDto { Id = 0, SortOrder = 1, IsActive = true };
        }

        private void FrmAreaEditDialog_Load(object sender, EventArgs e)
        {
            if (Area.Id > 0)
            {
                lblTitle.Text = "📁 CHỈNH SỬA KHU VỰC";
                Text = "Chỉnh sửa khu vực";
                txtName.Text = Area.Name;
                nudSort.Value = Math.Max(0, Area.SortOrder);
                chkActive.Checked = Area.IsActive;
            }
            else
            {
                lblTitle.Text = "📁 THÊM KHU VỰC MỚI";
                Text = "Thêm khu vực mới";
                txtName.Text = string.Empty;
                nudSort.Value = 1;
                chkActive.Checked = true;
            }

            txtName.Focus();
            txtName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            Area.Name = name;
            Area.SortOrder = (int)nudSort.Value;
            Area.IsActive = chkActive.Checked;

            if (_tableService.SaveArea(Area, out string error))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
