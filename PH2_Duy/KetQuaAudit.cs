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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ATBM_PH2
{
    public partial class KetQuaAudit : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        public KetQuaAudit()
        {
            InitializeComponent();
            LayDSUserName();
            LayDSObject();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * FROM DBA_AUDIT_TRAIL";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView) comboBox1.SelectedItem;

            String username = selectedRow["MANV"].ToString();


            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * FROM DBA_AUDIT_TRAIL WHERE USERNAME ='"+username+"'";
                    if (radioSuccess.Checked)
                        query = query + " and  RETURNCODE=0";
                    else if (radioNSuccess.Checked)
                        query = query + " and  RETURNCODE !=0";
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
        private void LayDSUserName()
        {
            //String username = comboBox1.SelectedItem.ToString();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "select manv from ADMIN.nhansu UNION all SELECT MASV FROM ADMIN.SINHVIEN";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView
                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "MANV"; // Tên cột muốn hiển thị trong ComboBox
                    comboBox1.ValueMember = "MANV";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LayDSObject()
        {
            //String username = comboBox1.SelectedItem.ToString();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT TABLE_NAME FROM ALL_TABLES WHERE OWNER = 'ADMIN'";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView
                    comboBox2.DataSource = dataTable;
                    comboBox2.DisplayMember = "TABLE_NAME"; // Tên cột muốn hiển thị trong ComboBox
                    comboBox2.ValueMember = "TABLE_NAME";


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //String object_name = comboBox2.SelectedItem.ToString();
            DataRowView selectedRow = (DataRowView)comboBox2.SelectedItem;

            String object_name = selectedRow["TABLE_NAME"].ToString();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * FROM DBA_AUDIT_TRAIL WHERE OBJ_NAME ='" + object_name + "'";
                    if (radioSuccess.Checked)
                        query = query + " and RETURNCODE=0";
                    else if (radioNSuccess.Checked)
                        query = query + " and RETURNCODE !=0";
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

        private void KetQuaAudit_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            radioSuccess.Checked = false;
            radioNSuccess.Checked = false;
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            dataGridView1.DataSource = null;

        }

    }
}
