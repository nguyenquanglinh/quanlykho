using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class PhieuNhapDAO
    {

        private PhieuNhapDAO() { }

        private static volatile PhieuNhapDAO instance;

        static object key = new object();

        public static PhieuNhapDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new PhieuNhapDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<PhieuNhap> GetList()
        {
            List<PhieuNhap> list = new List<PhieuNhap>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.PHIEUNHAP");
            foreach (DataRow item in data.Rows)
            {
                PhieuNhap obj = new PhieuNhap(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaPN, string NgayNhap,string MaNCC, string DiaChi, string MaNV, string MaKho, string GhiChu)
        {
            string query = $"INSERT dbo.PHIEUNHAP VALUES  ( N'{MaPN}', N'{NgayNhap}', N'{MaNCC}', N'{DiaChi}',N'{MaNV}', N'{MaKho}', N'{GhiChu}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaPN, string NgayNhap, string MaNCC, string DiaChi, string MaNV, string MaKho, string GhiChu)
        {
            string query = $"UPDATE dbo.PHIEUNHAP SET NgayNhap=N'{NgayNhap}',MaNCC=N'{MaNCC}',DiaChi=N'{DiaChi}',MaNV=N'{MaNV}',MaKho=N'{MaKho}',GhiChu=N'{GhiChu}' where MaPN={MaPN}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaPN)
        {
            string query = $"DELETE dbo.PHIEUNHAP WHERE MaPN={MaPN}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
