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
    public partial class frmBaoCaoXuatKhoTheoDoiTuong : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();

        public frmBaoCaoXuatKhoTheoDoiTuong()
        {
            InitializeComponent();
        }

        private void frmBaoCaoXuatKhoTheoDoiTuong_Load(object sender, EventArgs e)
        {
            //Load khách hàng
            cbbKhachHang.DataSource = dA_QLYKHOEntities.KHACHHANGs.ToList();
            cbbKhachHang.DisplayMember = nameof(KHACHHANG.TenKhachHang);
            cbbKhachHang.ValueMember = nameof(KHACHHANG.MaKH);

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
            else if (cbbKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Refresh lại báo cáo
            DateTime tungay = txtTuNgay.Value.Date;
            DateTime denngay = txtDenNgay.Value.Date;
            var listHANGHOA = dA_QLYKHOEntities.CTPHIEUXUATs
                .Where(x => x.PHIEUXUAT.NgayXuat >= tungay 
                && x.PHIEUXUAT.NgayXuat <= denngay 
                && x.PHIEUXUAT.MaKho == cbbKho.SelectedValue.ToString()
                && x.PHIEUXUAT.MaKH == cbbKhachHang.SelectedValue.ToString())
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

            string date = " Từ ngày " + txtTuNgay.Value.ToString("dd") + " tháng " + txtTuNgay.Value.ToString("MM") + " năm " + txtTuNgay.Value.ToString("yyyy") + "\n" + " Đến ngày " + txtDenNgay.Value.ToString("dd") + " tháng " + txtDenNgay.Value.ToString("MM") + " năm " + txtDenNgay.Value.ToString("yyyy");
            ReportDataSource reportDataSource = new ReportDataSource("DASDataSource", listHANGHOA);
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpXuatKhoTheoDoiTuong.rdlc";
            var listReportParameter = new List<ReportParameter>(){
                new ReportParameter("Date", date),
                new ReportParameter("MaKho", cbbKho.SelectedValue.ToString()),
                new ReportParameter("TenKho", cbbKho.Text),
                new ReportParameter("MaKH", cbbKhachHang.SelectedValue.ToString()),
                new ReportParameter("TenKH", cbbKhachHang.Text)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
