using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class KhachHangDAO
    {
        private KhachHangDAO() { }

        private static volatile KhachHangDAO instance;

        static object key = new object();

        public static KhachHangDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new KhachHangDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<KhachHang> GetList()
        {
            List<KhachHang> list = new List<KhachHang>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.KHACHHANG");
            foreach (DataRow item in data.Rows)
            {
                KhachHang obj = new KhachHang(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaKH, string TenKhachHang, string DiaChi, string SDT, string Email)
        {
            string query = $"INSERT dbo.KHACHHANG VALUES  ( N'{MaKH}', N'{TenKhachHang}', N'{DiaChi}',  N'{SDT},N'{Email}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaKH, string TenKhachHang, string DiaChi, string SDT, string Email)
        {
            string query = $"UPDATE dbo.KHACHHANG SET TenKhachHang=N'{TenKhachHang}',DiaChi=N'{DiaChi}',SDT=N'{SDT}',Email=N'{Email}' where MaKH={MaKH}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaKH)
        {
            string query = $"DELETE dbo.KHACHHANG WHERE MaKH={MaKH}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
