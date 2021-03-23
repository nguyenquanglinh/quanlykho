using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class NhaCungCapDAO
    {

        private NhaCungCapDAO() { }

        private static volatile NhaCungCapDAO instance;

        static object key = new object();

        public static NhaCungCapDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new NhaCungCapDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<NhaCungCap> GetList()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.NHACUNGCAP");
            foreach (DataRow item in data.Rows)
            {
                NhaCungCap obj = new NhaCungCap(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaNCC, string TenNCC, string DiaChi, string SDT, string Email)
        {
            string query = $"INSERT dbo.NHACUNGCAP VALUES  ( N'{MaNCC}', N'{TenNCC}', N'{DiaChi}',  N'{SDT}',N'{Email}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaNCC, string TenNCC, string DiaChi, string SDT, string Email)
        {
            string query = $"UPDATE dbo.KHO SET TenNCC=N'{TenNCC}',DiaChi=N'{DiaChi}',SDT=N'{SDT}' where MaNCC={MaNCC}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaNCC)
        {
            string query = $"DELETE dbo.NHACUNGCAP WHERE MaNCC={MaNCC}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
