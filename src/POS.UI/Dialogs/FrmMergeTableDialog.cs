using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;

namespace POS.UI.Dialogs
{
    public partial class FrmMergeTableDialog : Form
    {
        private readonly TableService _tableService = new TableService();
        public TableDto SourceTable { get; }
        public TableDto TargetTable { get; private set; }

        public FrmMergeTableDialog(TableDto sourceTable)
        {
            InitializeComponent();
            SourceTable = sourceTable;
        }

        private void FrmMergeTableDialog_Load(object sender, EventArgs e)
        {
            lblSourceInfo.Text = $"Bàn gộp đi: {SourceTable.Name} ({SourceTable.AreaName})\n" +
                                $"Số HĐ: {SourceTable.OrderNumber} | Tạm tính: {SourceTable.OrderTotal:N0} đ";

            LoadOccupiedTables();
        }

        private void LoadOccupiedTables()
        {
            var allTables = _tableService.GetAllTables(includeInactive: false);
            var targetTables = new List<TableDto>();

            foreach (var t in allTables)
            {
                if (t.Id != SourceTable.Id && (t.Status == "OCCUPIED" || t.Status == "PRINTED"))
                {
                    targetTables.Add(t);
                }
            }

            if (targetTables.Count == 0)
            {
                MessageBox.Show("Hiện không có bàn nào khác đang có khách để gộp vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirm.Enabled = false;
                return;
            }

            cboTargetTable.DisplayMember = "ToString";
            cboTargetTable.DataSource = targetTables;
            if (targetTables.Count > 0)
            {
                cboTargetTable.SelectedIndex = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!(cboTargetTable.SelectedItem is TableDto target))
            {
                MessageBox.Show("Vui lòng chọn bàn nhận gộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show(
                $"Xác nhận gộp toàn bộ món ăn từ [{SourceTable.Name}] vào [{target.Name}]?\n(Bàn [{SourceTable.Name}] sẽ trở về trạng thái trống).",
                "Xác nhận gộp bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                if (_tableService.MergeTables(SourceTable.Id, target.Id, out string error))
                {
                    TargetTable = target;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi gộp bàn", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
