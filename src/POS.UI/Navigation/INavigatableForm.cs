namespace POS.UI.Navigation
{
    /// <summary>
    /// Hợp đồng dành cho các Form cần chuẩn bị hoặc dọn dẹp trạng thái trước khi NavigationManager điều phối đóng Form.
    /// Giúp tuân thủ nguyên lý Open/Closed Principle (SOLID) và loại bỏ Tight Coupling.
    /// </summary>
    public interface INavigatableForm
    {
        /// <summary>
        /// Chuẩn bị đóng Form từ NavigationManager (ngắt xử lý đệ quy OnFormClosing, dọn tài nguyên)
        /// </summary>
        void PrepareForClose();
    }
}
