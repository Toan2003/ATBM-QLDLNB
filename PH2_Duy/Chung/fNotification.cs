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
    public partial class fNotification : Form
    {
        public Form baseForm;
        public fNotification(Form baseForm)
        {
            InitializeComponent();
            DisplayNotification();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            button1.Visible = false;
            foreach (string e in AppConfig.UserRoles)
            {
                if (e == "THONGBAO_POLICY_DBA")
                {
                    button1.Visible = true;
                    homeIcon.Visible = false;
                }
            }

            this.baseForm = baseForm;
            this.FormClosing += fNotification_FormClosing;
        }

        private void fNotification_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem form đang được đóng do người dùng tác động hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if(Array.Exists(AppConfig.UserRoles, role => role == "THONGBAO_POLICY_DBA"))
                {
                    Application.Exit();
                }

                // Chuyển về form DashBoardNV
                DashBoardNV dashBoard = new DashBoardNV();
                dashBoard.Show();
            }
        }


        private void DisplayNotification()
        {
            // Lấy thông tin sinh viên từ cơ sở dữ liệu và hiển thị lên DataGridView
            DataTable dt = new DataTable();
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                OracleDataAdapter adapter = new OracleDataAdapter("SELECT NOIDUNG, THOIGIAN FROM ADMIN_OLS.THONGBAO", connection);
                adapter.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem double click có diễn ra trên hàng nào không
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string notificationContent = selectedRow.Cells["NOIDUNG"].Value.ToString(); // Lấy nội dung thông báo
                MessageBox.Show(notificationContent, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }

        private void fNotification_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fAddNotification f = new fAddNotification();
            f.ShowDialog();
            DisplayNotification();
        }

    }
}
