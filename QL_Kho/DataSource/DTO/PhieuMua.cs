using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class PhieuMua
    {
        public string MaPM { get; set; }
        public string NgayLap { get; set; }
        public string MaNV { get; set; }
        public string GhiChu { get; set; }
        public PhieuMua() { }
        public PhieuMua(DataRow row)
        {
            MaNV = row["MaNV"].ToString();
            MaPM = row["MaPM"].ToString();
            NgayLap = row["NgayLap"].ToString();
            GhiChu = row["GhiChu"].ToString();
        }
    }
}
