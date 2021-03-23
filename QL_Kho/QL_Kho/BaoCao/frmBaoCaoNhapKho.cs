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
    public partial class frmBaoCaoNhapKho : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        const string hangsoID = "PN";

        public frmBaoCaoNhapKho()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var tungay = txtTuNgay.Value.Date;
            var denngay = txtDenNgay.Value.Date.AddDays(1);
            dgvDanhSach.DataSource = dA_QLYKHOEntities.PHIEUNHAPs
                .Where(x => x.NgayNhap >= tungay && x.NgayNhap < denngay && x.MaPN.StartsWith(hangsoID) && (x.GhiChu.Contains(txtTimKiem.Text) || x.NHACUNGCAP.TenNCC.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text) || x.NHANVIEN.TenNhanVien.Contains(txtTimKiem.Text) || x.KHO.TenKho.Contains(txtTimKiem.Text)))
                .Select(x => new { x.MaPN, x.NgayNhap, x.NHACUNGCAP.TenNCC, x.DiaChi, x.NHANVIEN.TenNhanVien, x.KHO.TenKho, x.GhiChu })
                .OrderByDescending(x=>x.NgayNhap)
                .ToList();
        }

        private void frmBaoCaoNhapKho_Load(object sender, EventArgs e)
        {
            txtDenNgay.Value = DateTime.Today;
            txtTuNgay.Value = DateTime.Today.AddMonths(-1);
            LoadData();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn Chưa chọn bản ghi.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PHIEUNHAP.MaPN)].Value.ToString();

            //Refresh lại báo cáo
            DateTime dauthang = txtTuNgay.Value.Date.AddDays(-(txtTuNgay.Value.Day - 1));
            DateTime cuoithang = dauthang.AddMonths(1);
            var phieuHang = dA_QLYKHOEntities.PHIEUNHAPs.FirstOrDefault(x=>x.MaPN == id);
            var listHANGHOA = dA_QLYKHOEntities.CTPHIEUNHAPs
                .Where(x => x.MaPN == id)
                .Select(x => new NhapKhoViewModel()
                {
                    MaPN = x.MaPN,
                    NgayNhap = x.PHIEUNHAP.NgayNhap,
                    GhiChu = x.PHIEUNHAP.GhiChu,
                    MaHH = x.MaHH,
                    TenHangHoa = x.HANGHOA.TenHangHoa,
                    DVT = x.HANGHOA.DVT,
                    DonGia = x.GiaNhap,
                    SoLuong = x.SoLuong,
                    ThanhTien = x.SoLuong * x.GiaNhap,
                }).ToList();

            string date = "Ngày " + phieuHang.NgayNhap.Value.ToString("dd") + " tháng " + phieuHang.NgayNhap.Value.ToString("MM") + " năm " + phieuHang.NgayNhap.Value.ToString("yyyy");
            ReportDataSource reportDataSource = new ReportDataSource("DASDataSource", listHANGHOA);
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpNhapKho.rdlc";
            var listReportParameter = new List<ReportParameter>(){
                new ReportParameter("Date", date),
                new ReportParameter("MaKho", phieuHang.MaKho),
                new ReportParameter("TenKho", phieuHang.KHO.TenKho),
                new ReportParameter("MaNCC", phieuHang.MaNCC),
                new ReportParameter("TenNCC", phieuHang.NHACUNGCAP.TenNCC),
                new ReportParameter("MaPhieu", phieuHang.MaPN),
                new ReportParameter("GhiChu", phieuHang.GhiChu)
            };
            this.rpvBaoCaoViewer.LocalReport.SetParameters(listReportParameter);
            this.rpvBaoCaoViewer.LocalReport.DataSources.Clear();
            this.rpvBaoCaoViewer.LocalReport.DataSources.Add(reportDataSource);
            rpvBaoCaoViewer.RefreshReport();
        }

        private class NhapKhoViewModel
        {
            public string MaPN { get; set; }
            public Nullable<DateTime> NgayNhap { get; set; }
            public string GhiChu { get; set; }
            public string MaHH { get; set; }
            public string TenHangHoa { get; set; }
            public string DVT { get; set; }
            public Nullable<int> SoLuong { get; set; }
            public Nullable<decimal> DonGia { get; set; }
            public Nullable<decimal> ThanhTien { get; set; }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
