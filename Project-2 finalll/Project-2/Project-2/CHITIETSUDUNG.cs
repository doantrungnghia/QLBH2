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
    
    public partial class CHITIETSUDUNG
    {
        public string ID_SIM { get; set; }
        public System.DateTime TG_BATDAU { get; set; }
        public System.DateTime TG_KETTHUC { get; set; }
        public string Tien_cuoc { get; set; }
    
        public virtual SIM SIM { get; set; }
    }
}
