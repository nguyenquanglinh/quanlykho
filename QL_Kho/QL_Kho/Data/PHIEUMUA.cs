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
    
    public partial class PHIEUMUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUA()
        {
            this.CTPHIEUMUAs = new HashSet<CTPHIEUMUA>();
        }
    
        public string MaPM { get; set; }
        public Nullable<System.DateTime> NgayLap { get; set; }
        public string MaNV { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUMUA> CTPHIEUMUAs { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
