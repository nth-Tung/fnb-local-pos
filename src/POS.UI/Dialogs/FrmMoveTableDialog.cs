using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmMoveTableDialog : Form
    {
        private readonly TableService _tableService = new TableService();
        public TableDto SourceTable { get; }
        public TableDto TargetTable { get; private set; }

        public FrmMoveTableDialog(TableDto sourceTable)
        {
            InitializeComponent();
            SourceTable = sourceTable;
        }

        private void FrmMoveTableDialog_Load(object sender, EventArgs e)
        {
            lblSourceInfo.Text = $"Bàn hiện tại: {SourceTable.Name} ({SourceTable.AreaName})\n" +
                                $"Số HĐ: {SourceTable.OrderNumber} | Tạm tính: {SourceTable.OrderTotal:N0} đ";

            LoadEmptyTables();
        }

        private void LoadEmptyTables()
        {
            var allTables = _tableService.GetAllTables(includeInactive: false);
            var emptyTables = new List<TableDto>();

            foreach (var t in allTables)
            {
                if (t.Id != SourceTable.Id && t.Status == "EMPTY")
                {
                    emptyTables.Add(t);
                }
            }

            if (emptyTables.Count == 0)
            {
                MessageBox.Show("Hiện không có bàn nào còn trống để chuyển đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirm.Enabled = false;
                return;
            }

            cboTargetTable.DisplayMember = "ToString";
            cboTargetTable.DataSource = emptyTables;
            if (emptyTables.Count > 0)
            {
                cboTargetTable.SelectedIndex = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!(cboTargetTable.SelectedItem is TableDto target))
            {
                MessageBox.Show("Vui lòng chọn bàn đích!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show(
                $"Xác nhận chuyển toàn bộ đơn hàng từ [{SourceTable.Name}] sang [{target.Name}]?",
                "Xác nhận chuyển bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                if (_tableService.MoveTable(SourceTable.Id, target.Id, out string error))
                {
                    TargetTable = target;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi chuyển bàn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
