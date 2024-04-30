using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class fAddNotification : Form
    {
        private Boolean ExecuteProcedure(string NameOfProcedure, params object[] args)
        {
            using (OracleConnection connection = new OracleConnection(AppConfig.connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = NameOfProcedure;

                        // Tạo parameter cho stored procedure

                        foreach (object o in args)
                        {
                            if (o is string)
                            {
                                command.Parameters.Add(o.ToString(), OracleDbType.Varchar2, ParameterDirection.Input).Value = (string)o;
                            }
                            else
                            {
                                //MessageBox.Show(o.ToString());
                                command.Parameters.Add(o.ToString(), OracleDbType.Int32, ParameterDirection.Input).Value = o;
                            }
                        }
                        //command.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                        //MessageBox.Show(command.Parameters[2].Value + "");
                        command.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
                catch //(Exception ex)
                {
                    //MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        public fAddNotification()
        {
            InitializeComponent();
            checkedListBox1.ItemCheck += CheckedListBox_ItemCheck;
        }

        private void fAddNotification_Load(object sender, EventArgs e)
        {
            
        }
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Iterate through each item in the CheckedListBox
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                // If the current item is not the item being checked
                if (i != e.Index)
                {
                    // Uncheck it
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("Hãy nhập nội dung thông báo");
                return;
            }
            List<string> selectedCS = new List<string>();
            List<string> selectedLV = new List<string>();
            List<string> selectedLVHD = new List<string>();
            // level
            foreach (int selectedIndex in checkedListBox1.CheckedIndices)
            {
                string value = checkedListBox1.Items[selectedIndex].ToString();
                selectedLV.Add(value);
            }
            // coso - group
            foreach (int selectedIndex in checkedListBox2.CheckedIndices)
            {
                string value = checkedListBox2.Items[selectedIndex].ToString();
                selectedCS.Add(value);
            }
            // linhvuc - compartments
            foreach (int selectedIndex in checkedListBox3.CheckedIndices)
            {
                string value = checkedListBox3.Items[selectedIndex].ToString();
                selectedLVHD.Add(value);
            }
            if (selectedLV.Count <= 0)
            {
                MessageBox.Show("Hãy chọn cấp bậc");
                return;
            }
            var hashCS = new Dictionary<string, string>
            {
                { "Cơ sở 1", "CS1" },
                { "Cơ sở 2", "CS2" }
            };
            var hashLV = new Dictionary<string, string>
            {
                { "Trưởng khoa", "TK" },
                { "Trưởng đơn vị", "TDV" },
                { "Giảng viên", "GVI" },
                { "Giáo vụ", "GVU" },
                { "Nhân viên", "NV" },
                { "Sinh viên", "SV" }
            };

            string label = hashLV[selectedLV[0].ToString()];
            if (selectedLVHD.Count > 0)
            {
                label = label + ":";
                for (int i = 0; i < selectedLVHD.Count-1; i++)
                {
                    label = label +selectedLVHD[i].ToString() +",";
                }
                label = label + selectedLVHD[selectedLVHD.Count - 1].ToString();
            }
            if (selectedCS.Count >0)
            {
                if (selectedLVHD.Count >0)
                {
                    label = label + ":";
                    for (int i = 0; i < selectedCS.Count-1; i++)
                    {
                        label = label  + hashCS[selectedCS[i].ToString()] + ",";
                    }
                } else
                {
                    label = label + "::";
                    for (int i = 0; i < selectedCS.Count - 1; i++)
                    {
                        label = label  + hashCS[selectedCS[i].ToString()] + ",";
                    }
                }
                label = label + hashCS[selectedCS[selectedCS.Count - 1].ToString()];
            }
            //MessageBox.Show(label);
            //Boolean isTrue = ExecuteProcedure("ADMIN_OLS.CreateDataLabelOLS", label);
            //if (!isTrue)
            //{
            //    MessageBox.Show("Không thể tạo nhãn");
            //}
            Boolean isTrue = ExecuteProcedure("ADMIN_OLS.ThemThongBao", textBox1.Text.ToString(), label);
            if (isTrue)
            {
                MessageBox.Show("Thành công");
            }
            //MessageBox.Show(label);
        }
    }
}
