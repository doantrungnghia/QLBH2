using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Project_2
{


    class tao_Chi_Tiet_Su_Dung_Random


    {
        public static void taofile()
        {
            Random rd = new Random();
            RandomDateTine date = new RandomDateTine();
            
            string[] line = File.ReadAllLines("sim.txt");
           // string filepath = "log.txt";
           // FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sw = File.AppendText("log.txt");
            string str;
            for (int i = 0; i < 2; i++)
            {
                foreach (string s in line)
                {
                    DateTime temp = date.Next();
                    
                    str = s.ToString() + '\t' + temp.ToString() + '\t' + temp.AddSeconds(rd.Next(20, 3599)).ToString();
                    sw.WriteLine(str);
                    Console.WriteLine(str);
                }

            
            }

            sw.Flush();
            sw.Close();
           // fs.Close();



            Console.ReadLine();
        }
        public static void cap_Nhat_File_Sim()
        {
            using (var db =new QLTCEntities2())
            {
                var query = (
                    from sim in db.SIMs
                    where sim.TrangThaiSIM == null
                    select sim.id_Sim
                    ).ToArray();
                FileStream fs = new FileStream("sim.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                foreach (string x in query)
                {
                    sw.WriteLine(x);
                }
            }

        }
    }
    class RandomDateTine
    {

        DateTime start;
        Random gen;
        int range, m, s, d, h;

        public RandomDateTine()
        {
            start = DateTime.Now;
            gen = new Random();
            range = (DateTime.Today - start).Days;

        }

        public DateTime Next()
        {
            m = gen.Next(0, 60); s = gen.Next(0, 60); d = gen.Next(range); h = gen.Next(0, 24);
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }

    }
 

}



