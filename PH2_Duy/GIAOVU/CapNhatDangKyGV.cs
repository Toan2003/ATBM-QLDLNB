using ATBM_PH2;
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
    public partial class CapNhatDangKyGV : Form
    {
        private string connectionString = AppConfig.connectionString;
        private string MASV;
        private DataTable selectSQL(string sql)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        // Assuming it's a SELECT statement, you might want to use ExecuteReader instead of ExecuteNonQuery
                        // Also, consider what you want to do with the result of the SELECT statement
                        OracleDataReader reader = command.ExecuteReader();

                        // Example: You can load the result into a DataTable and then bind it to a DataGridView
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Example: Binding the DataTable to a DataGridView
                        // dataGridView1.DataSource = dataTable;

                        // If you just want to execute the SQL statement without expecting any result, you can use ExecuteNonQuery
                        // command.ExecuteNonQuery();

                        connection.Close();
                        return dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }

        private bool updateSQL(string sql)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        // Execute the INSERT statement
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        // Optionally, you can check the number of rows affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Chỉnh sửa thông tin thành công");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Không thể chỉnh sửa thông tin");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private DataTable ExecuteProcedure(string NameOfProcedure, params object[] args)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = NameOfProcedure;

                        // Tạo parameter cho stored procedure

                        foreach (object o in args)
                        {
                            if (o is string)
                            {
                                command.Parameters.Add(o.ToString(), OracleDbType.Varchar2, ParameterDirection.Input).Value = (string)o;
                            }
                            else
                            {
                                //MessageBox.Show(o.ToString());
                                command.Parameters.Add(o.ToString(), OracleDbType.Int32, ParameterDirection.Input).Value = o;
                            }
                        }
                        command.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                        //MessageBox.Show(command.Parameters[2].Value + "");
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        connection.Close();
                        return dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }

        public CapNhatDangKyGV()
        {
            InitializeComponent();
            label5.Visible = false;
            label7.Visible = false; 
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void CapNhatDangKyGV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ các trường");
                return;
            }
            MASV = textBox3.Text;
            int HK = int.Parse(textBox2.Text);
            int NAM = int.Parse(textBox1.Text);
            
            DataTable DSMonDaDangKy = selectSQL("select * from ADMIN.DANGKY where MASV ='"+ MASV +"' and HK="+HK+" and NAM =" +NAM);
            DataColumn checkBoxColumn1 = new DataColumn("IsRegister", typeof(bool));
            DSMonDaDangKy.Columns.Add(checkBoxColumn1);
            if (DSMonDaDangKy.Columns.Contains("IsRegister")) // Check if the checkbox column exists
            {
                foreach (DataRow row in DSMonDaDangKy.Rows)
                {
                    row["IsRegister"] = true;
                }

            }
            dataGridView1.DataSource = DSMonDaDangKy;
            dataGridView1.Columns["IsRegister"].HeaderText = "Đăng ký";

            DataTable DSMonCoTheDangKy = ExecuteProcedure("GetListKHMOToRegisterGVu",MASV,HK,NAM);
            // them checkbox dang ky
            DataColumn checkBoxColumn = new DataColumn("IsRegister", typeof(bool));
            DSMonCoTheDangKy.Columns.Add(checkBoxColumn);
            if (DSMonCoTheDangKy.Columns.Contains("IsRegister")) // Check if the checkbox column exists
            {
                foreach (DataRow row in DSMonCoTheDangKy.Rows)
                {
                    row["IsRegister"] = false;
                }
            }
            dataGridView2.DataSource = DSMonCoTheDangKy;
            dataGridView2.Columns["IsRegister"].HeaderText = "Đăng ký";

            label5.Visible = true;
            label7.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["IsRegister"].Index && e.RowIndex >= 0)
            {
                //MessageBox.Show("HERE");
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = (bool)false;
                object MAGV = dataGridView1.Rows[e.RowIndex].Cells["MAGV"].Value;
                object MAHP = dataGridView1.Rows[e.RowIndex].Cells["MAHP"].Value;
                object HK = dataGridView1.Rows[e.RowIndex].Cells["HK"].Value;
                object NAM = dataGridView1.Rows[e.RowIndex].Cells["NAM"].Value;
                object MACT = dataGridView1.Rows[e.RowIndex].Cells["MACT"].Value;
                //Console.WriteLine("Checkbox in row " + e.RowIndex + " is checked.");
                //MessageBox.Show("" + MAGV.GetType() + MAHP.GetType() + HK.GetType() + NAM.GetType() + MACT.GetType());

                DataTable result = ExecuteProcedure("ADMIN.DeleteFromDangKy", MASV, MAGV, MAHP, HK, NAM, MACT);
                if (result != null)
                {
                    DataTable DSMonCoTheDangKy = ExecuteProcedure("GetListKHMOToRegisterGVu", MASV, HK, NAM); 
                    DataColumn checkBoxColumn = new DataColumn("IsRegister", typeof(bool));
                    DSMonCoTheDangKy.Columns.Add(checkBoxColumn);
                    if (DSMonCoTheDangKy.Columns.Contains("IsRegister")) // Check if the checkbox column exists
                    {
                        foreach (DataRow row in DSMonCoTheDangKy.Rows)
                        {
                            row["IsRegister"] = false;
                        }

                    }
                    dataGridView2.DataSource = DSMonCoTheDangKy;
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = true;
                    dataGridView1.EndEdit();
                    dataGridView1.InvalidateCell(e.ColumnIndex, e.RowIndex);

                }
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["IsRegister"].Index && e.RowIndex >= 0)
            {
                dataGridView2[e.ColumnIndex, e.RowIndex].Value = (bool)true;
                object MAGV = dataGridView2.Rows[e.RowIndex].Cells["MAGV"].Value;
                object MAHP = dataGridView2.Rows[e.RowIndex].Cells["MAHP"].Value;
                object HK = dataGridView2.Rows[e.RowIndex].Cells["HK"].Value;
                object NAM = dataGridView2.Rows[e.RowIndex].Cells["NAM"].Value;
                object MACT = dataGridView2.Rows[e.RowIndex].Cells["MACT"].Value;
                //Console.WriteLine("Checkbox in row " + e.RowIndex + " is checked.");
                //MessageBox.Show("" + MAGV.GetType() + MAHP.GetType() + HK.GetType() + NAM.GetType() + MACT.GetType());

                DataTable result = ExecuteProcedure("ADMIN.InsertNewDangKy", MASV, MAGV, MAHP, HK, NAM, MACT);
                if (result != null)
                {
                    DataTable DSMonDaDangKy = selectSQL("select * from ADMIN.DANGKY where MASV ='" + MASV + "' and HK=" + HK + " and NAM =" + NAM);
                    DataColumn checkBoxColumn1 = new DataColumn("IsRegister", typeof(bool));
                    DSMonDaDangKy.Columns.Add(checkBoxColumn1);
                    if (DSMonDaDangKy.Columns.Contains("IsRegister")) // Check if the checkbox column exists
                    {
                        foreach (DataRow row in DSMonDaDangKy.Rows)
                        {
                            row["IsRegister"] = true;
                        }

                    }
                    dataGridView1.DataSource = DSMonDaDangKy;
                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    dataGridView2[e.ColumnIndex, e.RowIndex].Value = false;
                    dataGridView2.EndEdit();
                    dataGridView2.InvalidateCell(e.ColumnIndex, e.RowIndex);

                }
            }
        }
    }
}
