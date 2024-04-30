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
    public partial class XemHP_NV : Form
    {
        private string connectionString = AppConfig.connectionString;
        private CapNhatHP_GVu form;
        OracleDataAdapter adapter;
        BindingSource source = new BindingSource();
        public Form baseForm;
        public XemHP_NV(Form baseForm)
        {
            InitializeComponent();
            CheckUserRole();
            LayDSHP();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.baseForm = baseForm;
            this.FormClosing += XemHP_NV_FormClosing;
            
        }

        private void CheckUserRole()
        {
            // Kiểm tra xem người dùng có vai trò "GIAO_VU" hay không
            if (Array.Exists(AppConfig.UserRoles, role => role == "GIAOVU"))
            {
                xoaBtn.Visible = true;
                themBtn.Visible = true;
                updateBtn.Visible = true;
            }
            else
            {
                xoaBtn.Visible = false;
                themBtn.Visible = false;
                updateBtn.Visible = false;
            }
        }
        private void XemHP_NV_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem form đang được đóng do người dùng tác động hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Chuyển về form DashBoardNV
                DashBoardNV dashBoard = new DashBoardNV();
                dashBoard.Show();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LayDSHP()
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT * from ADMIN.HOCPHAN";
                    OracleCommand command = new OracleCommand(query, connection);
                   
                    DataTable dataTable = new DataTable();
                    adapter = new OracleDataAdapter(command);
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu lên DataGridView
                    
                    source.DataSource = dataTable;
                    dataGridView1.DataSource = source;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            
        }
        public void Subscribe(CapNhatHP_GVu form)
        {
            form.UpdateEvent += HandleUpdateEvent;
            
        }
        private void HandleUpdateEvent(object sender, EventArgs e)
        {
           

            

        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string columnName = "MAHP";
                var value = selectedRow.Cells[columnName].Value.ToString();

                form = new CapNhatHP_GVu(value, baseForm);
                form.ShowDialog();
                LayDSHP();
  
            }
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            String mahp = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string columnName = "MAHP";
                mahp = selectedRow.Cells[columnName].Value.ToString();

            }
            else return;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "DELETE from ADMIN.HOCPHAN WHERE MAHP=:MAHP";
                    OracleCommand command = new OracleCommand(query, connection);

                    command.Parameters.Add("MAHP", OracleDbType.Char).Value = mahp;
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại thành công !");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            LayDSHP();
        }

        private void themBtn_Click(object sender, EventArgs e)
        {
            ThemHP themhp = new ThemHP();
            themhp.ShowDialog();
            LayDSHP();
        }

        private void XemHP_NV_Load(object sender, EventArgs e)
        {

        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            this.baseForm.Show();
            this.Dispose();
        }
    }
}
