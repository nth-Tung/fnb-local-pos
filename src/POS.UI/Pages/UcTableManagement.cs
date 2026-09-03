using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;
using POS.UI.Dialogs;

namespace POS.UI.Pages
{
    public partial class UcTableManagement : UserControl, IViewPage
    {
        public string PageTitle => "Quản lý Sơ đồ Bàn & Khu vực";

        private readonly TableService _tableService = new TableService();
        private List<AreaDto> _areas = new List<AreaDto>();

        public UcTableManagement()
        {
            InitializeComponent();
        }

        public void OnPageActivated()
        {
            LoadAreasFilter();
            LoadTables();
            LoadAreasGrid();
        }

        public void OnPageDeactivated()
        {
            dgvTables.DataSource = null;
            dgvAreas.DataSource = null;
            cboFilterArea.DataSource = null;
        }

        #region Bàn (Tables) Tab

        private void LoadAreasFilter()
        {
            _areas = _tableService.GetAllAreas(includeInactive: true);

            var filterList = new List<AreaDto>
            {
                new AreaDto { Id = 0, Name = "-- Tất cả khu vực --" }
            };
            filterList.AddRange(_areas);

            cboFilterArea.SelectedIndexChanged -= cboFilterArea_SelectedIndexChanged;
            cboFilterArea.DisplayMember = "Name";
            cboFilterArea.ValueMember = "Id";
            cboFilterArea.DataSource = filterList;
            cboFilterArea.SelectedIndex = 0;
            cboFilterArea.SelectedIndexChanged += cboFilterArea_SelectedIndexChanged;
        }

        private void LoadTables()
        {
            int? areaId = null;
            if (cboFilterArea.SelectedItem is AreaDto selectedArea && selectedArea.Id > 0)
            {
                areaId = selectedArea.Id;
            }

            var tables = _tableService.GetAllTables(areaId, includeInactive: true);
            dgvTables.DataSource = null;
            dgvTables.DataSource = tables;

            FormatTablesGrid();
        }

        private void FormatTablesGrid()
        {
            if (dgvTables.Columns.Count == 0) return;

            if (dgvTables.Columns["Id"] != null) { dgvTables.Columns["Id"].HeaderText = "ID"; dgvTables.Columns["Id"].Width = 50; }
            if (dgvTables.Columns["AreaName"] != null) { dgvTables.Columns["AreaName"].HeaderText = "Khu vực"; dgvTables.Columns["AreaName"].Width = 140; }
            if (dgvTables.Columns["Name"] != null) { dgvTables.Columns["Name"].HeaderText = "Tên bàn"; dgvTables.Columns["Name"].Width = 130; }
            if (dgvTables.Columns["Capacity"] != null) { dgvTables.Columns["Capacity"].HeaderText = "Số ghế"; dgvTables.Columns["Capacity"].Width = 70; }
            if (dgvTables.Columns["StatusText"] != null) { dgvTables.Columns["StatusText"].HeaderText = "Trạng thái"; dgvTables.Columns["StatusText"].Width = 110; }
            if (dgvTables.Columns["OrderTotal"] != null)
            {
                dgvTables.Columns["OrderTotal"].HeaderText = "Tạm tính (VNĐ)";
                dgvTables.Columns["OrderTotal"].Width = 120;
                dgvTables.Columns["OrderTotal"].DefaultCellStyle.Format = "N0";
                dgvTables.Columns["OrderTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvTables.Columns["SortOrder"] != null) { dgvTables.Columns["SortOrder"].HeaderText = "Thứ tự"; dgvTables.Columns["SortOrder"].Width = 70; }
            if (dgvTables.Columns["IsActive"] != null) { dgvTables.Columns["IsActive"].HeaderText = "Hoạt động"; dgvTables.Columns["IsActive"].Width = 90; }

            // Ẩn các cột nội bộ
            string[] hiddenCols = { "AreaId", "Status", "CurrentOrderId", "OrderNumber", "OccupiedSince", "CreatedBy", "ItemCount", "OccupiedMinutes" };
            foreach (var col in hiddenCols)
            {
                if (dgvTables.Columns[col] != null) dgvTables.Columns[col].Visible = false;
            }
        }

        private void cboFilterArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmTableEditDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadTables();
                    LoadAreasGrid();
                }
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (dgvTables.CurrentRow?.DataBoundItem is TableDto selectedTable)
            {
                using (var dlg = new FrmTableEditDialog(selectedTable))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadTables();
                        LoadAreasGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (dgvTables.CurrentRow?.DataBoundItem is TableDto selectedTable)
            {
                var dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa bàn [{selectedTable.Name}] không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_tableService.DeleteTable(selectedTable.Id, out string error))
                    {
                        LoadTables();
                        LoadAreasGrid();
                    }
                    else
                    {
                        MessageBox.Show(error, "Lỗi xóa bàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefreshTables_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        #endregion

        #region Khu Vực (Areas) Tab

        private void LoadAreasGrid()
        {
            _areas = _tableService.GetAllAreas(includeInactive: true);
            dgvAreas.DataSource = null;
            dgvAreas.DataSource = _areas;

            FormatAreasGrid();
        }

        private void FormatAreasGrid()
        {
            if (dgvAreas.Columns.Count == 0) return;

            if (dgvAreas.Columns["Id"] != null) { dgvAreas.Columns["Id"].HeaderText = "ID"; dgvAreas.Columns["Id"].Width = 60; }
            if (dgvAreas.Columns["Name"] != null) { dgvAreas.Columns["Name"].HeaderText = "Tên khu vực"; dgvAreas.Columns["Name"].Width = 200; }
            if (dgvAreas.Columns["TableCount"] != null) { dgvAreas.Columns["TableCount"].HeaderText = "Tổng số bàn"; dgvAreas.Columns["TableCount"].Width = 100; }
            if (dgvAreas.Columns["OccupiedCount"] != null) { dgvAreas.Columns["OccupiedCount"].HeaderText = "Đang có khách"; dgvAreas.Columns["OccupiedCount"].Width = 110; }
            if (dgvAreas.Columns["SortOrder"] != null) { dgvAreas.Columns["SortOrder"].HeaderText = "Thứ tự"; dgvAreas.Columns["SortOrder"].Width = 80; }
            if (dgvAreas.Columns["IsActive"] != null) { dgvAreas.Columns["IsActive"].HeaderText = "Hoạt động"; dgvAreas.Columns["IsActive"].Width = 90; }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmAreaEditDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadAreasFilter();
                    LoadAreasGrid();
                }
            }
        }

        private void btnEditArea_Click(object sender, EventArgs e)
        {
            if (dgvAreas.CurrentRow?.DataBoundItem is AreaDto selectedArea)
            {
                using (var dlg = new FrmAreaEditDialog(selectedArea))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadAreasFilter();
                        LoadAreasGrid();
                        LoadTables();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khu vực để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteArea_Click(object sender, EventArgs e)
        {
            if (dgvAreas.CurrentRow?.DataBoundItem is AreaDto selectedArea)
            {
                var dr = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa khu vực [{selectedArea.Name}] không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    if (_tableService.DeleteArea(selectedArea.Id, out string error))
                    {
                        LoadAreasFilter();
                        LoadAreasGrid();
                        LoadTables();
                    }
                    else
                    {
                        MessageBox.Show(error, "Lỗi xóa khu vực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khu vực để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefreshAreas_Click(object sender, EventArgs e)
        {
            LoadAreasGrid();
        }

        #endregion
    }
}
