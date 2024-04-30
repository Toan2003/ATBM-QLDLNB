namespace ATBM_PH2
{
    partial class fKHMOInfo
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnInsertKHMO = new System.Windows.Forms.Button();
            this.btnUpdateKHMO = new System.Windows.Forms.Button();
            this.btnDeleteKHMO = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.homeIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(43, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(585, 22);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnInsertKHMO
            // 
            this.btnInsertKHMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertKHMO.Location = new System.Drawing.Point(267, 470);
            this.btnInsertKHMO.Name = "btnInsertKHMO";
            this.btnInsertKHMO.Size = new System.Drawing.Size(124, 31);
            this.btnInsertKHMO.TabIndex = 13;
            this.btnInsertKHMO.Text = "Thêm";
            this.btnInsertKHMO.UseVisualStyleBackColor = true;
            this.btnInsertKHMO.Click += new System.EventHandler(this.btnInsertKHMO_Click);
            // 
            // btnUpdateKHMO
            // 
            this.btnUpdateKHMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateKHMO.Location = new System.Drawing.Point(397, 470);
            this.btnUpdateKHMO.Name = "btnUpdateKHMO";
            this.btnUpdateKHMO.Size = new System.Drawing.Size(124, 31);
            this.btnUpdateKHMO.TabIndex = 12;
            this.btnUpdateKHMO.Text = "Cập nhật";
            this.btnUpdateKHMO.UseVisualStyleBackColor = true;
            this.btnUpdateKHMO.Click += new System.EventHandler(this.btnUpdateKHMO_Click);
            // 
            // btnDeleteKHMO
            // 
            this.btnDeleteKHMO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteKHMO.Location = new System.Drawing.Point(137, 470);
            this.btnDeleteKHMO.Name = "btnDeleteKHMO";
            this.btnDeleteKHMO.Size = new System.Drawing.Size(124, 31);
            this.btnDeleteKHMO.TabIndex = 11;
            this.btnDeleteKHMO.Text = "Xóa";
            this.btnDeleteKHMO.UseVisualStyleBackColor = true;
            this.btnDeleteKHMO.Click += new System.EventHandler(this.btnDeleteKHMO_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 316);
            this.dataGridView1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Thông tin kế hoạch";
            // 
            // homeIcon
            // 
            this.homeIcon.Image = global::PH2_Duy.Properties.Resources.icon_home;
            this.homeIcon.Location = new System.Drawing.Point(630, 12);
            this.homeIcon.Name = "homeIcon";
            this.homeIcon.Size = new System.Drawing.Size(47, 47);
            this.homeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeIcon.TabIndex = 21;
            this.homeIcon.TabStop = false;
            this.homeIcon.Click += new System.EventHandler(this.homeIcon_Click);
            // 
            // fKHMOInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 513);
            this.Controls.Add(this.homeIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnInsertKHMO);
            this.Controls.Add(this.btnUpdateKHMO);
            this.Controls.Add(this.btnDeleteKHMO);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fKHMOInfo";
            this.Text = "Thông tin kế hoạch";
            this.Load += new System.EventHandler(this.fKHMOInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnInsertKHMO;
        private System.Windows.Forms.Button btnUpdateKHMO;
        private System.Windows.Forms.Button btnDeleteKHMO;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox homeIcon;
    }
}