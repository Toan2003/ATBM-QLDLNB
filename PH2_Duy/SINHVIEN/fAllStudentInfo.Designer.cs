namespace ATBM_PH2
{
    partial class fAllStudentInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnInsertStudent = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.homeIcon = new System.Windows.Forms.PictureBox();
            this.btnUpdateDiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(970, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStudent.Location = new System.Drawing.Point(381, 517);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(132, 31);
            this.btnDeleteStudent.TabIndex = 1;
            this.btnDeleteStudent.Text = "Xóa";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click_1);
            // 
            // btnInsertStudent
            // 
            this.btnInsertStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertStudent.Location = new System.Drawing.Point(519, 517);
            this.btnInsertStudent.Name = "btnInsertStudent";
            this.btnInsertStudent.Size = new System.Drawing.Size(132, 31);
            this.btnInsertStudent.TabIndex = 3;
            this.btnInsertStudent.Text = "Thêm";
            this.btnInsertStudent.UseVisualStyleBackColor = true;
            this.btnInsertStudent.Click += new System.EventHandler(this.btnInsertStudent_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(22, 90);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(970, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thông tin sinh viên";
            // 
            // homeIcon
            // 
            this.homeIcon.Image = global::PH2_Duy.Properties.Resources.icon_home;
            this.homeIcon.Location = new System.Drawing.Point(945, 12);
            this.homeIcon.Name = "homeIcon";
            this.homeIcon.Size = new System.Drawing.Size(47, 47);
            this.homeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeIcon.TabIndex = 20;
            this.homeIcon.TabStop = false;
            this.homeIcon.Click += new System.EventHandler(this.homeIcon_Click);
            // 
            // btnUpdateDiem
            // 
            this.btnUpdateDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDiem.Location = new System.Drawing.Point(409, 517);
            this.btnUpdateDiem.Name = "btnUpdateDiem";
            this.btnUpdateDiem.Size = new System.Drawing.Size(221, 31);
            this.btnUpdateDiem.TabIndex = 21;
            this.btnUpdateDiem.Text = "Cập nhật điểm";
            this.btnUpdateDiem.UseVisualStyleBackColor = true;
            this.btnUpdateDiem.Click += new System.EventHandler(this.btnUpdateDiem_Click);
            // 
            // fAllStudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 578);
            this.Controls.Add(this.btnUpdateDiem);
            this.Controls.Add(this.homeIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnInsertStudent);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fAllStudentInfo";
            this.Text = "Thông tin sinh viên";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnInsertStudent;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox homeIcon;
        private System.Windows.Forms.Button btnUpdateDiem;
    }
}