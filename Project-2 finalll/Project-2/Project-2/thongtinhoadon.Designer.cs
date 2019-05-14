namespace Project_2
{
    partial class thongtinhoadon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private KHACHHANG kh_A = new KHACHHANG();
        private string sodienthoai;
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
        public string HOVATEN { get; set; }
        public string CMND { get; set; }
        public string NGHENGHIEP { get; set; }
        public string DIACHI { get; set; }
        public string GMAIL { get; set; }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Danh_Sach_Hoa_Don = new System.Windows.Forms.DataGridView();
            this.button_Cap_Nhat_Trang_Thai = new System.Windows.Forms.Button();
            this.textBox_mm_Loc_DSHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Loc_DSHD = new System.Windows.Forms.Button();
            this.textBox_yyyy_Loc_DSHD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Danh_Sach_Hoa_Don)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Danh_Sach_Hoa_Don
            // 
            this.dataGridView_Danh_Sach_Hoa_Don.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Danh_Sach_Hoa_Don.Location = new System.Drawing.Point(2, 52);
            this.dataGridView_Danh_Sach_Hoa_Don.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView_Danh_Sach_Hoa_Don.Name = "dataGridView_Danh_Sach_Hoa_Don";
            this.dataGridView_Danh_Sach_Hoa_Don.Size = new System.Drawing.Size(795, 357);
            this.dataGridView_Danh_Sach_Hoa_Don.TabIndex = 0;
            this.dataGridView_Danh_Sach_Hoa_Don.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Danh_Sach_Hoa_Don_CellContentClick);
            this.dataGridView_Danh_Sach_Hoa_Don.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_Danh_Sach_Hoa_Don_DataError_1);
            // 
            // button_Cap_Nhat_Trang_Thai
            // 
            this.button_Cap_Nhat_Trang_Thai.Location = new System.Drawing.Point(654, 417);
            this.button_Cap_Nhat_Trang_Thai.Name = "button_Cap_Nhat_Trang_Thai";
            this.button_Cap_Nhat_Trang_Thai.Size = new System.Drawing.Size(134, 23);
            this.button_Cap_Nhat_Trang_Thai.TabIndex = 1;
            this.button_Cap_Nhat_Trang_Thai.Text = "Cập nhật Trạng Thái";
            this.button_Cap_Nhat_Trang_Thai.UseVisualStyleBackColor = true;
            this.button_Cap_Nhat_Trang_Thai.Click += new System.EventHandler(this.button_Cap_Nhat_Trang_Thai_Click);
            // 
            // textBox_mm_Loc_DSHD
            // 
            this.textBox_mm_Loc_DSHD.Location = new System.Drawing.Point(518, 24);
            this.textBox_mm_Loc_DSHD.Name = "textBox_mm_Loc_DSHD";
            this.textBox_mm_Loc_DSHD.Size = new System.Drawing.Size(62, 20);
            this.textBox_mm_Loc_DSHD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(466, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "mm yyyy";
            // 
            // button_Loc_DSHD
            // 
            this.button_Loc_DSHD.Location = new System.Drawing.Point(654, 21);
            this.button_Loc_DSHD.Name = "button_Loc_DSHD";
            this.button_Loc_DSHD.Size = new System.Drawing.Size(134, 23);
            this.button_Loc_DSHD.TabIndex = 4;
            this.button_Loc_DSHD.Text = "Lọc";
            this.button_Loc_DSHD.UseVisualStyleBackColor = true;
            this.button_Loc_DSHD.Click += new System.EventHandler(this.button_Loc_DSHD_Click);
            // 
            // textBox_yyyy_Loc_DSHD
            // 
            this.textBox_yyyy_Loc_DSHD.Location = new System.Drawing.Point(586, 24);
            this.textBox_yyyy_Loc_DSHD.Name = "textBox_yyyy_Loc_DSHD";
            this.textBox_yyyy_Loc_DSHD.Size = new System.Drawing.Size(62, 20);
            this.textBox_yyyy_Loc_DSHD.TabIndex = 5;
            // 
            // thongtinhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_yyyy_Loc_DSHD);
            this.Controls.Add(this.button_Loc_DSHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_mm_Loc_DSHD);
            this.Controls.Add(this.button_Cap_Nhat_Trang_Thai);
            this.Controls.Add(this.dataGridView_Danh_Sach_Hoa_Don);
            this.Name = "thongtinhoadon";
            this.Text = "Thông Tin Hóa Đơn Tổng Hợp";
            this.Load += new System.EventHandler(this.thongtinhoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Danh_Sach_Hoa_Don)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void InitializeComponent(KHACHHANG a)
        {
            kh_A = a;
            this.dataGridView_Danh_Sach_Hoa_Don = new System.Windows.Forms.DataGridView();
            this.button_Cap_Nhat_Trang_Thai = new System.Windows.Forms.Button();
            this.textBox_mm_Loc_DSHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Loc_DSHD = new System.Windows.Forms.Button();
            this.textBox_yyyy_Loc_DSHD = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Danh_Sach_Hoa_Don)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Danh_Sach_Hoa_Don
            // 
            this.dataGridView_Danh_Sach_Hoa_Don.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Danh_Sach_Hoa_Don.Location = new System.Drawing.Point(2, 52);
            this.dataGridView_Danh_Sach_Hoa_Don.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView_Danh_Sach_Hoa_Don.Name = "dataGridView_Danh_Sach_Hoa_Don";
            this.dataGridView_Danh_Sach_Hoa_Don.Size = new System.Drawing.Size(795, 357);
            this.dataGridView_Danh_Sach_Hoa_Don.TabIndex = 0;
            this.dataGridView_Danh_Sach_Hoa_Don.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Danh_Sach_Hoa_Don_CellContentClick);
            this.dataGridView_Danh_Sach_Hoa_Don.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_Danh_Sach_Hoa_Don_DataError_1);
            // 
            // button_Cap_Nhat_Trang_Thai
            // 
            this.button_Cap_Nhat_Trang_Thai.Location = new System.Drawing.Point(654, 417);
            this.button_Cap_Nhat_Trang_Thai.Name = "button_Cap_Nhat_Trang_Thai";
            this.button_Cap_Nhat_Trang_Thai.Size = new System.Drawing.Size(134, 23);
            this.button_Cap_Nhat_Trang_Thai.TabIndex = 1;
            this.button_Cap_Nhat_Trang_Thai.Text = "Cập nhật Trạng Thái";
            this.button_Cap_Nhat_Trang_Thai.UseVisualStyleBackColor = true;
            this.button_Cap_Nhat_Trang_Thai.Click += new System.EventHandler(this.button_Cap_Nhat_Trang_Thai_Click);
            // 
            // textBox_mm_Loc_DSHD
            // 
            this.textBox_mm_Loc_DSHD.Location = new System.Drawing.Point(518, 24);
            this.textBox_mm_Loc_DSHD.Name = "textBox_mm_Loc_DSHD";
            this.textBox_mm_Loc_DSHD.Size = new System.Drawing.Size(62, 20);
            this.textBox_mm_Loc_DSHD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(466, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "mm yyyy";
            // 
            // button_Loc_DSHD
            // 
            this.button_Loc_DSHD.Location = new System.Drawing.Point(654, 21);
            this.button_Loc_DSHD.Name = "button_Loc_DSHD";
            this.button_Loc_DSHD.Size = new System.Drawing.Size(134, 23);
            this.button_Loc_DSHD.TabIndex = 4;
            this.button_Loc_DSHD.Text = "Lọc";
            this.button_Loc_DSHD.UseVisualStyleBackColor = true;
            this.button_Loc_DSHD.Click += new System.EventHandler(this.button_Loc_DSHD_Click);
            // 
            // textBox_yyyy_Loc_DSHD
            // 
            this.textBox_yyyy_Loc_DSHD.Location = new System.Drawing.Point(586, 24);
            this.textBox_yyyy_Loc_DSHD.Name = "textBox_yyyy_Loc_DSHD";
            this.textBox_yyyy_Loc_DSHD.Size = new System.Drawing.Size(62, 20);
            this.textBox_yyyy_Loc_DSHD.TabIndex = 5;
            // 
            // thongtinhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_yyyy_Loc_DSHD);
            this.Controls.Add(this.button_Loc_DSHD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_mm_Loc_DSHD);
            this.Controls.Add(this.button_Cap_Nhat_Trang_Thai);
            this.Controls.Add(this.dataGridView_Danh_Sach_Hoa_Don);
            this.Name = "thongtinhoadon";
            this.Text = "Thông Tin Hóa Đơn Của Khách Hàng "+kh_A.CMND +" "+kh_A.HOVATEN;
            this.Load += new System.EventHandler(this.thongtinhoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Danh_Sach_Hoa_Don)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Danh_Sach_Hoa_Don;
        private System.Windows.Forms.Button button_Cap_Nhat_Trang_Thai;
        private System.Windows.Forms.TextBox textBox_mm_Loc_DSHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Loc_DSHD;
        private System.Windows.Forms.TextBox textBox_yyyy_Loc_DSHD;
    }
}