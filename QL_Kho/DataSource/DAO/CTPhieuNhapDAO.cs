using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class CTPhieuNhapDAO
    {

        private CTPhieuNhapDAO() { }

        private static volatile CTPhieuNhapDAO instance;

        static object key = new object();

        public static CTPhieuNhapDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new CTPhieuNhapDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<CTPPhieuNhap> GetList()
        {
            List<CTPPhieuNhap> list = new List<CTPPhieuNhap>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CTPHIEUNHAP");
            foreach (DataRow item in data.Rows)
            {
                CTPPhieuNhap obj = new CTPPhieuNhap(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaCTPN, string MaPN, string MaHH, string SoLuong, string GiaNhap)
        {
            string query = $"INSERT dbo.CTPHIEUNHAP VALUES  ( N'{MaCTPN}', N'{MaPN}', N'{MaHH}',  N'{SoLuong}),  N'{GiaNhap})";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaCTPN, string MaPN, string MaHH, string SoLuong, string GiaNhap)
        {
            string query = $"UPDATE dbo.CTPHIEUNHAP SET MaPN=N'{MaPN}',MaHH=N'{MaHH}',SoLuong=N'{SoLuong}',GiaNhap=N'{GiaNhap}' where MaCTPM={MaCTPN}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaCTPN)
        {
            string query = $"DELETE dbo.CTPHIEUNHAP WHERE MaCTPN={MaCTPN}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
