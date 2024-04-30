namespace ATBM_PH2
{
    partial class ThemHP
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
            this.updateBtn = new System.Windows.Forms.Button();
            this.maDVCB = new System.Windows.Forms.ComboBox();
            this.soSVMaxNuM = new System.Windows.Forms.NumericUpDown();
            this.soTietTHNum = new System.Windows.Forms.NumericUpDown();
            this.soTietLTNum = new System.Windows.Forms.NumericUpDown();
            this.soTCNum = new System.Windows.Forms.NumericUpDown();
            this.tenHPTB = new System.Windows.Forms.TextBox();
            this.maHPTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soSVMaxNuM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soTietTHNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soTietLTNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soTCNum)).BeginInit();
            this.SuspendLayout();
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(189, 265);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(111, 28);
            this.updateBtn.TabIndex = 31;
            this.updateBtn.Text = "Thêm";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // maDVCB
            // 
            this.maDVCB.FormattingEnabled = true;
            this.maDVCB.Items.AddRange(new object[] {
            "VPK",
            "KHMT",
            "HTTT",
            "CNTT",
            "TGMT",
            "CNPM",
            "MMTVT"});
            this.maDVCB.Location = new System.Drawing.Point(189, 202);
            this.maDVCB.Name = "maDVCB";
            this.maDVCB.Size = new System.Drawing.Size(265, 24);
            this.maDVCB.TabIndex = 30;
            // 
            // soSVMaxNuM
            // 
            this.soSVMaxNuM.Location = new System.Drawing.Point(189, 174);
            this.soSVMaxNuM.Name = "soSVMaxNuM";
            this.soSVMaxNuM.Size = new System.Drawing.Size(265, 22);
            this.soSVMaxNuM.TabIndex = 29;
            // 
            // soTietTHNum
            // 
            this.soTietTHNum.Location = new System.Drawing.Point(189, 146);
            this.soTietTHNum.Name = "soTietTHNum";
            this.soTietTHNum.Size = new System.Drawing.Size(265, 22);
            this.soTietTHNum.TabIndex = 28;
            // 
            // soTietLTNum
            // 
            this.soTietLTNum.Location = new System.Drawing.Point(189, 118);
            this.soTietLTNum.Name = "soTietLTNum";
            this.soTietLTNum.Size = new System.Drawing.Size(265, 22);
            this.soTietLTNum.TabIndex = 27;
            // 
            // soTCNum
            // 
            this.soTCNum.Location = new System.Drawing.Point(189, 89);
            this.soTCNum.Name = "soTCNum";
            this.soTCNum.Size = new System.Drawing.Size(265, 22);
            this.soTCNum.TabIndex = 26;
            // 
            // tenHPTB
            // 
            this.tenHPTB.Location = new System.Drawing.Point(189, 61);
            this.tenHPTB.Name = "tenHPTB";
            this.tenHPTB.Size = new System.Drawing.Size(265, 22);
            this.tenHPTB.TabIndex = 25;
            // 
            // maHPTB
            // 
            this.maHPTB.Location = new System.Drawing.Point(189, 33);
            this.maHPTB.Name = "maHPTB";
            this.maHPTB.Size = new System.Drawing.Size(265, 22);
            this.maHPTB.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Mã đơn vị";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Số sinh viên tối đa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Số tiết thực hành";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Số tiết lí thuyết";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Số tín chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tên học phần";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã học phần";
            // 
            // ThemHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 318);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.maDVCB);
            this.Controls.Add(this.soSVMaxNuM);
            this.Controls.Add(this.soTietTHNum);
            this.Controls.Add(this.soTietLTNum);
            this.Controls.Add(this.soTCNum);
            this.Controls.Add(this.tenHPTB);
            this.Controls.Add(this.maHPTB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ThemHP";
            this.Text = "Thêm học phần";
            this.Load += new System.EventHandler(this.ThemHP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soSVMaxNuM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soTietTHNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soTietLTNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soTCNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.ComboBox maDVCB;
        private System.Windows.Forms.NumericUpDown soSVMaxNuM;
        private System.Windows.Forms.NumericUpDown soTietTHNum;
        private System.Windows.Forms.NumericUpDown soTietLTNum;
        private System.Windows.Forms.NumericUpDown soTCNum;
        private System.Windows.Forms.TextBox tenHPTB;
        private System.Windows.Forms.TextBox maHPTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}