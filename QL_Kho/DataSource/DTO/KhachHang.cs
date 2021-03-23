using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public KhachHang() { }
        public KhachHang(DataRow row)
        {
            MaKH = row["MaKH"].ToString();
            TenKhachHang = row["TenKhachHang"].ToString();
            DiaChi = row["DiaChi"].ToString();
            SDT = row["SDT"].ToString();
            Email = row["Email"].ToString();
        }
    }
}
