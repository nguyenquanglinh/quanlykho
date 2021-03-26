using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
    public class CTPhieuNhap
    {
        public string MaCTPN { get; set; }
        public string MaPN { get; set; }
        public string MaHH { get; set; }
        public string SoLuong { get; set; }
        public string GiaNhap { get; set; }
        public CTPhieuNhap() { }
        public CTPhieuNhap(DataRow row)
        {
            MaCTPN = row["MaCTPN"].ToString();
            MaPN = row["MaPN"].ToString();
            MaHH = row["MaHH"].ToString();
            SoLuong = row["SoLuong"].ToString();
            GiaNhap = row["GiaNhap"].ToString();
        }
    }
}
