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
    public partial class ChinhSuaPC : Form
    {
        private string connectionString = AppConfig.connectionString;
        public ChinhSuaPC()
        {
            InitializeComponent();
            DSPC();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void DSPC()
        {
            
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * from ADMIN.PHANCONG PC, ADMIN.HOCPHAN HP, ADMIN.DONVI DV WHERE PC.MAHP = HP.MAHP AND HP.MADV = DV.MADV AND DV.TRGDV = '" + AppConfig.CurrentUsername + "'";
                    connection.Open();
                    OracleCommand command = new OracleCommand(query, connection);
                    DataTable dataTable = new DataTable();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter = new OracleDataAdapter(command);
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView                   
                    dataGridView1.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                //string columnName = "MAHP";
                //var value = selectedRow.Cells[columnName].Value.ToString();
                //string col2 = "MAGV";
                //var magv = selectedRow.Cells[columnName].Value.ToString();
                String[] val = new string[5];
                String[] columnName = { "MAGV", "MAHP", "HK", "NAM", "MACT" };
                for (int i=0; i < columnName.Length; i++)
                {
                    val[i] = selectedRow.Cells[columnName[i]].Value.ToString();
                    //MessageBox.Show("Error: " + val[i]);
                }

                CapNhatPC capnhat = new CapNhatPC(val[0], val[1], val[2], int.Parse(val[3]), val[4]);
                capnhat.ShowDialog();
                DSPC();
            }
            
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                //string columnName = "MAHP";
                //var value = selectedRow.Cells[columnName].Value.ToString();
                //string col2 = "MAGV";
                //var magv = selectedRow.Cells[columnName].Value.ToString();
                String[] val = new string[5];
                String[] columnName = { "MAGV", "MAHP", "HK", "NAM", "MACT" };
                for (int i = 0; i < columnName.Length; i++)
                {
                    val[i] = selectedRow.Cells[columnName[i]].Value.ToString();
                    //MessageBox.Show("Error: " + val[i]);
                }

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {

                        connection.Open();
                        string query = "DELETE from ADMIN.PHANCONG " +
                            "WHERE MAGV=:MAGV AND MAHP=:MAHP AND HK=:HK AND NAM=:NAM AND MACT=:MACT";
                        OracleCommand command = new OracleCommand(query, connection);

                        command.Parameters.Add("MAGV", OracleDbType.Char).Value = val[0];
                        command.Parameters.Add("MAHP", OracleDbType.Char).Value = val[1];
                        command.Parameters.Add("HK", OracleDbType.Int64).Value = int.Parse(val[2]);
                        command.Parameters.Add("NAM", OracleDbType.Int64).Value = int.Parse(val[3]);
                        command.Parameters.Add("MACT", OracleDbType.Char).Value = val[4];
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa thành công !");
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại !");
                        }
                        DSPC();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }


            }

        }

        private void ChinhSuaPC_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
