using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class NhomHangDAO
    {

        private NhomHangDAO() { }

        private static volatile NhomHangDAO instance;

        static object key = new object();

        public static NhomHangDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new NhomHangDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<NhomHang> GetList()
        {
            List<NhomHang> list = new List<NhomHang>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.NHOMHANG");
            foreach (DataRow item in data.Rows)
            {
                NhomHang obj = new NhomHang(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaNH, string TenNhomHang, string MoTa)
        {
            string query = $"INSERT dbo.NHOMHANG VALUES  ( N'{MaNH}', N'{TenNhomHang}', N'{MoTa}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaNH, string TenNhomHang, string MoTa)
        {
            string query = $"UPDATE dbo.NHOMHANG SET TenNhomHang=N'{TenNhomHang}',MoTa=N'{MoTa}' where MaNH={MaNH}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaNH)
        {
            string query = $"DELETE dbo.NHOMHANG WHERE MaNH={MaNH}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
