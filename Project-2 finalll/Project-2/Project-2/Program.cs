using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormQuanLyNguoiDung());
            Console.OutputEncoding = Encoding.Unicode;
            //using (var db = new QLTCCEntities())
            //{
            //    var select = from s in db.KHACHHANGs select s;
            //    foreach (var data in select)
            //    {
            //        Console.WriteLine("Ho va ten:{0}",data.HOVATEN);
            //        Console.WriteLine("CMND:{0}",data.CMND);
                    
            //    }
            //}
        }
    }
}
