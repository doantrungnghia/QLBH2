using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    public class QuanLyNguoiDung_QuanLy_DAO
    {

            public static bool sua_Khach_Hang(KHACHHANG Khach_Hang_A)
            {
                using (var db = new QLTCEntities2())
                {
                    var update = (from kh in db.KHACHHANGs where kh.CMND == Khach_Hang_A.CMND select kh).Single();
                    update.HOVATEN = Khach_Hang_A.HOVATEN;
                    update.NGHENGHIEP = Khach_Hang_A.NGHENGHIEP;
                    update.DIACHI = Khach_Hang_A.DIACHI;
                    update.GMAIL = Khach_Hang_A.GMAIL;
                    db.SaveChanges();
                }
                return true;
            }
            public static bool sua_Trang_Thai_SIM(string SDT, string trangthai)
            {
            DateTime ngaythang = DateTime.Now;
            
            string value;
            value=(trangthai=="1") ?  "1" : "0";
            if (value=="0")
            {
            using (var db = new QLTCEntities2())
            {
                var query = (
                             from sim in db.SIMs
                             where sim.id_Sim==SDT
                             select sim
                    ).Single();
                query.TrangThaiSIM = value;
                query.Ngay_lock = ngaythang;
                db.SaveChanges();
            }
                return true;
            }
            else
                using (var db = new QLTCEntities2())
                {
                    var query = (
                                 from sim in db.SIMs
                                 where sim.id_Sim == SDT
                                 select sim
                        ).Single();
                    query.TrangThaiSIM = value;
                    
                    query.Ngay_lock = null;
                    db.SaveChanges();
                }
            return true;
            }
    
            public static Array chi_Tiet_Hoa_Don(string CMND_temp,string SDT)
            {
                using (var db = new QLTCEntities2())
                {

                var query = (
                from kh in db.KHACHHANGs
                join s in db.SIMs on kh.CMND equals s.CMND
                join ctsd in db.CHITIETSUDUNGs on s.id_Sim equals ctsd.ID_SIM
                where s.CMND == CMND_temp
                where s.id_Sim==SDT
                               
                    select new
                    {
                        FullName=kh.HOVATEN,
                        CMND=kh.CMND,
                        PhoneNumber=ctsd.ID_SIM,
                        Month =ctsd.TG_BATDAU.Month,
                        StartingTime=ctsd.TG_BATDAU,
                        EndingTime = ctsd.TG_KETTHUC,
                        Fee =  ctsd.Tien_cuoc,
                       // cuocphicuocgoi=QuanLyNguoiDung_TinhToan_BUS.TinhTien(ctsd),
                    }).ToArray();
                    return query;
                }
                // Create a table from the query.          
            }
            public static Array chi_Tiet_Hoa_Don(string CMND_temp,string SDT, string month)
            {
                if (month == null || month == "")
                    return chi_Tiet_Hoa_Don(CMND_temp,SDT);
                using (var db = new QLTCEntities2())
                {

                    var query = (
                    from kh in db.KHACHHANGs
                    join s in db.SIMs on kh.CMND equals s.CMND
                    join ctsd in db.CHITIETSUDUNGs on s.id_Sim equals ctsd.ID_SIM
                    where s.CMND == CMND_temp
                    where s.id_Sim == SDT
                    //where month.Contains(ctsd.TG_BATDAU.Month.ToString())
                    where ctsd.TG_BATDAU.Month.ToString()==month
                    select new
                    {
                        FullName = kh.HOVATEN,
                        CMND = kh.CMND,
                        PhoneNumber = ctsd.ID_SIM,
                        Month = ctsd.TG_BATDAU.Month,
                        StartingTime = ctsd.TG_BATDAU,
                        EndingTime = ctsd.TG_KETTHUC,
                        Fee = ctsd.Tien_cuoc,
                        // cuocphicuocgoi=QuanLyNguoiDung_TinhToan_BUS.TinhTien(ctsd),
                    }).ToArray();
                    return query;
                }
                // Create a table from the query.          
            }
        //public static Array chi_tiet_su_dung()
        //{
        //    using (var db = new QLTCEntities1())
        //    {
        //        var select = (
        //            from ct in db.CHITIETSUDUNGs select new { ct.ID_SIM, ct.TG_BATDAU, ct.TG_KETTHUC, ct.Tien_cuoc }
        //            ).ToArray();
        //        return select;
        //    }


        //}
            public static Array Load_data()
            {
                using (var db = new QLTCEntities2())
                {

                    var select = (from ct in db.CHITIETSUDUNGs select new {SĐT =  ct.ID_SIM,Thời_gian_bắt_đầu =  ct.TG_BATDAU,Thời_gian_kết_thúc =  ct.TG_KETTHUC,Tiền_cước =  ct.Tien_cuoc }).ToArray();
                    return select;
                }
            }
            public static Array Load_data(string sdt,int m)
            {
            if(m!=-1)
                using (var db = new QLTCEntities2())
                {

                    var select = 
                        (from ct in db.CHITIETSUDUNGs
                         where ct.ID_SIM == sdt
                         where ct.TG_BATDAU.Month ==m
                         select new
                         { SĐT = ct.ID_SIM, Thời_gian_bắt_đầu = ct.TG_BATDAU, Thời_gian_kết_thúc = ct.TG_KETTHUC, Tiền_cước = ct.Tien_cuoc }).ToArray();
                    return select;
                }
            else
                using (var db = new QLTCEntities2())
                {

                    var select = (from ct in db.CHITIETSUDUNGs where ct.ID_SIM == sdt select new { SĐT = ct.ID_SIM, Thời_gian_bắt_đầu = ct.TG_BATDAU, Thời_gian_kết_thúc = ct.TG_KETTHUC, Tiền_cước = ct.Tien_cuoc }).ToArray();
                    return select;
                }
        }
        //public static int Tong_tien(string sdt, int m)
        //{
        //    if (m != -1)
        //        using (var db = new QLTC_TINHEntities())
        //        {

        //            int select =
        //                (from ct in db.CHITIETSUDUNGs
        //                 where ct.ID_SIM == sdt
        //                 where ct.TG_BATDAU.Month == m
        //                 select new
        //                 { ct.Tien_cuoc.Sum() }).ToArray();
        //            return select;
        //        }
        //    else
        //        using (var db = new QLTC_TINHEntities())
        //        {

        //            int select = (from ct in db.CHITIETSUDUNGs where ct.ID_SIM == sdt select new { SĐT = ct.ID_SIM, Thời_gian_bắt_đầu = ct.TG_BATDAU, Thời_gian_kết_thúc = ct.TG_KETTHUC, Tiền_cước = ct.Tien_cuoc }).ToArray();
        //            return select;
        //        }
        //}
        public static Array thong_Tin_Khach_Hang()
            {
                using (var db = new QLTCEntities2())
                {

                var query =
                    (
                    from kh in db.KHACHHANGs
                    join s in db.SIMs on kh.CMND equals s.CMND
                    select new
                    {
                        Identity = kh.CMND,
                        FullName = kh.HOVATEN,
                        PhoneNumber = s.id_Sim,
                        ActiveDate = s.NgayKichHoat,
                        SimStatus = s.TrangThaiSIM,
                        LockedDate=s.Ngay_lock,
                        Gmail=kh.GMAIL,
                        Address=kh.DIACHI,
                        Career=kh.NGHENGHIEP,
                        
                    }
                    ).ToArray();
                return query;
                }
            }
            public static Array thong_Tin_Khach_Hang(string CMND_Khach_hang)
            {
            if (CMND_Khach_hang == null || CMND_Khach_hang=="")
                return thong_Tin_Khach_Hang();
            else
                using (var db = new QLTCEntities2())
                {

                    var query =
                        (
                        from kh in db.KHACHHANGs
                        join s in db.SIMs on kh.CMND equals s.CMND
                        where kh.CMND.Contains(CMND_Khach_hang)
                        select new
                        {
                            Identity = kh.CMND,
                            FullName = kh.HOVATEN,
                            PhoneNumber = s.id_Sim,
                            ActiveDate = s.NgayKichHoat,
                            Gmail = kh.GMAIL,
                            Address = kh.DIACHI,
                            Career = kh.NGHENGHIEP,

                        }
                        ).ToArray();
                    return query;
                }
            }
            public static Array danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(KHACHHANG KH_A) // Trả về danh sách hóa đơn của khách hàng có ID_SIM(CMND) là id_SIM_Khach_Hang
        {
                
                    
                        if (KH_A == null)
                        {
                            using (var db = new QLTCEntities2())
                            {
                                var query = (
                                    from hd in db.HOADONTINHCUOCs
                                    select new
                                    {
                                        BillNumber = hd.Ngay_Thang,
                                        Fee = hd.Tong_Tien,
                                        Status = hd.TrangThai,
                                       
                                    }
                                    
                                    ).ToArray();
                                return query;
                            }
                        }
                        else
                        {
                            using (var db = new QLTCEntities2())
                            {
                    var query = (
                        from hd in db.HOADONTINHCUOCs
                        join simm in db.SIMs on hd.ID_SIM equals simm.id_Sim
                        join kh in db.KHACHHANGs on simm.CMND equals kh.CMND
                        where kh.CMND == KH_A.CMND
                        select new
                        {
                            BillNumber = hd.Ngay_Thang,
                            Status = hd.TrangThai,
                            PhoneNumber=simm.id_Sim,
                            Fee = hd.Tong_Tien,
                            //SimStatus = simm.TrangThaiSIM,


                            }
                            ).ToArray();
                                return query;
                            }
                        }
                    
                
                    
                
                    
            }
            public static Array danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(KHACHHANG KH_A,string thang,string nam) // Trả về danh sách hóa đơn của khách hàng có ID_SIM(CMND) là id_SIM_Khach_Hang
        {

            string ngaythang = thang + "-" + nam;
            if (KH_A == null)
            {
                using (var db = new QLTCEntities2())
                {
                    var query = (
                        from hd in db.HOADONTINHCUOCs
                        where hd.Ngay_Thang.Contains(ngaythang)
                       
                        select new
                        {
                            BillNumber = hd.Ngay_Thang,
                            PhoneNumber=hd.ID_SIM,
                            Fee = hd.Tong_Tien,
                            Status = hd.TrangThai,

                        }

                        ).ToArray();
                    return query;
                }
            }
            else
            {
                using (var db = new QLTCEntities2())
                {
                    var query = (
                        from hd in db.HOADONTINHCUOCs
                        join simm in db.SIMs on hd.ID_SIM equals simm.id_Sim
                        join kh in db.KHACHHANGs on simm.CMND equals kh.CMND
                        where kh.CMND == KH_A.CMND
                        where hd.Ngay_Thang.Contains(ngaythang)
                        select new
                        {
                            BillNumber = hd.Ngay_Thang,
                           
                            Status = hd.TrangThai,
                            PhoneNumber = hd.ID_SIM,
                            Fee = hd.Tong_Tien,
                            //SimStatus = simm.TrangThaiSIM,


                        }
                            ).ToArray();
                    return query;
                }
            }





        }
               public static List<CHITIETSUDUNG> lay_Danh_Sach_CTSD_theo_thang(string sim_ID, int thang_Hoa_Don)
            {
                using (var db = new QLTCEntities2())
                {
                    var query = from CHITIETSUDUNG in db.CHITIETSUDUNGs
                                where CHITIETSUDUNG.ID_SIM == sim_ID && CHITIETSUDUNG.TG_BATDAU.Month == thang_Hoa_Don
                                select CHITIETSUDUNG;
                    List<CHITIETSUDUNG> list_CTSD = query.ToList<CHITIETSUDUNG>();
                    return list_CTSD;
                }

            }
            public static List<SIM> lay_Danh_Sach_SIM(string sim_ID)
            {
                using (var db = new QLTCEntities2())
                {
                    var query = from s in db.SIMs
                                where s.id_Sim == sim_ID
                                select s;
                    List<SIM> list_SIM = query.ToList<SIM>();
                    return list_SIM;
                }

            }
            public static List<SIM> lay_Danh_Sach_Sim()
            {
                using (var db = new QLTCEntities2())
                {
                    var query = (from SIM in db.SIMs
                                 select SIM).ToList<SIM>();
                    return query;
                }

            }

            public static Array lay_Danh_Sach_Sim_Status(string status)
            {
                using (var db = new QLTCEntities2())
                {
                var query = (from s in db.SIMs
                             where s.TrangThaiSIM == status
                                 select s.id_Sim).ToArray();
                    return query;
                }

            }
            public static void them_Hoa_Don(HOADONTINHCUOC hoa_Don_A)
            {
                using (var db = new QLTCEntities2())
                {
                db.HOADONTINHCUOCs.Add(hoa_Don_A);
                 try {
                    db.SaveChanges();
}
                    catch { }
                }
            }
            public static Array danh_Sach_Khach_Hang_Chua_Thanh_Toan()
            {

                using (var db = new QLTCEntities2())
                {


                    var query = (
                        from hd in db.HOADONTINHCUOCs
                        join sim in db.SIMs on hd.ID_SIM equals sim.id_Sim
                        join kh in db.KHACHHANGs on sim.CMND equals kh.CMND
                        where hd.TrangThai == "Not Paid"
                        select new
                        {
                            Trạng_Thái = hd.TrangThai,
                            CMND = kh.CMND,
                             Họ_Tên= kh.HOVATEN,
                            Tiền_Cước = hd.Tong_Tien,

                            Mã_Hóa_Đơn = hd.Ngay_Thang,
                            Gmail = kh.GMAIL
                        }
                        ).ToArray();

                    // Create a table from the query.
                    return query;

                }


            }
            public static Array danh_Sach_Hoa_Don_Tong_Hop_DAO()
            {
            
                using (var db = new QLTCEntities2())
                {


                    var query = (
                        from hd in db.HOADONTINHCUOCs
                        join sim in db.SIMs on hd.ID_SIM equals sim.id_Sim
                        join kh in db.KHACHHANGs on sim.CMND equals kh.CMND
                        orderby kh.HOVATEN ascending
                        select new
                        {
                            BillNumber = hd.Ngay_Thang,
                            Status = hd.TrangThai,
                            FullName = kh.HOVATEN,
                            Identity = kh.CMND,                     
                            Fee = hd.Tong_Tien,
                            



                            // Gmail = kh.GMAIL
                        }
                        ).ToArray();

                    // Create a table from the query.
                    return query;

                }


            }
        public static Array danh_Sach_Hoa_Don_Tong_Hop(string thang,string nam)
        {
            string thangnam = thang + "-" + nam;
            using (var db = new QLTCEntities2())
            {


                var query = (
                    from hd in db.HOADONTINHCUOCs
                    join sim in db.SIMs on hd.ID_SIM equals sim.id_Sim
                    join kh in db.KHACHHANGs on sim.CMND equals kh.CMND
                    where hd.Ngay_Thang.Contains(thangnam)
                    orderby kh.HOVATEN ascending
                    select new
                    {
                        BillNumber = hd.Ngay_Thang,
                        Status = hd.TrangThai,
                        PhoneNumber=hd.ID_SIM,
                        FullName = kh.HOVATEN,
                        Identity = kh.CMND,
                        Fee = hd.Tong_Tien,




                            // Gmail = kh.GMAIL
                        }
                    ).ToArray();

                // Create a table from the query.
                return query;

            }


        }
        public static bool them_Khach_Hang(KHACHHANG Khach_Hang_A)
            {
                using (var db = new QLTCEntities2())
                {
                    if (db.KHACHHANGs.Find(Khach_Hang_A.CMND) == null)
                    {
                        db.KHACHHANGs.Add(Khach_Hang_A);
                        db.SaveChanges();


                    }
                    else return false;
                }
                return true;
            }
            public static void cap_Nhat_Trang_Thai_Hoa_Don(string mahoadon,string trang_Thai_Hoa_Don)
            {
            KHACHHANG khachhang_empty = new KHACHHANG();
            Array dshd = danh_Sach_Hoa_Don_Cua_Mot_Khach_Hang(khachhang_empty);
               
                    if (trang_Thai_Hoa_Don == "Not Paid") trang_Thai_Hoa_Don = "Paid";
                    else if (trang_Thai_Hoa_Don == "Paid") trang_Thai_Hoa_Don = "Not Paid";
            
                
                using (var db = new QLTCEntities2())
                {
                var query_update = (from hd in db.HOADONTINHCUOCs select hd).ToList<HOADONTINHCUOC>();
                foreach(HOADONTINHCUOC hd in query_update)
                     if(hd.Ngay_Thang==mahoadon)
                        hd.TrangThai= trang_Thai_Hoa_Don;
                db.SaveChanges();
                }
           
            }
            public static void tao_Sim_DAO(SIM sim_a)
        {
            try
            {
                using (var db = new QLTCEntities2())
                {
                    db.SIMs.Add(sim_a);
                    db.SaveChanges();
                }
            }
            catch { }
        }
            public static void xoa_Tat_Ca_Hoa_Don()
            {
                using (var db = new QLTCEntities2())
                {
                    var remove =( from hd in db.HOADONTINHCUOCs                             
                                 select hd).ToList<HOADONTINHCUOC>();
                    if (remove != null)
                    {
                    foreach(HOADONTINHCUOC hd in remove)
                          db.HOADONTINHCUOCs.Remove(hd);
                          db.SaveChanges();
                    }
                
                }
            }
            public static void xoa_Tat_Ca_Chi_Tiet_Su_Dung()
            {
                using (var db = new QLTCEntities2())
                {
                    var remove = (
                                  from ctsd in db.CHITIETSUDUNGs
                                  select ctsd
                                  ).ToList<CHITIETSUDUNG>();
                    if (remove != null)
                    {
                        foreach (CHITIETSUDUNG hd in remove)
                            db.CHITIETSUDUNGs.Remove(hd);
                            db.SaveChanges();
                }

                }

            }
        public static void cap_Nhat_Danh_Sach_Sim_DAO()
        {
            string status = 1.ToString();
            Array sdt = QuanLyNguoiDung_QuanLy_BUS.lay_Danh_Sach_Sim_Status(status);
            //tạo file sim.txt mới
            FileStream fs = new FileStream("sim.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            foreach (string s in sdt)
            {
                sw.WriteLine(s);
            }
            sw.Flush();
            fs.Close();
        }

    }

}
