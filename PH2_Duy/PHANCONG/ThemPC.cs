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
    public partial class ThemPC : Form
    {
        private string connectionString = AppConfig.connectionString;
        String maGV, maHP, hk, maCT;
        int nam;
        public ThemPC()
        {
            InitializeComponent();

            
            LayDSGV();
            LayDSMAHP();
            

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ADMIN.PHANCONG (MAGV, MAHP, HK, NAM, MACT) " +
                                    "VALUES (:MAGV, :MAHP, :HK, :NAM, :MACT) ";
                                   
                    OracleCommand command = new OracleCommand(query, connection);

                    DataRowView selectedRow = (DataRowView)magvCB.SelectedItem;
                    String magvnew = selectedRow["MANV"].ToString();

                    selectedRow = (DataRowView)mahpCB.SelectedItem;
                    String mahpnew = selectedRow["MAHP"].ToString();
                    int hknew = int.Parse(hkCB.SelectedItem.ToString());
                    int namnew = (int)namNum.Value;
                    String mactnew = mactCB.SelectedItem.ToString();
                    //MessageBox.Show(magvnew + " " + magvnew.Length);

                    command.Parameters.Add("MAGV", OracleDbType.Char).Value = magvnew;
                    command.Parameters.Add("MAHP", OracleDbType.Char).Value = mahpnew;
                    command.Parameters.Add("HK", OracleDbType.Int64).Value = hknew;
                    command.Parameters.Add("NAM", OracleDbType.Int64).Value = namnew;
                    command.Parameters.Add("MACT", OracleDbType.Char).Value = mactnew;

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Đã cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không có học phần được cập nhật");
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ThemPC_Load(object sender, EventArgs e)
        {

        }

        private void magvCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LayDSGV()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    // Create command for calling the stored procedure
                    OracleCommand command = new OracleCommand("ADMIN.SP_GetEmpID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add output parameter for the cursor
                    command.Parameters.Add("empID", OracleDbType.RefCursor, ParameterDirection.Output);

                    // Execute the command
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView
                    DataRow newRow = dataTable.NewRow();
                    newRow["MANV"] = "";
                    dataTable.Rows.InsertAt(newRow, 0);

                    magvCB.DataSource = dataTable;
                    
                    magvCB.DisplayMember = "MANV"; // Tên cột muốn hiển thị trong ComboBox
                    magvCB.ValueMember = "MANV";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public void LayDSMAHP()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    string query = "";

                    connection.Open();
                    if (Array.Exists(AppConfig.UserRoles, role => role == "GIAOVU" || role == "ROLE_TK"))
                    {
                        query = "SELECT MAHP FROM ADMIN.HOCPHAN WHERE MADV = 'VPK'";

                    } else
                    {
                        query = "SELECT MAHP FROM ADMIN.HOCPHAN JOIN ADMIN.NHANSU ON  ADMIN.HOCPHAN.MADV = ADMIN.NHANSU.MADV";
                    }
                    
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataRow newRow = dataTable.NewRow();
                    newRow["MAHP"] = "";
                    dataTable.Rows.InsertAt(newRow, 0);
                    // Hiển thị dữ liệu lên DataGridView
                    mahpCB.DataSource = dataTable;
                    mahpCB.DisplayMember = "MAHP"; // Tên cột muốn hiển thị trong ComboBox
                    mahpCB.ValueMember = "MAHP";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        
    }
}
