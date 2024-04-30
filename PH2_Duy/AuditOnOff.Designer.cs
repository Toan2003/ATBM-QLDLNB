namespace ATBM_PH2
{
    partial class AuditOnOff
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
            this.auditOnBtn = new System.Windows.Forms.Button();
            this.auditOffBtn = new System.Windows.Forms.Button();
            this.auditCreateBtn = new System.Windows.Forms.Button();
            this.xemAuditBtn = new System.Windows.Forms.Button();
            this.Auditing = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // auditOnBtn
            // 
            this.auditOnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auditOnBtn.Location = new System.Drawing.Point(41, 105);
            this.auditOnBtn.Name = "auditOnBtn";
            this.auditOnBtn.Size = new System.Drawing.Size(204, 70);
            this.auditOnBtn.TabIndex = 0;
            this.auditOnBtn.Text = "Bật audit hệ thống";
            this.auditOnBtn.UseVisualStyleBackColor = true;
            this.auditOnBtn.Click += new System.EventHandler(this.auditOnBtn_Click);
            // 
            // auditOffBtn
            // 
            this.auditOffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auditOffBtn.Location = new System.Drawing.Point(251, 105);
            this.auditOffBtn.Name = "auditOffBtn";
            this.auditOffBtn.Size = new System.Drawing.Size(204, 70);
            this.auditOffBtn.TabIndex = 1;
            this.auditOffBtn.Text = "Tắt audit hệ thống";
            this.auditOffBtn.UseVisualStyleBackColor = true;
            this.auditOffBtn.Click += new System.EventHandler(this.auditOffBtn_Click);
            // 
            // auditCreateBtn
            // 
            this.auditCreateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auditCreateBtn.Location = new System.Drawing.Point(251, 181);
            this.auditCreateBtn.Name = "auditCreateBtn";
            this.auditCreateBtn.Size = new System.Drawing.Size(204, 70);
            this.auditCreateBtn.TabIndex = 2;
            this.auditCreateBtn.Text = "Thêm audit chi tiết";
            this.auditCreateBtn.UseVisualStyleBackColor = true;
            this.auditCreateBtn.Click += new System.EventHandler(this.auditCreateBtn_Click);
            // 
            // xemAuditBtn
            // 
            this.xemAuditBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemAuditBtn.Location = new System.Drawing.Point(41, 181);
            this.xemAuditBtn.Name = "xemAuditBtn";
            this.xemAuditBtn.Size = new System.Drawing.Size(204, 70);
            this.xemAuditBtn.TabIndex = 3;
            this.xemAuditBtn.Text = "Xem chi tiết audit";
            this.xemAuditBtn.UseVisualStyleBackColor = true;
            this.xemAuditBtn.Click += new System.EventHandler(this.xemAuditBtn_Click);
            // 
            // Auditing
            // 
            this.Auditing.AutoSize = true;
            this.Auditing.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Auditing.Location = new System.Drawing.Point(177, 34);
            this.Auditing.Name = "Auditing";
            this.Auditing.Size = new System.Drawing.Size(127, 32);
            this.Auditing.TabIndex = 4;
            this.Auditing.Text = "Auditing";
            // 
            // AuditOnOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 293);
            this.Controls.Add(this.Auditing);
            this.Controls.Add(this.xemAuditBtn);
            this.Controls.Add(this.auditCreateBtn);
            this.Controls.Add(this.auditOffBtn);
            this.Controls.Add(this.auditOnBtn);
            this.Name = "AuditOnOff";
            this.Text = "Auditing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button auditOnBtn;
        private System.Windows.Forms.Button auditOffBtn;
        private System.Windows.Forms.Button auditCreateBtn;
        private System.Windows.Forms.Button xemAuditBtn;
        private System.Windows.Forms.Label Auditing;
    }
}