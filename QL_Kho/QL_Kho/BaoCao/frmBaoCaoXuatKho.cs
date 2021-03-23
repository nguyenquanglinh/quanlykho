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
    public partial class frmBaoCaoXuatKho : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        const string hangsoID = "PX";

        public frmBaoCaoXuatKho()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var tungay = txtTuNgay.Value.Date;
            var denngay = txtDenNgay.Value.Date.AddDays(1);
            dgvDanhSach.DataSource = dA_QLYKHOEntities.PHIEUXUATs
                .Where(x => x.NgayXuat >= tungay && x.NgayXuat < denngay && x.MaPX.StartsWith(hangsoID) && (x.GhiChu.Contains(txtTimKiem.Text) || x.KHACHHANG.TenKhachHang.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text) || x.NHANVIEN.TenNhanVien.Contains(txtTimKiem.Text) || x.KHO.TenKho.Contains(txtTimKiem.Text)))
                .Select(x => new { x.MaPX, x.NgayXuat, x.KHACHHANG.TenKhachHang, x.DiaChi, x.NHANVIEN.TenNhanVien, x.KHO.TenKho, x.GhiChu })
                .OrderByDescending(x=>x.NgayXuat)
                .ToList();
        }

        private void frmBaoCaoXuatKho_Load(object sender, EventArgs e)
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

            string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PHIEUXUAT.MaPX)].Value.ToString();

            //Refresh lại báo cáo
            DateTime dauthang = txtTuNgay.Value.Date.AddDays(-(txtTuNgay.Value.Day - 1));
            DateTime cuoithang = dauthang.AddMonths(1);
            var phieuHang = dA_QLYKHOEntities.PHIEUXUATs.FirstOrDefault(x=>x.MaPX == id);
            var listHANGHOA = dA_QLYKHOEntities.CTPHIEUXUATs
                .Where(x => x.MaPX == id)
                .Select(x => new XuatKhoViewModel()
                {
                    MaPX = x.MaPX,
                    NgayXuat = x.PHIEUXUAT.NgayXuat,
                    GhiChu = x.PHIEUXUAT.GhiChu,
                    MaHH = x.MaHH,
                    TenHangHoa = x.HANGHOA.TenHangHoa,
                    DVT = x.HANGHOA.DVT,
                    DonGia = x.GiaXuat,
                    SoLuong = x.SoLuong,
                    ThanhTien = x.SoLuong * x.GiaXuat,
                }).ToList();

            string date = "Ngày " + phieuHang.NgayXuat.Value.ToString("dd") + " tháng " + phieuHang.NgayXuat.Value.ToString("MM") + " năm " + phieuHang.NgayXuat.Value.ToString("yyyy");
            ReportDataSource reportDataSource = new ReportDataSource("DASDataSource", listHANGHOA);
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpXuatKho.rdlc";
            var listReportParameter = new List<ReportParameter>(){
                new ReportParameter("Date", date),
                new ReportParameter("MaKho", phieuHang.MaKho),
                new ReportParameter("TenKho", phieuHang.KHO.TenKho),
                new ReportParameter("MaKH", phieuHang.MaKH),
                new ReportParameter("TenKH", phieuHang.KHACHHANG.TenKhachHang),
                new ReportParameter("MaPhieu", phieuHang.MaPX),
                new ReportParameter("GhiChu", phieuHang.GhiChu)
            };
            this.rpvBaoCaoViewer.LocalReport.SetParameters(listReportParameter);
            this.rpvBaoCaoViewer.LocalReport.DataSources.Clear();
            this.rpvBaoCaoViewer.LocalReport.DataSources.Add(reportDataSource);
            rpvBaoCaoViewer.RefreshReport();
        }

        private class XuatKhoViewModel
        {
            public string MaPX { get; set; }
            public Nullable<DateTime> NgayXuat { get; set; }
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
