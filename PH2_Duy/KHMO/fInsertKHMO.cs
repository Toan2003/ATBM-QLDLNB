using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fInsertKHMO : Form
    {
        public fInsertKHMO()
        {
            InitializeComponent();
            LoadMAHPComboBox();
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
            // Thực hiện thêm KHMO vào cơ sở dữ liệu
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("INSERT INTO ADMIN.KHMO VALUES (:MAHP, :HK, :NAM, :MACT)", connection);
                command.Parameters.Add("MAHP", OracleDbType.Char).Value = cbMAHP.Text;
                command.Parameters.Add("HK", OracleDbType.Char).Value = cbHK.Text;
                command.Parameters.Add("NAM", OracleDbType.Char).Value = txtNAM.Text;
                command.Parameters.Add("MACT", OracleDbType.Char).Value = cbMACT.Text;
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm kế hoạch thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm kế hoạch thất bại");
                }
            }
        }
    }
}
