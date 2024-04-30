using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fInsertStudent : Form
    {
        public fInsertStudent()
        {
            InitializeComponent();
            GenerateNewMSSV();
            txtMASV.ReadOnly = true;
            LoadMANGANHComboBox();
            cbCoSo.SelectedItem = "";
            cbPHAI.SelectedItem = "";
            cbMANGANH.SelectedItem = "";
            cbMACT.SelectedItem = "";
        }

        // Phương thức để tạo MSSV mới
        private void GenerateNewMSSV()
        {
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        // Truy vấn để lấy MSSV lớn nhất hiện tại
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT MAX(MASV) FROM ADMIN.SINHVIEN";

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            // Nếu có MSSV lớn nhất, tăng số tiếp theo lên 1
                            string maxMSSV = result.ToString();
                            int nextNumber = int.Parse(maxMSSV.Substring(2)) + 1;
                            string newMSSV = "SV" + nextNumber.ToString("000000");

                            // Hiển thị MSSV mới lên TextBox
                            txtMASV.Text = newMSSV;
                        }
                        else
                        {
                            // Nếu không có MSSV nào trong cơ sở dữ liệu, sử dụng SV000001
                            txtMASV.Text = "SV000001";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand("INSERT INTO ADMIN.SINHVIEN VALUES (:MASV, :HOTEN, :PHAI, :NGSINH, :DCHI, :DT, :MACT, :MANGANH, :SOTCTL, :DTBTL, :COSO)", connection);
                    command.Parameters.Add("MASV", OracleDbType.Char).Value = txtMASV.Text;
                    command.Parameters.Add("HOTEN", OracleDbType.NVarchar2).Value = txtHOTEN.Text;
                    command.Parameters.Add("PHAI", OracleDbType.Char).Value = cbPHAI.SelectedItem.ToString();

                    DateTime selectedDate = dateTimePickerNGSINH.Value;
                    command.Parameters.Add("NGSINH", OracleDbType.Date).Value = selectedDate;

                    command.Parameters.Add("DCHI", OracleDbType.NVarchar2).Value = txtDCHI.Text;
                    command.Parameters.Add("DT", OracleDbType.Char).Value = txtDT.Text;
                    command.Parameters.Add("MACT", OracleDbType.Char).Value = cbMACT.SelectedItem.ToString();
                    command.Parameters.Add("MANGANH", OracleDbType.Char).Value = cbMANGANH.SelectedItem.ToString();
                    command.Parameters.Add("SOTCTL", OracleDbType.Int32).Value = int.Parse(txtSOTCTL.Text);
                    command.Parameters.Add("DTBTL", OracleDbType.Double).Value = double.Parse(txtDTBTL.Text);
                    command.Parameters.Add("COSO", OracleDbType.Char).Value = cbCoSo.SelectedItem.ToString(); ;
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm sinh viên thành công !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sinh viên thất bại, vui lòng kiểm tra lại !");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm sinh viên thất bại, vui lòng kiểm tra lại ");
            }
            // Thực hiện thêm sinh viên vào cơ sở dữ liệu
            
            
        }
    }
}
