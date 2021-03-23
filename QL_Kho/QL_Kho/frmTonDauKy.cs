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
    public partial class frmTonDauKy : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();

        string id = string.Empty;
        DateTime? ngaynhap;

        public frmTonDauKy()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.TONDAUKies.Select(x => new { x.MaHH, x.HANGHOA.TenHangHoa, x.MaKho, x.KHO.TenKho, x.SoLuong, x.ThanhTien, NgayCapNhat = x.NgayNhap }).ToList();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();

            //Load hàng hóa
            cbbHangHoa.DataSource = dA_QLYKHOEntities.HANGHOAs.ToList();
            cbbHangHoa.DisplayMember = nameof(HANGHOA.TenHangHoa);
            cbbHangHoa.ValueMember = nameof(HANGHOA.MaHH);

            //Load kho
            cbbKho.DataSource = dA_QLYKHOEntities.KHOes.ToList();
            cbbKho.DisplayMember = nameof(KHO.TenKho);
            cbbKho.ValueMember = nameof(KHO.MaKho);

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;

            cbbHangHoa.Enabled = true;
            cbbKho.Enabled = true;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (cbbHangHoa.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbbKho.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtNgayNhap.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn Ngày cập nhật!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtSoLuong.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtThanhTien.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập thành tiền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaycapnhat = txtNgayNhap.Value.Date.AddDays(-(txtNgayNhap.Value.Day - 1));
            if (id == string.Empty)
            {

                var tontai_TonDauKy = dA_QLYKHOEntities.TONDAUKies.Any(x => x.MaHH == cbbHangHoa.SelectedValue.ToString() && x.MaKho == cbbKho.SelectedValue.ToString() && x.NgayCapNhat == ngaycapnhat);

                if (tontai_TonDauKy == true)
                {
                    MessageBox.Show("Hàng hóa này đã tồn tại trong kho này trong tháng " + txtNgayNhap.Value.Month + "!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TONDAUKY tONDAUKY = new TONDAUKY()
                {
                    MaHH = cbbHangHoa.SelectedValue.ToString(),
                    MaKho = cbbKho.SelectedValue.ToString(),
                    SoLuong = int.Parse(txtSoLuong.Text),
                    ThanhTien = decimal.Parse(txtThanhTien.Text),
                    NgayCapNhat = ngaycapnhat,
                    NgayNhap = txtNgayNhap.Value
                };
                dA_QLYKHOEntities.TONDAUKies.Add(tONDAUKY);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                if (ngaynhap != ngaycapnhat)
                {
                    MessageBox.Show("Tồn này của tháng " + ngaynhap.Value.Month + " bạn không được thay đổi tháng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TONDAUKY tONDAUKY = dA_QLYKHOEntities.TONDAUKies.FirstOrDefault(x => x.MaHH == cbbHangHoa.SelectedValue.ToString() && x.MaKho == cbbKho.SelectedValue.ToString() && x.NgayCapNhat == ngaycapnhat);
                tONDAUKY.SoLuong = int.Parse(txtSoLuong.Text);
                tONDAUKY.ThanhTien = decimal.Parse(txtThanhTien.Text);
                tONDAUKY.NgayNhap = txtNgayNhap.Value;
                dA_QLYKHOEntities.SaveChanges();
            }
            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(TONDAUKY.MaHH)].Value.ToString();
                string makho = dgvDanhSach.SelectedRows[0].Cells[nameof(TONDAUKY.MaKho)].Value.ToString();
                DateTime ngaycapnhat = DateTime.Parse(dgvDanhSach.SelectedRows[0].Cells[nameof(TONDAUKY.NgayCapNhat)].Value.ToString());
                ngaycapnhat = ngaycapnhat.Date.AddDays(-(ngaycapnhat.Day - 1));
                TONDAUKY tONDAUKY = dA_QLYKHOEntities.TONDAUKies.FirstOrDefault(x => x.MaHH == id && x.MaKho == makho && x.NgayCapNhat == ngaycapnhat);

                ngaynhap = ngaycapnhat;
                cbbHangHoa.SelectedValue = tONDAUKY.MaHH;
                cbbKho.SelectedValue = tONDAUKY.MaKho;
                txtSoLuong.Text = tONDAUKY.SoLuong.ToString();
                txtThanhTien.Text = tONDAUKY.ThanhTien.ToString();
                txtNgayNhap.Value = tONDAUKY.NgayNhap;

                //bật tắt các nút
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuuLai.Enabled = true;
                btnHuy.Enabled = true;
                groupThaoTac.Enabled = true;

                cbbHangHoa.Enabled = false;
                cbbKho.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        void huy()
        {
            id = string.Empty;
            ngaynhap = null;
            txtSoLuong.ResetText();
            txtThanhTien.ResetText();
            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
            txtNgayNhap.ResetText();

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            cbbHangHoa.Enabled = false;
            cbbKho.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(TONDAUKY.MaHH)].Value.ToString();
                string makho = dgvDanhSach.SelectedRows[0].Cells[nameof(TONDAUKY.MaKho)].Value.ToString();
                DateTime ngaycapnhat = DateTime.Parse(dgvDanhSach.SelectedRows[0].Cells[nameof(TONDAUKY.NgayCapNhat)].Value.ToString());
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        TONDAUKY tONDAUKY = dA_QLYKHOEntities.TONDAUKies.FirstOrDefault(x => x.MaHH == id && x.MaKho == makho && x.NgayCapNhat == ngaycapnhat);
                        dA_QLYKHOEntities.TONDAUKies.Remove(tONDAUKY);
                        dA_QLYKHOEntities.SaveChanges();
                        LoadData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bản ghi này đang được sử dụng. Không thể xóa.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
            else
            {
                MessageBox.Show("Bạn Chưa chọn bản ghi.", "Thông báo!");
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.TONDAUKies
                .Where(x => x.HANGHOA.TenHangHoa.Contains(txtTimKiem.Text) || x.KHO.TenKho.Contains(txtTimKiem.Text))
                .Select(x => new { x.MaHH, x.HANGHOA.TenHangHoa, x.MaKho, x.KHO.TenKho, x.SoLuong, x.ThanhTien, NgayCapNhat = x.NgayNhap })
                .ToList();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
