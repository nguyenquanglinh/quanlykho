using DataSource.DTO;
using System.Collections.Generic;
using System.Data;

namespace DataSource.DAO
{
    public class CTPhieuMuaDAO
    {
        private CTPhieuMuaDAO() { }

        private static volatile CTPhieuMuaDAO instance;

        static object key = new object();

        public static CTPhieuMuaDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new CTPhieuMuaDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<CTPPhieuMua> GetList()
        {
            List<CTPPhieuMua> list = new List<CTPPhieuMua>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.CTPHIEUMUA");
            foreach (DataRow item in data.Rows)
            {
                CTPPhieuMua obj = new CTPPhieuMua(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaCTPM, string MaPM, string MaHH, string SoLuong)
        {
            string query = $"INSERT dbo.CTPHIEUMUA VALUES  ( N'{MaCTPM}', N'{MaPM}', N'{MaHH}',  N'{SoLuong})";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaCTPM, string MaPM, string MaHH, string SoLuong)
        {
            string query = $"UPDATE dbo.CTPHIEUMUA SET MaPM=N'{MaPM}',MaHH=N'{MaHH}',SoLuong=N'{SoLuong}' where MaCTPM={MaCTPM}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaCTPM)
        {
            string query = $"DELETE dbo.CTPHIEUMUA WHERE MaCTPM={MaCTPM}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
