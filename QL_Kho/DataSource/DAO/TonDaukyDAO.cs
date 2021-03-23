using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class TonDaukyDAO
    {

        private TonDaukyDAO() { }

        private static volatile TonDaukyDAO instance;

        static object key = new object();

        public static TonDaukyDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new TonDaukyDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<TonDauKy> GetList()
        {
            List<TonDauKy> list = new List<TonDauKy>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TONDAUKY");
            foreach (DataRow item in data.Rows)
            {
                TonDauKy obj = new TonDauKy(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaHH, string MaKho, string SoLuong, string ThanhTien, string NgayCapNhat, string NgayNhap)
        {
            string query = $"INSERT dbo.TONDAUKY VALUES  ( N'{MaHH}', N'{MaKho}', N'{SoLuong}', N'{ThanhTien}',N'{NgayCapNhat}', N'{NgayNhap}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaHH, string MaKho, string SoLuong, string ThanhTien, string NgayCapNhat, string NgayNhap)
        {
            string query = $"UPDATE dbo.TONDAUKY SET SoLuong=N'{SoLuong}',ThanhTien=N'{ThanhTien}',NgayNhap=N'{NgayNhap}' where MaHH={MaHH} and MaKho={MaKho} and NgayCapNhat={NgayCapNhat}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaHH, string MaKho, string NgayCapNhat)
        {
            string query = $"DELETE dbo.TONDAUKY  where MaHH={MaHH} and MaKho={MaKho} and NgayCapNhat={NgayCapNhat}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
