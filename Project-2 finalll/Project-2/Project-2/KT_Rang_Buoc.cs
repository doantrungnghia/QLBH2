using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project_2
{
    class KT_Rang_Buoc
    {
        
        public static bool is_Gmail(string gmail)
        {
            string rex = @"^[\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$";
            Regex regex = new Regex(rex);

            if (regex.IsMatch(gmail))
                return true;
            return false;
        }
        public static bool is_Word_Only(string word)
        {
            string rex = "[a-zA-Z]";
            Regex regex = new Regex(rex);

            if (regex.IsMatch(word))
                return true;
            return false;
        }
        public static bool is_Name(string ten)
        {
            string rex = @"^(\p{L}+\s?)+$";
            Regex regex = new Regex(rex);

            if (regex.IsMatch(ten))
                return true;
            return false;
        }
        public static bool is_Number_Only(string cmnd)
        {
            string rex = "^([0-9]{9})$";
            Regex regex = new Regex(rex);

            if (regex.IsMatch(cmnd))
                return true;
            return false;
        }



    }
}
