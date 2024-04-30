using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fUpdateKHMO : Form
    {
        private string MAHP;
        private string HK;
        private string NAM;
        private string MACT;

        public fUpdateKHMO(string MAHP, string HK, string NAM, string MACT)
        {
            InitializeComponent();
            this.MAHP = MAHP;
            this.HK = HK;
            this.NAM = NAM;
            this.MACT = MACT;
            LoadKHMOInfo();
            LoadMAHPComboBox();
        }

        private void LoadKHMOInfo()
        {
            // Lấy thông tin KHMO từ cơ sở dữ liệu và hiển thị lên các textbox
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("SELECT * FROM ADMIN.KHMO WHERE MAHP = :MAHP AND HK = :HK AND NAM = :NAM AND MACT = :MACT", connection);
                command.Parameters.Add("MAHP", OracleDbType.Char).Value = MAHP;
                command.Parameters.Add("HK", OracleDbType.Char).Value = HK;
                command.Parameters.Add("NAM", OracleDbType.Char).Value = NAM;
                command.Parameters.Add("MACT", OracleDbType.Char).Value = MACT;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cbMAHP.Text = reader["MAHP"].ToString();
                        cbHK.Text = reader["HK"].ToString();
                        txtNAM.Text = reader["NAM"].ToString();
                        cbMACT.Text = reader["MACT"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Kế hoạch không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadMAHPComboBox()
        {
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT MAHP FROM ADMIN.HOCPHAN";

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string MADV = reader["MAHP"].ToString();
                                cbMAHP.Items.Add(MADV);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Thực hiện cập nhật thông tin KHMO vào cơ sở dữ liệu
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("UPDATE ADMIN.KHMO SET MAHP = :MAHP AND HK = :HK AND NAM = :NAM AND MACT = :MACT", connection);
                command.Parameters.Add("MAHP", OracleDbType.Char).Value = cbMAHP.Text;
                command.Parameters.Add("HK", OracleDbType.Char).Value = cbHK.Text;
                command.Parameters.Add("NAM", OracleDbType.Char).Value = txtNAM.Text;
                command.Parameters.Add("MACT", OracleDbType.Char).Value = cbMACT.Text;
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật kế hoạch thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật kế hoạch thất bại");
                }
            }
        }
    }
}
