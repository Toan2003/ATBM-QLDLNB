using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fInsertDept : Form
    {
        public fInsertDept()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Thực hiện thêm đơn vị vào cơ sở dữ liệu
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                connection.Open();
                OracleCommand command = new OracleCommand("INSERT INTO ADMIN.DONVI VALUES (:MADV, :TENDV, :TRGDV)", connection);
                command.Parameters.Add("MADV", OracleDbType.Char).Value = txtMADV.Text;
                command.Parameters.Add("TENDV", OracleDbType.NVarchar2).Value = txtTENDV.Text;
                command.Parameters.Add("TRGDV", OracleDbType.Char).Value = txtTRGDV.Text;
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm đơn vị thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm đơn vị thất bại");
                }
            }
        }
    }
}
