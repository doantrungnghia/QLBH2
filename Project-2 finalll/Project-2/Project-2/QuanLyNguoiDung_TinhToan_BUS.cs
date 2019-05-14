using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    class QuanLyNguoiDung_TinhToan_BUS
    {
        
        public static double TinhTien(CHITIETSUDUNG CTSD_A)
        {
            double tongtien_cua_CTHD = 0;
            DateTime giobatdau = CTSD_A.TG_BATDAU;
            DateTime gioketthuc = CTSD_A.TG_KETTHUC;
            //DateTime haibagio = new DateTime(giobatdau.Year,giobatdau.Month,giobatdau.Day,23,00,00);
            //DateTime baygio = new DateTime(giobatdau.Year, giobatdau.Month, giobatdau.Day, 7, 00, 00);
            ////DateTime baygio = Convert.ToDateTime("7:00:00", CultureInfo.CreateSpecificCulture("fr-FR"));
            ////DateTime haibagio = Convert.ToDateTime("23:00:00", CultureInfo.CreateSpecificCulture("fr-FR"));
            //var tongthoigian = gioketthuc.Minute - giobatdau.Minute;
            ////Gần mốc nào thì trừ mốc đó
            //TimeSpan temp1 = new TimeSpan(); //Tìm thời gian giá 1
            //TimeSpan temp2 = new TimeSpan();
            //if (Math.Abs(giobatdau.Hour - 23) > Math.Abs(giobatdau.Hour -7))
            //    temp1 = giobatdau.Subtract(baygio);
            //else  giobatdau.Subtract(haibagio);

            //if (Math.Abs(gioketthuc.Hour - 23) > Math.Abs(gioketthuc.Hour - 7))
            //    temp2 = gioketthuc.Subtract(baygio);
            //else temp2 = gioketthuc.Subtract(haibagio);

            //double thoigiangia1 =temp1.TotalSeconds+temp2.TotalSeconds ;
            //tongtien_cua_CTHD = thoigiangia1*.;

            ////tạo biến đếm
            //bắt đấu tăng 1s thì *200/60

            ////
            ///
            DateTime temp = new DateTime();
            temp = giobatdau;
            //float comp = DateTime.Compare(temp, gioketthuc);
            while (DateTime.Compare(temp, gioketthuc)<= 0)
            {
               
                temp=temp.AddSeconds(10);

                if (temp.Hour < 23 && temp.Hour > 7)
                    tongtien_cua_CTHD = tongtien_cua_CTHD + (200/6)*1.0;
                else tongtien_cua_CTHD = tongtien_cua_CTHD + (150/6)*1.0;
            }
            return tongtien_cua_CTHD;
        
        }
    
    }
}
