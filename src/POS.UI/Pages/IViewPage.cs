using System;

namespace POS.UI.Pages
{
    /// <summary>
    /// Hợp đồng chuẩn cho các UserControl nhúng vào Admin Shell
    /// </summary>
    public interface IViewPage
    {
        string PageTitle { get; }

        /// <summary>
        /// Được gọi ngay sau khi trang được nhúng vào Shell (Nạp dữ liệu mới nhất từ CSDL)
        /// </summary>
        void OnPageActivated();

        /// <summary>
        /// Được gọi trước khi trang bị tháo khỏi Shell và Dispose (Hủy đăng ký Event, dọn dẹp tài nguyên)
        /// </summary>
        void OnPageDeactivated();
    }
}
