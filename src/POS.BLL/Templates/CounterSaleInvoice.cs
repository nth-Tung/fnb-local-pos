using System;
using POS.BLL.DTOs;
using POS.BLL.Helpers;

namespace POS.BLL.Templates
{
    /// <summary>
    /// Mẫu hóa đơn cụ thể cho mô hình Quầy bán nhanh (Counter Service / Fast Food / Cafe)
    /// </summary>
    public class CounterSaleInvoice : BaseInvoiceTemplate
    {
        public string StoreName { get; set; } = "F&B LOCAL STORE";
        public string StoreAddress { get; set; } = "123 Duong ABC, Quan 1, TPHCM";
        public string StorePhone { get; set; } = "Hotline: 0123.456.789";
        public string WifiInfo { get; set; } = "Wifi: FNB_FreePass / Pass: 88888888";

        protected override void PrintHeader(TicketBuilder builder, string orderNo)
        {
            builder.AlignCenter()
                .SetTextSize(true, true) // Phóng to tiêu đề cửa hàng
                .SetBold(true)
                .PrintLine(StoreName)
                .SetTextSize(false, false) // Về cỡ chữ bình thường
                .SetBold(false)
                .PrintLine(StoreAddress)
                .PrintLine(StorePhone)
                .PrintLine()
                .SetBold(true)
                .PrintLine("HOA DON BAN HANG")
                .SetBold(false)
                .PrintLine($"So HD: {orderNo}")
                .PrintSeparator();
        }

        protected override void PrintFooter(TicketBuilder builder, OrderSummaryDto summary)
        {
            builder.AlignLeft()
                .PrintRow("Tong tien hang:", $"{summary.RawTotal:N0}d");

            if (summary.DiscountAmount > 0)
            {
                builder.PrintRow("Giam gia / Chiet khau:", $"-{summary.DiscountAmount:N0}d");
            }

            builder.PrintSeparator('.');

            // Khối tổng thanh toán in đậm cỡ lớn nổi bật
            builder.SetTextSize(true, false)
                .SetBold(true)
                .PrintRow("TONG CONG:", $"{summary.FinalTotal:N0}d")
                .SetTextSize(false, false)
                .SetBold(false)
                .PrintSeparator();

            builder.AlignCenter()
                .PrintLine("CAM ON QUY KHACH & HEN GAP LAI!")
                .PrintLine(WifiInfo);
        }
    }
}
