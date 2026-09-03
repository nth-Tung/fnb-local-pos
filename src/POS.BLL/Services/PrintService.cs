using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
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
        private const string MicrosoftPrintToPdf = "Microsoft Print to PDF";
        public string TargetPrinterName { get; set; } = "Microsoft Print to PDF";
        private BaseInvoiceTemplate _invoiceTemplate;

        public PrintService() : this(null, null)
        {
        }

        public PrintService(string printerName) : this(printerName, null)
        {
        }

        public PrintService(string printerName, BaseInvoiceTemplate template)
        {
            TargetPrinterName = string.IsNullOrEmpty(printerName) ? "Microsoft Print to PDF" : printerName;
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

                if (IsMicrosoftPrintToPdf())
                {
                    return PrintToPdf(ticketBytes, orderNo);
                }

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

        private bool IsMicrosoftPrintToPdf()
        {
            return string.Equals(TargetPrinterName, MicrosoftPrintToPdf, StringComparison.OrdinalIgnoreCase);
        }

        private bool PrintToPdf(byte[] ticketBytes, string orderNo)
        {
            using (var printDocument = new PrintDocument())
            {
                printDocument.PrinterSettings.PrinterName = TargetPrinterName;
                if (!printDocument.PrinterSettings.IsValid)
                {
                    return false;
                }

                printDocument.DocumentName = "Hoa don " + (orderNo ?? string.Empty);
                // K80: 80 mm (315/100 inch), vùng in thực tế khoảng 72 mm.
                string invoiceText = ExtractPrintableText(ticketBytes);
                int lineCount = invoiceText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).Length;
                int paperHeight = Math.Max(560, 120 + (lineCount * 16));
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("K80", 315, paperHeight);
                printDocument.DefaultPageSettings.Margins = new Margins(15, 15, 15, 15);
                printDocument.PrintPage += (sender, args) =>
                {
                    DrawReceiptPage(args.Graphics, args.MarginBounds, invoiceText);
                };

                printDocument.Print();
                return true;
            }
        }

        private void DrawReceiptPage(Graphics graphics, Rectangle bounds, string invoiceText)
        {
            using (var font = new Font("Consolas", 7.5f, FontStyle.Regular))
            {
                float lineHeight = font.GetHeight(graphics);
                float y = bounds.Top;
                StringFormat format = new StringFormat { Alignment = StringAlignment.Near };
                string[] lines = invoiceText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                foreach (string line in lines)
                {
                    if (y + lineHeight > bounds.Bottom)
                    {
                        break;
                    }
                    graphics.DrawString(line, font, Brushes.Black, new RectangleF(bounds.Left, y, bounds.Width, lineHeight), format);
                    y += lineHeight;
                }
            }
        }

        private string ExtractPrintableText(byte[] ticketBytes)
        {
            var text = new StringBuilder();
            var line = new StringBuilder();
            int alignment = 0;

            for (int index = 0; index < ticketBytes.Length; index++)
            {
                byte value = ticketBytes[index];
                if (value == 10)
                {
                    string printableLine = line.ToString();
                    if (alignment == 1)
                    {
                        int leftPadding = Math.Max(0, (48 - printableLine.Length) / 2);
                        printableLine = new string(' ', leftPadding) + printableLine;
                    }
                    else if (alignment == 2)
                    {
                        printableLine = new string(' ', Math.Max(0, 48 - printableLine.Length)) + printableLine;
                    }

                    text.AppendLine(printableLine);
                    line.Clear();
                }
                else if (value == 27)
                {
                    if (index + 1 < ticketBytes.Length)
                    {
                        byte command = ticketBytes[++index];
                        if (command == 97 && index + 1 < ticketBytes.Length)
                        {
                            alignment = ticketBytes[++index];
                        }
                        else if (command == 69 && index + 1 < ticketBytes.Length)
                        {
                            index++;
                        }
                    }
                }
                else if (value == 29)
                {
                    if (index + 1 < ticketBytes.Length)
                    {
                        byte command = ticketBytes[++index];
                        if (command == 33 && index + 1 < ticketBytes.Length)
                        {
                            index++;
                        }
                        else if (command == 86)
                        {
                            index = Math.Min(index + 2, ticketBytes.Length - 1);
                        }
                    }
                }
                else if (value >= 32 && value <= 126)
                {
                    line.Append((char)value);
                }
            }

            return text.ToString().TrimEnd('\r', '\n');
        }
    }
}
