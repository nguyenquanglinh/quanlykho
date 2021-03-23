using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class PhieuXuatDAO
    {

        private PhieuXuatDAO() { }

        private static volatile PhieuXuatDAO instance;

        static object key = new object();

        public static PhieuXuatDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new PhieuXuatDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<PhieuXuat> GetList()
        {
            List<PhieuXuat> list = new List<PhieuXuat>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.PHIEUXUAT");
            foreach (DataRow item in data.Rows)
            {
                PhieuXuat obj = new PhieuXuat(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaPX, string NgayXuat, string MaKH, string DiaChi, string MaNV, string MaKho, string GhiChu)
        {
            string query = $"INSERT dbo.PHIEUXUAT VALUES  ( N'{MaPX}', N'{NgayXuat}', N'{MaKH}', N'{DiaChi}',N'{MaNV}', N'{MaKho}', N'{GhiChu}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaPX, string NgayXuat, string MaKH, string DiaChi, string MaNV, string MaKho, string GhiChu)
        {
            string query = $"UPDATE dbo.PHIEUXUAT SET NgayXuat=N'{NgayXuat}',MaKH=N'{MaKH}',DiaChi=N'{DiaChi}',MaNV=N'{MaNV}',MaKho=N'{MaKho}',GhiChu=N'{GhiChu}' where MaPX={MaPX}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaPX)
        {
            string query = $"DELETE dbo.PHIEUXUAT WHERE MaPX={MaPX}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
