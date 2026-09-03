using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmTableEditDialog : Form
    {
        private readonly TableService _tableService = new TableService();
        public TableDto Table { get; private set; }

        public FrmTableEditDialog() : this(null)
        {
        }

        public FrmTableEditDialog(TableDto table)
        {
            InitializeComponent();
            Table = table ?? new TableDto { Id = 0, Capacity = 4, SortOrder = 1, IsActive = true };
        }

        private void FrmTableEditDialog_Load(object sender, EventArgs e)
        {
            LoadAreas();

            if (Table.Id > 0)
            {
                lblTitle.Text = "🍽️ CHỈNH SỬA BÀN";
                Text = "Chỉnh sửa bàn";
                txtName.Text = Table.Name;
                nudCapacity.Value = Math.Max(1, Table.Capacity);
                nudSort.Value = Math.Max(0, Table.SortOrder);
                chkActive.Checked = Table.IsActive;

                if (Table.AreaId > 0)
                {
                    cboArea.SelectedValue = Table.AreaId;
                }
            }
            else
            {
                lblTitle.Text = "🍽️ THÊM BÀN MỚI";
                Text = "Thêm bàn mới";
                txtName.Text = string.Empty;
                nudCapacity.Value = 4;
                nudSort.Value = 1;
                chkActive.Checked = true;
            }

            txtName.Focus();
            txtName.SelectAll();
        }

        private void LoadAreas()
        {
            var areas = _tableService.GetAllAreas(includeInactive: false);
            cboArea.DisplayMember = "Name";
            cboArea.ValueMember = "Id";
            cboArea.DataSource = areas;

            if (Table.AreaId > 0)
            {
                cboArea.SelectedValue = Table.AreaId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!(cboArea.SelectedItem is AreaDto selectedArea))
            {
                MessageBox.Show("Vui lòng chọn Khu vực cho bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboArea.Focus();
                return;
            }

            Table.AreaId = selectedArea.Id;
            Table.Name = name;
            Table.Capacity = (int)nudCapacity.Value;
            Table.SortOrder = (int)nudSort.Value;
            Table.IsActive = chkActive.Checked;

            if (_tableService.SaveTable(Table, out string error))
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
