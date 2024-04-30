using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class CapNhatHP_GVu : Form
    {
        private string connectionString = AppConfig.connectionString;

        private string maHP;
        private string maHPChange;
        private string tenHocPhan = "", madv = "";
        private int soTC = 0, stlt = 0, stth = 0, sosvtd = 0;
        public delegate void UpdateEventHandler(object sender, EventArgs e);
        public event UpdateEventHandler UpdateEvent;
        private XemHP_NV xemhpnv;
        public Form baseForm;

        private void CapNhatHP_GVu_Load(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE ADMIN.HOCPHAN " +
                                   "SET MAHP=:MAHPCHANGE, TENHP=:TENHP, SOTC=:SOTC, STLT=:STLT, " +
                                   "STTH=:STTH, SOSVTD=:SOSVTD, MADV=:MADV " +
                                   "WHERE MAHP=:MAHP" ;
                    OracleCommand command = new OracleCommand(query, connection);

                    maHPChange = maHPTB.Text;
                    tenHocPhan = tenHPTB.Text;
                    soTC = (int) soTCNum.Value;
                    stlt = (int) soTietLTNum.Value;
                    stth = (int) soTietTHNum.Value;
                    sosvtd = (int) soSVMaxNuM.Value;
                    madv = maDVCB.SelectedItem.ToString();

                    command.Parameters.Add("MAHPCHANGE", OracleDbType.Char).Value = maHPChange;
                    command.Parameters.Add("TENHP", OracleDbType.NVarchar2).Value = tenHocPhan;
                    command.Parameters.Add("SOTC", OracleDbType.Int64).Value = soTC;
                    command.Parameters.Add("STLT", OracleDbType.Int64).Value = stlt;
                    command.Parameters.Add("STTH", OracleDbType.Int64).Value = stth;
                    command.Parameters.Add("SOSVTD", OracleDbType.Int64).Value = sosvtd;
                    command.Parameters.Add("MADV", OracleDbType.Char).Value = madv;
                    command.Parameters.Add("MAHP", OracleDbType.Char).Value = maHP;
                   
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Đã cập nhật thành công");
                        UpdateEvent?.Invoke(this, e);

                    }
                    else { 
                        MessageBox.Show("Không có học phần được cập nhật"); 
                    }

                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }    
        }

        public CapNhatHP_GVu(string maHP, Form baseForm)
        {
            InitializeComponent();
            this.maHP = maHP;
            LayTTHP();
            xemhpnv = new XemHP_NV(baseForm);
            xemhpnv.Subscribe(this);

        }

        private void maHPTB_TextChanged(object sender, EventArgs e)
        {

        }
        public void LayTTHP()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                   
                    string query = "SELECT * FROM ADMIN.HOCPHAN WHERE MAHP = :MAHP";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("MAHP", OracleDbType.Char).Value = maHP;

                        // Thực thi truy vấn bằng OracleDataReader
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                // Lấy dữ liệu từ reader
                                if (!reader.IsDBNull(reader.GetOrdinal("TENHP")))
                                {
                                    tenHocPhan = reader["TENHP"].ToString();
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("SOTC")))
                                {
                                    soTC = reader.GetInt32(reader.GetOrdinal("SOTC"));
                                }
                                if (!reader.IsDBNull(reader.GetOrdinal("STLT")))
                                {
                                    stlt = reader.GetInt32(reader.GetOrdinal("STLT"));
                                }
                                if (!reader.IsDBNull(reader.GetOrdinal("STTH")))
                                {
                                    stth = reader.GetInt32(reader.GetOrdinal("STTH"));
                                }
                                if (!reader.IsDBNull(reader.GetOrdinal("SOSVTD")))
                                {
                                    sosvtd = reader.GetInt32(reader.GetOrdinal("SOSVTD"));
                                }
                                if (!reader.IsDBNull(reader.GetOrdinal("MADV")))
                                {
                                    madv = reader["MADV"].ToString();
                                }
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            maHPTB.Text = maHP;
            tenHPTB.Text = tenHocPhan;
            soTCNum.Value = soTC;
            soTietLTNum.Value = stlt;
            soTietTHNum.Value = stth;
            soSVMaxNuM.Value = sosvtd;
            maDVCB.SelectedItem = madv.Trim();
        }
    }
}
