using ATBM_PH2;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class CapNhatDiemSinhVien : Form
    {
        private string connectionString = AppConfig.connectionString;
        private string MAGV;
        private int HK;
        private int NAM;
        private string MAHP;
        private List<int> RowsChange =new List<int>();
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
                            //MessageBox.Show("Chỉnh sửa thông tin thành công");
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("Không thể chỉnh sửa thông tin");
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

        public CapNhatDiemSinhVien()
        {
            InitializeComponent();
            DataTable temp = selectSQL("select * from ADMIN.NHANSU");
            if (temp == null) { this.Dispose();return;}
            MAGV = temp.Rows[0]["MANV"].ToString();
            //MAGV = "NV0091";
            label2.Visible = false;
            label5.Visible = false;
            button1.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void CapNhatDiemSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text =="")
            {
                MessageBox.Show("Hãy nhập đầy đủ các trường");
                return;
            }
            HK = int.Parse(textBox2.Text);
            NAM = int.Parse(textBox1.Text);
            DataTable DSHocPhan = selectSQL("select MAHP from ADMIN.PHANCONG where MAGV='"+MAGV+"' and HK="+HK+" and NAM="+NAM);
            comboBox1.Items.Clear();
            if (DSHocPhan.Rows.Count == 0)
            {
                MessageBox.Show("Không có lớp chịu trách nhiệm trong thời gian đã nhập");
                return ;
            }
            foreach (DataRow row in DSHocPhan.Rows)
            {
                // Check if the row contains a non-null value in the "MAGV" column
                if (!row.IsNull("MAHP"))
                {
                    // Get the value of the "MAGV" column for the current row
                    string MAHP = row["MAHP"].ToString();

                    // Add the value to the ComboBox
                    comboBox1.Items.Add(MAHP);
                }
            }
            comboBox1.Visible = true;
            label2.Visible = true;
            label5.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MAHP = comboBox1.SelectedItem.ToString();
            //MessageBox.Show("Bạn đã chọn: " + selectedItem);
            DataTable DSLop = selectSQL("select * from ADMIN.DANGKY where MAHP='"+MAHP+"' and MAGV='"+MAGV+"' and NAM="+NAM +" and HK="+HK);
            dataGridView1.DataSource = DSLop;
            dataGridView1.Visible = true;
            button1.Visible = true;
            button1.Enabled = false;
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RowsChange.Add(e.RowIndex);
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           foreach(int rowIndex in RowsChange)
           {
                //MessageBox.Show(a+"");
                string DIEMTH = dataGridView1.Rows[rowIndex].Cells["DIEMTH"].Value.ToString().Trim();
                string DIEMQT = dataGridView1.Rows[rowIndex].Cells["DIEMQT"].Value.ToString().Trim();
                string DIEMCK = dataGridView1.Rows[rowIndex].Cells["DIEMCK"].Value.ToString().Trim();
                string DIEMTK = dataGridView1.Rows[rowIndex].Cells["DIEMTK"].Value.ToString().Trim();
                if (string.IsNullOrEmpty(DIEMTH)) { DIEMTH = "null"; }
                if (string.IsNullOrEmpty(DIEMQT)) { DIEMQT = "null"; }
                if (string.IsNullOrEmpty(DIEMCK)) { DIEMCK = "null"; }
                if (string.IsNullOrEmpty(DIEMTK)) { DIEMTK = "null"; }

                string MACT = dataGridView1.Rows[rowIndex].Cells["MACT"].Value.ToString().Trim();
                string MASV = dataGridView1.Rows[rowIndex].Cells["MASV"].Value.ToString().Trim();
                //MessageBox.Show(MASV);
                string SQL = "UPDATE ADMIN.DANGKY " +
                    "SET DIEMTH=" + DIEMTH + ", DIEMQT="+DIEMQT+", DIEMCK="+DIEMCK + ", DIEMTK=" + DIEMTK+" " +
                    "WHERE MACT='"+MACT+"' AND MASV='"+MASV+"' AND MAGV='"+MAGV+"' AND HK="+ HK +" AND NAM=" + NAM;   
                bool isUPdate = updateSQL(SQL);
                if (!isUPdate)
                {
                    MessageBox.Show("Không thể cập nhật điểm sinh viên: " + MASV);
                }
           }
           RowsChange.Clear();
           DataTable DSLop = selectSQL("select * from ADMIN.DANGKY where MAHP='" + MAHP + "' and MAGV='" + MAGV + "' and NAM=" + NAM + " and HK=" + HK);
           dataGridView1.DataSource = DSLop;
           dataGridView1.Visible = true;
           button1.Visible = true;
           button1.Enabled = false;
            MessageBox.Show("Chỉnh sửa thông tin thành công");
        }
    }
}
