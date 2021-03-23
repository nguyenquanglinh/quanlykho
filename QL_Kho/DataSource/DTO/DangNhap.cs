using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DTO
{
    public class DangNhap
    {
        public string ID { get; set; }
        public string Password { get; set; }
        public string MaNV { get; set; }
        public string PhanQuyen { get; set; }
        public DangNhap() { }
        public DangNhap(DataRow row)
        {
            ID = row["ID"].ToString();
            Password = row["Password"].ToString();
            MaNV = row["MaNV"].ToString();
            PhanQuyen = row["PhanQuyen"].ToString();
        }
    }
}
