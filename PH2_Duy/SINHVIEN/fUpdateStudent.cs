using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fUpdateStudent : Form
    {
        private string studentId;

        public fUpdateStudent(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadStudentInfo();
            txtMASV.ReadOnly = true;
            LoadMANGANHComboBox();
        }

        private void LoadStudentInfo()
        {
            // Lấy thông tin sinh viên từ cơ sở dữ liệu và hiển thị lên các textbox
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("SELECT * FROM ADMIN.SINHVIEN WHERE MASV = :studentId", connection);
                command.Parameters.Add("studentId", OracleDbType.Char).Value = studentId;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMASV.Text = reader["MASV"].ToString();
                        txtHOTEN.Text = reader["HOTEN"].ToString();
                        cbPHAI.Text = reader["PHAI"].ToString();
                        dateTimePickerNGSINH.Value = Convert.ToDateTime(reader["NGSINH"]);
                        txtDCHI.Text = reader["DCHI"].ToString();
                        txtDT.Text = reader["DT"].ToString();
                        cbMACT.Text = reader["MACT"].ToString();
                        cbMANGANH.Text = reader["MANGANH"].ToString();
                        txtSOTCTL.Text = reader["SOTCTL"].ToString();
                        txtDTBTL.Text = reader["DTBTL"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Sinh viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadMANGANHComboBox()
        {
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT MADV FROM ADMIN.DONVI";

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string MADV = reader["MADV"].ToString();
                                cbMANGANH.Items.Add(MADV);
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
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            // Thực hiện cập nhật thông tin sinh viên vào cơ sở dữ liệu
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("UPDATE ADMIN.SINHVIEN SET HOTEN = :HOTEN, PHAI = :PHAI, NGSINH = :NGSINH, DCHI = :DCHI, DT = :DT, MACT = :MACT, MANGANH = :MANGANH, SOTCTL = :SOTCTL, DTBTL = :DTBTL WHERE MASV = :MASV", connection);
                command.Parameters.Add("HOTEN", OracleDbType.NVarchar2).Value = txtHOTEN.Text;
                command.Parameters.Add("PHAI", OracleDbType.Char).Value = cbPHAI.SelectedItem.ToString();

                DateTime selectedDate = dateTimePickerNGSINH.Value;
                command.Parameters.Add("NGSINH", OracleDbType.Date).Value = selectedDate;

                command.Parameters.Add("DCHI", OracleDbType.NVarchar2).Value = txtDCHI.Text;
                command.Parameters.Add("DT", OracleDbType.Char).Value = txtDT.Text;
                command.Parameters.Add("MACT", OracleDbType.Char).Value = cbMACT.Text;
                command.Parameters.Add("MANGANH", OracleDbType.Char).Value = cbMANGANH.Text;
                command.Parameters.Add("SOTCTL", OracleDbType.Int32).Value = int.Parse(txtSOTCTL.Text);
                command.Parameters.Add("DTBTL", OracleDbType.Double).Value = double.Parse(txtDTBTL.Text);
                command.Parameters.Add("MASV", OracleDbType.Char).Value = txtMASV.Text;
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật sinh viên thất bại");
                }
            }
        }
    }
}
