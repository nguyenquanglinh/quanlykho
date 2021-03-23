using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.DAO
{
    public class HangHoaDAO
    {

        private HangHoaDAO() { }

        private static volatile HangHoaDAO instance;

        static object key = new object();

        public static HangHoaDAO Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new HangHoaDAO();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }


        public List<HangHoa> GetList()
        {
            List<HangHoa> list = new List<HangHoa>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.HANGHOA");
            foreach (DataRow item in data.Rows)
            {
                HangHoa obj = new HangHoa(item);
                list.Add(obj);
            }
            return list;
        }

        public int Create(string MaHH, string TenHangHoa, string MoTa, string DVT, string MaNH, string MaNCC, string GiaVon, string NgayCapNhat)
        {
            string query = $"INSERT dbo.HANGHOA VALUES  ( N'{MaHH}', N'{TenHangHoa}', N'{MoTa}',  N'{DVT},N'{MaNH}', N'{MaNCC}', N'{GiaVon}',  N'{NgayCapNhat}'))";
            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }
        public int Update(string MaHH, string TenHangHoa, string MoTa, string DVT, string MaNH, string MaNCC, string GiaVon, string NgayCapNhat)
        {
            string query = $"UPDATE dbo.HANGHOA SET TenHangHoa=N'{TenHangHoa}',MoTa=N'{MoTa}',DVT=N'{DVT}',MaNH=N'{MaNH}',MaNCC=N'{MaNCC}',GiaVon=N'{GiaVon}',NgayCapNhat=N'{NgayCapNhat}' where MaHH={MaHH}";
            DataProvider.Instance.ExecuteNonQuery(query);
            return 1;
        }
        public int Delete(string MaHH)
        {
            string query = $"DELETE dbo.HANGHOA WHERE MaHH={MaHH}";

            DataProvider.Instance.ExecuteNonQuery(query);

            return 1;
        }

    }
}
