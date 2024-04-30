using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fDeptInfo : Form
    {
        public Form baseForm;
        public fDeptInfo(Form baseForm)
        {
            InitializeComponent();
            // Kiểm tra vai trò của người dùng và hiển thị các nút tương ứng
            CheckUserRole();
            // Hiển thị thông tin đơn vị
            DisplayDeptInfo();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.baseForm = baseForm;
            this.FormClosing += fDeptInfo_FormClosing;
            dataGridView1.ReadOnly = true;
        }

        private void fDeptInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem form đang được đóng do người dùng tác động hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardNV
                DashBoardNV dashBoard = new DashBoardNV();
                dashBoard.Show();
            }
        }

        private void CheckUserRole()
        {
            // Kiểm tra xem người dùng có vai trò "GIAO_VU" hay không
            if (Array.Exists(AppConfig.UserRoles, role => role == "GIAOVU"))
            {
                btnDeleteDept.Visible = true;
                btnInsertDept.Visible = true;
                btnUpdateDept.Visible = true;
            }
            else
            {
                btnDeleteDept.Visible = false;
                btnInsertDept.Visible = false;
                btnUpdateDept.Visible = false;
            }
        }

        private void DisplayDeptInfo()
        {
            // Lấy thông tin đơn vị từ cơ sở dữ liệu và hiển thị lên DataGridView
            DataTable dt = new DataTable();
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM ADMIN.DONVI", connection);
                adapter.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private void btnUpdateDept_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string deptId = dataGridView1.SelectedRows[0].Cells["MADV"].Value.ToString();
                fUpdateDept updateForm = new fUpdateDept(deptId);
                updateForm.ShowDialog();
                DisplayDeptInfo();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn vị để cập nhật.");
            }
        }

        private void btnInsertDept_Click(object sender, EventArgs e)
        {
            fInsertDept insertForm = new fInsertDept();
            insertForm.ShowDialog();
            DisplayDeptInfo();
        }

        private void btnDeleteDept_Click(object sender, EventArgs e)
        {
            // Xóa đơn vị được chọn từ DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string deptId = dataGridView1.SelectedRows[0].Cells["MADV"].Value.ToString();
                using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
                {
                    connection.Open();
                    OracleCommand command = new OracleCommand("DELETE FROM ADMIN.DONVI WHERE MADV = :deptId", connection);
                    command.Parameters.Add("deptId", OracleDbType.Char).Value = deptId;
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa đơn vị thành công !");
                        DisplayDeptInfo();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đơn vị thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn vị để xóa.");
            }
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
                if (column.HeaderText.Contains("MADV"))
                {
                    // Tìm thấy tên cột chứa username, sử dụng tên cột này để thay đổi màu sắc và cuộn tới dòng chứa kết quả tìm kiếm đầu tiên
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[column.Index].Value != null)
                        {
                            string tmp_str = row.Cells[column.Index].Value.ToString().ToLower();

                            if (tmp_str.Contains(searchText))
                            {
                                // Thay đổi màu sắc của cột Username tương ứng
                                row.DefaultCellStyle.BackColor = Color.LightCyan; // Thay màu nền thành màu bạn mong muốn

                                // Cuộn tới dòng chứa kết quả tìm kiếm đầu tiên
                                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

                                found = true; // Đánh dấu đã tìm thấy kết quả
                                break; // Thoát khỏi vòng lặp khi tìm thấy kết quả
                            }
                            else
                            {
                                // Nếu không phù hợp với tìm kiếm, đặt lại màu sắc về mặc định
                                dataGridView1.BackColor = Color.White; // Thay màu nền thành màu mặc định
                            }
                        }
                    }
                    // Nếu đã tìm thấy kết quả, không cần duyệt các cột khác nữa
                    if (found)
                        break;
                }
            }
        }

        private void fDeptInfo_Load(object sender, EventArgs e)
        {

        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }
    }
}
