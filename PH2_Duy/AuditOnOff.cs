using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class AuditOnOff : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        public AuditOnOff()
        {
            InitializeComponent();
            this.FormClosing += AuditOnOff_FormClosing;
        }

        private void AuditOnOff_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void auditOnBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "alter session set container=cdb$root";
                    OracleCommand command = new OracleCommand(query, connection);
                    int result = command.ExecuteNonQuery();

                    query = "ALTER SYSTEM SET audit_trail=db SCOPE=SPFILE";
                    OracleCommand command2 = new OracleCommand(query, connection); 
                    command2.ExecuteNonQuery();

                    query = "alter session set container = PDBQLDLNB";
                    OracleCommand command3 = new OracleCommand(query, connection);
                    command3.ExecuteNonQuery();

                    MessageBox.Show("Đã bật audit trên hệ thống");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void auditOffBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "alter session set container=cdb$root";
                    OracleCommand command = new OracleCommand(query, connection);
                    int result = command.ExecuteNonQuery();

                    query = "ALTER SYSTEM SET audit_trail=none SCOPE=SPFILE";
                    OracleCommand command2 = new OracleCommand(query, connection);
                    command2.ExecuteNonQuery();

                    query = "alter session set container = PDBQLDLNB";
                    OracleCommand command3 = new OracleCommand(query, connection);
                    command3.ExecuteNonQuery();

                    MessageBox.Show("Đã tắt audit trên hệ thống");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void auditCreateBtn_Click(object sender, EventArgs e)
        {
            ThemAudit form = new ThemAudit();
            form.ShowDialog();
        }

        private void xemAuditBtn_Click(object sender, EventArgs e)
        {
            ChiTietAudit form = new ChiTietAudit();
            form.ShowDialog();
        }
    }
}
