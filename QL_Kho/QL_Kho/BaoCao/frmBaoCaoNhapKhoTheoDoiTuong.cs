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
    public partial class frmBaoCaoNhapKhoTheoDoiTuong : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();

        public frmBaoCaoNhapKhoTheoDoiTuong()
        {
            InitializeComponent();
        }
        private void frmBaoCaoNhapKhoTheoDoiTuong_Load(object sender, EventArgs e)
        {
            //Load nhà cung cấp
            cbbNCC.DataSource = dA_QLYKHOEntities.NHACUNGCAPs.ToList();
            cbbNCC.DisplayMember = nameof(NHACUNGCAP.TenNCC);
            cbbNCC.ValueMember = nameof(NHACUNGCAP.MaNCC);

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
            else if (cbbNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhà cung cấp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Refresh lại báo cáo
            DateTime tungay = txtTuNgay.Value.Date;
            DateTime denngay = txtDenNgay.Value.Date;
            var listHANGHOA = dA_QLYKHOEntities.CTPHIEUNHAPs
                .Where(x => x.PHIEUNHAP.NgayNhap >= tungay 
                && x.PHIEUNHAP.NgayNhap <= denngay 
                && x.PHIEUNHAP.MaKho == cbbKho.SelectedValue.ToString()
                && x.PHIEUNHAP.MaNCC == cbbNCC.SelectedValue.ToString())
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

            string date = " Từ ngày " + txtTuNgay.Value.ToString("dd")+ " tháng " + txtTuNgay.Value.ToString("MM") + " năm " + txtTuNgay.Value.ToString("yyyy") +"\n"+ " Đến ngày " + txtDenNgay.Value.ToString("dd") + " tháng " + txtDenNgay.Value.ToString("MM") + " năm " + txtDenNgay.Value.ToString("yyyy");
            ReportDataSource reportDataSource = new ReportDataSource("DASDataSource", listHANGHOA);
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpNhapKhoTheoDoiTuong.rdlc";
            var listReportParameter = new List<ReportParameter>(){
                new ReportParameter("Date", date),
                new ReportParameter("MaKho", cbbKho.SelectedValue.ToString()),
                new ReportParameter("TenKho", cbbKho.Text),
                new ReportParameter("MaNCC", cbbNCC.SelectedValue.ToString()),
                new ReportParameter("TenNCC", cbbNCC.Text)
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

        private void txtDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
