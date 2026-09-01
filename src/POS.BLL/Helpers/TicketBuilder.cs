using System;
using System.IO;
using System.Text;

namespace POS.BLL.Helpers
{
    /// <summary>
    /// Builder Pattern (Fluent API) để trừu tượng hóa và dựng chuỗi lệnh in ESC/POS
    /// </summary>
    public class TicketBuilder : IDisposable
    {
        private readonly MemoryStream _ms;
        private readonly BinaryWriter _bw;
        private readonly int _maxChars; // Khổ K80 thường là 48 ký tự, K57 là 32 ký tự

        public TicketBuilder(int maxChars = 48)
        {
            _maxChars = maxChars;
            _ms = new MemoryStream();
            _bw = new BinaryWriter(_ms);
            Initialize();
        }

        public TicketBuilder Initialize()
        {
            _bw.Write((byte)27);
            _bw.Write((byte)64); // ESC @ - Khởi tạo lại máy in
            return this;
        }

        public TicketBuilder AlignCenter()
        {
            _bw.Write((byte)27);
            _bw.Write((byte)97);
            _bw.Write((byte)1); // ESC a 1
            return this;
        }

        public TicketBuilder AlignLeft()
        {
            _bw.Write((byte)27);
            _bw.Write((byte)97);
            _bw.Write((byte)0); // ESC a 0
            return this;
        }

        public TicketBuilder AlignRight()
        {
            _bw.Write((byte)27);
            _bw.Write((byte)97);
            _bw.Write((byte)2); // ESC a 2
            return this;
        }

        public TicketBuilder SetTextSize(bool doubleWidth, bool doubleHeight)
        {
            byte size = 0;
            if (doubleWidth) size |= 0x10;  // Phóng to chiều ngang
            if (doubleHeight) size |= 0x01; // Phóng to chiều dọc
            _bw.Write((byte)29);
            _bw.Write((byte)33);
            _bw.Write(size); // GS !
            return this;
        }

        public TicketBuilder SetBold(bool isBold)
        {
            _bw.Write((byte)27);
            _bw.Write((byte)69);
            _bw.Write((byte)(isBold ? 1 : 0)); // ESC E
            return this;
        }

        public TicketBuilder PrintLine(string text = "")
        {
            if (!string.IsNullOrEmpty(text))
            {
                _bw.Write(Encoding.ASCII.GetBytes(ConvertToUnsign(text)));
            }
            _bw.Write((byte)10); // Ký tự xuống dòng LF
            return this;
        }

        public TicketBuilder PrintSeparator(char ch = '-')
        {
            PrintLine(new string(ch, _maxChars));
            return this;
        }

        /// <summary>
        /// Tạo dòng dữ liệu 2 cột căn sát về 2 biên (Ví dụ: Tổng tiền: .......... 50.000d)
        /// </summary>
        public TicketBuilder PrintRow(string leftText, string rightText)
        {
            string left = ConvertToUnsign(leftText);
            string right = ConvertToUnsign(rightText);

            int spaces = _maxChars - (left.Length + right.Length);
            if (spaces < 1) spaces = 1; // Đảm bảo luôn có ít nhất 1 dấu cách giữa 2 cột

            PrintLine(left + new string(' ', spaces) + right);
            return this;
        }

        /// <summary>
        /// Tạo dòng 3 cột định dạng cố định (Ví dụ: Tên món | SL | Thành tiền)
        /// </summary>
        public TicketBuilder Print3Columns(string col1, int w1, string col2, int w2, string col3, int w3)
        {
            string c1 = ConvertToUnsign(col1);
            if (c1.Length > w1) c1 = c1.Substring(0, w1 - 2) + "..";

            string c2 = ConvertToUnsign(col2);
            string c3 = ConvertToUnsign(col3);

            string line = string.Format("{0,-" + w1 + "} {1," + w2 + "} {2," + w3 + "}", c1, c2, c3);
            PrintLine(line);
            return this;
        }

        /// <summary>
        /// Đẩy thêm dòng trắng và gửi mã cắt giấy tự động (GS V 66 0)
        /// </summary>
        public TicketBuilder CutPaper(int feedLines = 3)
        {
            for (int i = 0; i < feedLines; i++)
            {
                PrintLine();
            }
            _bw.Write((byte)29);
            _bw.Write((byte)86);
            _bw.Write((byte)66);
            _bw.Write((byte)0); // GS V 66 0
            return this;
        }

        /// <summary>
        /// Gửi xung mở két tiền thu ngân qua cổng RJ11 (ESC p 0 25 250)
        /// </summary>
        public TicketBuilder OpenDrawer()
        {
            _bw.Write((byte)27);
            _bw.Write((byte)112);
            _bw.Write((byte)0);
            _bw.Write((byte)25);
            _bw.Write((byte)250);
            return this;
        }

        public byte[] Build()
        {
            _bw.Flush();
            return _ms.ToArray();
        }

        /// <summary>
        /// Chuyển đổi chuỗi tiếng Việt có dấu sang không dấu chuẩn Unicode
        /// </summary>
        public static string ConvertToUnsign(string text)
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

        public void Dispose()
        {
            _bw?.Dispose();
            _ms?.Dispose();
        }
    }
}
