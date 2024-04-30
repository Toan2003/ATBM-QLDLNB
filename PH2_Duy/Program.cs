using ATBM_PH2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
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
            Application.Run(new LoginForm());
        }
    }
    public static class AppConfig
    {
        // Chuỗi kết nối mặc định
        public static string connectionString = "User Id=default;Password=default;Data Source=localhost:1521/PDBQLDLNB;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;";
        // Tên người dùng hiện tại
        public static string CurrentUsername { get; set; }

        // Mật khẩu của người dùng hiện tại
        public static string CurrentPassword { get; set; }

        // Mảng chứa các vai trò của người dùng
        public static string[] UserRoles { get; set; }

        public static void LogOut()
        {
            CurrentUsername = "";
            CurrentPassword = "";
            connectionString = "User Id=default;Password=default;Data Source=localhost:1521/PDBQLDLNB;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;";
        }
    }
}

