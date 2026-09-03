using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmProductEditDialog : Form
    {
        private readonly ProductManagementService _productService = new ProductManagementService();
        private readonly CategoryService _categoryService = new CategoryService();

        public ProductDto Product { get; private set; }
        private List<ModifierDto> _allModifiers = new List<ModifierDto>();

        public FrmProductEditDialog(ProductDto product = null)
        {
            InitializeComponent();
            Product = product ?? new ProductDto { Id = 0, Price = 25000, ProductType = "SINGLE", IsActive = true };
        }

        private void FrmProductEditDialog_Load(object sender, EventArgs e)
        {
            // 1. Nạp danh mục
            var categories = _categoryService.GetAllCategories(false);
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.DataSource = categories;

            // 2. Nạp loại món
            cboType.Items.Clear();
            cboType.Items.Add(new { Key = "SINGLE", Text = "Đồ uống / Món đơn lẻ" });
            cboType.Items.Add(new { Key = "FOOD", Text = "Món ăn / Điểm tâm" });
            cboType.Items.Add(new { Key = "COMBO", Text = "Combo trọn gói" });
            cboType.DisplayMember = "Text";
            cboType.ValueMember = "Key";
            cboType.SelectedIndex = 0;

            // 3. Nạp danh sách Topping
            _allModifiers = _productService.GetAllModifiers(true);
            clbModifiers.Items.Clear();
            foreach (var mod in _allModifiers)
            {
                clbModifiers.Items.Add(mod, Product.ModifierIds.Contains(mod.Id));
            }

            // 4. Điền dữ liệu nếu là sửa
            if (Product.Id > 0)
            {
                lblTitle.Text = "☕ CHỈNH SỬA MÓN ĂN";
                Text = "Chỉnh sửa món ăn";
                txtName.Text = Product.Name;
                txtPrice.Text = Product.Price.ToString("N0");
                chkActive.Checked = Product.IsActive;

                cboCategory.SelectedValue = Product.CategoryId;

                for (int i = 0; i < cboType.Items.Count; i++)
                {
                    dynamic item = cboType.Items[i];
                    if (item.Key == Product.ProductType)
                    {
                        cboType.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                lblTitle.Text = "☕ THÊM MÓN ĂN MỚI";
                Text = "Thêm món ăn mới";
                txtName.Text = string.Empty;
                txtPrice.Text = "25,000";
                chkActive.Checked = true;
                if (cboCategory.Items.Count > 0)
                {
                    cboCategory.SelectedIndex = 0;
                }
            }

            txtName.Focus();
            txtName.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int selectedCategoryId = 0;
            string selectedCategoryName = string.Empty;

            if (cboCategory.SelectedItem is CategoryDto selectedCat)
            {
                selectedCategoryId = selectedCat.Id;
                selectedCategoryName = selectedCat.Name;
            }
            else if (cboCategory.SelectedValue is int catIdInt)
            {
                selectedCategoryId = catIdInt;
                selectedCategoryName = cboCategory.Text;
            }

            if (selectedCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục hợp lệ cho món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            string cleanPrice = txtPrice.Text.Replace(",", "").Replace(".", "").Replace("đ", "").Trim();
            if (!decimal.TryParse(cleanPrice, out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá bán không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                txtPrice.SelectAll();
                return;
            }

            Product.CategoryId = selectedCategoryId;
            Product.CategoryName = selectedCategoryName;
            Product.Name = txtName.Text.Trim();
            Product.Price = price;

            dynamic selectedType = cboType.SelectedItem;
            Product.ProductType = selectedType != null ? (string)selectedType.Key : "SINGLE";
            Product.IsActive = chkActive.Checked;

            // Thu thập các ModifierIds đã chọn
            var selectedModIds = new List<int>();
            for (int i = 0; i < clbModifiers.CheckedItems.Count; i++)
            {
                if (clbModifiers.CheckedItems[i] is ModifierDto mod)
                {
                    selectedModIds.Add(mod.Id);
                }
            }
            Product.ModifierIds = selectedModIds;

            if (_productService.SaveProduct(Product, selectedModIds, out string error))
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
