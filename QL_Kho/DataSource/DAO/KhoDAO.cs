using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
 
    public class KhoDAO
    {

        private KhoDAO() { }

        private static volatile KhoDAO instance;

        static object key = new object();

        public static KhoDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new KhoDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<Kho> GetList()
        {
            List<Kho> list = new List<Kho>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHO");
            foreach (DataRow item in data.Rows)
            {
                Kho obj = new Kho(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaKho, string TenKho, string DiaChi)
        {
            string query = $"INSERT dbo.KHO VALUES  ( N'{MaKho}', N'{TenKho}', N'{DiaChi}',  N'{DiaChi}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaKho, string TenKho, string DiaChi)
        {
            string query = $"UPDATE dbo.KHO SET TenKho=N'{TenKho}',DiaChi=N'{DiaChi}' where MaKho={MaKho}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaKho)
        {
            string query = $"DELETE dbo.KHO WHERE MaKho={MaKho}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
