using QLCafe.Presentation.Views.Auth;
using QLCafe.Presentation.Views.Cashier;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace QLCafe.Presentation
{
    internal static class Program
    {
        public static string ConnectionString { get; private set; }

        [STAThread]
        static void Main()
        {
            // Lấy connection string từ App.config
            ConnectionString = ConfigurationManager.ConnectionStrings["QLCafeConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Không tìm thấy connection string trong App.config");
                return;
            }

            // THÊM System.Windows.Forms. để tránh conflict
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginView());
        }
    }
}