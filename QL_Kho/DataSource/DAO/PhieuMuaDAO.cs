using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class PhieuMuaDAO
    {

        private PhieuMuaDAO() { }

        private static volatile PhieuMuaDAO instance;

        static object key = new object();

        public static PhieuMuaDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new PhieuMuaDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<PhieuMua> GetList()
        {
            List<PhieuMua> list = new List<PhieuMua>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.PHIEUMUA");
            foreach (DataRow item in data.Rows)
            {
                PhieuMua obj = new PhieuMua(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaPM, string NgayLap, string MaNV, string GhiChu)
        {
            string query = $"INSERT dbo.PHIEUMUA VALUES  ( N'{MaPM}', N'{NgayLap}', N'{MaNV}', N'{GhiChu}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaPM, string NgayLap, string MaNV, string GhiChu)
        {
            string query = $"UPDATE dbo.PHIEUMUA SET NgayLap=N'{NgayLap}',MaNV=N'{MaNV}',GhiChu=N'{GhiChu}' where MaPM={MaPM}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaPM)
        {
            string query = $"DELETE dbo.PHIEUMUA WHERE MaPM={MaPM}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
