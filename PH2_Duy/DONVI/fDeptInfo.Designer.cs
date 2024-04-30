namespace ATBM_PH2
{
    partial class fDeptInfo
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
            this.btnInsertDept = new System.Windows.Forms.Button();
            this.btnUpdateDept = new System.Windows.Forms.Button();
            this.btnDeleteDept = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.homeIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(29, 111);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(585, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnInsertDept
            // 
            this.btnInsertDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertDept.Location = new System.Drawing.Point(260, 488);
            this.btnInsertDept.Name = "btnInsertDept";
            this.btnInsertDept.Size = new System.Drawing.Size(125, 33);
            this.btnInsertDept.TabIndex = 8;
            this.btnInsertDept.Text = "Thêm";
            this.btnInsertDept.UseVisualStyleBackColor = true;
            this.btnInsertDept.Click += new System.EventHandler(this.btnInsertDept_Click);
            // 
            // btnUpdateDept
            // 
            this.btnUpdateDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDept.Location = new System.Drawing.Point(391, 488);
            this.btnUpdateDept.Name = "btnUpdateDept";
            this.btnUpdateDept.Size = new System.Drawing.Size(125, 33);
            this.btnUpdateDept.TabIndex = 7;
            this.btnUpdateDept.Text = "Cập nhật";
            this.btnUpdateDept.UseVisualStyleBackColor = true;
            this.btnUpdateDept.Click += new System.EventHandler(this.btnUpdateDept_Click);
            // 
            // btnDeleteDept
            // 
            this.btnDeleteDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDept.Location = new System.Drawing.Point(129, 488);
            this.btnDeleteDept.Name = "btnDeleteDept";
            this.btnDeleteDept.Size = new System.Drawing.Size(125, 33);
            this.btnDeleteDept.TabIndex = 6;
            this.btnDeleteDept.Text = "Xóa";
            this.btnDeleteDept.UseVisualStyleBackColor = true;
            this.btnDeleteDept.Click += new System.EventHandler(this.btnDeleteDept_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 316);
            this.dataGridView1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Thông tin đơn vị";
            // 
            // homeIcon
            // 
            this.homeIcon.Image = global::PH2_Duy.Properties.Resources.icon_home;
            this.homeIcon.Location = new System.Drawing.Point(583, 12);
            this.homeIcon.Name = "homeIcon";
            this.homeIcon.Size = new System.Drawing.Size(47, 47);
            this.homeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeIcon.TabIndex = 20;
            this.homeIcon.TabStop = false;
            this.homeIcon.Click += new System.EventHandler(this.homeIcon_Click);
            // 
            // fDeptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 537);
            this.Controls.Add(this.homeIcon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnInsertDept);
            this.Controls.Add(this.btnUpdateDept);
            this.Controls.Add(this.btnDeleteDept);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fDeptInfo";
            this.Text = "Thông tin đơn vị";
            this.Load += new System.EventHandler(this.fDeptInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnInsertDept;
        private System.Windows.Forms.Button btnUpdateDept;
        private System.Windows.Forms.Button btnDeleteDept;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox homeIcon;
    }
}