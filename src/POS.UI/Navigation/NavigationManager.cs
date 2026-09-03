using System;
using System.Threading;
using System.Windows.Forms;
using POS.BLL.DTOs;
using POS.UI.Forms;
using POS.UI.Session;

namespace POS.UI.Navigation
{
    /// <summary>
    /// Bộ điều phối chuyển đổi Form trung tâm, bảo vệ Session, giải phóng bộ nhớ và đảm bảo an toàn đa luồng (Thread-Safe UI Dispatching)
    /// </summary>
    public static class NavigationManager
    {
        private static PosApplicationContext _context;
        private static Form _currentForm;
        private static FrmAdminShell _activeAdminShell;
        private static bool _isNavigating = false;
        private static SynchronizationContext _uiContext;

        public static bool IsExiting { get; private set; } = false;

        public static void Initialize(PosApplicationContext context)
        {
            _context = context;
            // Bắt lấy SynchronizationContext của UI Thread ngay tại thời điểm khởi tạo
            _uiContext = SynchronizationContext.Current ?? new WindowsFormsSynchronizationContext();
            IsExiting = false;
        }

        /// <summary>
        /// Đảm bảo mọi thao tác can thiệp giao diện (UI) luôn được dispatch về UI Thread
        /// </summary>
        private static void ExecuteOnUIThread(Action action)
        {
            if (_uiContext == null || SynchronizationContext.Current == _uiContext)
            {
                action();
            }
            else
            {
                _uiContext.Post(_ => action(), null);
            }
        }

        /// <summary>
        /// Mở màn hình Đăng nhập (Xóa phiên hiện tại)
        /// </summary>
        public static void ShowLogin()
        {
            ExecuteOnUIThread(() =>
            {
                UserSession.Current.Logout();
                _activeAdminShell = null;
                SwitchForm(new FrmLogin());
            });
        }

        /// <summary>
        /// Mở màn hình Quản trị (Admin Dashboard Shell)
        /// </summary>
        public static void ShowAdminDashboard(string defaultPage = "Dashboard")
        {
            ExecuteOnUIThread(() =>
            {
                if (UserSession.Current.Role != UserRole.Admin)
                {
                    MessageBox.Show("Bạn không có quyền truy cập khu vực Quản trị!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _activeAdminShell = new FrmAdminShell(defaultPage);
                SwitchForm(_activeAdminShell);
            });
        }

        /// <summary>
        /// Mở màn hình Sơ đồ bàn & Khu vực (Dining Table Floor)
        /// </summary>
        public static void ShowTableFloor()
        {
            ExecuteOnUIThread(() =>
            {
                SwitchForm(new FrmTableFloor());
            });
        }

        /// <summary>
        /// Mở màn hình Bán hàng tại quầy (POS), tùy chọn gắn với Bàn
        /// </summary>
        public static void ShowPosScreen(bool fromAdmin = false, TableDto table = null)
        {
            ExecuteOnUIThread(() =>
            {
                var posForm = new FrmCounterSale(table, fromAdmin);

                if (fromAdmin && _activeAdminShell != null)
                {
                    // Khi Admin mở POS: Ẩn Admin Shell để bảo lưu Session, mở POS đè lên
                    _activeAdminShell.Hide();
                    _currentForm = posForm;
                    if (_context != null)
                    {
                        _context.MainForm = posForm;
                    }
                    posForm.Show();
                }
                else
                {
                    // Chuyển hẳn sang POS
                    SwitchForm(posForm);
                }
            });
        }

        /// <summary>
        /// Đóng màn hình con (POS, KDS,...) và quay lại Admin Shell (Dành cho Quản lý)
        /// Sử dụng Interface INavigatableForm để tuân thủ Open/Closed Principle (SOLID)
        /// </summary>
        public static void ReturnToAdmin(Form childForm = null)
        {
            ExecuteOnUIThread(() =>
            {
                if (_isNavigating) return;
                _isNavigating = true;

                try
                {
                    if (_activeAdminShell != null && !_activeAdminShell.IsDisposed)
                    {
                        _currentForm = _activeAdminShell;
                        if (_context != null)
                        {
                            _context.MainForm = _activeAdminShell;
                        }
                        _activeAdminShell.Show();
                        _activeAdminShell.BringToFront();

                        if (childForm != null && !childForm.IsDisposed)
                        {
                            if (childForm is INavigatableForm navigatable)
                            {
                                navigatable.PrepareForClose();
                            }
                            childForm.Close();
                            childForm.Dispose();
                        }
                    }
                    else
                    {
                        ShowAdminDashboard();
                    }
                }
                finally
                {
                    _isNavigating = false;
                }
            });
        }

        /// <summary>
        /// Đăng xuất tài khoản và quay trở lại màn hình Đăng nhập
        /// </summary>
        public static void Logout(Form callerForm = null)
        {
            ExecuteOnUIThread(() =>
            {
                if (_isNavigating) return;

                var dr = MessageBox.Show(
                    $"Xác nhận đăng xuất tài khoản [{UserSession.Current.FullName}]?",
                    "Đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    _isNavigating = true;
                    try
                    {
                        UserSession.Current.Logout();
                        _activeAdminShell = null;

                        var loginForm = new FrmLogin();
                        SwitchForm(loginForm);
                    }
                    finally
                    {
                        _isNavigating = false;
                    }
                }
            });
        }

        /// <summary>
        /// Thoát ứng dụng hoàn toàn
        /// </summary>
        public static void ExitApp()
        {
            ExecuteOnUIThread(() =>
            {
                IsExiting = true;
                _context?.ExitThread();
                Application.Exit();
            });
        }

        private static void SwitchForm(Form nextForm)
        {
            var oldForm = _currentForm;
            _currentForm = nextForm;
            if (_context != null)
            {
                _context.MainForm = nextForm;
            }

            nextForm.Show();

            if (oldForm != null && oldForm != nextForm && !oldForm.IsDisposed)
            {
                if (oldForm is INavigatableForm navigatable)
                {
                    navigatable.PrepareForClose();
                }

                oldForm.Close();
                oldForm.Dispose();
            }
        }
    }
}
