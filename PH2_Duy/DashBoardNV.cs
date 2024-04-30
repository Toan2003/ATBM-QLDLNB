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
    public partial class DashBoardNV : Form
    {
        public DashBoardNV()
        {
            InitializeComponent();
            MSNV.Text = AppConfig.CurrentUsername;
            this.FormClosing += DashBoardNV_FormClosing;
        }

        private void DashBoardNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnTTCN_Click(object sender, EventArgs e)
        {
            fEmpInfo f = new fEmpInfo(this);
            f.Show();
            this.Hide();
            
        }

        private void btnTTNS_Click(object sender, EventArgs e)
        {
            if (Array.Exists(AppConfig.UserRoles, role => role == "ROLE_TK"))
            {
                Form1 f = new Form1(this);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Trưởng khoa mới được thực hiện chức năng này !");
            }
            
        }

        private void btnTTDV_Click(object sender, EventArgs e)
        {
            fDeptInfo f = new fDeptInfo(this);
            f.Show();
            this.Hide();
        }

        private void btnTTSV_Click(object sender, EventArgs e)
        {
            fAllStudentInfo f = new fAllStudentInfo(this);
            f.Show();
            this.Hide();
        }

        private void btnTTHP_Click(object sender, EventArgs e)
        {
            XemHP_NV f = new XemHP_NV(this);
            f.Show();
            this.Hide();
        }

        private void btnThongbao_Click(object sender, EventArgs e)
        {
            fNotification f = new fNotification(this);
            f.Show();
            this.Hide();

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.Show();
            this.Dispose();
            AppConfig.LogOut();
        }

        private void btnPC_Click(object sender, EventArgs e)
        {

            if (Array.Exists(AppConfig.UserRoles, role => role != "NHAN_VIEN_CO_BAN"))
            {
                XemPhanCong f = new XemPhanCong(this);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không được thực hiện chức năng này ! ");
            }
        }

        private void btnKHMO_Click(object sender, EventArgs e)
        {
            fKHMOInfo f = new fKHMOInfo(this);
            f.Show();
            this.Hide();
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
