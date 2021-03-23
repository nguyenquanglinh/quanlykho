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
    public partial class frmTinhGiaVonTonKho : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();

        public frmTinhGiaVonTonKho()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (txtNgayTinhTonKho.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập tháng muốn tính giá vốn tồn kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaycapnhat = txtNgayTinhTonKho.Value.Date.AddDays(-(txtNgayTinhTonKho.Value.Day - 1));
            DateTime ngayketthuc = ngaycapnhat.AddMonths(1);

            List<HANGHOA> listHANGHOA = dA_QLYKHOEntities.HANGHOAs.ToList();
            List<TONDAUKY> listTONDAUKY = dA_QLYKHOEntities.TONDAUKies.Where(x=>x.NgayCapNhat == ngaycapnhat).ToList();
            List<CTPHIEUNHAP> listPHIEUNHAP = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.PHIEUNHAP.NgayNhap >= ngaycapnhat && x.PHIEUNHAP.NgayNhap < ngayketthuc).ToList();

            foreach (var hanghoa in listHANGHOA)
            {
                //  Đơn giá xuất kho bình quân trong kỳ của một loại sản phẩm
                //  = 
                //  (Giá trị hàng tồn đầu kỳ + Giá trị hàng nhập trong kỳ)
                //  /(Số lượng hàng tồn đầu kỳ + Số lượng hàng nhập trong kỳ)

                try
                {
                    decimal tonggiatridauky = listTONDAUKY.Where(x => x.MaHH == hanghoa.MaHH).Sum(x => x.ThanhTien) ?? 0;
                    decimal tongsoluongdauky = listTONDAUKY.Where(x => x.MaHH == hanghoa.MaHH).Sum(x => x.SoLuong) ?? 0;
                    decimal tonggiatrinhap = listPHIEUNHAP.Where(x => x.MaHH == hanghoa.MaHH).Sum(x => x.SoLuong * x.GiaNhap) ?? 0;
                    decimal tongsoluongnhap = listPHIEUNHAP.Where(x => x.MaHH == hanghoa.MaHH).Sum(x => x.SoLuong) ?? 0;
                    hanghoa.GiaVon = (tonggiatridauky + tonggiatrinhap) / (tongsoluongdauky + tongsoluongnhap);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            dA_QLYKHOEntities.SaveChanges();

            MessageBox.Show("Cập nhật giá vốn thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
}
