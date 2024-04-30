namespace ATBM_PH2
{
    partial class ThemAudit
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
            this.cbTableName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.themBtn = new System.Windows.Forms.Button();
            this.radioSuccess = new System.Windows.Forms.RadioButton();
            this.radioNSuccess = new System.Windows.Forms.RadioButton();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm Audit";
            // 
            // cbTableName
            // 
            this.cbTableName.FormattingEnabled = true;
            this.cbTableName.Location = new System.Drawing.Point(46, 129);
            this.cbTableName.Name = "cbTableName";
            this.cbTableName.Size = new System.Drawing.Size(307, 24);
            this.cbTableName.TabIndex = 1;
            this.cbTableName.SelectedIndexChanged += new System.EventHandler(this.cbTableName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên bảng/view/procedure/function";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Action";
            // 
            // cbAction
            // 
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Items.AddRange(new object[] {
            "SELECT",
            "UPDATE",
            "INSERT",
            "DELETE"});
            this.cbAction.Location = new System.Drawing.Point(46, 205);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(307, 24);
            this.cbAction.TabIndex = 10;
            // 
            // themBtn
            // 
            this.themBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themBtn.Location = new System.Drawing.Point(87, 370);
            this.themBtn.Name = "themBtn";
            this.themBtn.Size = new System.Drawing.Size(109, 29);
            this.themBtn.TabIndex = 11;
            this.themBtn.Text = "Thêm";
            this.themBtn.UseVisualStyleBackColor = true;
            this.themBtn.Click += new System.EventHandler(this.themBtn_Click);
            // 
            // radioSuccess
            // 
            this.radioSuccess.AutoSize = true;
            this.radioSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSuccess.Location = new System.Drawing.Point(46, 262);
            this.radioSuccess.Name = "radioSuccess";
            this.radioSuccess.Size = new System.Drawing.Size(244, 24);
            this.radioSuccess.TabIndex = 15;
            this.radioSuccess.TabStop = true;
            this.radioSuccess.Text = "WHENEVER SUCCESSFUL";
            this.radioSuccess.UseVisualStyleBackColor = true;
            this.radioSuccess.Click += new System.EventHandler(this.radioSuccess_Click);
            // 
            // radioNSuccess
            // 
            this.radioNSuccess.AutoSize = true;
            this.radioNSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNSuccess.Location = new System.Drawing.Point(46, 303);
            this.radioNSuccess.Name = "radioNSuccess";
            this.radioNSuccess.Size = new System.Drawing.Size(284, 24);
            this.radioNSuccess.TabIndex = 16;
            this.radioNSuccess.TabStop = true;
            this.radioNSuccess.Text = "WHENEVER NOT SUCCESSFUL";
            this.radioNSuccess.UseVisualStyleBackColor = true;
            this.radioNSuccess.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioNSuccess.Click += new System.EventHandler(this.radioNSuccess_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(202, 370);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(109, 29);
            this.btnHuy.TabIndex = 17;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // ThemAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 429);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.radioNSuccess);
            this.Controls.Add(this.radioSuccess);
            this.Controls.Add(this.themBtn);
            this.Controls.Add(this.cbAction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTableName);
            this.Controls.Add(this.label1);
            this.Name = "ThemAudit";
            this.Text = "Thêm audit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAction;
        private System.Windows.Forms.Button themBtn;
        private System.Windows.Forms.RadioButton radioSuccess;
        private System.Windows.Forms.RadioButton radioNSuccess;
        private System.Windows.Forms.Button btnHuy;
    }
}