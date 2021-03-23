using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class HangHoa
    {
        public string MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public string MoTa { get; set; }
        public string DVT { get; set; }
        public string MaNH { get; set; }
        public string MaNCC { get; set; }
        public string GiaVon { get; set; }
        public string NgayCapNhat { get; set; }

        public HangHoa() { }
        public HangHoa(DataRow row)
        {
            MaHH = row["MaHH"].ToString();
            TenHangHoa = row["TenHH"].ToString();
            MoTa = row["MoTa"].ToString();
            DVT = row["DVT"].ToString();
            MaNH = row["MaNH"].ToString();
            MaNCC = row["MaNCC"].ToString();
            GiaVon = row["GiaVon"].ToString();
            NgayCapNhat = row["NgayCapNhat"].ToString();
        }
    }
}
