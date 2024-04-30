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
    public partial class ChiTietAudit : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        public ChiTietAudit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuditKichHoat form = new AuditKichHoat();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KetQuaAudit form = new KetQuaAudit();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AuditDangKy form = new AuditDangKy();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AuditNhanSu form = new AuditNhanSu();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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
                                    object_name     => 'NHANSU',
                                    policy_name     => 'audit_salary_selects'
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

        private void ChiTietAudit_Load(object sender, EventArgs e)
        {

        }
    }
}
