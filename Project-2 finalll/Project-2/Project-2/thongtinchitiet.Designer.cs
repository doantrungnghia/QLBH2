namespace Project_2
{
    partial class thongtinchitiet
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Thang_TABCHITIETSUDUNG = new System.Windows.Forms.TextBox();
            this.button_Loc_TABCHITIETSUDUNG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1064, 434);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox_Thang_TABCHITIETSUDUNG
            // 
            this.textBox_Thang_TABCHITIETSUDUNG.ForeColor = System.Drawing.Color.Gray;
            this.textBox_Thang_TABCHITIETSUDUNG.Location = new System.Drawing.Point(645, 20);
            this.textBox_Thang_TABCHITIETSUDUNG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Thang_TABCHITIETSUDUNG.Name = "textBox_Thang_TABCHITIETSUDUNG";
            this.textBox_Thang_TABCHITIETSUDUNG.Size = new System.Drawing.Size(100, 22);
            this.textBox_Thang_TABCHITIETSUDUNG.TabIndex = 1;
            this.textBox_Thang_TABCHITIETSUDUNG.Text = "Tháng";
            this.textBox_Thang_TABCHITIETSUDUNG.Enter += new System.EventHandler(this.textBox_Thang_TABCHITIETSUDUNG_Enter);
            // 
            // button_Loc_TABCHITIETSUDUNG
            // 
            this.button_Loc_TABCHITIETSUDUNG.Enabled = false;
            this.button_Loc_TABCHITIETSUDUNG.Location = new System.Drawing.Point(752, 20);
            this.button_Loc_TABCHITIETSUDUNG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Loc_TABCHITIETSUDUNG.Name = "button_Loc_TABCHITIETSUDUNG";
            this.button_Loc_TABCHITIETSUDUNG.Size = new System.Drawing.Size(75, 23);
            this.button_Loc_TABCHITIETSUDUNG.TabIndex = 3;
            this.button_Loc_TABCHITIETSUDUNG.Text = "Tìm";
            this.button_Loc_TABCHITIETSUDUNG.UseVisualStyleBackColor = true;
            this.button_Loc_TABCHITIETSUDUNG.Click += new System.EventHandler(this.button_Loc_TABCHITIETSUDUNG_Click);
            // 
            // thongtinchitiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 487);
            this.Controls.Add(this.button_Loc_TABCHITIETSUDUNG);
            this.Controls.Add(this.textBox_Thang_TABCHITIETSUDUNG);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "thongtinchitiet";
            this.Text = "Thông Tin Chi Tiết Sử Dụng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Thang_TABCHITIETSUDUNG;
        private System.Windows.Forms.Button button_Loc_TABCHITIETSUDUNG;
    }
}