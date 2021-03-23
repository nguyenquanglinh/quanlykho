using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
    public class NhomHang
    {
        public string MaNH { get; set; }
        public string TenNhomHang { get; set; }
        public string MoTa { get; set; }
        public NhomHang() { }
        public NhomHang(DataRow row)
        {
            MaNH = row["MaNH"].ToString();
            TenNhomHang = row["TenNhomHang"].ToString();
            MoTa = row["MoTa"].ToString();
        }
    }
}
