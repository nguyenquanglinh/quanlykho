using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
    public class PhieuNhap
    {
        public string MaPN { get; set; }
        public string NgayNhap { get; set; }
        public string MaNCC { get; set; }
        public string DiaChi { get; set; }
        public string MaNV { get; set; }
        public string MaKho { get; set; }
        public string GhiChu { get; set; }
        public PhieuNhap() { }
        public PhieuNhap(DataRow row)
        {
            MaNV = row["MaNV"].ToString();
            MaPN = row["MaPN"].ToString();
            NgayNhap = row["NgayNhap"].ToString();
            GhiChu = row["GhiChu"].ToString();
            MaNCC = row["MaNCC"].ToString();
            DiaChi = row["DiaChi"].ToString();
            MaKho = row["MaKho"].ToString();
        }
    }
}
