namespace ATBM_PH2
{
    partial class XemHP_NV
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.xoaBtn = new System.Windows.Forms.Button();
            this.themBtn = new System.Windows.Forms.Button();
            this.homeIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(477, 400);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(134, 28);
            this.updateBtn.TabIndex = 5;
            this.updateBtn.Text = "Cập nhật";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(746, 305);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh sách học phần";
            // 
            // xoaBtn
            // 
            this.xoaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoaBtn.Location = new System.Drawing.Point(187, 400);
            this.xoaBtn.Name = "xoaBtn";
            this.xoaBtn.Size = new System.Drawing.Size(134, 28);
            this.xoaBtn.TabIndex = 6;
            this.xoaBtn.Text = "Xóa";
            this.xoaBtn.UseVisualStyleBackColor = true;
            this.xoaBtn.Click += new System.EventHandler(this.xoaBtn_Click);
            // 
            // themBtn
            // 
            this.themBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themBtn.Location = new System.Drawing.Point(333, 400);
            this.themBtn.Name = "themBtn";
            this.themBtn.Size = new System.Drawing.Size(134, 28);
            this.themBtn.TabIndex = 7;
            this.themBtn.Text = "Thêm";
            this.themBtn.UseVisualStyleBackColor = true;
            this.themBtn.Click += new System.EventHandler(this.themBtn_Click);
            // 
            // homeIcon
            // 
            this.homeIcon.Image = global::PH2_Duy.Properties.Resources.icon_home;
            this.homeIcon.Location = new System.Drawing.Point(741, 12);
            this.homeIcon.Name = "homeIcon";
            this.homeIcon.Size = new System.Drawing.Size(47, 47);
            this.homeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeIcon.TabIndex = 21;
            this.homeIcon.TabStop = false;
            this.homeIcon.Click += new System.EventHandler(this.homeIcon_Click);
            // 
            // XemHP_NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.homeIcon);
            this.Controls.Add(this.themBtn);
            this.Controls.Add(this.xoaBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "XemHP_NV";
            this.Text = "Danh sách học phần";
            this.Load += new System.EventHandler(this.XemHP_NV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button xoaBtn;
        private System.Windows.Forms.Button themBtn;
        private System.Windows.Forms.PictureBox homeIcon;
    }
}