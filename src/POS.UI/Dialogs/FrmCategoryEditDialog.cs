using System;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmCategoryEditDialog : Form
    {
        private readonly CategoryService _categoryService = new CategoryService();
        public CategoryDto Category { get; private set; }

        public FrmCategoryEditDialog(CategoryDto category = null)
        {
            InitializeComponent();
            Category = category ?? new CategoryDto { Id = 0, IsActive = true };
        }

        private void FrmCategoryEditDialog_Load(object sender, EventArgs e)
        {
            if (Category.Id > 0)
            {
                lblTitle.Text = "📁 CHỈNH SỬA DANH MỤC";
                Text = "Chỉnh sửa danh mục";
                txtName.Text = Category.Name;
                chkActive.Checked = Category.IsActive;
            }
            else
            {
                lblTitle.Text = "📁 THÊM DANH MỤC MỚI";
                Text = "Thêm danh mục mới";
                txtName.Text = string.Empty;
                chkActive.Checked = true;
            }

            txtName.Focus();
            txtName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Category.Name = txtName.Text.Trim();
            Category.IsActive = chkActive.Checked;

            if (_categoryService.SaveCategory(Category, out string error))
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
