using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += LoginForm_FormClosing;
            this.KeyPreview = true;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            string tmp_conStr = $"User Id={username};Password={password};Data Source=localhost:1521/PDBQLDLNB;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;";

            if (!AuthenticateUser(tmp_conStr))
            {
                tmp_conStr = $"User Id={username};Password={password};Data Source=localhost:1521/XE;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\ASUS\\Oracle\\network\\admin;";
            }
            if (AuthenticateUser(tmp_conStr))
            {
                MessageBox.Show("Đăng nhập thành công!");

                // Lưu thông tin người dùng hiện tại vào cấu hình
                AppConfig.CurrentUsername = username;
                AppConfig.CurrentPassword = password;

                // Đọc và lưu các vai trò của người dùng
                List<string> userRoles = GetUserRoles(tmp_conStr);
                AppConfig.UserRoles = userRoles.ToArray();

                // Cập nhật chuỗi kết nối mặc định
                AppConfig.connectionString = tmp_conStr;

                ////Hiển thị các vai trò trong MessageBox
                //string rolesMessage = "Các vai trò của người dùng:\n";

                
                //foreach (string role in userRoles)
                //{
                //    rolesMessage += $"{role}\n";
                //}
                //string connName = getContainerName(tmp_conStr);

                //MessageBox.Show(rolesMessage);

                if (Array.Exists(AppConfig.UserRoles, role => role == "THONGBAO_POLICY_DBA"))
                {
                    this.Hide();
                    fNotification f = new fNotification(this);
                    f.ShowDialog();
                }
                else if (username.ToUpper() == "SYS")
                {
                    this.Hide();
                    AuditOnOff f = new AuditOnOff();
                    f.ShowDialog();
                }
                else if (Array.Exists(AppConfig.UserRoles, role => role == "ROLE_SV"))
                {
                    this.Hide();
                    DashBoardSV f = new DashBoardSV();
                    f.ShowDialog();
                }
                else
                {
                    this.Hide();
                    DashBoardNV f = new DashBoardNV();
                    f.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra tên đăng nhập và nhập khẩu !");
            }
        }

        private bool AuthenticateUser(string connectionString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Kết nối thành công, trả về true
                    return true;
                }
                catch (Exception ex)
                {
                    // Kết nối thất bại, trả về false và hiển thị thông báo lỗi
                    //MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private List<string> GetUserRoles(string connectionString)
        {
            List<string> roles = new List<string>();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT ROLE FROM SESSION_ROLES";
                    

                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            return roles;
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private string getContainerName(string connectionString)
        {
            string connName = null;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT SYS_CONTEXT('USERENV', 'CON_NAME') AS container_name FROM dual";

                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        connName = reader["container_name"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    //MessageBox.Show("Error: " + ex.Message);
                }
            }
            return connName;
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi sự kiện click của nút Login
                btnLogin_Click(sender, e);
            }
        }
    }
}
