using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class QuanLyNguoiDung_QuanLy_BUS
    {
        public static bool sua_Khach_Hang(KHACHHANG Khach_Hang_A)
        {


            //Thêm vào DB bằng LINQ
            if (QuanLyNguoiDung_QuanLy_DAO.sua_Khach_Hang(Khach_Hang_A) == true) //Đã add được
            {
                QuanLyNguoiDung_QuanLy_DAO.sua_Khach_Hang(Khach_Hang_A);
                return true;
            }

            return false;
        }
        public static bool sua_Trang_Thai_SIM_BUS(string SDT, string trangthai)
        {
            return QuanLyNguoiDung_QuanLy_DAO.sua_Trang_Thai_SIM(SDT, trangthai);
        }
        //public static Array danh_Sach_Khach_Hang_BUS()
        //{
        //    Array dskh= QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Nguoi_Dung();
        //    return dskh;
        //}
        public static void lap_Hoa_Don()
        {
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            DateTime now = DateTime.Now;
            //DateTime date;
            Random rnd = new Random();

            List<SIM> danh_Sach_Sim_ID = QuanLyNguoiDung_QuanLy_DAO.lay_Danh_Sach_Sim();

            foreach (SIM SIM_temp in danh_Sach_Sim_ID)
            {
                bool tao_hay_khong = true;
               
                //Hóa đơn theo tháng kích hoạt
                //Hàm lấy tháng năm kích hoạt
                //List<SIM> SIM_temp =QuanLyNguoiDung_TinhToan_DAO.lay_Danh_Sach_SIM(str);
                //foreach(SIM s in SIM_temp)
               // {
                DateTime ngaykichhoat = SIM_temp.NgayKichHoat; //Lay ngay kich hoat de so sanh voi hien tai, tao bien dem de hinh thanh duoc hoa don tu luc kich hoat sim den hien tai
                int thang_Lap_Hoa_Don = ngaykichhoat.Month;
                //Thang lap hoa don boi vi hoa don chi lap tu luc tai khoan kich hoat cho den hien tai
                
                    while (DateTime.Compare(ngaykichhoat, now) <= 0 && thang_Lap_Hoa_Don < now.Month)
                    {
                        if (SIM_temp.TrangThaiSIM=="0" && QuanLyNguoiDung_QuanLy_DAO.chi_Tiet_Hoa_Don(SIM_temp.CMND,SIM_temp.id_Sim,thang_Lap_Hoa_Don.ToString())==null )
                        tao_hay_khong = false;

                        int sohoadon = rnd.Next(1, 2018);
                        List<CHITIETSUDUNG> list_CTSD = QuanLyNguoiDung_QuanLy_DAO.lay_Danh_Sach_CTSD_theo_thang(SIM_temp.id_Sim.ToString(), thang_Lap_Hoa_Don); //lúc này sẽ có list CTSD của SIM_ID str
                        HOADONTINHCUOC hoa_Don = new HOADONTINHCUOC();
                        hoa_Don.ID_SIM = SIM_temp.id_Sim;
                        if (thang_Lap_Hoa_Don < 10)
                            hoa_Don.Ngay_Thang = "HD-0" + thang_Lap_Hoa_Don + "-" + year + "-" + SIM_temp.CMND+"-"+SIM_temp.id_Sim;
                        else
                            hoa_Don.Ngay_Thang = "HD-" + thang_Lap_Hoa_Don + "-" + year + "-" + SIM_temp.CMND + "-" + SIM_temp.id_Sim;
                        //hoa_Don.ID_SIM = "0778222557";

                        //    hoa_Don.Ngay_Thang = "15 - 02 - 2019";
                        float tongtien = 0;
                        foreach (CHITIETSUDUNG cTSD_in_List in list_CTSD) //Tính tổng tiền
                        {
                            //tongtien = TinhTien(cTSD_in_List) + tongtien;
                            if (thang_Lap_Hoa_Don == cTSD_in_List.TG_BATDAU.Month)
                                tongtien = float.Parse(cTSD_in_List.Tien_cuoc) + tongtien;
                        }
                       
                        hoa_Don.Tong_Tien = (tongtien + 50000).ToString();                        
                        hoa_Don.TrangThai = "Not Paid";
                        //hoa_Don.Tong_Tien = "50000";
                        //    hoa_Don.TrangThai = "Not Paid";
                        //nếu có trong database hoa don roi thi không add
                        KHACHHANG khachhang_empty = new KHACHHANG();
                        Array dshd_daco = QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(khachhang_empty);
                       
                        // bool tao_hay_khong = true;
                        foreach (HOADONTINHCUOC hd in dshd_daco)
                        {
                            if (hd.Ngay_Thang == hoa_Don.Ngay_Thang)
                                tao_hay_khong = false;
                        }
                        

                        if (tao_hay_khong == true)
                            QuanLyNguoiDung_QuanLy_DAO.them_Hoa_Don(hoa_Don);
                        thang_Lap_Hoa_Don++;
                      // }
                    }
              



            }
        }
        public static void xoa_Tat_Ca_Hoa_Don_BUS()
        {
            QuanLyNguoiDung_QuanLy_DAO.xoa_Tat_Ca_Hoa_Don();
        }
        public static void xoa_Tat_Ca_Chi_Tiet_Su_Dung_BUS()
        {
            QuanLyNguoiDung_QuanLy_DAO.xoa_Tat_Ca_Chi_Tiet_Su_Dung();
        }
        public static Array danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(KHACHHANG KH_A)
        {
          return  QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(KH_A);
        }
        public static Array thong_Tin_Khach_Hang_BUS()
        {
            return QuanLyNguoiDung_QuanLy_DAO.thong_Tin_Khach_Hang();
        }
        public static Array thong_Tin_Khach_Hang_BUS(string tenkhachhang)
        {
            return QuanLyNguoiDung_QuanLy_DAO.thong_Tin_Khach_Hang(tenkhachhang);
        }
        public static Array lay_Danh_Sach_Sim_Status(string status)
        {
            return QuanLyNguoiDung_QuanLy_DAO.lay_Danh_Sach_Sim_Status(status);
        }
        public static Array danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang_BUS(KHACHHANG KH_A, string thang, string nam)
        {
            return QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(KH_A, thang, nam);
        }
        public static Array danh_Sach_Hoa_Don_Tong_Hop_BUS()
        {
            return QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Hoa_Don_Tong_Hop_DAO();
        }
        public static void cap_Nhat_Danh_Sach_Sim_BUS()
        {
            QuanLyNguoiDung_QuanLy_DAO.cap_Nhat_Danh_Sach_Sim_DAO();
        }
    }
}
