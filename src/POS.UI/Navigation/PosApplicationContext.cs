using System;
using System.Threading;
using System.Windows.Forms;

namespace POS.UI.Navigation
{
    /// <summary>
    /// Quản lý vòng đời tiến trình WinForms độc lập với MainForm đơn lẻ.
    /// Cho phép đóng Form đăng nhập, mở Form POS hoặc Form Admin mà tiến trình không bị tắt.
    /// </summary>
    public class PosApplicationContext : ApplicationContext
    {
        public PosApplicationContext()
        {
            // Đảm bảo SynchronizationContext của UI Thread được kích hoạt
            if (SynchronizationContext.Current == null)
            {
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            }

            NavigationManager.Initialize(this);
            NavigationManager.ShowLogin();
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            // Ngăn chặn WinForms tự động ExitThread khi MainForm cũ đóng trong quá trình đổi giao diện.
            // Chỉ đóng luồng Application khi người dùng chọn Thoát ứng dụng có chủ đích.
            if (NavigationManager.IsExiting)
            {
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
