using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
   public class Kho
    {
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string DiaChi { get; set; }
        public Kho() { }
        public Kho(DataRow row)
        {
            MaKho = row["MaKho"].ToString();
            TenKho = row["TenKho"].ToString();
            DiaChi = row["DiaChi"].ToString();
        }
    }
}
