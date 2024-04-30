using Oracle.ManagedDataAccess.Client;
using PH2_Duy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATBM_PH2
{
    public partial class Form1 : Form
    {
        private string connectionString = AppConfig.connectionString;
        public Form baseForm;

        public Form1(Form baseForm)
        {
            InitializeComponent();
            this.baseForm = baseForm;
            LayDSNV();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormClosing += Form1_FormClosing;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem form đang được đóng do người dùng tác động hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardNV
                DashBoardNV dashBoard = new DashBoardNV();
                dashBoard.Show();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LayDSNV()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * from ADMIN.NHANSU";
                    OracleCommand command = new OracleCommand(query, connection);
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void xemctnv_Click(object sender, EventArgs e)
        {
            ThemNV themNV = new ThemNV();
            themNV.ShowDialog();
            LayDSNV();

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            String mahp, hoten, phai, ngsinh, phucap, dt, vaitro, madv;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string[] value = new string[8];
              
                string[] columnName = { "MANV", "HOTEN", "PHAI", "NGSINH", "PHUCAP", "DT", "VAITRO", "MADV" };
                for (int i=0; i<columnName.Length; i++)
                {
                    value[i]= selectedRow.Cells[columnName[i]].Value.ToString();
                }
                CapNhatNV capnhat = new CapNhatNV(value[0], value[1], value[2].Trim(), value[3], value[4], value[5], value[6].Trim(), value[7].Trim());
                capnhat.ShowDialog();
            }

            LayDSNV();

        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            String mahp, hoten, phai, ngsinh, phucap, dt, vaitro, madv;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string[] value = new string[1];

                string[] columnName = { "MANV" };
                for (int i = 0; i < columnName.Length; i++)
                {
                    value[i] = selectedRow.Cells[columnName[i]].Value.ToString();
                }

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE ADMIN.NHANSU " +                       
                                    "WHERE MANV=:MANV";
                    OracleCommand command = new OracleCommand(query, connection);

                    // Thêm các parameter cho lệnh INSERT
                    command.Parameters.Add("MANV", OracleDbType.Char).Value = value[0];
                    


                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    if (result > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");
                        LayDSNV();
                        }
                    else
                    {
                        MessageBox.Show("Data insertion failed.");
                    }
                }
            }
        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            bool found = false;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                return;
            }


            // Duyệt qua từng cột trong DataGridView để tìm tên cột chứa MASV
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText.Contains("MANV") || column.HeaderText.Contains("HOTEN"))
                {
                    // Tìm thấy tên cột chứa username, sử dụng tên cột này để thay đổi màu sắc và cuộn tới dòng chứa kết quả tìm kiếm đầu tiên
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[column.Index].Value != null)
                        {
                            string tmp_str = row.Cells[column.Index].Value.ToString().ToLower();

                            if (tmp_str.Contains(searchText))
                            {

                                // Cuộn tới dòng chứa kết quả tìm kiếm đầu tiên
                                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                                // Thay đổi màu sắc tương ứng
                                row.DefaultCellStyle.BackColor = Color.LightCyan;

                                found = true; // Đánh dấu đã tìm thấy kết quả
                                break; // Thoát khỏi vòng lặp khi tìm thấy kết quả
                            }
                            else
                            {
                                // Nếu không phù hợp với tìm kiếm, đặt lại màu sắc về mặc định
                                row.DefaultCellStyle.BackColor = Color.White; // Thay màu nền thành màu mặc định
                            }
                        }
                    }
                    // Nếu đã tìm thấy kết quả, không cần duyệt các cột khác nữa
                    if (found)
                    {
                        break;
                    }

                }
            }
        }
    }
}
