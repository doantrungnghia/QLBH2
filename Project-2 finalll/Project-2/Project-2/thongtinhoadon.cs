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
    public partial class thongtinhoadon : Form
    {
        public string cap_Nhat_Trang_Thai_Button;
        public thongtinhoadon()
        {
            cap_Nhat_Trang_Thai_Button = "all";
            InitializeComponent();
            dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_BUS.danh_Sach_Hoa_Don_Tong_Hop_BUS(); //Thêm vào BUS để ra 3 layer

        }
        public thongtinhoadon(KHACHHANG khachhang_A)
        {
            
            cap_Nhat_Trang_Thai_Button = "ones";
            kh_A = khachhang_A;
         InitializeComponent(khachhang_A);
          //  InitializeComponent();  
            dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_BUS.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(khachhang_A); //Thêm vào BUS để ra 3 layer
            //dataGridView_Danh_Sach_Hoa_Don.Columns["SIM"].Visible = false;
        }
     

        //private void dataGridView_Danh_Sach_Hoa_Don_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //Khi nhấn vào hóa đơn vào 2 lần thì nó sẽ set trạng thái hóa đơn bằng "đã trả"
        //    if (dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value == "Not Paid")
        //        dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value = "Paid";
        //    else dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value = "Not Paid";
        //    dataGridView_Danh_Sach_Hoa_Don.Refresh();
        //    dataGridView_Danh_Sach_Hoa_Don.Update();

        //}

        //private void dataGridView_Danh_Sach_Hoa_Don_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    //Khi nhấn vào hóa đơn vào 2 lần thì nó sẽ set trạng thái hóa đơn bằng "đã trả"
        //    if (dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value == "Not Paid")
        //        dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value = "Paid";
        //    else dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value = "Not Paid";
        //    dataGridView_Danh_Sach_Hoa_Don.Refresh();
        //    dataGridView_Danh_Sach_Hoa_Don.Update();
        //}

        private void button_Cap_Nhat_Trang_Thai_Click(object sender, EventArgs e)
        {
            if(dataGridView_Danh_Sach_Hoa_Don.CurrentRow !=null)
            { 
            if (dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[1].Value.ToString() == "Not Paid")
                dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[1].Value = "Paid";
            else dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[1].Value = "Not Paid";
           

            //Cập nhật vào database
            string ma_hoa_don = dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[0].Value.ToString();
            string trang_Thai_Hoa_Don = dataGridView_Danh_Sach_Hoa_Don.CurrentRow.Cells[1].Value.ToString();
            QuanLyNguoiDung_QuanLy_DAO.cap_Nhat_Trang_Thai_Hoa_Don(ma_hoa_don,trang_Thai_Hoa_Don);
                // chia trường hợp cho 2 tab thông tin hóa đơn
               
               if (kh_A==null || cap_Nhat_Trang_Thai_Button=="all")
                    dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_BUS.danh_Sach_Hoa_Don_Tong_Hop_BUS();
                else
                    dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(kh_A);
            dataGridView_Danh_Sach_Hoa_Don.Update();
            dataGridView_Danh_Sach_Hoa_Don.Refresh();

                button_Loc_DSHD_Click(sender,e);
            }
        }

        private void dataGridView_Danh_Sach_Hoa_Don_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void thongtinhoadon_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_Danh_Sach_Hoa_Don_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Loc_HD_Click(object sender, EventArgs e)
        {
            /// thang = textBox_mm_HD.Text.ToString();
            ///string nam = textBox_yyyy_HD.Text.ToString();
          // dataGridView_Danh_Sach_Hoa_Don.DataSource= QuanLyNguoiDung_QuanLy_BUS.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang_BUS(kh_A, thang, nam);
        }     

        private void button_Loc_DSHD_Click(object sender, EventArgs e)
        {
            string thang = textBox_mm_Loc_DSHD.Text.ToString();
            string nam = textBox_yyyy_Loc_DSHD.Text.ToString();
            if (thang != "" && nam != "")
            {
                if (kh_A.CMND == null) dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Tong_Hop(thang, nam);
                else dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(kh_A, thang, nam);
            }
            else 
                if(kh_A.CMND==null) dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_BUS.danh_Sach_Hoa_Don_Tong_Hop_BUS(); //Thêm vào BUS để ra 3 layer
                else
                dataGridView_Danh_Sach_Hoa_Don.DataSource = QuanLyNguoiDung_QuanLy_BUS.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(kh_A);
        }
    }
}
