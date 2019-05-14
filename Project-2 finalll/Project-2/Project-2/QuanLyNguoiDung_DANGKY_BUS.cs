using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    class QuanLyNguoiDung_DANGKY_BUS
    {
        public static bool xu_Ly_Dang_Ky(KHACHHANG Khach_Hang_A,string sDT_Dang_Ky)
        {
          
            
                //Thêm vào DB bằng LINQ
                if (QuanLyNguoiDung_QuanLy_DAO.them_Khach_Hang(Khach_Hang_A) == true) //false có nghĩa là đã tồn tại khách hàng này hoặc lí do khác mà không add được
                {
                    QuanLyNguoiDung_QuanLy_DAO.them_Khach_Hang(Khach_Hang_A);
                                               tao_Sim(Khach_Hang_A, sDT_Dang_Ky);
                   // MessageBox.Show("Tạo tài khoản thành công");
                return true;
                }
                else
                {
                
                    tao_Sim(Khach_Hang_A, sDT_Dang_Ky);
                   // MessageBox.Show("Tạo tài khoản thành công");
                }

            return false;
            

        }
        public static void tao_Sim(KHACHHANG khach_Hang_A, string so_Dien_Thoai)
        {
            DateTime time = DateTime.Now;
            SIM sim = new SIM();
            sim.id_Sim = so_Dien_Thoai;
            sim.NgayKichHoat = time;
            sim.CMND = khach_Hang_A.CMND;
            sim.TrangThaiSIM = 1.ToString();

            QuanLyNguoiDung_QuanLy_DAO.tao_Sim_DAO(sim);

        }





    }
}
