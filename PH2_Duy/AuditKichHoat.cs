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
    public partial class AuditKichHoat : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        public AuditKichHoat()
        {
            InitializeComponent();
            LayDSAudit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LayDSAudit()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT OBJECT_NAME, SEL, INS, UPD, DEL FROM DBA_OBJ_AUDIT_OPTS WHERE OWNER ='ADMIN'";
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

        private void offBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy dòng đầu tiên được chọn
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy dữ liệu từ cột cụ thể, ví dụ cột 'Name'
                string name = selectedRow.Cells["OBJECT_NAME"].Value.ToString();
                string sel = selectedRow.Cells["SEL"].Value.ToString();
                string ins = selectedRow.Cells["INS"].Value.ToString();
                string upd = selectedRow.Cells["UPD"].Value.ToString();
                string del = selectedRow.Cells["Del"].Value.ToString();

                OffAudit form = new OffAudit(name, sel, ins, upd, del);
                form.ShowDialog();
                LayDSAudit();
            }
        }
    }
}
