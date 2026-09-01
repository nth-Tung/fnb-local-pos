using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using POS.BLL.DTOs;
using POS.DAL.Helpers;

namespace POS.BLL.Services
{
    public class PrintService
    {
        // Tên driver máy in cài trên Windows (ví dụ: "POS-80C", "Xprinter XP-N160I" hoặc "PRP-085")
        public string TargetPrinterName { get; set; } = "POS-80C";

        public PrintService()
        {
            TargetPrinterName = "POS-80C";
        }

        public PrintService(string printerName)
        {
            TargetPrinterName = string.IsNullOrEmpty(printerName) ? "POS-80C" : printerName;
        }

        public bool PrintOrderInvoice(string orderNo, string cashier, string paymentMethod, List<CartItemDto> items, decimal rawTotal, decimal discount, decimal finalTotal)
        {
            if (items == null || items.Count == 0)
            {
                return false;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    // 1. Khởi tạo máy in (ESC @)
                    bw.Write((byte)27); bw.Write((byte)64);

                    // 2. Tiêu đề cửa hàng
                    // Căn giữa (ESC a 1) + Chữ to tiêu đề (GS ! 16)
                    bw.Write((byte)27); bw.Write((byte)97); bw.Write((byte)1);
                    bw.Write((byte)29); bw.Write((byte)33); bw.Write((byte)16);
                    bw.Write(Encoding.ASCII.GetBytes("F&B LOCAL STORE\n"));

                    // Chữ thường (GS ! 0)
                    bw.Write((byte)29); bw.Write((byte)33); bw.Write((byte)0);
                    bw.Write(Encoding.ASCII.GetBytes("CHAO MUNG QUY KHACH\n"));
                    bw.Write(Encoding.ASCII.GetBytes("================================================\n"));

                    // 3. Thông tin hóa đơn (Căn trái ESC a 0)
                    bw.Write((byte)27); bw.Write((byte)97); bw.Write((byte)0);
                    bw.Write(Encoding.ASCII.GetBytes($"Ma HD:    {orderNo}\n"));
                    bw.Write(Encoding.ASCII.GetBytes($"Ngay gio: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n"));
                    bw.Write(Encoding.ASCII.GetBytes($"Thu ngan: {ConvertToUnsign(cashier)}\n"));
                    bw.Write(Encoding.ASCII.GetBytes($"Hinh thuc:{ConvertToUnsign(paymentMethod)}\n"));
                    bw.Write(Encoding.ASCII.GetBytes("------------------------------------------------\n"));

                    // 4. Danh sách món ăn (Khổ K80 rộng 48 ký tự: Tên 26 | SL 4 | Đơn giá/Thành tiền 16)
                    bw.Write(Encoding.ASCII.GetBytes(string.Format("{0,-24} {1,4} {2,16}\n", "Ten mon", "SL", "Thanh tien")));
                    bw.Write(Encoding.ASCII.GetBytes("------------------------------------------------\n"));

                    foreach (var item in items)
                    {
                        string name = ConvertToUnsign(item.ProductName);
                        if (name.Length > 24) name = name.Substring(0, 22) + "..";

                        string line = string.Format("{0,-24} {1,4} {2,15:N0}d\n", name, item.Quantity, item.LineTotal);
                        bw.Write(Encoding.ASCII.GetBytes(line));

                        if (!string.IsNullOrEmpty(item.Note))
                        {
                            bw.Write(Encoding.ASCII.GetBytes($"   * {ConvertToUnsign(item.Note)}\n"));
                        }
                    }
                    bw.Write(Encoding.ASCII.GetBytes("------------------------------------------------\n"));

                    // 5. Tổng tiền thanh toán
                    bw.Write(Encoding.ASCII.GetBytes(string.Format("{0,-30} {1,16:N0}d\n", "Tong tien hang:", rawTotal)));
                    if (discount > 0)
                    {
                        bw.Write(Encoding.ASCII.GetBytes(string.Format("{0,-30} {1,16:N0}d\n", "Giam gia / Chiet khau:", -discount)));
                    }

                    // In đậm tổng tiền cuối cùng (ESC E 1) + Chữ cỡ lớn gấp đôi (GS ! 17)
                    bw.Write((byte)27); bw.Write((byte)69); bw.Write((byte)1);
                    bw.Write((byte)29); bw.Write((byte)33); bw.Write((byte)17);
                    bw.Write(Encoding.ASCII.GetBytes(string.Format("{0,-12} {1,11:N0}d\n", "TONG CONG:", finalTotal)));

                    // Tắt in đậm, tắt chữ to
                    bw.Write((byte)27); bw.Write((byte)69); bw.Write((byte)0);
                    bw.Write((byte)29); bw.Write((byte)33); bw.Write((byte)0);
                    bw.Write(Encoding.ASCII.GetBytes("================================================\n"));

                    // 6. Lời chào kết đơn (Căn giữa ESC a 1)
                    bw.Write((byte)27); bw.Write((byte)97); bw.Write((byte)1);
                    bw.Write(Encoding.ASCII.GetBytes("CAM ON QUY KHACH & HEN GAP LAI!\n"));
                    bw.Write(Encoding.ASCII.GetBytes("Wifi: FNB_FreePass / Pass: 88888888\n\n\n\n"));

                    // 7. Lệnh cắt giấy tự động (GS V 66 0)
                    bw.Write((byte)29); bw.Write((byte)86); bw.Write((byte)66); bw.Write((byte)0);

                    bw.Flush();
                    return RawPrinterHelper.SendBytesToPrinter(TargetPrinterName, ms.ToArray());
                }
            }
            catch
            {
                return false;
            }
        }

        // Mở két tiền thu ngân tự động (ESC p m t1 t2 - Kick drawer pulse)
        public bool OpenCashDrawer()
        {
            try
            {
                byte[] drawerBytes = new byte[] { 27, 112, 0, 25, 250 };
                return RawPrinterHelper.SendBytesToPrinter(TargetPrinterName, drawerBytes);
            }
            catch
            {
                return false;
            }
        }

        // Hàm loại bỏ dấu tiếng Việt chuẩn Unicode phục vụ máy in nhiệt nội bộ
        public string ConvertToUnsign(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;

            string normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString()
                .Normalize(NormalizationForm.FormC)
                .Replace('đ', 'd')
                .Replace('Đ', 'D');
        }
    }
}
