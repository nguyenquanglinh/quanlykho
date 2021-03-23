using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QL_Kho.Data;

namespace QL_Kho
{
    public partial class frmNhanVien : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        string id = string.Empty;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.NHANVIENs.Select(x=> new { x.MaNV, x.TenNhanVien, x.ChucVu, x.NgaySinh, x.GioiTinh, x.DiaChi, x.SDT, x.Email}).ToList();
            bingding();
        }
        public void bingding()
        {
            txtMaNhanVien.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaNV");
            txtTenNhanVien.DataBindings.Clear();
            txtTenNhanVien.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenNhanVien");
            cbbChucVu.DataBindings.Clear();
            cbbChucVu.DataBindings.Add("Text", dgvDanhSach.DataSource, "ChucVu");
            txtNgaySinh.DataBindings.Clear();
            txtNgaySinh.DataBindings.Add("Text", dgvDanhSach.DataSource, "NgaySinh");
            cbbGioiTinh.DataBindings.Clear();
            cbbGioiTinh.DataBindings.Add("Text", dgvDanhSach.DataSource, "GioiTinh");
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
            txtMaNhanVien.Text = NewID();
            id = string.Empty;
            txtTenNhanVien.ResetText();
            cbbChucVu.ResetText();
            txtNgaySinh.ResetText();
            cbbGioiTinh.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
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
            if (txtTenNhanVien.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {
                NHANVIEN nHANVIEN = new NHANVIEN()
                {
                    MaNV = NewID(),
                    TenNhanVien = txtTenNhanVien.Text,
                    ChucVu = cbbChucVu.Text,
                    NgaySinh = txtNgaySinh.Value,
                    GioiTinh = cbbGioiTinh.Text,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    Email = txtEmail.Text,
                };
                dA_QLYKHOEntities.NHANVIENs.Add(nHANVIEN);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                NHANVIEN nHANVIEN = dA_QLYKHOEntities.NHANVIENs.FirstOrDefault(x=>x.MaNV == id);
                nHANVIEN.TenNhanVien = txtTenNhanVien.Text;
                nHANVIEN.ChucVu = cbbChucVu.Text;
                nHANVIEN.NgaySinh = txtNgaySinh.Value;
                nHANVIEN.GioiTinh = cbbGioiTinh.Text;
                nHANVIEN.DiaChi = txtDiaChi.Text;
                nHANVIEN.SDT = txtSDT.Text;
                nHANVIEN.Email = txtEmail.Text;
                dA_QLYKHOEntities.SaveChanges();
            };
               
            LoadData();
            huy();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells["MaNV"].Value.ToString();
                NHANVIEN nHANVIEN = dA_QLYKHOEntities.NHANVIENs.FirstOrDefault(x => x.MaNV == id);
                txtMaNhanVien.Text = nHANVIEN.MaNV;
                txtTenNhanVien.Text = nHANVIEN.TenNhanVien;
                cbbChucVu.Text = nHANVIEN.ChucVu;
                txtNgaySinh.Value = nHANVIEN.NgaySinh.Value;
                cbbGioiTinh.Text = nHANVIEN.GioiTinh;
                txtDiaChi.Text = nHANVIEN.DiaChi;
                txtSDT.Text = nHANVIEN.SDT;
                txtEmail.Text = nHANVIEN.Email;

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
            txtMaNhanVien.ResetText();
            txtTenNhanVien.ResetText();
            cbbChucVu.ResetText();
            txtNgaySinh.ResetText();
            cbbGioiTinh.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
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
                string id = dgvDanhSach.SelectedRows[0].Cells["MaNV"].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        NHANVIEN nHANVIEN = dA_QLYKHOEntities.NHANVIENs.FirstOrDefault(x => x.MaNV == id);
                        dA_QLYKHOEntities.NHANVIENs.Remove(nHANVIEN);
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
            dgvDanhSach.DataSource = dA_QLYKHOEntities.NHANVIENs
                .Where(x => x.TenNhanVien.Contains(txtTimKiem.Text) || x.SDT.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text) || x.Email.Contains(txtTimKiem.Text))
                .Select(x => new { x.MaNV, x.TenNhanVien, x.ChucVu, x.NgaySinh, x.GioiTinh, x.DiaChi, x.SDT, x.Email })
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
            string hangsoID = "NV";
            string oldID = "0";
            NHANVIEN nHANVIEN = dA_QLYKHOEntities.NHANVIENs.OrderByDescending(x => x.MaNV).FirstOrDefault();
            if (nHANVIEN != null)
            {
                oldID = nHANVIEN.MaNV.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }
    }
}
