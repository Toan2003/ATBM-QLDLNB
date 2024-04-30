namespace ATBM_PH2
{
    partial class CapNhatPC
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.magvCB = new System.Windows.Forms.ComboBox();
            this.mahpCB = new System.Windows.Forms.ComboBox();
            this.hkCB = new System.Windows.Forms.ComboBox();
            this.mactCB = new System.Windows.Forms.ComboBox();
            this.namNum = new System.Windows.Forms.NumericUpDown();
            this.updateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.namNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã giáo viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã học phần";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Học kì";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Năm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã chương trình";
            // 
            // magvCB
            // 
            this.magvCB.FormattingEnabled = true;
            this.magvCB.Location = new System.Drawing.Point(197, 53);
            this.magvCB.Name = "magvCB";
            this.magvCB.Size = new System.Drawing.Size(121, 24);
            this.magvCB.TabIndex = 6;
            this.magvCB.SelectedIndexChanged += new System.EventHandler(this.magvCB_SelectedIndexChanged);
            // 
            // mahpCB
            // 
            this.mahpCB.FormattingEnabled = true;
            this.mahpCB.Location = new System.Drawing.Point(197, 83);
            this.mahpCB.Name = "mahpCB";
            this.mahpCB.Size = new System.Drawing.Size(121, 24);
            this.mahpCB.TabIndex = 7;
            // 
            // hkCB
            // 
            this.hkCB.FormattingEnabled = true;
            this.hkCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.hkCB.Location = new System.Drawing.Point(197, 113);
            this.hkCB.Name = "hkCB";
            this.hkCB.Size = new System.Drawing.Size(121, 24);
            this.hkCB.TabIndex = 8;
            // 
            // mactCB
            // 
            this.mactCB.FormattingEnabled = true;
            this.mactCB.Items.AddRange(new object[] {
            "CLC",
            "CQ",
            "CTTT",
            "VP"});
            this.mactCB.Location = new System.Drawing.Point(197, 171);
            this.mactCB.Name = "mactCB";
            this.mactCB.Size = new System.Drawing.Size(121, 24);
            this.mactCB.TabIndex = 10;
            // 
            // namNum
            // 
            this.namNum.Location = new System.Drawing.Point(197, 143);
            this.namNum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.namNum.Name = "namNum";
            this.namNum.Size = new System.Drawing.Size(121, 22);
            this.namNum.TabIndex = 11;
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(118, 222);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(118, 29);
            this.updateBtn.TabIndex = 12;
            this.updateBtn.Text = "Cập nhật";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // CapNhatPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 274);
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
            this.Name = "CapNhatPC";
            this.Text = "Cập nhật phân công";
            this.Load += new System.EventHandler(this.CapNhatPC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.namNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox magvCB;
        private System.Windows.Forms.ComboBox mahpCB;
        private System.Windows.Forms.ComboBox hkCB;
        private System.Windows.Forms.ComboBox mactCB;
        private System.Windows.Forms.NumericUpDown namNum;
        private System.Windows.Forms.Button updateBtn;
    }
}