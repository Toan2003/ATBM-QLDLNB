using ATBM_PH2;
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

namespace PH2_Duy
{
    public partial class CapNhatNV : Form
    {
        String manv, hoten, phai, ngsinh, phucap, dt, vaitro, madv;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string connectionString = AppConfig.connectionString;
        private void updateBtn_Click(object sender, EventArgs e)
        {
            manv = manvTB.Text;
            hoten = hotenTB.Text;
            phai = comboBox1.SelectedItem.ToString();
            DateTime ngsinh2 = dateTimePicker1.Value.Date;
            phucap = pcTB.Text;
            dt = dienthoai.Text;
            vaitro = vtCB.SelectedItem.ToString();
            madv = madvCB.SelectedItem.ToString();
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE ADMIN.NHANSU " +
                    "SET HOTEN=:HOTEN, PHAI=:PHAI, NGSINH=:NGSINH, PHUCAP=:PHUCAP, DT=:DT,VAITRO=:VAITRO, MADV=:MADV " +
                    "WHERE MANV=:MANV";
                OracleCommand command = new OracleCommand(query, connection);

                // Thêm các parameter cho lệnh INSERT
               
                command.Parameters.Add("HOTEN", OracleDbType.NVarchar2).Value = hoten;
                command.Parameters.Add("PHAI", OracleDbType.Char).Value = phai;
                command.Parameters.Add("NGSINH", OracleDbType.Date).Value = ngsinh2;
                command.Parameters.Add("PHUCAP", OracleDbType.Double).Value = float.Parse(phucap);
                command.Parameters.Add("DT", OracleDbType.Char).Value = dt;
                command.Parameters.Add("VAITRO", OracleDbType.NVarchar2).Value = vaitro;
                command.Parameters.Add("MADV", OracleDbType.Char).Value = madv;
                command.Parameters.Add("MANV", OracleDbType.Char).Value = manv; 
                MessageBox.Show(manv + hoten + phai +" " +ngsinh2 +" "+ phucap + dt + vaitro + madv);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data inserted successfully!");
                }
                else
                {
                    MessageBox.Show("Data insertion failed.");
                }
            }
        }

        String manvChange;
        public CapNhatNV(String manv, String hoten, String phai,String ngsinh, String phucap,String dt, String vaitro, String madv)
        {
            InitializeComponent();
            this.manv = manv;
            this.hoten = hoten;
            this.phai = phai;  
            this.ngsinh = ngsinh;
            this.phucap = phucap;
            this.dt = dt;
            this.vaitro = vaitro;
            this.madv = madv;
           
            manvTB.Text = manv;
            hotenTB.Text = hoten;
            //comboBox1.Text = phai;
            comboBox1.SelectedItem = phai;
            dateTimePicker1.Value = DateTime.Parse(ngsinh);
            pcTB.Text = phucap;
            dienthoai.Text = dt;
            //vtCB.Text = vaitro;
            vtCB.SelectedItem = vaitro;
            //madvCB.Text = madv;
            madvCB.SelectedItem = madv;
        

        }

        private void manvTB_TextChanged(object sender, EventArgs e)
        {

        }
        public void LayDS()
        {
            
            
            
        }
    }
}
