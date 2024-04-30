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

namespace ATBM_PH2
{
    public partial class CapNhatPC : Form
    {
        private string connectionString = AppConfig.connectionString;
        String maGV, maHP, hk, maCT;
        int nam;
        public CapNhatPC(String maGV, string maHP, String hk, int nam, String maCT)
        {
            InitializeComponent();
            this.maGV = maGV.Trim();
            this.maHP = maHP;
            this.hk = hk;
            this.nam = nam;
            this.maCT = maCT.Trim();
            LayDSGV();
            LayDSMAHP();
            //MessageBox.Show("Error 2 " + maGV + "lll");
            foreach (DataRowView item in magvCB.Items)
            {               
                if (item["MANV"].ToString() == maGV)
                {
                    
                    magvCB.SelectedItem = item;
                    break; 
                }
            }
            foreach (DataRowView item in mahpCB.Items)
            {               
                if (item["MAHP"].ToString() == maHP)
                {                    
                    mahpCB.SelectedItem = item;
                    break; 
                }
            }
            
            hkCB.SelectedItem = hk.Trim();
            namNum.Value = nam;
            mactCB.SelectedItem = maCT.Trim();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ADMIN.PHANCONG " +
                                   "SET MAGV=:MAGV, MAHP=:MAHP, HK=:HK, NAM=:NAM, MACT=:MACT " +
                                   "WHERE MAGV=:MAGVOLD AND MAHP=:MAHPOLD AND HK=:HKOLD AND NAM=:NAMOLD AND MACT=:MACTOLD ";
                    OracleCommand command = new OracleCommand(query, connection);

                    DataRowView selectedRow = (DataRowView)magvCB.SelectedItem;
                    String magvnew = selectedRow["MANV"].ToString();

                    selectedRow = (DataRowView)mahpCB.SelectedItem;
                    String mahpnew = selectedRow["MAHP"].ToString();
                    int hknew = int.Parse(hkCB.SelectedItem.ToString());
                    int namnew = (int)namNum.Value;
                    String mactnew = mactCB.SelectedItem.ToString();
                    MessageBox.Show(magvnew + " " + magvnew.Length);

                    command.Parameters.Add("MAGV", OracleDbType.Char).Value = magvnew;
                    command.Parameters.Add("MAHP", OracleDbType.Char).Value = mahpnew;
                    command.Parameters.Add("HK", OracleDbType.Int64).Value = hknew;
                    command.Parameters.Add("NAM", OracleDbType.Int64).Value = namnew;
                    command.Parameters.Add("MACT", OracleDbType.Char).Value = mactnew;

                    command.Parameters.Add("MAGVOLD", OracleDbType.Char).Value = maGV;
                    command.Parameters.Add("MAHPOLD", OracleDbType.Char).Value = maHP;
                    command.Parameters.Add("HKOLD", OracleDbType.Int64).Value = int.Parse(hk);
                    command.Parameters.Add("NAMOLD", OracleDbType.Int64).Value = nam;

                    command.Parameters.Add("MACTOLD", OracleDbType.Char).Value = maCT;


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

        private void CapNhatPC_Load(object sender, EventArgs e)
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

                    connection.Open();
                    string query = "SELECT MAHP from ADMIN.HOCPHAN WHERE MADV = 'VPK'";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

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
