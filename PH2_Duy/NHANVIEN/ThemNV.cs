using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class ThemNV : Form
    {
        private string connectionString = AppConfig.connectionString;
        public ThemNV()
        {
            InitializeComponent();
            GenerateNewMSNV();
            manv.ReadOnly = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void GenerateNewMSNV()
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
                        command.CommandText = "SELECT MAX(MANV) FROM ADMIN.NHANSU WHERE MANV LIKE 'NV%'";

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            // Nếu có MSSV lớn nhất, tăng số tiếp theo lên 1
                            string maxMSNV = result.ToString();
                            int nextNumber = int.Parse(maxMSNV.Substring(2)) + 1;
                            string newMSNV = "NV" + nextNumber.ToString("0000");

                            // Hiển thị MSSV mới lên TextBox
                            manv.Text = newMSNV;
                        }
                        else
                        {
                            // Nếu không có MSSV nào trong cơ sở dữ liệu, sử dụng SV000001
                            manv.Text = "NV0001";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ThemNV_Load(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            String manvText = manv.Text;
            String ten = hoten.Text;
            String phaiText = phai.SelectedItem.ToString();
            DateTime ngsinh = dateTimePicker1.Value;
            String phucap = textBox1.Text;
            String dt = textBox3.Text;
            String vt = vaitro.SelectedItem.ToString();
            String mdv = madv.SelectedItem.ToString();
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO ADMIN.NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DT,VAITRO, MADV) VALUES (:MANV, :HOTEN, :PHAI, :NGSINH, :PHUCAP, :DT, :VAITRO, :MADV)";
                    OracleCommand command = new OracleCommand(query, connection);

                    // Thêm các parameter cho lệnh INSERT
                    command.Parameters.Add("MANV", OracleDbType.Char).Value = manvText;
                    command.Parameters.Add("HOTEN", OracleDbType.NVarchar2).Value = ten;
                    command.Parameters.Add("PHAI", OracleDbType.NChar).Value = phaiText;
                    command.Parameters.Add("NGSINH", OracleDbType.Date).Value = ngsinh;
                    command.Parameters.Add("PHUCAP", OracleDbType.Long).Value = phucap;
                    command.Parameters.Add("DT", OracleDbType.Char).Value = dt;
                    command.Parameters.Add("VAITRO", OracleDbType.NVarchar2).Value = vt;
                    command.Parameters.Add("MADV", OracleDbType.Char).Value = mdv;


                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm nhân sự thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân sự thất bại !");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm nhân sự thất bại !");
            }


        }
    }
}
