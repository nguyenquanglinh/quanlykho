using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class CTPhieuXuatDAO
    {

        private CTPhieuXuatDAO() { }

        private static volatile CTPhieuXuatDAO instance;

        static object key = new object();

        public static CTPhieuXuatDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new CTPhieuXuatDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<CTPPhieuXuat> GetList()
        {
            List<CTPPhieuXuat> list = new List<CTPPhieuXuat>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CTPHIEUXUAT");
            foreach (DataRow item in data.Rows)
            {
                CTPPhieuXuat obj = new CTPPhieuXuat(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaCTPX, string MaPX, string MaHH, string SoLuong, string GiaXuat)
        {
            string query = $"INSERT dbo.CTPHIEUXUAT VALUES  ( N'{MaCTPX}', N'{MaPX}', N'{MaHH}',  N'{SoLuong}',  N'{GiaXuat}')";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaCTPX, string MaPX, string MaHH, string SoLuong, string GiaXuat)
        {
            string query = $"UPDATE dbo.CTPHIEUXUAT SET MaPX=N'{MaPX}',MaHH=N'{MaHH}',SoLuong=N'{SoLuong}',GiaXuat=N'{GiaXuat}' where MaCTPX={MaCTPX}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaCTPX)
        {
            string query = $"DELETE dbo.CTPHIEUXUAT WHERE MaCTPX={MaCTPX}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
