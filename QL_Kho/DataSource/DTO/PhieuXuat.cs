using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class PhieuXuat
    {
        public string MaPX { get; set; }
        public string NgayXuat { get; set; }
        public string MaKH { get; set; }
        public string DiaChi { get; set; }
        public string MaNV { get; set; }
        public string MaKho { get; set; }
        public string GhiChu { get; set; }
        public PhieuXuat() { }
        public PhieuXuat(DataRow row)
        {
            MaNV = row["MaNV"].ToString();
            MaPX = row["MaPX"].ToString();
            NgayXuat = row["NgayXuat"].ToString();
            GhiChu = row["GhiChu"].ToString();
            MaKH = row["MaKH"].ToString();
            DiaChi = row["DiaChi"].ToString();
            MaKho = row["MaKho"].ToString();
        }
    }
}
