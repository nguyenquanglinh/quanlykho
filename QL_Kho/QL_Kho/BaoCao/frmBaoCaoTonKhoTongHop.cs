using Microsoft.Reporting.WinForms;
using QL_Kho.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Kho
{
    public partial class frmBaoCaoTonKhoTongHop : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        List<TonKhoViewModel> listHANGHOA = new List<TonKhoViewModel>();

        public frmBaoCaoTonKhoTongHop()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTonKhoTongHop_Load(object sender, EventArgs e)
        {
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            listHANGHOA.Clear();
            var listKho = dA_QLYKHOEntities.KHOes.ToList();
            int soluongkho = listKho.Count;
            // DateTime dauthang = txtTuNgay.Value.Date.AddDays(-(txtTuNgay.Value.Day - 1)); Tính trong tháng
            // DateTime cuoithang = dauthang.AddMonths(1);
            DateTime tungay = txtTuNgay.Value.Date;
            DateTime denngay = txtDenNgay.Value.Date;
            string kho1 = soluongkho > 0 ? listKho[0].MaKho : string.Empty;
            string kho2 = soluongkho > 1 ? listKho[1].MaKho : string.Empty;
            string kho3 = soluongkho > 2 ? listKho[2].MaKho : string.Empty;
            string kho4 = soluongkho > 3 ? listKho[3].MaKho : string.Empty;
            string kho5 = soluongkho > 4 ? listKho[4].MaKho : string.Empty;
            string kho6 = soluongkho > 5 ? listKho[5].MaKho : string.Empty;
            string kho7 = soluongkho > 6 ? listKho[6].MaKho : string.Empty;
            string kho8 = soluongkho > 7 ? listKho[7].MaKho : string.Empty;
            string kho9 = soluongkho > 8 ? listKho[8].MaKho : string.Empty;
            string kho10 = soluongkho > 9 ? listKho[9].MaKho : string.Empty;

            var result = dA_QLYKHOEntities.HANGHOAs.Select(x => new TonKhoViewModel()
            {
                MaHH = x.MaHH,
                TenHangHoa = x.TenHangHoa,
                DVT = x.DVT
            }).ToList();

            var TONDAUKies = dA_QLYKHOEntities.TONDAUKies.Where(x => x.NgayCapNhat >= tungay).ToList();
            var CTPHIEUNHAPs = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.PHIEUNHAP.NgayNhap >= tungay && x.PHIEUNHAP.NgayNhap < denngay).Select(x => new NhapXuatViewModel { MaHH = x.MaHH, MaKho = x.PHIEUNHAP.MaKho, SoLuong = x.SoLuong }).ToList();
            var CTPHIEUXUATs = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.PHIEUXUAT.NgayXuat >= tungay && x.PHIEUXUAT.NgayXuat < denngay).Select(x => new NhapXuatViewModel { MaHH = x.MaHH, MaKho = x.PHIEUXUAT.MaKho, SoLuong = x.SoLuong }).ToList();

            foreach (var x in result)
            {
                x.SoLuongKho1 = soluongkho > 0 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho1).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho1).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho1).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho2 = soluongkho > 1 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho2).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho2).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho2).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho3 = soluongkho > 2 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho3).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho3).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho3).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho4 = soluongkho > 3 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho4).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho4).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho4).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho5 = soluongkho > 4 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho5).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho5).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho5).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho6 = soluongkho > 5 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho6).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho6).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho6).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho7 = soluongkho > 6 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho7).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho7).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho7).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho8 = soluongkho > 7 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho8).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho8).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho8).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho9 = soluongkho > 8 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho9).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho9).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho9).Sum(y => y.SoLuong) : 0;
                x.SoLuongKho10 = soluongkho > 9 ? TONDAUKies.Where(y => y.MaHH == x.MaHH && y.MaKho == kho10).Sum(y => y.SoLuong) + CTPHIEUNHAPs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho10).Sum(y => y.SoLuong) - CTPHIEUXUATs.Where(y => y.MaHH == x.MaHH && y.MaKho == kho10).Sum(y => y.SoLuong) : 0;
            }

            if (result.Count > 0)
            {
                listHANGHOA.AddRange(result);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Refresh lại báo cáo
            string date = " Đến ngày " + txtDenNgay.Value.ToString("dd") + " tháng " + txtDenNgay.Value.ToString("MM") + " năm " + txtDenNgay.Value.ToString("yyyy");
            ReportDataSource reportDataSource = new ReportDataSource("DASDataSource", listHANGHOA);
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpTonKho.rdlc";

            var listReportParameter = new List<ReportParameter>(){
                new ReportParameter("Date", date)};

            // Đẩy thông tin kho vào tham số
            var paramKho = listKho.Select((x, index) => new ReportParameter("Kho" + (index + 1), x.TenKho));
            listReportParameter.AddRange(paramKho);
            for (int i = soluongkho + 1; i <= 10; i++)
            {
                listReportParameter.Add(new ReportParameter("Kho" + i, "N/A"));
            }

            this.rpvBaoCaoViewer.LocalReport.SetParameters(listReportParameter);
            this.rpvBaoCaoViewer.LocalReport.DataSources.Add(reportDataSource);
            rpvBaoCaoViewer.RefreshReport();
        }

        private class TonKhoViewModel
        {
            public string MaHH { get; set; }
            public string TenHangHoa { get; set; }
            public string DVT { get; set; }
            public Nullable<int> SoLuongKho1 { get; set; }
            public Nullable<int> SoLuongKho2 { get; set; }
            public Nullable<int> SoLuongKho3 { get; set; }
            public Nullable<int> SoLuongKho4 { get; set; }
            public Nullable<int> SoLuongKho5 { get; set; }
            public Nullable<int> SoLuongKho6 { get; set; }
            public Nullable<int> SoLuongKho7 { get; set; }
            public Nullable<int> SoLuongKho8 { get; set; }
            public Nullable<int> SoLuongKho9 { get; set; }
            public Nullable<int> SoLuongKho10 { get; set; }
        }

        private partial class NhapXuatViewModel
        {
            public string MaKho { get; set; }
            public string MaHH { get; set; }
            public Nullable<int> SoLuong { get; set; }
        }
    }
}
