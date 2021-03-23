using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public NhaCungCap() { }
        public NhaCungCap(DataRow row)
        {
            MaNCC = row["MaNCC"].ToString();
            TenNCC = row["TenNCC"].ToString();
            DiaChi = row["DiaChi"].ToString();
            SDT = row["SDT"].ToString();
            Email = row["Email"].ToString();
        }
    }
}
