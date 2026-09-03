using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.BLL.Services;
using POS.UI.Dialogs;
using POS.UI.Navigation;
using POS.UI.Session;

namespace POS.UI.Forms
{
    public partial class FrmTableFloor : Form, INavigatableForm
    {
        private readonly TableService _tableService = new TableService();
        private bool _isClosingFromNavigation = false;
        private List<AreaDto> _areas = new List<AreaDto>();
        private List<TableDto> _tables = new List<TableDto>();
        private int? _selectedAreaId = null;
        private TableDto _selectedTable = null;
        private Panel _selectedCard = null;

        public FrmTableFloor()
        {
            InitializeComponent();
        }

        public void PrepareForClose()
        {
            _isClosingFromNavigation = true;
            tmrAutoRefresh?.Stop();
        }

        private void FrmTableFloor_Load(object sender, EventArgs e)
        {
            lblStaff.Text = $"👤 {UserSession.Current.FullName} ({UserSession.Current.Role})";
            btnAdmin.Visible = (UserSession.Current.Role == UserRole.Admin);

            LoadAreas();
            LoadFloor();

            tmrAutoRefresh.Interval = 10000; // Tự động làm mới mỗi 10 giây
            tmrAutoRefresh.Start();
        }

        private void LoadAreas()
        {
            _areas = _tableService.GetAllAreas(includeInactive: false);
            flpAreaTabs.Controls.Clear();

            // Nút "Tất cả khu vực"
            var btnAll = CreateAreaTabButton("Tất cả", null);
            flpAreaTabs.Controls.Add(btnAll);

            foreach (var area in _areas)
            {
                var btnArea = CreateAreaTabButton(area.Name, area.Id);
                flpAreaTabs.Controls.Add(btnArea);
            }

            HighlightAreaButton(btnAll);
        }

        private Button CreateAreaTabButton(string text, int? areaId)
        {
            var btn = new Button
            {
                Text = text,
                Tag = areaId,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Height = 40,
                AutoSize = true,
                Padding = new Padding(12, 0, 12, 0),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(51, 65, 85),
                Margin = new Padding(0, 0, 8, 0)
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += AreaTabButton_Click;
            return btn;
        }

        private void AreaTabButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                _selectedAreaId = (int?)btn.Tag;
                HighlightAreaButton(btn);
                LoadFloor();
            }
        }

        private void HighlightAreaButton(Button activeBtn)
        {
            foreach (Control c in flpAreaTabs.Controls)
            {
                if (c is Button b)
                {
                    b.BackColor = Color.FromArgb(241, 245, 249);
                    b.ForeColor = Color.FromArgb(51, 65, 85);
                }
            }

            activeBtn.BackColor = Color.FromArgb(14, 165, 233); // Sky Blue
            activeBtn.ForeColor = Color.White;
        }

        public void LoadFloor()
        {
            _tables = _tableService.GetAllTables(_selectedAreaId, includeInactive: false);
            UpdateSummaryCounters();
            RenderTableCards();
            UpdateActionButtons();
        }

        private void UpdateSummaryCounters()
        {
            int total = _tables.Count;
            int empty = 0, occupied = 0, printed = 0;

            foreach (var t in _tables)
            {
                if (t.Status == "OCCUPIED") occupied++;
                else if (t.Status == "PRINTED") printed++;
                else empty++;
            }

            lblSummary.Text = $"📊 Tổng: {total} bàn  |  🟢 Trống: {empty}  |  🔴 Có khách: {occupied}  |  🟡 Đã in bill: {printed}";
        }

        private void RenderTableCards()
        {
            flpTables.SuspendLayout();
            flpTables.Controls.Clear();
            _selectedCard = null;

            foreach (var table in _tables)
            {
                var card = CreateTableCard(table);
                flpTables.Controls.Add(card);

                // Giữ lựa chọn cũ nếu bàn vẫn còn
                if (_selectedTable != null && _selectedTable.Id == table.Id)
                {
                    SelectTable(table, card);
                }
            }

            flpTables.ResumeLayout();
        }

        private Panel CreateTableCard(TableDto table)
        {
            var pnl = new Panel
            {
                Width = 160,
                Height = 130,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = table
            };

            Color bgColor, borderColor, headerColor;

            switch (table.Status)
            {
                case "OCCUPIED":
                    bgColor = Color.FromArgb(254, 242, 242);     // Red light
                    borderColor = Color.FromArgb(239, 68, 68);    // Red
                    headerColor = Color.FromArgb(185, 28, 28);
                    break;
                case "PRINTED":
                    bgColor = Color.FromArgb(254, 252, 232);     // Amber light
                    borderColor = Color.FromArgb(234, 179, 8);    // Amber
                    headerColor = Color.FromArgb(161, 98, 7);
                    break;
                default: // EMPTY
                    bgColor = Color.FromArgb(240, 253, 244);     // Green light
                    borderColor = Color.FromArgb(34, 197, 94);    // Green
                    headerColor = Color.FromArgb(21, 128, 61);
                    break;
            }

            pnl.BackColor = bgColor;

            // Border painting
            pnl.Paint += (s, pe) =>
            {
                using (var pen = new Pen(borderColor, (_selectedTable != null && _selectedTable.Id == table.Id) ? 3 : 1.5F))
                {
                    pe.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            };

            // Label Tên bàn + Sức chứa
            var lblName = new Label
            {
                Text = $"{table.Name} (👤{table.Capacity})",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = headerColor,
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = table
            };

            // Label Khu vực
            var lblArea = new Label
            {
                Text = table.AreaName,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = table
            };

            // Label Trạng thái / Giờ / Món
            var lblStatus = new Label
            {
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Dock = DockStyle.Top,
                Height = 24,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = table
            };

            // Label Tiền
            var lblTotal = new Label
            {
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Dock = DockStyle.Bottom,
                Height = 32,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = table
            };

            if (table.Status == "EMPTY")
            {
                lblStatus.Text = "🟢 Bàn trống";
                lblTotal.Text = "Sẵn sàng";
                lblTotal.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                int mins = table.OccupiedMinutes;
                string timeText = mins < 60 ? $"{mins}p" : $"{mins / 60}h{mins % 60}p";
                lblStatus.Text = table.Status == "PRINTED" ? "🟡 Đã in bill" : $"🔴 {timeText} ({table.ItemCount} món)";
                lblTotal.Text = table.OrderTotal.ToString("N0") + " đ";
                lblTotal.ForeColor = Color.FromArgb(220, 38, 38);
            }

            pnl.Controls.Add(lblStatus);
            pnl.Controls.Add(lblArea);
            pnl.Controls.Add(lblName);
            pnl.Controls.Add(lblTotal);

            // Gán sự kiện click cho cả Panel và tất cả các Label con
            Action clickHandler = () => SelectTable(table, pnl);
            Action doubleClickHandler = () => OpenCounterSaleForTable(table);

            pnl.Click += (s, e) => clickHandler();
            lblName.Click += (s, e) => clickHandler();
            lblArea.Click += (s, e) => clickHandler();
            lblStatus.Click += (s, e) => clickHandler();
            lblTotal.Click += (s, e) => clickHandler();

            pnl.DoubleClick += (s, e) => doubleClickHandler();
            lblName.DoubleClick += (s, e) => doubleClickHandler();
            lblArea.DoubleClick += (s, e) => doubleClickHandler();
            lblStatus.DoubleClick += (s, e) => doubleClickHandler();
            lblTotal.DoubleClick += (s, e) => doubleClickHandler();

            return pnl;
        }

        private void SelectTable(TableDto table, Panel card)
        {
            _selectedTable = table;

            if (_selectedCard != null && !_selectedCard.IsDisposed)
            {
                _selectedCard.Invalidate();
            }

            _selectedCard = card;
            if (_selectedCard != null && !_selectedCard.IsDisposed)
            {
                _selectedCard.Invalidate();
            }

            UpdateActionButtons();
        }

        private void UpdateActionButtons()
        {
            if (_selectedTable == null)
            {
                lblSelectedTableInfo.Text = "👉 Vui lòng chọn một bàn trên sơ đồ";
                btnEnterTable.Enabled = false;
                btnMoveTable.Enabled = false;
                btnMergeTable.Enabled = false;
                btnPrintPreReceipt.Enabled = false;
                btnQuickPay.Enabled = false;
                return;
            }

            string statusStr = _selectedTable.StatusText;
            if (_selectedTable.Status != "EMPTY")
            {
                lblSelectedTableInfo.Text = $"📍 Đang chọn: [{_selectedTable.Name} - {_selectedTable.AreaName}] | {statusStr} | Tạm tính: {_selectedTable.OrderTotal:N0} đ";
                btnEnterTable.Text = "🍽️ Gọi Món / Sửa";
                btnEnterTable.Enabled = true;
                btnMoveTable.Enabled = true;
                btnMergeTable.Enabled = true;
                btnPrintPreReceipt.Enabled = true;
                btnQuickPay.Enabled = true;
            }
            else
            {
                lblSelectedTableInfo.Text = $"📍 Đang chọn: [{_selectedTable.Name} - {_selectedTable.AreaName}] | 🟢 Bàn trống (Sức chứa {_selectedTable.Capacity} người)";
                btnEnterTable.Text = "🍽️ Vào Bàn / Gọi Món";
                btnEnterTable.Enabled = true;
                btnMoveTable.Enabled = false;
                btnMergeTable.Enabled = false;
                btnPrintPreReceipt.Enabled = false;
                btnQuickPay.Enabled = false;
            }
        }

        private void OpenCounterSaleForTable(TableDto table)
        {
            NavigationManager.ShowPosScreen(fromAdmin: false, table: table);
        }

        private void btnEnterTable_Click(object sender, EventArgs e)
        {
            if (_selectedTable != null)
            {
                OpenCounterSaleForTable(_selectedTable);
            }
        }

        private void btnMoveTable_Click(object sender, EventArgs e)
        {
            if (_selectedTable == null || _selectedTable.Status == "EMPTY") return;

            using (var dlg = new FrmMoveTableDialog(_selectedTable))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadFloor();
                }
            }
        }

        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            if (_selectedTable == null || _selectedTable.Status == "EMPTY") return;

            using (var dlg = new FrmMergeTableDialog(_selectedTable))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    LoadFloor();
                }
            }
        }

        private void btnPrintPreReceipt_Click(object sender, EventArgs e)
        {
            if (_selectedTable == null || _selectedTable.Status == "EMPTY") return;

            var dr = MessageBox.Show(
                $"In phiếu tạm tính cho [{_selectedTable.Name}] ({_selectedTable.OrderTotal:N0} đ)?",
                "In tạm tính",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                if (_tableService.PrintPreReceipt(_selectedTable.Id, "POS-80C", out string error))
                {
                    MessageBox.Show("Đã gửi lệnh in tạm tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFloor();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi in tạm tính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnQuickPay_Click(object sender, EventArgs e)
        {
            if (_selectedTable != null)
            {
                OpenCounterSaleForTable(_selectedTable);
            }
        }

        private void btnQuickTakeaway_Click(object sender, EventArgs e)
        {
            // Mở màn hình Bán nhanh không gắn bàn (Mang đi)
            NavigationManager.ShowPosScreen(fromAdmin: false, table: null);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            NavigationManager.ShowAdminDashboard("Tables");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            NavigationManager.Logout(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFloor();
        }

        private void tmrAutoRefresh_Tick(object sender, EventArgs e)
        {
            LoadFloor();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_isClosingFromNavigation) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var dr = MessageBox.Show("Xác nhận thoát chương trình?", "Thoát POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    NavigationManager.ExitApp();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
