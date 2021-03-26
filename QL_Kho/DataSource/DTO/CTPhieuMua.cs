using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class CTPhieuMua
    {
        public string MaCTPM { get; set; }
        public string MaPM { get; set; }
        public string MaHH { get; set; }
        public string SoLuong { get; set; }
        public CTPhieuMua() { }
        public CTPhieuMua(DataRow row)
        {
            MaCTPM = row["MaCTPM"].ToString();
            MaPM = row["MaPM"].ToString();
            MaHH = row["MaHH"].ToString();
            SoLuong = row["SoLuong"].ToString();
        }
    }
}
