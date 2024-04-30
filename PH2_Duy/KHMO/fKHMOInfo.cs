using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fKHMOInfo : Form
    {
        public Form baseForm;
        public fKHMOInfo(Form baseForm)
        {
            InitializeComponent();
            // Kiểm tra vai trò của người dùng và hiển thị các nút tương ứng
            CheckUserRole();
            // Hiển thị thông tin KHMO
            DisplayKHMOInfo();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.baseForm = baseForm;
            this.FormClosing += FKHMOInfo_FormClosing;
            dataGridView1.ReadOnly = true;
        }

        private void FKHMOInfo_FormClosing(object sender, FormClosingEventArgs e)
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
            if (Array.Exists(AppConfig.UserRoles, role => role == "GIAOVU" || role == "TRUONGDONVI" || role == "ROLE_TK"))

            {
                btnDeleteKHMO.Visible = true;
                btnInsertKHMO.Visible = true;
                btnUpdateKHMO.Visible = true;
            }
            else
            {
                btnDeleteKHMO.Visible = false;
                btnInsertKHMO.Visible = false;
                btnUpdateKHMO.Visible = false;
            }
        }

        private void DisplayKHMOInfo()
        {
            // Lấy thông tin KHMO từ cơ sở dữ liệu và hiển thị lên DataGridView
            DataTable dt = new DataTable();
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM ADMIN.KHMO", connection);
                adapter.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private void btnUpdateKHMO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string MAHP = dataGridView1.SelectedRows[0].Cells["MAHP"].Value.ToString();
                string HK = dataGridView1.SelectedRows[0].Cells["HK"].Value.ToString();
                string NAM = dataGridView1.SelectedRows[0].Cells["NAM"].Value.ToString();
                string MACT = dataGridView1.SelectedRows[0].Cells["MACT"].Value.ToString();
                fUpdateKHMO updateForm = new fUpdateKHMO(MAHP, HK, NAM, MACT);
                updateForm.ShowDialog();
                DisplayKHMOInfo();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một KHMO để cập nhật.");
            }
        }

        private void btnInsertKHMO_Click(object sender, EventArgs e)
        {
            fInsertKHMO insertForm = new fInsertKHMO();
            insertForm.ShowDialog();
            DisplayKHMOInfo();
        }

        private void btnDeleteKHMO_Click(object sender, EventArgs e)
        {
            // Xóa KHMO được chọn từ DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string MAHP = dataGridView1.SelectedRows[0].Cells["MAHP"].Value.ToString();
                string HK = dataGridView1.SelectedRows[0].Cells["HK"].Value.ToString();
                string NAM = dataGridView1.SelectedRows[0].Cells["NAM"].Value.ToString();
                string MACT = dataGridView1.SelectedRows[0].Cells["MACT"].Value.ToString();
                using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "ADMIN.XOAKHMO";
                            command.Parameters.Add("MAHP", OracleDbType.Char).Value = MAHP;
                            command.Parameters.Add("HK", OracleDbType.Char).Value = HK;
                            command.Parameters.Add("NAM", OracleDbType.Char).Value = NAM;
                            command.Parameters.Add("MACT", OracleDbType.Char).Value = MACT;

                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa kế hoạch thành công !");
                            DisplayKHMOInfo();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa kế hoạch thất bại !");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một kế hoạch để xóa.");
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


            // Duyệt qua từng cột trong DataGridView để tìm tên cột chứa MAKHMO
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText.Contains("MAHP"))
                {
                    
                    // Tìm thấy tên cột chứa MAKHMO, sử dụng tên cột này để thay đổi màu sắc và cuộn tới dòng chứa kết quả tìm kiếm đầu tiên
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[column.Index].Value != null)
                        {
                            string tmp_str = row.Cells[column.Index].Value.ToString().ToLower();

                            if (tmp_str.Contains(searchText))
                            {
                                // Thay đổi màu sắc của cột MAKHMO tương ứng
                                row.DefaultCellStyle.BackColor = Color.LightCyan; // Thay màu nền thành màu bạn mong muốn
                                row.Selected = true;

                                // Cuộn tới dòng chứa kết quả tìm kiếm đầu tiên
                                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

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
                        break;
                }
            }
        }

        private void fKHMOInfo_Load(object sender, EventArgs e)
        {

        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }
    }
}
