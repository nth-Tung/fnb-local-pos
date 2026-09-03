using System;
using System.Windows.Forms;
using POS.DAL;
using POS.UI.Navigation;

namespace POS.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Khởi tạo cơ sở dữ liệu SQLite và nạp dữ liệu mẫu ban đầu
                DatabaseInitializer.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo CSDL SQLite: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new PosApplicationContext());
        }
    }
}
