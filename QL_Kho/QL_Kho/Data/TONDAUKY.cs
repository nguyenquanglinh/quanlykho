//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_Kho.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TONDAUKY
    {
        public string MaHH { get; set; }
        public string MaKho { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
        public System.DateTime NgayCapNhat { get; set; }
        public System.DateTime NgayNhap { get; set; }
    
        public virtual HANGHOA HANGHOA { get; set; }
        public virtual KHO KHO { get; set; }
    }
}
