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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ATBM_PH2
{
    public partial class AuditDangKy : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        public AuditDangKy()
        {
            InitializeComponent();
            LayKq();

        }

        private void AuditDangKy_Load(object sender, EventArgs e)
        {

        }
        
        private void LayKq()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * FROM DBA_FGA_AUDIT_TRAIL WHERE policy_name ='FGA_1'";


                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    // Hiển thị dữ liệu lên DataGridView

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string plsql = @"
                            BEGIN
                                DBMS_FGA.DISABLE_POLICY(
                                    object_schema   => 'ADMIN',
                                    object_name     => 'DANGKY',
                                    policy_name     => 'FGA_1'
                                );
                            END;";

                    using (OracleCommand command = new OracleCommand(plsql, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        // Thực thi câu lệnh
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Tắt Audit thành công !");

                }
                catch
                {
                    MessageBox.Show("Tắt Audit không thành công !");
                }
            }
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string plsql = @"
                            BEGIN
                                DBMS_FGA.ENABLE_POLICY(
                                    object_schema   => 'ADMIN',
                                    object_name     => 'DANGKY',
                                    policy_name     => 'FGA_1'
                                );
                            END;";

                    using (OracleCommand command = new OracleCommand(plsql, connection))
                    {
                        command.CommandType = System.Data.CommandType.Text;

                        // Thực thi câu lệnh
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bắt Audit thành công !");


                }
                catch
                {
                    MessageBox.Show("Bắt Audit không thành công !");
                }
            }
        }

    }
}
