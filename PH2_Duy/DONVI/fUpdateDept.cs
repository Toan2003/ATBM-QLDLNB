using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fUpdateDept : Form
    {
        private string deptId;

        public fUpdateDept(string deptId)
        {
            InitializeComponent();
            this.deptId = deptId;
            LoadDeptInfo();
            txtMADV.ReadOnly = true;
        }

        private void LoadDeptInfo()
        {
            // Lấy thông tin đơn vị từ cơ sở dữ liệu và hiển thị lên các textbox
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("SELECT * FROM ADMIN.DONVI WHERE MADV = :deptId", connection);
                command.Parameters.Add("deptId", OracleDbType.Char).Value = deptId;
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMADV.Text = reader["MADV"].ToString();
                        txtTENDV.Text = reader["TENDV"].ToString();
                        txtTRGDV.Text = reader["TRGDV"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Đơn vị không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Thực hiện cập nhật thông tin sinh viên vào cơ sở dữ liệu
            try
            {
                using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand("UPDATE ADMIN.DONVI SET TENDV = :TENDV, TRGDV = :TRGDV WHERE MADV = :MADV", connection);
                    command.Parameters.Add("TENDV", OracleDbType.NVarchar2).Value = txtTENDV.Text;
                    command.Parameters.Add("TRGDV", OracleDbType.Char).Value = txtTRGDV.Text;
                    command.Parameters.Add("MADV", OracleDbType.Char).Value = txtMADV.Text;

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật đơn vị thành công !");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đơn vị thất bại");
                    }
                }
            } catch
            {
                MessageBox.Show("Cập nhật đơn vị thất bại");
            }
            
        }
    }
}
