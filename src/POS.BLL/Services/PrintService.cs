using System;
using System.Collections.Generic;
using POS.BLL.DTOs;
using POS.BLL.Helpers;
using POS.BLL.Templates;
using POS.DAL.Helpers;

namespace POS.BLL.Services
{
    /// <summary>
    /// Service quản lý giao tiếp in ấn và điều phối mẫu in hóa đơn
    /// </summary>
    public class PrintService
    {
        public string TargetPrinterName { get; set; } = "POS-80C";
        private BaseInvoiceTemplate _invoiceTemplate;

        public PrintService()
        {
            TargetPrinterName = "POS-80C";
            _invoiceTemplate = new CounterSaleInvoice();
        }

        public PrintService(string printerName)
        {
            TargetPrinterName = string.IsNullOrEmpty(printerName) ? "POS-80C" : printerName;
            _invoiceTemplate = new CounterSaleInvoice();
        }

        public PrintService(string printerName, BaseInvoiceTemplate template)
        {
            TargetPrinterName = string.IsNullOrEmpty(printerName) ? "POS-80C" : printerName;
            _invoiceTemplate = template ?? new CounterSaleInvoice();
        }

        /// <summary>
        /// Thay đổi mẫu in linh hoạt (Strategy / Template Swap)
        /// </summary>
        public void SetTemplate(BaseInvoiceTemplate template)
        {
            if (template != null)
            {
                _invoiceTemplate = template;
            }
        }

        /// <summary>
        /// In hóa đơn bán hàng sử dụng Template Method Pattern & Builder Pattern
        /// </summary>
        public bool PrintOrderInvoice(string orderNo, string cashier, string paymentMethod, List<CartItemDto> items, OrderSummaryDto summary)
        {
            if (items == null || items.Count == 0 || summary == null)
            {
                return false;
            }

            try
            {
                // 1. Dựng mảng byte ESC/POS theo mẫu thiết kế
                byte[] ticketBytes = _invoiceTemplate.GenerateInvoiceBytes(orderNo, cashier, paymentMethod, items, summary);

                // 2. Gửi luồng byte RAW trực tiếp xuống máy in qua winspool.Drv
                return RawPrinterHelper.SendBytesToPrinter(TargetPrinterName, ticketBytes);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kích xung mở két tiền thu ngân qua cổng RJ11 máy in nhiệt (ESC p 0 25 250)
        /// </summary>
        public bool OpenCashDrawer()
        {
            try
            {
                using (var builder = new TicketBuilder())
                {
                    byte[] drawerBytes = builder.OpenDrawer().Build();
                    return RawPrinterHelper.SendBytesToPrinter(TargetPrinterName, drawerBytes);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
