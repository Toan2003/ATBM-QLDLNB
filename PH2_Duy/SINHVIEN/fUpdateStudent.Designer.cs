namespace ATBM_PH2
{
    partial class fUpdateStudent
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
            this.btnOK = new System.Windows.Forms.Button();
            this.cbMANGANH = new System.Windows.Forms.ComboBox();
            this.cbMACT = new System.Windows.Forms.ComboBox();
            this.cbPHAI = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MSSV = new System.Windows.Forms.Label();
            this.txtDTBTL = new System.Windows.Forms.TextBox();
            this.txtSOTCTL = new System.Windows.Forms.TextBox();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.txtDCHI = new System.Windows.Forms.TextBox();
            this.txtHOTEN = new System.Windows.Forms.TextBox();
            this.txtMASV = new System.Windows.Forms.TextBox();
            this.dateTimePickerNGSINH = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(270, 329);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 29);
            this.btnOK.TabIndex = 44;
            this.btnOK.Text = "Cập nhật";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // cbMANGANH
            // 
            this.cbMANGANH.FormattingEnabled = true;
            this.cbMANGANH.Items.AddRange(new object[] {
            "VPK",
            "HTTT",
            "CNPM",
            "KHMT",
            "CNTT",
            "TGMT",
            "MMTVT"});
            this.cbMANGANH.Location = new System.Drawing.Point(202, 230);
            this.cbMANGANH.Name = "cbMANGANH";
            this.cbMANGANH.Size = new System.Drawing.Size(387, 24);
            this.cbMANGANH.TabIndex = 43;
            // 
            // cbMACT
            // 
            this.cbMACT.FormattingEnabled = true;
            this.cbMACT.Items.AddRange(new object[] {
            "CLC",
            "CQ",
            "CTTT",
            "VP"});
            this.cbMACT.Location = new System.Drawing.Point(202, 200);
            this.cbMACT.Name = "cbMACT";
            this.cbMACT.Size = new System.Drawing.Size(387, 24);
            this.cbMACT.TabIndex = 42;
            // 
            // cbPHAI
            // 
            this.cbPHAI.FormattingEnabled = true;
            this.cbPHAI.Items.AddRange(new object[] {
            "NAM",
            "NU"});
            this.cbPHAI.Location = new System.Drawing.Point(202, 89);
            this.cbPHAI.Name = "cbPHAI";
            this.cbPHAI.Size = new System.Drawing.Size(387, 24);
            this.cbPHAI.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Điểm TB tích lũy";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Số tín chỉ túy lũy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(48, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Mã ngành";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(48, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Mã chương trình";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "Điện thoại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Ngày sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Họ tên";
            // 
            // MSSV
            // 
            this.MSSV.AutoSize = true;
            this.MSSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSSV.Location = new System.Drawing.Point(48, 34);
            this.MSSV.Name = "MSSV";
            this.MSSV.Size = new System.Drawing.Size(56, 20);
            this.MSSV.TabIndex = 31;
            this.MSSV.Text = "MSSV";
            // 
            // txtDTBTL
            // 
            this.txtDTBTL.Location = new System.Drawing.Point(202, 284);
            this.txtDTBTL.Name = "txtDTBTL";
            this.txtDTBTL.Size = new System.Drawing.Size(387, 22);
            this.txtDTBTL.TabIndex = 30;
            // 
            // txtSOTCTL
            // 
            this.txtSOTCTL.Location = new System.Drawing.Point(202, 256);
            this.txtSOTCTL.Name = "txtSOTCTL";
            this.txtSOTCTL.Size = new System.Drawing.Size(387, 22);
            this.txtSOTCTL.TabIndex = 29;
            // 
            // txtDT
            // 
            this.txtDT.Location = new System.Drawing.Point(202, 172);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(387, 22);
            this.txtDT.TabIndex = 28;
            // 
            // txtDCHI
            // 
            this.txtDCHI.Location = new System.Drawing.Point(202, 144);
            this.txtDCHI.Name = "txtDCHI";
            this.txtDCHI.Size = new System.Drawing.Size(387, 22);
            this.txtDCHI.TabIndex = 27;
            // 
            // txtHOTEN
            // 
            this.txtHOTEN.Location = new System.Drawing.Point(202, 60);
            this.txtHOTEN.Name = "txtHOTEN";
            this.txtHOTEN.Size = new System.Drawing.Size(387, 22);
            this.txtHOTEN.TabIndex = 25;
            // 
            // txtMASV
            // 
            this.txtMASV.Location = new System.Drawing.Point(202, 32);
            this.txtMASV.Name = "txtMASV";
            this.txtMASV.Size = new System.Drawing.Size(387, 22);
            this.txtMASV.TabIndex = 24;
            // 
            // dateTimePickerNGSINH
            // 
            this.dateTimePickerNGSINH.Location = new System.Drawing.Point(202, 122);
            this.dateTimePickerNGSINH.Name = "dateTimePickerNGSINH";
            this.dateTimePickerNGSINH.Size = new System.Drawing.Size(387, 22);
            this.dateTimePickerNGSINH.TabIndex = 45;
            // 
            // fUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 383);
            this.Controls.Add(this.dateTimePickerNGSINH);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbMANGANH);
            this.Controls.Add(this.cbMACT);
            this.Controls.Add(this.cbPHAI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MSSV);
            this.Controls.Add(this.txtDTBTL);
            this.Controls.Add(this.txtSOTCTL);
            this.Controls.Add(this.txtDT);
            this.Controls.Add(this.txtDCHI);
            this.Controls.Add(this.txtHOTEN);
            this.Controls.Add(this.txtMASV);
            this.Name = "fUpdateStudent";
            this.Text = "Cập nhật thông tin sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbMANGANH;
        private System.Windows.Forms.ComboBox cbMACT;
        private System.Windows.Forms.ComboBox cbPHAI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MSSV;
        private System.Windows.Forms.TextBox txtDTBTL;
        private System.Windows.Forms.TextBox txtSOTCTL;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.TextBox txtDCHI;
        private System.Windows.Forms.TextBox txtHOTEN;
        private System.Windows.Forms.TextBox txtMASV;
        private System.Windows.Forms.DateTimePicker dateTimePickerNGSINH;
    }
}