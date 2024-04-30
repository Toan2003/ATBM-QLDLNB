using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fAllStudentInfo : Form
    {
        public Form baseForm;
        public fAllStudentInfo(Form baseForm)
        {
            InitializeComponent();
            // Kiểm tra vai trò của người dùng và hiển thị các nút tương ứng
            CheckUserRole();
            // Hiển thị thông tin sinh viên
            DisplayStudentInfo();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            this.baseForm = baseForm;
            this.FormClosing += fAllStudentInfo_FormClosing;
        }

        private void fAllStudentInfo_FormClosing(object sender, FormClosingEventArgs e)
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
                btnDeleteStudent.Visible = true;
                btnInsertStudent.Visible = true;
            }
            else
            {
                btnDeleteStudent.Visible = false;
                btnInsertStudent.Visible = false;
                btnUpdateDiem.Visible = false;
            }

            if (Array.Exists(AppConfig.UserRoles, role => role == "GIANG_VIEN"))
            {
                btnUpdateDiem.Visible = true;
            } else
            {
                btnUpdateDiem.Visible = false;
            }
        }

        private void DisplayStudentInfo()
        {
            // Lấy thông tin sinh viên từ cơ sở dữ liệu và hiển thị lên DataGridView
            DataTable dt = new DataTable();
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM ADMIN.SINHVIEN", connection);
                adapter.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }


        private void btnUpdateStudent_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string studentId = dataGridView1.SelectedRows[0].Cells["MASV"].Value.ToString();
                fUpdateStudent updateForm = new fUpdateStudent(studentId);
                updateForm.ShowDialog();
                DisplayStudentInfo();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để cập nhật.");
            }
        }

        private void btnInsertStudent_Click_1(object sender, EventArgs e)
        {
            fInsertStudent insertForm = new fInsertStudent();
            insertForm.ShowDialog();
            DisplayStudentInfo();
        }

        private void btnDeleteStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Xóa sinh viên được chọn từ DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string studentId = dataGridView1.SelectedRows[0].Cells["MASV"].Value.ToString();
                    using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
                    {
                        connection.Open();
                        OracleCommand command = new OracleCommand("DELETE FROM ADMIN.SINHVIEN WHERE MASV = :studentId", connection);
                        command.Parameters.Add("studentId", OracleDbType.Char).Value = studentId;
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công !");
                            DisplayStudentInfo();
                        }
                        else
                        {
                            MessageBox.Show("Xóa sinh viên thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
                }
            } catch
            {
                MessageBox.Show("Xóa sinh viên thất bại");
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
                if (column.HeaderText.Contains("MASV") || column.HeaderText.Contains("HOTEN"))
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

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }

        private void btnUpdateDiem_Click(object sender, EventArgs e)
        {
            CapNhatDiemSinhVien f = new CapNhatDiemSinhVien();
            f.ShowDialog();
            DisplayStudentInfo();
        }
    }
}
