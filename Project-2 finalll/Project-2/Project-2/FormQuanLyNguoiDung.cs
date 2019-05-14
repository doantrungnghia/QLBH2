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

            //    CTSD.Tien_cuoc = QuanLyNguoiDung_TinhToan_BUS.TinhTien(CTSD).ToString();
            //    using (var db = new QLTCEntities9())
            //    {
            //        db.CHITIETSUDUNGs.Add(CTSD);
            //        db.SaveChanges();
            //    }
            //}
            //CHITIETSUDUNG abc = new CHITIETSUDUNG();
            //abc.ID_SIM = "0901503060";
            //abc.TG_BATDAU = Convert.ToDateTime("25 - 12 - 2017 09:12:17 AM", CultureInfo.CreateSpecificCulture("fr-FR"));
            //abc.TG_KETTHUC = Convert.ToDateTime("25 - 12 - 2017 09:15:22 AM", CultureInfo.CreateSpecificCulture("fr-FR"));
            //abc.Tien_cuoc = null ;

            //textBox_HoVaTenNguoiDung_TABDANGKY.Text = QuanLyNguoiDung_TinhToan_BUS.TinhTien(abc).ToString();
            //CHITIETSUDUNG abc = new CHITIETSUDUNG();
            //abc = QuanLyNguoiDung_TinhToan_DAO.lay_Danh_Sach_CTSD_theo_thang("0778222557", 3);
            //Xóa tất cả hóa đơn
           // QuanLyNguoiDung_QuanLy_BUS.xoa_Tat_Ca_Hoa_Don();
            //Lập lại hóa đơn
            //QuanLyNguoiDung_QuanLy_BUS.lap_Hoa_Don();



        }
        private void DisEnl(bool e)
        {
            textBox_HoVaTenNguoiDung_TABQUANLY.Enabled = e;
            textBox_CMND_TABQUANLY.Enabled = e;
            textBox_NgheNghiep_TABQUANLY.Enabled = e;
            textBox_DiaChi_TABQUANLY.Enabled = e;
            textBox_Gmail_TABQUANLY.Enabled = e;
            RadioButton1_Actived.Enabled = e;
            radioButton1_Unactive.Enabled = e;
            //textBox_SDT_TABQUANLY.Enabled = e;
            button_LuuThongTinNguoiDung_TABQUANLY.Enabled = e;
            //button_LuuThongTinNguoiDung_TABQUANLY.Enabled = !e;
            dataGridView1.Enabled = !e;
        }
        private void button_SuaNguoiDung_TABQUANLY_Click(object sender, EventArgs e)
        {
            DisEnl(true);

        }
        private void button_LuuThongTinNguoiDung_TABQUANLY_Click(object sender, EventArgs e)
        {
            var KH = new KHACHHANG();
            KH.CMND = textBox_CMND_TABQUANLY.Text.ToString();
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
            if (RadioButton1_Actived.Checked)
            {
                QuanLyNguoiDung_QuanLy_BUS.sua_Trang_Thai_SIM_BUS(textBox_SDT_TABQUANLY.Text.ToString(), "1");
            }
            else if (radioButton1_Unactive.Checked)
            {
                QuanLyNguoiDung_QuanLy_BUS.sua_Trang_Thai_SIM_BUS(textBox_SDT_TABQUANLY.Text.ToString(), "0");
            }
            QuanLyNguoiDung_QuanLy_BUS.cap_Nhat_Danh_Sach_Sim_BUS();

            FormQuanLyNguoiDung_Load(sender, e); DisEnl(false);
        }
        private void button_XemChiTietCuoc_TABQUANLY_Click(object sender, EventArgs e)
        {

            Form form2 = new thongtinchitiet(dataGridView1.CurrentRow);
            form2.Show();
        }
        private void databingding()
        {
            //DisEnl(false);
            textBox_HoVaTenNguoiDung_TABQUANLY.DataBindings.Clear();
            textBox_HoVaTenNguoiDung_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "FullName");
            textBox_CMND_TABQUANLY.DataBindings.Clear();
            textBox_CMND_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "Identity");
            textBox_NgheNghiep_TABQUANLY.DataBindings.Clear();
            textBox_NgheNghiep_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "Career");
            textBox_DiaChi_TABQUANLY.DataBindings.Clear();
            textBox_DiaChi_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "Address");
            textBox_Gmail_TABQUANLY.DataBindings.Clear();
            textBox_Gmail_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "Gmail");
            textBox_SDT_TABQUANLY.DataBindings.Clear();
            textBox_SDT_TABQUANLY.DataBindings.Add("Text", dataGridView1.DataSource, "PhoneNumber");
            //RadioButton1_Actived.DataBindings.Add("Text",dataGridView1.DataSource,"SimStatus");
            //if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "1")
            //{
            //    RadioButton1_Actived.Checked = true;

            //}
            //else
            //{
            //    radioButton1_Unactive.Checked = true;

            //    // radioButton1_Unactive.
            //}


        }      
        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            if (button_Tim_Theo_CMND.Text.ToString() == null || button_Tim_Theo_CMND.Text.ToString()=="")
            {
                dataGridView1.DataSource = QuanLyNguoiDung_QuanLy_BUS.thong_Tin_Khach_Hang_BUS();
                dataGridView1.Update();
                DisEnl(false);
                databingding();
            }
            else button_Tim_Theo_CMND_Click(sender,e);
            ////Up danh sách bên tab3(tab gửi thư)
            //dataGridView_Danh_Sach_Khach_Hang_Hoa_Don.DataSource = QuanLyNguoiDung_GuiThu_BUS.danh_Sach_Khach_Hang_Chua_Thanh_Toan_BUS();

        }
        private void button_DangKyVaXuatThongTin_TABDANGKY_Click(object sender, EventArgs e)
        {
            var KH = new KHACHHANG();
            string ten = textBox_HoVaTenNguoiDung_TABDANGKY.Text;
            string cmnd = textBox_CMND_TABDANGKY.Text;
            string nghe = textBox_NgheNghiep_TABDANGKY.Text;

            string diachi = textBox_DiaChi_TABDANGKY.Text;
            string mail = textBox_Gmail_TABDANGKY.Text;
            string sdt = textBox_SDT_TABDANGKY.Text.ToString();

            
            //Kiếm tra các ràng buộc
            if(ten == "" || ten == "" || nghe == "" || diachi == "" || mail == "" || sdt == "")
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
            else
            {
                if (KT_Rang_Buoc.is_Name(textBox_HoVaTenNguoiDung_TABDANGKY.Text) && KT_Rang_Buoc.is_Gmail(textBox_Gmail_TABDANGKY.Text)
                && KT_Rang_Buoc.is_Number_Only(textBox_CMND_TABDANGKY.Text) && textBox_CMND_TABDANGKY.Text != null && textBox_HoVaTenNguoiDung_TABDANGKY.Text != null
                && textBox_Gmail_TABDANGKY != null)
                {
                    KH.HOVATEN = textBox_HoVaTenNguoiDung_TABDANGKY.Text;
                    KH.CMND = textBox_CMND_TABDANGKY.Text.ToString();
                    KH.NGHENGHIEP = textBox_NgheNghiep_TABDANGKY.Text;

                    KH.DIACHI = textBox_DiaChi_TABDANGKY.Text;
                    KH.GMAIL = textBox_Gmail_TABDANGKY.Text;
                    string SDT = textBox_SDT_TABDANGKY.Text.ToString();
                    if (QuanLyNguoiDung_DANGKY_BUS.xu_Ly_Dang_Ky(KH, SDT))
                    {
                        StreamWriter mf = File.AppendText("sim.txt");
                        mf.WriteLine(sdt);
                        mf.Close();
                        QuanLyNguoiDung_DANGKY_BUS.xu_Ly_Dang_Ky(KH, SDT);
                        MessageBox.Show("Tạo mới khách hàng THÀNH CÔNG " + KH.HOVATEN, "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Tạo mới khách hàng THẤT BẠI  " + KH.HOVATEN, "Thông báo", MessageBoxButtons.OK);
                        MessageBox.Show("Nếu khách hàng tạo thêm số mới, đã hoàn tất yêu cầu", "Thông báo", MessageBoxButtons.OK);


                }
                else
                    MessageBox.Show("Vui lòng nhập đúng định dạng các trường dữ liệu !");
            }
            QuanLyNguoiDung_QuanLy_BUS.cap_Nhat_Danh_Sach_Sim_BUS();

            // }
            //Truyền vào BUS Khách hàng KH để kiểm tra tồn tại chưa và thực hiện add vào DB

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
                string ngayhoadon = row.Cells[4].Value.ToString();
                string gmailkhachhang = row.Cells[5].Value.ToString();
                if (QuanLyNguoiDung_GuiThu_BUS.gui_Thu_Dien_Tu(textBox_Noi_Dung_Thu.Text + " " + cmnd + " " + tenkhachhang + " " + tiencuoc + " " + mahoadon + " " + ngayhoadon, tenkhachhang, gmailkhachhang))
                {
                   
                    AutoClosingMessageBox.Show("Đã gửi gmail cho khách hàng "+tenkhachhang, "Thành công", 1000);
                }
                else
                    MessageBox.Show("Gửi gmail cho khách hàng " + tenkhachhang + " thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
               

            }
            MessageBox.Show("Đã gửi gmail cho tất cả khách hàng ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   
        private void button_Xem_Chi_Tiet_Hoa_Don_MOT_KHACH_Click(object sender, EventArgs e)
        {
            KHACHHANG khachhang_temp = new KHACHHANG();
            khachhang_temp.CMND =textBox_CMND_TABQUANLY.Text.ToString();
            khachhang_temp.HOVATEN =textBox_HoVaTenNguoiDung_TABQUANLY.Text.ToString();
            khachhang_temp.NGHENGHIEP =textBox_NgheNghiep_TABQUANLY.Text.ToString();
            khachhang_temp.DIACHI =textBox_DiaChi_TABQUANLY.Text.ToString();
            khachhang_temp.GMAIL =textBox_Gmail_TABQUANLY.Text.ToString();
           // string sodienthoai = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Form form_xem_chi_tiet_hoa_don = new thongtinhoadon(khachhang_temp); //truyền cmnd vào
            
            form_xem_chi_tiet_hoa_don.Show();
        }
        private void button_taoCTSD_TABQUANLY_Click(object sender, EventArgs e)
        {
            //string status = 1.ToString();
            //Array sdt = QuanLyNguoiDung_QuanLy_BUS.lay_Danh_Sach_Sim_Status(status);
            ////tạo file sim.txt mới
            //FileStream fs = new FileStream("sim.txt", FileMode.Create);
            //StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            //foreach(string s in sdt)
            //{
            //    sw.WriteLine(s);
            //}
            //sw.Flush();
            //fs.Close();
            //tạo file chi tiết sử dụng mới
            tao_Chi_Tiet_Su_Dung_Random.taofile();
            //////Xóa tất cả hóa đơn
            //QuanLyNguoiDung_QuanLy_BUS.xoa_Tat_Ca_Hoa_Don_BUS();
            //////Xóa tất cả chi tiết sử dụng cũ
            //QuanLyNguoiDung_QuanLy_BUS.xoa_Tat_Ca_Chi_Tiet_Su_Dung_BUS();
            //Đọc từ file log vào
            string[] lines = File.ReadAllLines("log.txt");
            foreach (string s in lines)
            {
                CHITIETSUDUNG CTSD = new CHITIETSUDUNG();
                string[] row = s.Split('\t');
                CTSD.ID_SIM = row[0].ToString();

                CTSD.TG_BATDAU = Convert.ToDateTime(row[1], CultureInfo.CreateSpecificCulture("fr-FR"));
                CTSD.TG_KETTHUC = Convert.ToDateTime(row[2], CultureInfo.CreateSpecificCulture("fr-FR"));

                CTSD.Tien_cuoc = QuanLyNguoiDung_TinhToan_BUS.TinhTien(CTSD).ToString();
                using (var db = new QLTCEntities2())
                {
                    try {
                        db.CHITIETSUDUNGs.Add(CTSD); db.SaveChanges();
                    }
                    catch { }
                   
                }
            }
            ////Xóa tất cả hóa đơn
            ////QuanLyNguoiDung_QuanLy_BUS.xoa_Tat_Ca_Hoa_Don_BUS();
           
        }
        private void button_Xem_Chi_Tiet_Hoa_Don_TABQUANLY_Click(object sender, EventArgs e)
        {
            Form form_xem_chi_tiet_hoa_don = new thongtinhoadon();
            form_xem_chi_tiet_hoa_don.Show();
        }
            

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Up danh sách bên tab3(tab gửi thư)
            dataGridView_Danh_Sach_Khach_Hang_Hoa_Don.DataSource = QuanLyNguoiDung_GuiThu_BUS.danh_Sach_Khach_Hang_Chua_Thanh_Toan_BUS();
        }
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        private void button_Tim_Theo_CMND_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = QuanLyNguoiDung_QuanLy_BUS.thong_Tin_Khach_Hang_BUS(textBox_CMND_TABQUANLY_SEARCH.Text.ToString());
            dataGridView1.Update();
            DisEnl(false);
            databingding();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "1")
            {
                RadioButton1_Actived.Checked = true;

            }
            else
            {
                radioButton1_Unactive.Checked = true;

                // radioButton1_Unactive.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormQuanLyNguoiDung_Load(sender,e);
          
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button_Lap_Hoa_Don_TABQUANLY_Click(object sender, EventArgs e)
        {
            //Lập lại hóa đơn
            QuanLyNguoiDung_QuanLy_BUS.lap_Hoa_Don();
        }
    }
}
