//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOADONTINHCUOC
    {
        public string ID_SIM { get; set; }
        public string Ngay_Thang { get; set; }
        public string Tong_Tien { get; set; }
        public string TrangThai { get; set; }
    
        public virtual SIM SIM { get; set; }
    }
}
