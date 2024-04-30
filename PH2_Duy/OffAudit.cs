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
    public partial class OffAudit : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        String name, sel, ins, upd, del;

        private void button3_Click(object sender, EventArgs e)
        {
            clickBtn("UPDATE", "WHENEVER SUCCESSFUL");
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clickBtn("INSERT", "WHENEVER SUCCESSFUL");
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clickBtn("SELECT", "WHENEVER NOT SUCCESSFUL");
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clickBtn("DELETE", "WHENEVER NOT SUCCESSFUL");
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clickBtn("UPDATE", "WHENEVER NOT SUCCESSFUL");
            button7.Enabled = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            clickBtn("INSERT", "WHENEVER NOT SUCCESSFUL");
            button8.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clickBtn("DELETE", "WHENEVER SUCCESSFUL"); 
            button2.Enabled = false;
        }

        public OffAudit(String name, String sel, String ins, String upd, String del)
        {
            InitializeComponent();
            this.name = name;
            this.sel = sel;
            this.ins = ins;
            this.upd = upd;
            this.del = del;
            label2.Text = name;

            string[] parts = sel.Split('/');
            if (parts[0]=="A")
                button1.Enabled = true;
            else button1.Enabled = false;
            if (parts[1]=="A")
                button5.Enabled = true;
            else button5.Enabled = false;

            parts = ins.Split('/');
            if (parts[0] == "A")
                button2.Enabled = true;
            else button2.Enabled = false;
            if (parts[1] == "A")
                button6.Enabled = true;
            else button6.Enabled = false;

            parts = upd.Split('/');
            if (parts[0] == "A")
                button3.Enabled = true;
            else button3.Enabled = false;
            if (parts[1] == "A")
                button7.Enabled = true;
            else button7.Enabled = false;

            parts = del.Split('/');
            if (parts[0] == "A")
                button4.Enabled = true;
            else button4.Enabled = false;
            if (parts[1] == "A")
                button8.Enabled = true;
            else button8.Enabled = false;

        }
        private void clickBtn(string action, string success)
        {
            string query = "NOAUDIT " + action + " ON ADMIN." + name + " "+ success;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    command.ExecuteNonQuery();

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
            clickBtn("SELECT", "WHENEVER SUCCESSFUL");
            button1.Enabled = false;
        }

    }
}
