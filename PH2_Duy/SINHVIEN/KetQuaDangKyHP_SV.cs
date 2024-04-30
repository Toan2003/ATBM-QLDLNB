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
    public partial class KetQuaDangKyHP_SV : Form
    {
        private string connectionString = AppConfig.connectionString;
        public Form baseForm;
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
        public KetQuaDangKyHP_SV(Form baseForm)
        {
            InitializeComponent();
            DataTable temp = selectSQL("select * from ADMIN.SINHVIEN");
            textBox1.Enabled = false;
            if (temp != null)
            {
                textBox1.Text = temp.Rows[0]["MASV"].ToString().Trim();
            }
            int year = DateTime.Now.Year;
            for (int i = year; i >= 2010; i--)
            {
                comboBox1.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 3; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }

            //dataGridView1.Visible = false;
            dataGridView1.Visible = true;
            DataTable t = selectSQL("SELECT HP.TENHP,DK.MAHP,DK.MASV, DK.HK, DK.NAM, DK.MACT, DK.DIEMTH, DK.DIEMQT, DK.DIEMCK, DK.DIEMTK  FROM ADMIN.DANGKY DK JOIN ADMIN.HOCPHAN HP ON DK.MAHP = HP.MAHP");
            dataGridView1.DataSource = t;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.baseForm = baseForm;
            this.FormClosing += KetQuaDangKyHP_SV_FormClosing;
        }

        private void KetQuaDangKyHP_SV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardSV
                DashBoardSV dashBoard = new DashBoardSV();
                dashBoard.Show();
            }
        }

        private void KetQuaDangKyHP_SV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm học");
                return;
            }
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn học kỳ");
                return;
            }
            //MessageBox.Show(comboBox1.SelectedItem.ToString()+" " + comboBox2.SelectedItem.ToString());
            DataTable KetQuaDK = ExecuteProcedure("ADMIN.GetTheListOfDangKy", int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString()));
            dataGridView1.DataSource = KetQuaDK;
            dataGridView1.Columns["MAGV"].Visible = false;
            dataGridView1.Visible = true;
        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }
    }
}
