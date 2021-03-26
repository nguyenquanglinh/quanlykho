using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace QL_Kho
{
    public class DataManager
    {
        private string baseAddress = "http://localhost:64458/api/";
        private static object key = new object();
        private static volatile DataManager instance;

        private DataManager()
        {
            this.ListCTPhieuMua = GetListCTPhieuMua();
            this.ListCTPhieuNhap = GetListCTPhieuNhap();
            this.ListCTPhieuXuat = GetListCTPhieuXuat();
            this.ListDangNhap = GetListDangNhap();
            this.ListHangHoa = GetListHangHoa();
            this.ListKhachHang = GetListKhachHang();
            this.ListKho = GetListkho();
            this.ListNhaCC = GetListNhaCC();
            this.ListNhanVien = GetListNhanVien();
            this.ListNhomHang = GetListNhomHang();
            this.ListPhieuMua = GetListPhieuMua();
            this.ListPhieuNhap = GetListPhieuNhap();
            this.ListPhieuXuat = GetListPhieuXuat();
            this.ListTonDauKy = GetListTonDauKy();
        }

        public static DataManager Instance
        {
            get
            {
                lock (key)
                {
                    if (instance == null)
                    {
                        instance = new DataManager();
                    }
                }

                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        #region list 14 bang
        // lay duw lieu cho 14 bang
        public List<CTPhieuMua> ListCTPhieuMua { get; private set; }
        public List<CTPhieuNhap> ListCTPhieuNhap { get; private set; }
        public List<CTPhieuXuat> ListCTPhieuXuat { get; private set; }
        public List<DangNhap> ListDangNhap { get; private set; }
        public List<HangHoa> ListHangHoa { get; private set; }
        public List<KhachHang> ListKhachHang { get; private set; }
        public List<Kho> ListKho { get; private set; }
        public List<NhaCungCap> ListNhaCC { get; private set; }
        public List<NhanVien> ListNhanVien { get; private set; }
        public List<NhomHang> ListNhomHang { get; private set; }
        public List<PhieuMua> ListPhieuMua { get; private set; }
        public List<PhieuNhap> ListPhieuNhap { get; private set; }
        public List<PhieuXuat> ListPhieuXuat { get; private set; }
        public List<TonDauKy> ListTonDauKy { get; private set; }
        #endregion

        #region funtion api get
        //ham xu ly 14 bang
        private List<CTPhieuMua> GetListCTPhieuMua()
        {
            List<CTPhieuMua> list = new List<CTPhieuMua>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("ctphieumua");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CTPhieuMua>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<CTPhieuNhap> GetListCTPhieuNhap()
        {
            List<CTPhieuNhap> list = new List<CTPhieuNhap>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("ctphieunhap");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CTPhieuNhap>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }

        private List<CTPhieuXuat> GetListCTPhieuXuat()
        {
            List<CTPhieuXuat> list = new List<CTPhieuXuat>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("ctphieuxuat");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CTPhieuXuat>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<DangNhap> GetListDangNhap()
        {
            List<DangNhap> list = new List<DangNhap>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("dangnhap");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<DangNhap>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<HangHoa> GetListHangHoa()
        {
            List<HangHoa> list = new List<HangHoa>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("hanghoa");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<HangHoa>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<KhachHang> GetListKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("khachhang");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<KhachHang>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<Kho> GetListkho()
        {
            List<Kho> list = new List<Kho>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("kho");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Kho>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<NhaCungCap> GetListNhaCC()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("nhacungcap");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NhaCungCap>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<NhanVien> GetListNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("nhanvien");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NhanVien>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<NhomHang> GetListNhomHang()
        {
            List<NhomHang> list = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("nhomhang");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<NhomHang>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<PhieuMua> GetListPhieuMua()
        {
            List<PhieuMua> list = new List<PhieuMua>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("phieumua");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PhieuMua>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<PhieuNhap> GetListPhieuNhap()
        {
            List<PhieuNhap> list = new List<PhieuNhap>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("phieunhap");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PhieuNhap>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<PhieuXuat> GetListPhieuXuat()
        {
            List<PhieuXuat> list = new List<PhieuXuat>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("phieuxuat");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<PhieuXuat>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        private List<TonDauKy> GetListTonDauKy()
        {
            List<TonDauKy> list = new List<TonDauKy>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP GET
                var responseTask = client.GetAsync("tondauky");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<TonDauKy>>();
                    readTask.Wait();

                    list = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..    

                }
            }
            return list;
        }
        #endregion

        #region api post put delete
        public bool PostHangHoa(HangHoa hh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<HangHoa>("hanghoa", hh);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListHangHoa = GetListHangHoa();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutHangHoa(HangHoa hh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<HangHoa>("hanghoa", hh);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListHangHoa = GetListHangHoa();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteHangHoa(HangHoa hh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("hanghoa?mahh=" + hh.MaHH);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListHangHoa = GetListHangHoa();

                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostDangNhap(DangNhap dn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<DangNhap>("dangnhap", dn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListDangNhap = GetListDangNhap();

                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutDangNhap(DangNhap dn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<DangNhap>("dangnhap", dn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListDangNhap = GetListDangNhap();

                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteDangNhap(DangNhap dn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("dangnhap?ID=" + dn.ID);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListDangNhap = GetListDangNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostKhachHang(KhachHang kh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<KhachHang>("khachhang", kh);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListKhachHang = GetListKhachHang();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutKhachHang(KhachHang kh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<KhachHang>("khachhang", kh);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListKhachHang = GetListKhachHang();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteKhachHang(KhachHang kh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("khachhang?MaKH=" + kh.MaKH);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListKhachHang = GetListKhachHang();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostKho(Kho kho)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Kho>("kho", kho);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListKho = GetListkho();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutKho(Kho kho)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<Kho>("kho", kho);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListKho = GetListkho();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteKho(Kho kho)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("kho?MaKho=" + kho.MaKho);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListKho = GetListkho();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostNhaCC(NhaCungCap nhaCC)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<NhaCungCap>("nhacungcap", nhaCC);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhaCC = GetListNhaCC();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutNhaCC(NhaCungCap nhaCC)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<NhaCungCap>("nhacungcap", nhaCC);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhaCC = GetListNhaCC();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteNhaCC(NhaCungCap nhaCC)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("kho?MaNCC=" + nhaCC.MaNCC);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhaCC = GetListNhaCC();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostNhanVien(NhanVien nv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<NhanVien>("nhanvien", nv);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhanVien = GetListNhanVien();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutNhanVien(NhanVien nv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<NhanVien>("nhanvien", nv);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhanVien = GetListNhanVien();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteNhanVien(NhanVien nv)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("nhanvien?MaNV=" + nv.MaNV);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhanVien = GetListNhanVien();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostNhomHang(NhomHang nh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<NhomHang>("nhomhang", nh);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhomHang = GetListNhomHang();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutNhomHang(NhomHang nh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<NhomHang>("nhomhang", nh);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhomHang = GetListNhomHang();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteNhomHang(NhomHang nh)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("nhomhang?MaNH=" + nh.MaNH);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListNhomHang = GetListNhomHang();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostPhieuMua(PhieuMua pm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<PhieuMua>("phieumua", pm);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuMua = GetListPhieuMua();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutPhieuMua(PhieuMua pm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<PhieuMua>("phieumua", pm);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuMua = GetListPhieuMua();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeletePhieuMua(PhieuMua pm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("phieumua?MaPM=" + pm.MaPM);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuMua = GetListPhieuMua();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostCTPhieuMua(CTPhieuMua ctpm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<CTPhieuMua>("ctphieumua", ctpm);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuMua = GetListCTPhieuMua();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutCTPhieuMua(CTPhieuMua ctpm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<CTPhieuMua>("ctphieumua", ctpm);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuMua = GetListPhieuMua();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteCTPhieuMua(CTPhieuMua pm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("ctphieumua?MaCTPM=" + pm.MaCTPM);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuMua = GetListPhieuMua();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostPhieuNhap(PhieuNhap pn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<PhieuNhap>("phieunhap", pn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuNhap = GetListPhieuNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutPhieuNhap(PhieuNhap pn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<PhieuNhap>("phieunhap", pn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuNhap = GetListPhieuNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeletePhieuNhap(PhieuNhap pn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("phieunhap?MaPN=" + pn.MaPN);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuNhap = GetListPhieuNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostCTPhieuNhap(CTPhieuNhap ctpn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<CTPhieuNhap>("phieunhap", ctpn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuNhap = GetListCTPhieuNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutCTPhieuNhap(CTPhieuNhap ctpn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<CTPhieuNhap>("ctphieunhap", ctpn);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuNhap = GetListCTPhieuNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteCTPhieuNhap(CTPhieuNhap pn)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("ctphieunhap?MaCTPN=" + pn.MaCTPN);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuNhap = GetListCTPhieuNhap();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostPhieuXuat(PhieuXuat px)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<PhieuXuat>("phieuxuat", px);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuXuat = GetListPhieuXuat();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutPhieuXuat(PhieuXuat px)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<PhieuXuat>("phieuxuat", px);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuXuat = GetListPhieuXuat();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeletePhieuXuat(PhieuXuat px)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("phieuxuat?MaPX=" + px.MaPX);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListPhieuXuat = GetListPhieuXuat();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostCTPhieuXuat(CTPhieuXuat ctpx)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<CTPhieuXuat>("ctphieuxuat", ctpx);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuXuat = GetListCTPhieuXuat();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutCTPhieuXuat(CTPhieuXuat px)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PutAsJsonAsync<CTPhieuXuat>("ctphieuxuat", px);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuXuat = GetListCTPhieuXuat();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteCTPhieuXuat(CTPhieuXuat px)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("ctphieuxuat?MaCTPX=" + px.MaCTPX);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListCTPhieuXuat = GetListCTPhieuXuat();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PostTonDauKy(TonDauKy tdk)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<TonDauKy>("tondauky", tdk);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListTonDauKy = GetListTonDauKy();
                    return true;
                }
                else
                    return false;

            }
        }
        public bool PutTonDauKy(TonDauKy tdk)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                //HTTP POST
                var postTask = client.PutAsJsonAsync<TonDauKy>("tondauky", tdk);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListTonDauKy = GetListTonDauKy();

                    return true;
                }
                else
                    return false;

            }
        }
        public bool DeleteTonDauKy(TonDauKy tdk)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);

                //HTTP POST
                var postTask = client.DeleteAsync("tondauky?MaHH=" + tdk.MaHH + "&MaKho=" + tdk.MaKho + "&NgayCapNhat=" + tdk.NgayCapNhat);//string MaHH, string MaKho, string NgayCapNhat
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ListTonDauKy = GetListTonDauKy();
                    return true;
                }
                else
                    return false;

            }
        }
        #endregion
    }
}
