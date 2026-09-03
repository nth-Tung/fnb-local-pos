using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;
using POS.UI.Dialogs;

namespace POS.UI.Pages
{
    public partial class UcMenuManagement : UserControl, IViewPage
    {
        private readonly ProductManagementService _productService = new ProductManagementService();
        private readonly CategoryService _categoryService = new CategoryService();

        public string PageTitle => "Quản lý Thực đơn & Món ăn";

        public UcMenuManagement()
        {
            InitializeComponent();
        }

        public void OnPageActivated()
        {
            SetupProductColumns();
            SetupCategoryColumns();
            SetupModifierColumns();

            InitFilters();
            LoadAllData();
        }

        public void OnPageDeactivated()
        {
            // Giải phóng dữ liệu và binding để chống Memory Leak
            dgvProducts.DataSource = null;
            dgvCategories.DataSource = null;
            dgvModifiers.DataSource = null;
            cboFilterCategory.DataSource = null;
        }

        private void InitFilters()
        {
            var categories = _categoryService.GetAllCategories(true);
            var filterCats = new List<CategoryDto>
            {
                new CategoryDto { Id = 0, Name = "-- Tất cả danh mục --" }
            };
            filterCats.AddRange(categories);

            cboFilterCategory.SelectedIndexChanged -= Filter_Changed;
            cboFilterCategory.DisplayMember = "Name";
            cboFilterCategory.ValueMember = "Id";
            cboFilterCategory.DataSource = filterCats;
            cboFilterCategory.SelectedIndex = 0;
            cboFilterCategory.SelectedIndexChanged += Filter_Changed;

            cboFilterStatus.SelectedIndexChanged -= Filter_Changed;
            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.Add(new { Key = -1, Text = "-- Tất cả trạng thái --" });
            cboFilterStatus.Items.Add(new { Key = 1, Text = "🟢 Đang kinh doanh" });
            cboFilterStatus.Items.Add(new { Key = 0, Text = "🔴 Tạm ngưng bán" });
            cboFilterStatus.DisplayMember = "Text";
            cboFilterStatus.ValueMember = "Key";
            cboFilterStatus.SelectedIndex = 0;
            cboFilterStatus.SelectedIndexChanged += Filter_Changed;
        }

        private void SetupProductColumns()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "Mã", DataPropertyName = "Id", Width = 55 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Tên món ăn / Đồ uống", DataPropertyName = "Name", MinimumWidth = 180, FillWeight = 35 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "Danh mục", DataPropertyName = "CategoryName", Width = 150 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Đơn giá (VNĐ)", DataPropertyName = "Price", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Loại món", DataPropertyName = "ProductType", Width = 110 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colModifiers", HeaderText = "Topping kèm", DataPropertyName = "ModifierCount", Width = 105, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng thái", DataPropertyName = "IsActive", Width = 135, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
        }

        private void SetupCategoryColumns()
        {
            dgvCategories.Columns.Clear();
            dgvCategories.AutoGenerateColumns = false;

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCatId", HeaderText = "Mã", DataPropertyName = "Id", Width = 60 });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCatName", HeaderText = "Tên nhóm danh mục", DataPropertyName = "Name", MinimumWidth = 200, FillWeight = 50 });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCatProductCount", HeaderText = "Số lượng món đang có", DataPropertyName = "ProductCount", Width = 160, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCatStatus", HeaderText = "Trạng thái", DataPropertyName = "IsActive", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
        }

        private void SetupModifierColumns()
        {
            dgvModifiers.Columns.Clear();
            dgvModifiers.AutoGenerateColumns = false;

            dgvModifiers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colModId", HeaderText = "Mã", DataPropertyName = "Id", Width = 60 });
            dgvModifiers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colModName", HeaderText = "Tên Topping / Món kèm", DataPropertyName = "Name", MinimumWidth = 200, FillWeight = 50 });
            dgvModifiers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colModPrice", HeaderText = "Đơn giá cộng thêm (VNĐ)", DataPropertyName = "Price", Width = 180, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });
            dgvModifiers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colModStatus", HeaderText = "Trạng thái", DataPropertyName = "IsActive", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
        }

        private void LoadAllData()
        {
            LoadProducts();
            LoadCategories();
            LoadModifiers();
        }

        #region 1. Tab Món Ăn (Products)

        private void LoadProducts()
        {
            int? catId = null;
            if (cboFilterCategory.SelectedItem is CategoryDto selectedCat && selectedCat.Id > 0)
            {
                catId = selectedCat.Id;
            }
            else if (cboFilterCategory.SelectedValue is int intVal && intVal > 0)
            {
                catId = intVal;
            }

            string kw = txtSearchProduct.Text.Trim();

            bool? isActive = null;
            if (cboFilterStatus.SelectedItem != null)
            {
                dynamic item = cboFilterStatus.SelectedItem;
                try
                {
                    if (item.Key == 1) isActive = true;
                    else if (item.Key == 0) isActive = false;
                }
                catch { }
            }

            var products = _productService.GetFilteredProducts(catId, kw, isActive);
            dgvProducts.DataSource = products;
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            txtSearchProduct.Text = string.Empty;
            cboFilterCategory.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            LoadProducts();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmProductEditDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadProducts();
                    LoadCategories();
                }
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is ProductDto selectedProduct)
            {
                var detail = _productService.GetProductById(selectedProduct.Id);
                using (var dlg = new FrmProductEditDialog(detail))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadProducts();
                        LoadCategories();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn cần chỉnh sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditProduct.PerformClick();
            }
        }

        private void btnToggleProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is ProductDto selectedProduct)
            {
                bool newStatus = !selectedProduct.IsActive;
                string statusText = newStatus ? "Đang kinh doanh" : "Tạm ngưng bán (Hết hàng)";

                _productService.ToggleProductStatus(selectedProduct.Id, newStatus);
                LoadProducts();

                MessageBox.Show($"Đã chuyển trạng thái món '{selectedProduct.Name}' sang: {statusText}", "Cập nhật trạng thái", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn cần thay đổi trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow?.DataBoundItem is ProductDto selectedProduct)
            {
                var dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa món '{selectedProduct.Name}' khỏi thực đơn?",
                    "Xác nhận xóa món",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_productService.DeleteProduct(selectedProduct.Id, out bool wasSoftDeleted, out string message))
                    {
                        LoadProducts();
                        LoadCategories();
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvProducts.Columns[e.ColumnIndex].Name == "colStatus" && e.Value is bool isActive)
            {
                e.Value = isActive ? "🟢 Đang bán" : "🔴 Tạm ngưng";
                e.FormattingApplied = true;
            }
            else if (dgvProducts.Columns[e.ColumnIndex].Name == "colType" && e.Value != null)
            {
                string type = e.Value.ToString();
                if (type == "SINGLE") e.Value = "Đơn lẻ";
                else if (type == "FOOD") e.Value = "Đồ ăn";
                else if (type == "COMBO") e.Value = "Combo";
                e.FormattingApplied = true;
            }
        }

        #endregion

        #region 2. Tab Danh Mục (Categories)

        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories(true);
            dgvCategories.DataSource = categories;
        }

        private void btnRefreshCategories_Click(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmCategoryEditDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadCategories();
                    InitFilters();
                }
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is CategoryDto selectedCategory)
            {
                using (var dlg = new FrmCategoryEditDialog(selectedCategory))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadCategories();
                        LoadProducts();
                        InitFilters();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhóm danh mục cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditCategory.PerformClick();
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow?.DataBoundItem is CategoryDto selectedCategory)
            {
                var dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhóm danh mục '{selectedCategory.Name}'?",
                    "Xác nhận xóa danh mục",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_categoryService.DeleteCategory(selectedCategory.Id, out string error))
                    {
                        LoadCategories();
                        InitFilters();
                        MessageBox.Show("Đã xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(error, "Cảnh báo ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCategories.Columns[e.ColumnIndex].Name == "colCatStatus" && e.Value is bool isActive)
            {
                e.Value = isActive ? "🟢 Đang hoạt động" : "🔴 Ngưng dùng";
                e.FormattingApplied = true;
            }
        }

        #endregion

        #region 3. Tab Topping (Modifiers)

        private void LoadModifiers()
        {
            var modifiers = _productService.GetAllModifiers(true);
            dgvModifiers.DataSource = modifiers;
        }

        private void btnRefreshModifiers_Click(object sender, EventArgs e)
        {
            LoadModifiers();
        }

        private void btnAddModifier_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmModifierEditDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadModifiers();
                }
            }
        }

        private void btnEditModifier_Click(object sender, EventArgs e)
        {
            if (dgvModifiers.CurrentRow?.DataBoundItem is ModifierDto selectedMod)
            {
                using (var dlg = new FrmModifierEditDialog(selectedMod))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadModifiers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Topping cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvModifiers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditModifier.PerformClick();
            }
        }

        private void btnDeleteModifier_Click(object sender, EventArgs e)
        {
            if (dgvModifiers.CurrentRow?.DataBoundItem is ModifierDto selectedMod)
            {
                var dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa Topping '{selectedMod.Name}'?",
                    "Xác nhận xóa Topping",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_productService.DeleteModifier(selectedMod.Id, out string error))
                    {
                        LoadModifiers();
                        LoadProducts();
                        MessageBox.Show("Đã xóa Topping thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Topping cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvModifiers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvModifiers.Columns[e.ColumnIndex].Name == "colModStatus" && e.Value is bool isActive)
            {
                e.Value = isActive ? "🟢 Đang hoạt động" : "🔴 Ngưng dùng";
                e.FormattingApplied = true;
            }
        }

        #endregion

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab == tabProducts)
            {
                LoadProducts();
            }
            else if (tabMenu.SelectedTab == tabCategories)
            {
                LoadCategories();
            }
            else if (tabMenu.SelectedTab == tabModifiers)
            {
                LoadModifiers();
            }
        }
    }
}
