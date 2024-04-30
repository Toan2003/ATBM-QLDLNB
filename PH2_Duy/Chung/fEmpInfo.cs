using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;


namespace ATBM_PH2
{
    public partial class fEmpInfo : Form
    {
        private string empID;
        public Form baseForm;

        public fEmpInfo(Form baseForm)
        {
            InitializeComponent();
            this.empID = AppConfig.CurrentUsername;
            DisplayEmpInfo();
            this.baseForm = baseForm;
            this.FormClosing += fEmpInfo_FormClosing;
        }


        private void fEmpInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem form đang được đóng do người dùng tác động hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardNV
                DashBoardNV dashBoard = new DashBoardNV();
                dashBoard.Show();
            }
        }

        private void DisplayEmpInfo()
        {
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT ADMIN.NHANSU.*, ADMIN.DONVI.TENDV AS TEN_DONVI   FROM ADMIN.NHANSU   LEFT JOIN ADMIN.DONVI ON ADMIN.NHANSU.MADV = ADMIN.DONVI.MADV AND ADMIN.NHANSU.MANV = '"+AppConfig.CurrentUsername+"'";

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lbEmpID.Text = reader["MANV"].ToString();
                                lbName.Text = reader["HOTEN"].ToString();
                                lbGender.Text = reader["PHAI"].ToString();
                                lbDOB.Text = ((DateTime)reader["NGSINH"]).ToString("dd/MM/yyyy");
                                lbPhone.Text = reader["DT"].ToString();
                                lbRole.Text = reader["VAITRO"].ToString();
                                lbDept.Text = reader["TEN_DONVI"].ToString(); 
                                lbAllowance.Text = reader["PHUCAP"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nhân viên!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdatePhoneNumber(string newPhone)
        {
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE ADMIN.NHANSU SET DT = :newPhone WHERE ADMIN.NHANSU.MANV = '"+AppConfig.CurrentUsername+"'";

                        // Thêm tham số cho stored procedure
                        command.Parameters.Add("newPhone", OracleDbType.Char).Value = newPhone;

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật số điện thoại thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lbPhone.Text = newPhone;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật số điện thoại thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdatePhone_Click(object sender, EventArgs e)
        {
            // Hiển thị form popup để nhập số điện thoại mới
            using (var updatePhoneForm = new UpdatePhoneNumberForm())
            {
                // Nếu người dùng nhấn OK trên form popup
                if (updatePhoneForm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy số điện thoại mới từ form popup
                    string newPhone = updatePhoneForm.NewPhoneNumber;

                    // Gọi hàm cập nhật số điện thoại
                    UpdatePhoneNumber(newPhone);
                }
            }
        }

        private void btnManageEmp_Click(object sender, EventArgs e)
        {

        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }

        private void fEmpInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
