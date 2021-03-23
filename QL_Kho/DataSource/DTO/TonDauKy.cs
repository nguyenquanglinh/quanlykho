using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class TonDauKy
    {
        public string MaHH { get; set; }
        public string MaKho { get; set; }
        public string SoLuong { get; set; }
        public string ThanhTien { get; set; }
        public string NgayCapNhat { get; set; }
        public string NgayNhap { get; set; }
        public TonDauKy() { }
        public TonDauKy(DataRow row)
        {
            MaHH = row["MaHH"].ToString();
            MaKho = row["MaKho"].ToString();
            SoLuong = row["SoLuong"].ToString();
            ThanhTien = row["ThanhTien"].ToString();
            NgayCapNhat = row["NgayCapNhat"].ToString();
            NgayNhap = row["NgayNhap"].ToString();
        }
    }
}
