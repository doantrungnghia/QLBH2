using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace Project_2
{
    class QuanLyNguoiDung_GuiThu_BUS
    {
       
        public static bool gui_Thu_Dien_Tu(string noidunggui,string tenkhachhang,string gmail)
        {
            try
            {
                
               
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("minhtinh9x8@gmail.com","tinhvirgo9x");
                //vòng lặp các gmail khách hàng
                MailMessage message = new MailMessage("minhtinh9x8@gmail.com",gmail);
                // Nội dung gửi đi
                message.Subject = "Về Việc Cước Phí Hàng Tháng - "+ tenkhachhang;
                message.Body = noidunggui;
                        

                mailclient.Send(message);
                return true;

               // MessageBox.Show("Đã gửi gmail cho khách hàng " + tenkhachhang, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                


            }
            catch (Exception ex)
            {

                MessageBox.Show("Gửi gmail cho khách hàng "+tenkhachhang+" thất bại" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

        }
        public static Array danh_Sach_Khach_Hang_Chua_Thanh_Toan_BUS()
        {
            Array arr;
            arr = QuanLyNguoiDung_QuanLy_DAO.danh_Sach_Khach_Hang_Chua_Thanh_Toan();
            return arr;
        }
    }
    
}
