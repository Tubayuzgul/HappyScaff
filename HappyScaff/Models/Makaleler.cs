//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HappyScaff.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Makaleler
    {
        public int MakaleId { get; set; }
        public string MakaleBaslik { get; set; }
        public string MakaleIcerik { get; set; }
        public Nullable<int> KategoriId { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
    }
}