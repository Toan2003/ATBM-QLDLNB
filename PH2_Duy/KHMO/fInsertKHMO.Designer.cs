namespace ATBM_PH2
{
    partial class fInsertKHMO
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNAM = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.TENDV = new System.Windows.Forms.Label();
            this.MADV = new System.Windows.Forms.Label();
            this.cbHK = new System.Windows.Forms.ComboBox();
            this.cbMACT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMAHP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Năm";
            // 
            // txtNAM
            // 
            this.txtNAM.Location = new System.Drawing.Point(164, 97);
            this.txtNAM.Name = "txtNAM";
            this.txtNAM.Size = new System.Drawing.Size(299, 22);
            this.txtNAM.TabIndex = 36;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(200, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "Thêm";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TENDV
            // 
            this.TENDV.AutoSize = true;
            this.TENDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENDV.Location = new System.Drawing.Point(27, 71);
            this.TENDV.Name = "TENDV";
            this.TENDV.Size = new System.Drawing.Size(57, 20);
            this.TENDV.TabIndex = 34;
            this.TENDV.Text = "Học kì";
            // 
            // MADV
            // 
            this.MADV.AutoSize = true;
            this.MADV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MADV.Location = new System.Drawing.Point(27, 43);
            this.MADV.Name = "MADV";
            this.MADV.Size = new System.Drawing.Size(105, 20);
            this.MADV.TabIndex = 33;
            this.MADV.Text = "Mã học phần";
            // 
            // cbHK
            // 
            this.cbHK.FormattingEnabled = true;
            this.cbHK.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbHK.Location = new System.Drawing.Point(164, 69);
            this.cbHK.Name = "cbHK";
            this.cbHK.Size = new System.Drawing.Size(299, 24);
            this.cbHK.TabIndex = 38;
            // 
            // cbMACT
            // 
            this.cbMACT.FormattingEnabled = true;
            this.cbMACT.Items.AddRange(new object[] {
            "CLC",
            "CTTT",
            "VP",
            "CQ"});
            this.cbMACT.Location = new System.Drawing.Point(164, 125);
            this.cbMACT.Name = "cbMACT";
            this.cbMACT.Size = new System.Drawing.Size(299, 24);
            this.cbMACT.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Mã chương trình";
            // 
            // cbMAHP
            // 
            this.cbMAHP.FormattingEnabled = true;
            this.cbMAHP.Location = new System.Drawing.Point(164, 39);
            this.cbMAHP.Name = "cbMAHP";
            this.cbMAHP.Size = new System.Drawing.Size(299, 24);
            this.cbMAHP.TabIndex = 41;
            // 
            // fInsertKHMO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 223);
            this.Controls.Add(this.cbMAHP);
            this.Controls.Add(this.cbMACT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbHK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNAM);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.TENDV);
            this.Controls.Add(this.MADV);
            this.Name = "fInsertKHMO";
            this.Text = "Thêm kế hoạch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNAM;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label TENDV;
        private System.Windows.Forms.Label MADV;
        private System.Windows.Forms.ComboBox cbHK;
        private System.Windows.Forms.ComboBox cbMACT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMAHP;
    }
}