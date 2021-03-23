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
    public partial class frmTrangChu : Form
    {
        string tenhienthi = "Xin chào: ";
        string quyen = string.Empty;
        public frmTrangChu(string tentaikhoan, string phanquyen)
        {
            InitializeComponent();
            lblTaiKhoan.Text = tenhienthi + tentaikhoan;
            lblTaiKhoan.BackColor = menuStrip1.BackColor;
            quyen = phanquyen;
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgresult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            if(quyen == "Nhân viên")
            {
                menuTaiKhoan.Visible = false;
                menuDanhMuc.Visible = false;
                menuNhapKho.Visible = false;
                menuXuatKho.Visible = false;
            }
        }

        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuHangHoa_Click(object sender, EventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuHopDong_Click(object sender, EventArgs e)
        {
            frmPhieuNhapKho frm = new frmPhieuNhapKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCao_Click(object sender, EventArgs e)
        {
            //frmBaoCao frm = new frmBaoCao();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void menuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(lblTaiKhoan.Text.Replace(tenhienthi, ""));
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
        }

        private void menuNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuNhomHang_Click(object sender, EventArgs e)
        {
            frmNhomHang frm = new frmNhomHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuKho_Click(object sender, EventArgs e)
        {
            frmKho frm = new frmKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuPhieuMua_Click(object sender, EventArgs e)
        {
            frmPhieuMua frm = new frmPhieuMua();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuTonDauKy_Click(object sender, EventArgs e)
        {
            frmTonDauKy frm = new frmTonDauKy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuPhieuXuatKho_Click(object sender, EventArgs e)
        {
            frmPhieuXuatKho frm = new frmPhieuXuatKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuTinhGiaVonTonKho_Click(object sender, EventArgs e)
        {
            frmTinhGiaVonTonKho frm = new frmTinhGiaVonTonKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuDieuChuyenKho_Click(object sender, EventArgs e)
        {
            frmPhieuChuyenKho frm = new frmPhieuChuyenKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCaoNhapKho_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhapKho frm = new frmBaoCaoNhapKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCaoXuatKho_Click(object sender, EventArgs e)
        {
            frmBaoCaoXuatKho frm = new frmBaoCaoXuatKho();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCaoTonKho_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKhoTongHop frm = new frmBaoCaoTonKhoTongHop();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCaoNhapXuatTon_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhapXuatTon frm = new frmBaoCaoNhapXuatTon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCaoNhapKhoTheoDoiTuong_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhapKhoTheoDoiTuong frm = new frmBaoCaoNhapKhoTheoDoiTuong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuBaoCaoXuatKhoTheoDoiTuong_Click(object sender, EventArgs e)
        {
            frmBaoCaoXuatKhoTheoDoiTuong frm = new frmBaoCaoXuatKhoTheoDoiTuong();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
