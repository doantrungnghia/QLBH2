using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public partial class thongtinchitiet : Form
    {
        public string CMND;
        public string SDT;
        public thongtinchitiet(DataGridViewRow khachhang_Form_Main)
        {
            CMND = khachhang_Form_Main.Cells[0].Value.ToString();
            SDT= khachhang_Form_Main.Cells[2].Value.ToString();
            InitializeComponent();
            dataGridView1.DataSource = QuanLyNguoiDung_QuanLy_DAO.chi_Tiet_Hoa_Don(CMND,SDT);
        }

        private void button_Loc_TABCHITIETSUDUNG_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QuanLyNguoiDung_QuanLy_DAO.chi_Tiet_Hoa_Don(CMND,SDT, textBox_Thang_TABCHITIETSUDUNG.Text.ToString());
        }

       

        private void textBox_Thang_TABCHITIETSUDUNG_Enter(object sender, EventArgs e)
        {
            textBox_Thang_TABCHITIETSUDUNG.Text = "";
            textBox_Thang_TABCHITIETSUDUNG.ForeColor = Color.Black;
            button_Loc_TABCHITIETSUDUNG.Enabled = true;
        }
    }
}
