using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNhanVien { get; set; }
        public string ChucVu { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public NhanVien() { }
        public NhanVien(DataRow row)
        {
            MaNV = row["MaNV"].ToString();
            TenNhanVien = row["TenNhanVien"].ToString();
            ChucVu = row["ChucVu"].ToString();
            SDT = row["SDT"].ToString();
            Email = row["Email"].ToString();
            NgaySinh = row["NgaySinh"].ToString();
            GioiTinh = row["GioiTinh"].ToString();
        }
    }
}
