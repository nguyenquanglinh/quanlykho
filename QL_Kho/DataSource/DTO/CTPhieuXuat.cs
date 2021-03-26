using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class CTPhieuXuat
    {
        public string MaCTPX { get; set; }
        public string MaPX { get; set; }
        public string MaHH { get; set; }
        public string SoLuong { get; set; }
        public string GiaXuat { get; set; }
        public CTPhieuXuat() { }
        public CTPhieuXuat(DataRow row)
        {
            MaCTPX = row["MaCTPX"].ToString();
            MaPX = row["MaPX"].ToString();
            MaHH = row["MaHH"].ToString();
            SoLuong = row["SoLuong"].ToString();
            GiaXuat = row["GiaXuat"].ToString();
        }
    }
}
