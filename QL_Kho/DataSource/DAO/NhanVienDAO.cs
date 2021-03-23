using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class NhanVienDAO
    {

        private NhanVienDAO() { }

        private static volatile NhanVienDAO instance;

        static object key = new object();

        public static NhanVienDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<NhanVien> GetList()
        {
            List<NhanVien> list = new List<NhanVien>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.NHANVIEN");
            foreach (DataRow item in data.Rows)
            {
                NhanVien obj = new NhanVien(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaNV, string TenNhanVien, string NgaySinh, string GioiTinh, string DiaChi, string SDT, string Email)
        {
            string query = $"INSERT dbo.NHANVIEN VALUES  ( N'{MaNV}', N'{TenNhanVien}', N'{NgaySinh}',  N'{GioiTinh}',N'{DiaChi}', N'{SDT}',N'{Email}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaNV, string TenNhanVien, string NgaySinh, string GioiTinh, string DiaChi, string SDT, string Email)
        {
            string query = $"UPDATE dbo.NHANVIEN SET TenNhanVien=N'{TenNhanVien}',NgaySinh=N'{NgaySinh}',GioiTinh=N'{GioiTinh}',DiaChi=N'{DiaChi}',SDT=N'{SDT}',Email=N'{Email}' where MaNV={MaNV}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaNV)
        {
            string query = $"DELETE dbo.NHANVIEN WHERE MaNV={MaNV}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
