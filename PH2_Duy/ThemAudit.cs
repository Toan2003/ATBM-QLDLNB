using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ATBM_PH2
{

    public partial class ThemAudit : Form
    {
        private string connectionString = "User Id=sys;Password=123;DATA SOURCE=localhost:1521/PDBQLDLNB;DBA PRIVILEGE=SYSDBA;TNS_ADMIN=C:\\Users\\trana\\Oracle\\network\\admin";

        public ThemAudit()
        {
            InitializeComponent();
            layDSTable();
            //layDSUser();
            
        }

        private void cbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void layDSTable()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT TABLE_NAME from ALL_TABLES WHERE OWNER = 'ADMIN'";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    cbTableName.DataSource = table;
                    cbTableName.DisplayMember = "TABLE_NAME";  // Cột mà bạn muốn hiển thị trong ComboBox
                    cbTableName.ValueMember = "TABLE_NAME";


                    // Hiển thị dữ liệu lên DataGridView

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        //private void layDSUser()
        //{
        //    using (OracleConnection connection = new OracleConnection(connectionString))
        //    {
        //        try
        //        {

        //            connection.Open();
        //            string query = "SELECT MANV FROM ADMIN.NHANSU";
        //            OracleCommand command = new OracleCommand(query, connection);
        //            OracleDataAdapter adapter = new OracleDataAdapter(command);
        //            DataTable dataTable = new DataTable();
        //            adapter.Fill(dataTable);

        //            DataRow newRow = dataTable.NewRow();
        //            newRow["MANV"] = "";
        //            dataTable.Rows.InsertAt(newRow, 0);

        //            cbUsername.DataSource = dataTable;
        //            cbUsername.DisplayMember = "MANV";  // Cột mà bạn muốn hiển thị trong ComboBox
        //            cbUsername.ValueMember = "MANV";


        //            // Hiển thị dữ liệu lên DataGridView

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }
        //}

        private void themBtn_Click(object sender, EventArgs e)
        {
            //DataRowView selectedRow = (DataRowView)cbUsername.SelectedItem;
            //String manvnew = selectedRow["MANV"].ToString();
            String success = "FALSE";
            String notsuccess = "FALSE";
            //if (manvnew == "")
            //{
            //    manvnew = null;
            //}
            if (radioSuccess.Checked)
            {
                success = "TRUE";
            }
            if (radioNSuccess.Checked)
            {
                notsuccess = "FALSE";
            }
            String action = cbAction.SelectedItem.ToString();
            DataRowView selectedRow = (DataRowView)cbTableName.SelectedItem;
            String table = selectedRow["TABLE_NAME"].ToString();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SP_KICHHOATAUDIT";

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add("TABLENAME", OracleDbType.Varchar2).Value = table;
                        //command.Parameters.Add("USERNAME", OracleDbType.Varchar2).Value = manvnew;
                        command.Parameters.Add("SUCCESS", OracleDbType.Varchar2).Value = success;
                        command.Parameters.Add("NOTSUCCESS", OracleDbType.Varchar2).Value = notsuccess;
                        command.Parameters.Add("ACTION", OracleDbType.Varchar2).Value = action;
                        MessageBox.Show(table + success + notsuccess + action);
                        command.ExecuteNonQuery();
                        
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioNSuccess_Click(object sender, EventArgs e)
        {
            
        }

        private void radioSuccess_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            radioSuccess.Checked = false;
            radioNSuccess.Checked = false;
            cbAction.SelectedItem = null;
            cbTableName.SelectedItem = null;
        }

        //private void getContainerName(string connectionString)
        //{
        //    string connName = null;
        //    using (OracleConnection connection = new OracleConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            OracleCommand cmd = connection.CreateCommand();
        //            cmd.CommandText = "SELECT SYS_CONTEXT('USERENV', 'CON_NAME') AS container_name FROM dual";

        //            OracleDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                connName = reader["container_name"].ToString();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Xử lý lỗi nếu cần
        //            //MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }
        //    MessageBox.Show(connName);

        //}

    }

}
