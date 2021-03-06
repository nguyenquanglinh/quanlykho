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
    
    public partial class HANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGHOA()
        {
            this.CTPHIEUMUAs = new HashSet<CTPHIEUMUA>();
            this.CTPHIEUNHAPs = new HashSet<CTPHIEUNHAP>();
            this.CTPHIEUXUATs = new HashSet<CTPHIEUXUAT>();
            this.TONDAUKies = new HashSet<TONDAUKY>();
        }
    
        public string MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        public string DVT { get; set; }
        public string MaNH { get; set; }
        public string MaNCC { get; set; }
        public Nullable<decimal> GiaVon { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUMUA> CTPHIEUMUAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUNHAP> CTPHIEUNHAPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUXUAT> CTPHIEUXUATs { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHOMHANG NHOMHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONDAUKY> TONDAUKies { get; set; }
    }
}
