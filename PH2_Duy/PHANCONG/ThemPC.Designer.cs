namespace ATBM_PH2
{
    partial class ThemPC
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
            this.namNum = new System.Windows.Forms.NumericUpDown();
            this.mactCB = new System.Windows.Forms.ComboBox();
            this.hkCB = new System.Windows.Forms.ComboBox();
            this.mahpCB = new System.Windows.Forms.ComboBox();
            this.magvCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.namNum)).BeginInit();
            this.SuspendLayout();
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(198, 206);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(100, 29);
            this.updateBtn.TabIndex = 24;
            this.updateBtn.Text = "Thêm";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // namNum
            // 
            this.namNum.Location = new System.Drawing.Point(198, 128);
            this.namNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.namNum.Name = "namNum";
            this.namNum.Size = new System.Drawing.Size(234, 22);
            this.namNum.TabIndex = 23;
            // 
            // mactCB
            // 
            this.mactCB.FormattingEnabled = true;
            this.mactCB.Items.AddRange(new object[] {
            "CLC",
            "CQ",
            "CTTT",
            "VP"});
            this.mactCB.Location = new System.Drawing.Point(198, 156);
            this.mactCB.Name = "mactCB";
            this.mactCB.Size = new System.Drawing.Size(234, 24);
            this.mactCB.TabIndex = 22;
            // 
            // hkCB
            // 
            this.hkCB.FormattingEnabled = true;
            this.hkCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.hkCB.Location = new System.Drawing.Point(198, 98);
            this.hkCB.Name = "hkCB";
            this.hkCB.Size = new System.Drawing.Size(234, 24);
            this.hkCB.TabIndex = 21;
            // 
            // mahpCB
            // 
            this.mahpCB.FormattingEnabled = true;
            this.mahpCB.Location = new System.Drawing.Point(198, 68);
            this.mahpCB.Name = "mahpCB";
            this.mahpCB.Size = new System.Drawing.Size(234, 24);
            this.mahpCB.TabIndex = 20;
            // 
            // magvCB
            // 
            this.magvCB.FormattingEnabled = true;
            this.magvCB.Location = new System.Drawing.Point(198, 38);
            this.magvCB.Name = "magvCB";
            this.magvCB.Size = new System.Drawing.Size(234, 24);
            this.magvCB.TabIndex = 19;
            this.magvCB.SelectedIndexChanged += new System.EventHandler(this.magvCB_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mã chương trình";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Học kì";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mã học phần";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã giáo viên";
            // 
            // ThemPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 268);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.namNum);
            this.Controls.Add(this.mactCB);
            this.Controls.Add(this.hkCB);
            this.Controls.Add(this.mahpCB);
            this.Controls.Add(this.magvCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ThemPC";
            this.Text = "Thêm phân công";
            this.Load += new System.EventHandler(this.ThemPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.NumericUpDown namNum;
        private System.Windows.Forms.ComboBox mactCB;
        private System.Windows.Forms.ComboBox hkCB;
        private System.Windows.Forms.ComboBox mahpCB;
        private System.Windows.Forms.ComboBox magvCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}