using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//Sử dụng thư viện này để làm việc với Stream
using System.Globalization;
namespace Project_2
{
    public partial class FormQuanLyNguoiDung : Form
    {
        public FormQuanLyNguoiDung()
        {
            InitializeComponent();
            Console.OutputEncoding = Encoding.Unicode;
            

            //////Đọc từ file log vào
            //string[] lines = File.ReadAllLines("log.txt");
            //foreach (string s in lines)
            //{
            //    CHITIETSUDUNG CTSD = new CHITIETSUDUNG();
            //    string[] row = s.Split('\t');
            //    CTSD.ID_SIM = row[0].ToString();

            //    CTSD.TG_BATDAU = Convert.ToDateTime(row[1], CultureInfo.CreateSpecificCulture("fr-FR"));
            //    CTSD.TG_KETTHUC = Convert.ToDateTime(row[2], CultureInfo.CreateSpecificCulture("fr-FR"));
            //    using (var db = new QLTCEntities1())
            //    {
            //        db.CHITIETSUDUNGs.Add(CTSD);
            //        db.SaveChanges();
            //    }
            //}
            //CHITIETSUDUNG abc = new CHITIETSUDUNG();
            //abc.ID_SIM = "0901503060";
            //abc.TG_BATDAU = Convert.ToDateTime("25 - 12 - 2017 09:12:17 AM", CultureInfo.CreateSpecificCulture("fr-FR"));
            //abc.TG_KETTHUC = Convert.ToDateTime("25 - 12 - 2017 09:15:22 AM", CultureInfo.CreateSpecificCulture("fr-FR"));

            //textBox_HoVaTenNguoiDung_TABDANGKY.Text = QuanLyNguoiDung_TinhToan_BUS.TinhTien(abc).ToString();
           //QuanLyNguoiDung_TinhToan_BUS.lap_Hoa_Don();


        }

        private void DisEnl(bool e)
        {
            textBox_HoVaTenNguoiDung_TABQUANLY.Enabled = e;
            textBox_CMND_TABQUANLY.Enabled = e;
            textBox_NgheNghiep_TABQUANLY.Enabled = e;
            textBox_DiaChi_TABQUANLY.Enabled = e;
            textBox_Gmail_TABQUANLY.Enabled = e;
            button_LuuThongTinNguoiDung_TABQUANLY.Enabled = e;
            //button_LuuThongTinNguoiDung_TABQUANLY.Enabled = !e;
            dataGridView1.Enabled = !e;
        }
        private void button_SuaNguoiDung_TABQUANLY_Click(object sender, EventArgs e)
        {
            DisEnl(true);

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button_LuuThongTinNguoiDung_TABQUANLY_Click(object sender, EventArgs e)
        {
            var KH = new KHACHHANG();
            KH.CMND = int.Parse(textBox_CMND_TABQUANLY.Text);
            KH.HOVATEN = textBox_HoVaTenNguoiDung_TABQUANLY.Text;
            KH.DIACHI = textBox_DiaChi_TABQUANLY.Text;
            KH.NGHENGHIEP = textBox_NgheNghiep_TABQUANLY.Text;
            KH.GMAIL = textBox_Gmail_TABQUANLY.Text;
            if (QuanLyNguoiDung_QuanLy_BUS.sua_Khach_Hang(KH))
            {
                QuanLyNguoiDung_QuanLy_BUS.sua_Khach_Hang(KH);
                MessageBox.Show("Khách hàng đã được sửa");
            }
            else MessageBox.Show("Khách hàng CHƯA được sửa");

            FormQuanLyNguoiDung_Load(sender, e); DisEnl(false);
        }
        private void databingding()
        {
            //DisEnl(false);
            textBox_HoVaTenNguoiDung_TABQUANLY.DataBindings.Clear();
            textBox_HoVaTenNguoiDung_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "HOVATEN");
            textBox_CMND_TABQUANLY.DataBindings.Clear();
            textBox_CMND_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "CMND");
            textBox_NgheNghiep_TABQUANLY.DataBindings.Clear();
            textBox_NgheNghiep_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "NGHENGHIEP");
            textBox_DiaChi_TABQUANLY.DataBindings.Clear();
            textBox_DiaChi_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "DIACHI");
            textBox_Gmail_TABQUANLY.DataBindings.Clear();
            textBox_Gmail_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "GMAIL");
        }
        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            using (var db = new QLTCEntities2())
            {

                //dataGridView1.DataSource = null;
                //dataGridView1.Refresh();
                var select = (from s in db.SIMs from kh in db.KHACHHANGs select new { kh.CMND, kh.HOVATEN, kh.NGHENGHIEP, kh.DIACHI, kh.GMAIL }).Distinct().ToList();
                dataGridView1.DataSource = select;
                DisEnl(false);
                databingding();
            }

            //Up danh sách bên tab3(tab gửi thư)
            dataGridView_Danh_Sach_Khach_Hang_Hoa_Don.DataSource = QuanLyNguoiDung_GuiThu_BUS.danh_Sach_Khach_Hang_Chua_Thanh_Toan_BUS();
          
        }

        private void button_DangKyVaXuatThongTin_TABDANGKY_Click(object sender, EventArgs e)
        {
            var KH = new KHACHHANG();
            //Kiếm tra các ràng buộc
            //if (KT_Rang_Buoc.is_Word_Only(textBox_HoVaTenNguoiDung_TABDANGKY.Text) && KT_Rang_Buoc.is_Gmail(textBox_Gmail_TABDANGKY.Text)
            //    && textBox_CMND_TABDANGKY.Text != null && textBox_HoVaTenNguoiDung_TABDANGKY.Text != null
            //    )
        //    {
                
                KH.HOVATEN = textBox_HoVaTenNguoiDung_TABDANGKY.Text;
                KH.CMND = int.Parse(textBox_CMND_TABDANGKY.Text);
                KH.NGHENGHIEP = textBox_NgheNghiep_TABDANGKY.Text;
               
                KH.DIACHI = textBox_DiaChi_TABDANGKY.Text;
                KH.GMAIL = textBox_Gmail_TABDANGKY.Text;
           // }
            //Truyền vào BUS Khách hàng KH để kiểm tra tồn tại chưa và thực hiện add vào DB

            
                QuanLyNguoiDung_DANGKY_BUS.xu_Ly_Dang_Ky(KH);
                
        

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button_Gui_Thu_Dien_Tu(object sender, EventArgs e)
        {
            //duyệt gridview  để gửi thư
            foreach (DataGridViewRow row in dataGridView_Danh_Sach_Khach_Hang_Hoa_Don.Rows)
            { //0 cmnd 1 ten 2 tien cuoc ,3 ma hoa don ,4 ngay hoa don
                string cmnd = row.Cells[0].Value.ToString();
                string tenkhachhang = row.Cells[1].Value.ToString();
                string tiencuoc = row.Cells[2].Value.ToString();
                string mahoadon = row.Cells[3].Value.ToString();
                string ngayhoadon= row.Cells[4].Value.ToString();
                string gmailkhachhang= row.Cells[5].Value.ToString();
                QuanLyNguoiDung_GuiThu_BUS.gui_Thu_Dien_Tu(textBox_Noi_Dung_Thu.Text+" "+ cmnd + " " +  tenkhachhang + " " + tiencuoc + " " + mahoadon + " " + ngayhoadon, tenkhachhang, gmailkhachhang);
            }
        }

        private void button_XemChiTietCuoc_TABQUANLY_Click(object sender, EventArgs e)
        {
           
            Form form2 = new thongtinchitiet(dataGridView1.CurrentRow);
            form2.Show();
        }
    }
}
