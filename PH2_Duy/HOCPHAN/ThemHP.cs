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
    public partial class ThemHP : Form
    {
        private string connectionString = AppConfig.connectionString;

        private string maHP;
        private string maHPChange;
        private string tenHocPhan = "", madv = "";
        private int soTC = 0, stlt = 0, stth = 0, sosvtd = 0;
        public delegate void UpdateEventHandler(object sender, EventArgs e);
        public event UpdateEventHandler UpdateEvent;

        private void ThemHP_Load(object sender, EventArgs e)
        {

        }

        private XemHP_NV xemhpnv;
        public ThemHP()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ADMIN.HOCPHAN(MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) " +
                                    "VALUES (:MAHP, :TENHP, :SOTC, :STLT, :STTH, :SOSVTD, :MADV) ";
                                   
                    OracleCommand command = new OracleCommand(query, connection);

                    maHP = maHPTB.Text;
                    tenHocPhan = tenHPTB.Text;
                    soTC = (int)soTCNum.Value;
                    stlt = (int)soTietLTNum.Value;
                    stth = (int)soTietTHNum.Value;
                    sosvtd = (int)soSVMaxNuM.Value;
                    madv = maDVCB.SelectedItem.ToString();

                    command.Parameters.Add("MAHP", OracleDbType.Char).Value = maHP;
                    command.Parameters.Add("TENHP", OracleDbType.NVarchar2).Value = tenHocPhan;
                    command.Parameters.Add("SOTC", OracleDbType.Int64).Value = soTC;
                    command.Parameters.Add("STLT", OracleDbType.Int64).Value = stlt;
                    command.Parameters.Add("STTH", OracleDbType.Int64).Value = stth;
                    command.Parameters.Add("SOSVTD", OracleDbType.Int64).Value = sosvtd;
                    command.Parameters.Add("MADV", OracleDbType.Char).Value = madv;
                    

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Đã thêm thành công");
                        

                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }

                }

                catch 
                {   
                    if (maHP.Length > 8)
                    {
                        MessageBox.Show("Mã học phần quá dài !");
                    } else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    
                }
            }
        }
    }
}

