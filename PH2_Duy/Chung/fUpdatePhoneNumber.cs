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
    public partial class UpdatePhoneNumberForm : Form
    {
        public string NewPhoneNumber { get; private set; }

        public UpdatePhoneNumberForm()
        {
            InitializeComponent();
        }


        private void btnOK_Click_1(object sender, EventArgs e)
        {
            // Lấy số điện thoại mới từ TextBox
            NewPhoneNumber = txtNewPhone.Text.Trim();

            // Đóng form popup và trả về DialogResult.OK
            DialogResult = DialogResult.OK;
            this.Close();
        }

       
    }

}
