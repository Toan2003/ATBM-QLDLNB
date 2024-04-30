namespace ATBM_PH2
{
    partial class fInsertDept
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTRGDV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(220, 145);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 29);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "Thêm";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TENDV
            // 
            this.TENDV.AutoSize = true;
            this.TENDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENDV.Location = new System.Drawing.Point(21, 59);
            this.TENDV.Name = "TENDV";
            this.TENDV.Size = new System.Drawing.Size(86, 20);
            this.TENDV.TabIndex = 27;
            this.TENDV.Text = "Tên đơn vị";
            // 
            // MADV
            // 
            this.MADV.AutoSize = true;
            this.MADV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MADV.Location = new System.Drawing.Point(21, 31);
            this.MADV.Name = "MADV";
            this.MADV.Size = new System.Drawing.Size(81, 20);
            this.MADV.TabIndex = 26;
            this.MADV.Text = "Mã đơn vị";
            // 
            // txtTENDV
            // 
            this.txtTENDV.Location = new System.Drawing.Point(156, 59);
            this.txtTENDV.Name = "txtTENDV";
            this.txtTENDV.Size = new System.Drawing.Size(299, 22);
            this.txtTENDV.TabIndex = 25;
            // 
            // txtMADV
            // 
            this.txtMADV.Location = new System.Drawing.Point(156, 31);
            this.txtMADV.Name = "txtMADV";
            this.txtMADV.Size = new System.Drawing.Size(299, 22);
            this.txtMADV.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "Trưởng đơn vị";
            // 
            // txtTRGDV
            // 
            this.txtTRGDV.Location = new System.Drawing.Point(156, 87);
            this.txtTRGDV.Name = "txtTRGDV";
            this.txtTRGDV.Size = new System.Drawing.Size(299, 22);
            this.txtTRGDV.TabIndex = 38;
            // 
            // fInsertDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTRGDV);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.TENDV);
            this.Controls.Add(this.MADV);
            this.Controls.Add(this.txtTENDV);
            this.Controls.Add(this.txtMADV);
            this.Name = "fInsertDept";
            this.Text = "Thêm đơn vị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label TENDV;
        private System.Windows.Forms.Label MADV;
        private System.Windows.Forms.TextBox txtTENDV;
        private System.Windows.Forms.TextBox txtMADV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTRGDV;
    }
}