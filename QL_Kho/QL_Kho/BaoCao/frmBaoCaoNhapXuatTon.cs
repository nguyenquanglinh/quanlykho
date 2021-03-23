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
    public partial class frmBaoCaoNhapXuatTon : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        const string hangsoID = "DC";

        public frmBaoCaoNhapXuatTon()
        {
            InitializeComponent();
        }

        private void frmBaoCaoNhapXuatTon_Load(object sender, EventArgs e)
        {
            //Load kho
            cbbKho.DataSource = dA_QLYKHOEntities.KHOes.ToList();
            cbbKho.DisplayMember = nameof(KHO.TenKho);
            cbbKho.ValueMember = nameof(KHO.MaKho);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cbbKho.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Refresh lại báo cáo
            DateTime dauthang = txtTuNgay.Value.Date.AddDays(-(txtTuNgay.Value.Day - 1));
            DateTime cuoithang = dauthang.AddMonths(1);
            var listHANGHOA = dA_QLYKHOEntities.HANGHOAs.Select(x => new NhapXuatTonViewModel()
            {
                MaHH = x.MaHH,
                TenHangHoa = x.TenHangHoa,
                DVT = x.DVT
            }).ToList();

            var TONDAUKies = dA_QLYKHOEntities.TONDAUKies.Where(x => x.MaKho == cbbKho.SelectedValue.ToString() && x.NgayCapNhat == dauthang).ToList();
            var CTPHIEUNHAPs = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.PHIEUNHAP.MaKho == cbbKho.SelectedValue.ToString() && x.PHIEUNHAP.NgayNhap >= dauthang && x.PHIEUNHAP.NgayNhap < cuoithang).Select(x => new NhapXuatViewModel { MaPhieu = x.PHIEUNHAP.MaPN, MaHH = x.MaHH, SoLuong = x.SoLuong }).ToList();
            var CTPHIEUXUATs = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.PHIEUXUAT.MaKho == cbbKho.SelectedValue.ToString() && x.PHIEUXUAT.NgayXuat >= dauthang && x.PHIEUXUAT.NgayXuat < cuoithang).Select(x => new NhapXuatViewModel { MaPhieu = x.PHIEUXUAT.MaPX, MaHH = x.MaHH, SoLuong = x.SoLuong }).ToList();

            foreach (var x in listHANGHOA)
            {
                x.TonDauKy = TONDAUKies.Where(y => y.MaHH == x.MaHH).Sum(y => y.SoLuong);
                x.SoLuongNhap = CTPHIEUNHAPs.Where(y => !y.MaPhieu.StartsWith(hangsoID) && y.MaHH == x.MaHH).Sum(y => y.SoLuong);
                x.NhapDieuChuyen = CTPHIEUNHAPs.Where(y => y.MaPhieu.StartsWith(hangsoID) && y.MaHH == x.MaHH).Sum(y => y.SoLuong);
                x.SoLuongXuat = CTPHIEUXUATs.Where(y => !y.MaPhieu.StartsWith(hangsoID) && y.MaHH == x.MaHH).Sum(y => y.SoLuong);
                x.XuatDieuChuyen = CTPHIEUXUATs.Where(y => y.MaPhieu.StartsWith(hangsoID) && y.MaHH == x.MaHH).Sum(y => y.SoLuong);
            }

            string date = "Trong tháng " + txtTuNgay.Value.ToString("MM") + " năm " + txtTuNgay.Value.ToString("yyyy");
            ReportDataSource reportDataSource = new ReportDataSource("DASDataSource", listHANGHOA);
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpNhapXuatTon.rdlc";
            var listReportParameter = new List<ReportParameter>(){
                new ReportParameter("Date", date),
                new ReportParameter("MaKho", cbbKho.SelectedValue.ToString()),
                new ReportParameter("TenKho", cbbKho.Text)
            };
            this.rpvBaoCaoViewer.LocalReport.SetParameters(listReportParameter);
            this.rpvBaoCaoViewer.LocalReport.DataSources.Clear();
            this.rpvBaoCaoViewer.LocalReport.DataSources.Add(reportDataSource);
            rpvBaoCaoViewer.RefreshReport();
        }

        private class NhapXuatTonViewModel
        {
            public string MaHH { get; set; }
            public string TenHangHoa { get; set; }
            public string DVT { get; set; }
            public Nullable<int> TonDauKy { get; set; }
            public Nullable<int> SoLuongNhap { get; set; }
            public Nullable<int> NhapDieuChuyen { get; set; }
            public Nullable<int> SoLuongXuat { get; set; }
            public Nullable<int> XuatDieuChuyen { get; set; }
        }

        private partial class NhapXuatViewModel
        {
            public string MaPhieu { get; set; }
            public string MaHH { get; set; }
            public Nullable<int> SoLuong { get; set; }
        }
    }
}
