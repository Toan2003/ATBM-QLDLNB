using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ATBM_PH2
{
    public partial class ThongtinSV : Form
    {
        private string connectionString = AppConfig.connectionString;
        public Form baseForm;
        private bool isClick = false;
        private DataTable information = null;
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

        private void fillField(DataTable information)
        {
            foreach (DataRow row in information.Rows)
            {
                this.mssv.Text = row["MASV"].ToString().Trim();
                this.hoten.Text = row["HOTEN"].ToString().Trim();
       
                if (row["PHAI"].ToString().Trim() == "NU")
                {
                    this.gioitinh.Text = "Nữ";
                } else {        
                    this.gioitinh.Text = "Nam";
                }
                this.ngaysinh.Text = row["NGSINH"].ToString().Trim();
                this.diachi.Text = row["DCHI"].ToString().Trim();
                this.dienthoai.Text = row["DT"].ToString().Trim();
                this.machuongtrinh.Text = row["MACT"].ToString().Trim();
                this.tinchitichluy.Text = row["SOTCTL"].ToString().Trim();
                this.diemtb.Text = row["DTBTL"].ToString().Trim();
                this.manganh.Text = row["MANGANH"].ToString().Trim();
            }
        }

        public ThongtinSV(String value, Form baseForm)
        {
            value = "";
            InitializeComponent();
            information = selectSQL("SELECT * FROM ADMIN.SINHVIEN");
            fillField(information);
            this.mssv.Enabled = false;
            this.hoten.Enabled = false;
            this.gioitinh.Enabled = false;
            this.diachi.Enabled = false;
            this.ngaysinh.Enabled = false;
            this.dienthoai.Enabled = false;
            this.machuongtrinh.Enabled = false;
            this.manganh.Enabled = false;
            this.diemtb.Enabled = false;
            this.tinchitichluy.Enabled = false;
            this.baseForm = baseForm;

            this.FormClosing += ThongtinSV_FormClosing;
        }

        private void ThongtinSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardSV
                DashBoardSV dashBoard = new DashBoardSV();
                dashBoard.Show();
            }
        }

        private void ThongtinSV_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Chỉnh sửa thông tin")
            {
                this.diachi.Enabled = true;
                this.dienthoai.Enabled=true;
                this.button1.Text = "Cập nhật";
            } else if (this.button1.Text == "Cập nhật") {
                String temp = "UPDATE ADMIN.SINHVIEN SET DCHI = '" + this.diachi.Text + "', " +
                    "DT ='" + this.dienthoai.Text + "'";
                MessageBox.Show(temp);
                if (updateSQL(temp))
                {
                    this.button1.Text = "Chỉnh sửa thông tin";
                    this.diachi.Enabled = false;
                    this.dienthoai.Enabled = false;
                } else
                {
                    information = selectSQL("SELECT * FROM ADMIN.SINHVIEN");
                    fillField(information);
                }
                
            }

        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
