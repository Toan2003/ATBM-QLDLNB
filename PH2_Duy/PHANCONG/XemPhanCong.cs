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
    public partial class XemPhanCong : Form
    {
        private string connectionString = AppConfig.connectionString;
        public Form baseForm;
        public XemPhanCong(Form baseForm)
        {
            InitializeComponent();
            LayDSPC();
            CheckUserRole();
            this.baseForm = baseForm;
            this.FormClosing += XemPhanCong_FormClosing;
        }

        private void CheckUserRole()
        {
            // Kiểm tra xem người dùng có vai trò "GIAO_VU" hay không
            if (Array.Exists(AppConfig.UserRoles, role => role == "GIAOVU" || role == "TRUONGDONVI" || role == "ROLE_TK"))
            {
                themBtn.Visible = true;
                updateBtn.Visible = true;
            }
            else
            {
                themBtn.Visible = false;
                updateBtn.Visible = false;
            }
        }

        private void XemPhanCong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardSV
                DashBoardNV dashBoard = new DashBoardNV();
                dashBoard.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LayDSPC()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * from ADMIN.PHANCONG";
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
                    //MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            ChinhSuaPC capnhat = new ChinhSuaPC();
            capnhat.Show();
        }

        private void themBtn_Click(object sender, EventArgs e)
        {
            ThemPC them = new ThemPC();
            them.ShowDialog();
            LayDSPC();
        }

        private void XemPhanCong_Load(object sender, EventArgs e)
        {

        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
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
                if (column.HeaderText.Contains("MAHP"))
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
