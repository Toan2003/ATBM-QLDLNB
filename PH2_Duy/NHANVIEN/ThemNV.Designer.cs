namespace ATBM_PH2
{
    partial class ThemNV
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
            this.label2 = new System.Windows.Forms.Label();
            this.manv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.vaitro = new System.Windows.Forms.ComboBox();
            this.madv = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên";
            // 
            // manv
            // 
            this.manv.Location = new System.Drawing.Point(188, 37);
            this.manv.Name = "manv";
            this.manv.Size = new System.Drawing.Size(224, 22);
            this.manv.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Họ và tên";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // hoten
            // 
            this.hoten.Location = new System.Drawing.Point(188, 65);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(224, 22);
            this.hoten.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phái";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Phụ cấp";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Vai trò";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(43, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Mã đơn vị";
            // 
            // phai
            // 
            this.phai.FormattingEnabled = true;
            this.phai.Items.AddRange(new object[] {
            "NAM",
            "NU"});
            this.phai.Location = new System.Drawing.Point(188, 93);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(224, 24);
            this.phai.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(188, 123);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 22);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(188, 179);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(224, 22);
            this.textBox3.TabIndex = 14;
            // 
            // vaitro
            // 
            this.vaitro.FormattingEnabled = true;
            this.vaitro.Items.AddRange(new object[] {
            "TRUONG KHOA",
            "TRUONG DON VI",
            "NHAN VIEN CO BAN",
            "GIAO VU",
            "GIANG VIEN"});
            this.vaitro.Location = new System.Drawing.Point(188, 207);
            this.vaitro.Name = "vaitro";
            this.vaitro.Size = new System.Drawing.Size(224, 24);
            this.vaitro.TabIndex = 15;
            // 
            // madv
            // 
            this.madv.FormattingEnabled = true;
            this.madv.Items.AddRange(new object[] {
            "VPK",
            "HTTT",
            "CNPM",
            "KHMT",
            "CNTT",
            "TGMT",
            "MMTVT"});
            this.madv.Location = new System.Drawing.Point(188, 237);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(224, 24);
            this.madv.TabIndex = 16;
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(188, 292);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(98, 27);
            this.Save.TabIndex = 17;
            this.Save.Text = "Thêm";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 22);
            this.textBox1.TabIndex = 18;
            // 
            // ThemNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 348);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.vaitro);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manv);
            this.Controls.Add(this.label2);
            this.Name = "ThemNV";
            this.Text = "Thêm nhân sự";
            this.Load += new System.EventHandler(this.ThemNV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox manv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hoten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox phai;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox vaitro;
        private System.Windows.Forms.ComboBox madv;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox textBox1;
    }
}