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
    public partial class frmKhachHang : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        string id = string.Empty;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.KHACHHANGs.Select(x => new { x.MaKH, x.TenKhachHang, x.DiaChi, x.SDT, x.Email }).ToList();
            bingding();
        }
        public void bingding()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaKH");
            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenKhachHang");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSach.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dgvDanhSach.DataSource, "SDT");
            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvDanhSach.DataSource, "Email");
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lấy id tự tạo mới nhất
            txtMaKH.Text = NewID();
            id = string.Empty;
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtTenKhachHang.ResetText();
            txtEmail.ResetText();
            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {
                KHACHHANG kHACHHANG = new KHACHHANG()
                {
                    MaKH = NewID(),
                    TenKhachHang = txtTenKhachHang.Text,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    Email = txtEmail.Text,
                };
                dA_QLYKHOEntities.KHACHHANGs.Add(kHACHHANG);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                KHACHHANG kHACHHANG = dA_QLYKHOEntities.KHACHHANGs.FirstOrDefault(x => x.MaKH == txtMaKH.Text);
                kHACHHANG.TenKhachHang = txtTenKhachHang.Text;
                kHACHHANG.DiaChi = txtDiaChi.Text;
                kHACHHANG.SDT = txtSDT.Text;
                kHACHHANG.Email = txtEmail.Text;
                dA_QLYKHOEntities.SaveChanges();
            }

            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(KHACHHANG.MaKH)].Value.ToString();
                KHACHHANG kHACHHANG = dA_QLYKHOEntities.KHACHHANGs.FirstOrDefault(x => x.MaKH == id);
                txtMaKH.Text = kHACHHANG.MaKH;
                txtDiaChi.Text = kHACHHANG.DiaChi;
                txtSDT.Text = kHACHHANG.SDT;
                txtTenKhachHang.Text = kHACHHANG.TenKhachHang;
                txtEmail.Text = kHACHHANG.Email;

                //bật tắt các nút
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuuLai.Enabled = true;
                btnHuy.Enabled = true;
                groupThaoTac.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        void huy()
        {
            id = string.Empty;
            txtMaKH.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtTenKhachHang.ResetText();
            txtEmail.ResetText();

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(KHACHHANG.MaKH)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        KHACHHANG kHACHHANG = dA_QLYKHOEntities.KHACHHANGs.FirstOrDefault(x => x.MaKH == id);
                        dA_QLYKHOEntities.KHACHHANGs.Remove(kHACHHANG);
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
            dgvDanhSach.DataSource = dA_QLYKHOEntities.KHACHHANGs
                .Where(x => x.TenKhachHang.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text) || x.SDT.Contains(txtTimKiem.Text) || x.Email.Contains(txtTimKiem.Text))
                .Select(x => new { x.MaKH, x.TenKhachHang, x.DiaChi, x.SDT, x.Email })
                .ToList();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private string NewID()
        {
            string hangsoID = "KH";
            string oldID = "0";
            KHACHHANG kHACHHANG = dA_QLYKHOEntities.KHACHHANGs.OrderByDescending(x => x.MaKH).FirstOrDefault();
            if (kHACHHANG != null)
            {
                oldID = kHACHHANG.MaKH.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }
    }
}
