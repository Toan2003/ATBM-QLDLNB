namespace ATBM_PH2
{
    partial class fUpdateDept
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
            this.TENDV = new System.Windows.Forms.Label();
            this.MADV = new System.Windows.Forms.Label();
            this.txtTENDV = new System.Windows.Forms.TextBox();
            this.txtMADV = new System.Windows.Forms.TextBox();
            this.txtTRGDV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(187, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 30);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "Cập nhật";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TENDV
            // 
            this.TENDV.AutoSize = true;
            this.TENDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENDV.Location = new System.Drawing.Point(12, 73);
            this.TENDV.Name = "TENDV";
            this.TENDV.Size = new System.Drawing.Size(86, 20);
            this.TENDV.TabIndex = 34;
            this.TENDV.Text = "Tên đơn vị";
            // 
            // MADV
            // 
            this.MADV.AutoSize = true;
            this.MADV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MADV.Location = new System.Drawing.Point(12, 45);
            this.MADV.Name = "MADV";
            this.MADV.Size = new System.Drawing.Size(81, 20);
            this.MADV.TabIndex = 33;
            this.MADV.Text = "Mã đơn vị";
            // 
            // txtTENDV
            // 
            this.txtTENDV.Location = new System.Drawing.Point(147, 71);
            this.txtTENDV.Name = "txtTENDV";
            this.txtTENDV.Size = new System.Drawing.Size(299, 22);
            this.txtTENDV.TabIndex = 32;
            // 
            // txtMADV
            // 
            this.txtMADV.Location = new System.Drawing.Point(147, 43);
            this.txtMADV.Name = "txtMADV";
            this.txtMADV.Size = new System.Drawing.Size(299, 22);
            this.txtMADV.TabIndex = 31;
            // 
            // txtTRGDV
            // 
            this.txtTRGDV.Location = new System.Drawing.Point(147, 99);
            this.txtTRGDV.Name = "txtTRGDV";
            this.txtTRGDV.Size = new System.Drawing.Size(299, 22);
            this.txtTRGDV.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "Trưởng đơn vị";
            // 
            // fUpdateDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 191);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTRGDV);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.TENDV);
            this.Controls.Add(this.MADV);
            this.Controls.Add(this.txtTENDV);
            this.Controls.Add(this.txtMADV);
            this.Name = "fUpdateDept";
            this.Text = "Cập nhật đơn vị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label TENDV;
        private System.Windows.Forms.Label MADV;
        private System.Windows.Forms.TextBox txtTENDV;
        private System.Windows.Forms.TextBox txtMADV;
        private System.Windows.Forms.TextBox txtTRGDV;
        private System.Windows.Forms.Label label1;
    }
}