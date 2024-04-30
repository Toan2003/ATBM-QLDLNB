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
    public partial class DashBoardSV : Form
    {
        public DashBoardSV( )
        {
            InitializeComponent();
            this.FormClosing += DashBoardSV_FormClosing;
            MSSV.Text = AppConfig.CurrentUsername;
        }

        private void DashBoardSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnThongtin_Click(object sender, EventArgs e)
        {
            ThongtinSV f = new ThongtinSV("",this);
            f.Show();
            this.Hide();
        }

        private void btnDKHP_Click(object sender, EventArgs e)
        {
            DangKyHocPhanSV f = new DangKyHocPhanSV(this);
            f.Show();
            this.Hide();
        }

        private void btnKQHP_Click(object sender, EventArgs e)
        {
            KetQuaDangKyHP_SV f = new KetQuaDangKyHP_SV(this);
            f.Show();
            this.Hide();
        }

        private void btnTTHP_Click(object sender, EventArgs e)
        {
            DanhSachHocPhanSV f = new DanhSachHocPhanSV(this);
            f.Show();
            this.Hide();
        }

        private void btnKHMO_Click(object sender, EventArgs e)
        {
            KeHoachMoHPSV f = new KeHoachMoHPSV(this);
            f.Show();
            this.Hide();
        }

        private void btnTBao_Click(object sender, EventArgs e)
        {
            fNotification f = new fNotification(this);
            f.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logOut_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.Show();
            this.Dispose();
            AppConfig.LogOut();
        }

        private void DashBoardSV_Load(object sender, EventArgs e)
        {

        }
    }
}
