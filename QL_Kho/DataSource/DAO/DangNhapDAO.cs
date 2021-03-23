using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{

    public class DangNhapDAO
    {

        private DangNhapDAO() { }

        private static volatile DangNhapDAO instance;

        static object key = new object();

        public static DangNhapDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new DangNhapDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<DangNhap> GetList()
        {
            List<DangNhap> list = new List<DangNhap>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DANGNHAP");
            foreach (DataRow item in data.Rows)
            {
                DangNhap obj = new DangNhap(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string ID, string Password, string MaNV, string PhanQuyen)
        {
            string query = $"INSERT dbo.DANGNHAP VALUES  ( N'{ID}', N'{Password}', N'{MaNV}',  N'{PhanQuyen}))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string ID, string Password, string MaNV, string PhanQuyen)
        {
            string query = $"UPDATE dbo.DANGNHAP SET Password=N'{Password}',MaNV=N'{MaNV}',PhanQuyen=N'{PhanQuyen}' where ID={ID}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string ID)
        {
            string query = $"DELETE dbo.DANGNHAP WHERE MaCTPX={ID}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
