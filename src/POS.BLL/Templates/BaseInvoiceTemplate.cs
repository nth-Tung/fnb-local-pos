using System;
using System.Collections.Generic;
using POS.BLL.DTOs;
using POS.BLL.Helpers;

namespace POS.BLL.Templates
{
    /// <summary>
    /// Template Method Pattern: Quản lý cấu trúc khung sườn cố định của mẫu hóa đơn
    /// </summary>
    public abstract class BaseInvoiceTemplate
    {
        public int MaxChars { get; set; } = 48; // Chuẩn K80 = 48 ký tự, K57 = 32 ký tự

        /// <summary>
        /// Thuật toán khung sườn in hóa đơn (Template Method)
        /// </summary>
        public byte[] GenerateInvoiceBytes(string orderNo, string cashier, string paymentMethod, List<CartItemDto> items, OrderSummaryDto summary)
        {
            using (var builder = new TicketBuilder(MaxChars))
            {
                // 1. In tiêu đề hóa đơn (Tên quán, địa chỉ, số HĐ)
                PrintHeader(builder, orderNo);

                // 2. In thông tin phụ (Thu ngân, ngày giờ, phương thức thanh toán)
                PrintMetaInfo(builder, cashier, paymentMethod);

                // 3. In chi tiết danh sách món ăn
                PrintInvoiceBody(builder, items);

                // 4. In tổng kết chi phí & chân trang (Lời chào, wifi)
                PrintFooter(builder, summary);

                // 5. Cắt giấy và xuất mảng byte
                return builder.CutPaper().Build();
            }
        }

        /// <summary>
        /// In thông tin bổ trợ (Có thể ghi đè nếu cần)
        /// </summary>
        protected virtual void PrintMetaInfo(TicketBuilder builder, string cashier, string paymentMethod)
        {
            builder.AlignLeft()
                .PrintLine($"Thu ngan:  {cashier}")
                .PrintLine($"Ngay gio:  {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                .PrintLine($"Hinh thuc: {paymentMethod}")
                .PrintSeparator();
        }

        /// <summary>
        /// In phần thân danh sách món ăn (Có thể ghi đè nếu muốn thay đổi layout cột)
        /// </summary>
        protected virtual void PrintInvoiceBody(TicketBuilder builder, List<CartItemDto> items)
        {
            builder.AlignLeft()
                .Print3Columns("Ten mon", 24, "SL", 4, "Thanh tien", 16)
                .PrintSeparator();

            if (items != null)
            {
                foreach (var item in items)
                {
                    builder.Print3Columns(item.ProductName, 24, item.Quantity.ToString(), 4, $"{item.LineTotal:N0}d", 16);

                    if (!string.IsNullOrEmpty(item.Note))
                    {
                        builder.PrintLine($"   * {item.Note}");
                    }
                }
            }

            builder.PrintSeparator();
        }

        /// <summary>
        /// Lớp con bắt buộc định nghĩa phần Đầu hóa đơn
        /// </summary>
        protected abstract void PrintHeader(TicketBuilder builder, string orderNo);

        /// <summary>
        /// Lớp con bắt buộc định nghĩa phần Chân hóa đơn & Tổng tiền
        /// </summary>
        protected abstract void PrintFooter(TicketBuilder builder, OrderSummaryDto summary);
    }
}
