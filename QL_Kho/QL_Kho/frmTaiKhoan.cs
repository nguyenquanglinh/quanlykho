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
    public partial class frmTaiKhoan : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        string id = string.Empty;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.DANGNHAPs.Select(x => new { TaiKhoan = x.ID, x.Password, x.MaNV, x.NHANVIEN.TenNhanVien, x.PhanQuyen }).ToList();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();

            //Load nhân viên
            txtIdNhanVien.DataSource = dA_QLYKHOEntities.NHANVIENs.ToList();
            txtIdNhanVien.DisplayMember = nameof(NHANVIEN.TenNhanVien);
            txtIdNhanVien.ValueMember = nameof(NHANVIEN.MaNV);

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;
            txtTenTaiKhoan.Enabled = true;
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
            txtTenTaiKhoan.Enabled = true;
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (txtTenTaiKhoan.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tài khoản tối thiểu phải có 3 kí tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {
                DANGNHAP dANGNHAP_TonTai = dA_QLYKHOEntities.DANGNHAPs.FirstOrDefault(x => x.ID == txtTenTaiKhoan.Text);
                if (dANGNHAP_TonTai != null)
                {
                    MessageBox.Show("Tên tài khoản này đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DANGNHAP dANGNHAP = new DANGNHAP()
                {
                    ID = txtTenTaiKhoan.Text,
                    Password = txtMatKhau.Text,
                    MaNV = txtIdNhanVien.SelectedValue == null ? null : txtIdNhanVien.SelectedValue.ToString(),
                    PhanQuyen = chkQuyen.Text,
                };
                dA_QLYKHOEntities.DANGNHAPs.Add(dANGNHAP);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                DANGNHAP dANGNHAP = dA_QLYKHOEntities.DANGNHAPs.FirstOrDefault(x => x.ID == id);
                dANGNHAP.Password = txtMatKhau.Text;
                dANGNHAP.MaNV = txtIdNhanVien.SelectedValue == null ? null : txtIdNhanVien.SelectedValue.ToString();
                dANGNHAP.PhanQuyen = chkQuyen.Text;
                dA_QLYKHOEntities.SaveChanges();
            }

            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells["TaiKhoan"].Value.ToString();
                DANGNHAP dANGNHAP = dA_QLYKHOEntities.DANGNHAPs.FirstOrDefault(x => x.ID == id);
                txtTenTaiKhoan.Text = dANGNHAP.ID;
                txtMatKhau.Text = dANGNHAP.Password;
                txtIdNhanVien.SelectedValue = dANGNHAP.MaNV ?? string.Empty;

                for (int i = 0; i < chkQuyen.Items.Count; i++)
                {
                    if (chkQuyen.Items[i].ToString() == dANGNHAP.PhanQuyen)
                    {
                        chkQuyen.SetItemChecked(i, true);
                    }
                }

                //bật tắt các nút
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuuLai.Enabled = true;
                btnHuy.Enabled = true;
                groupThaoTac.Enabled = true;
                txtTenTaiKhoan.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        void huy()
        {
            id = string.Empty;
            txtTenTaiKhoan.ResetText();
            txtMatKhau.ResetText();
            if (txtIdNhanVien.Items.Count > 0) txtIdNhanVien.SelectedIndex = 0;

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;
            txtTenTaiKhoan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells["TaiKhoan"].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        DANGNHAP dANGNHAP = dA_QLYKHOEntities.DANGNHAPs.FirstOrDefault(x => x.ID == id);
                        dA_QLYKHOEntities.DANGNHAPs.Remove(dANGNHAP);
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
            dgvDanhSach.DataSource = dA_QLYKHOEntities.DANGNHAPs
                .Where(x => x.ID.Contains(txtTimKiem.Text) || x.NHANVIEN.TenNhanVien.Contains(txtTimKiem.Text))
                .Select(x => new { TaiKhoan = x.ID, x.Password, x.MaNV, x.NHANVIEN.TenNhanVien, x.PhanQuyen })
                .ToList();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void chkQuyen_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < chkQuyen.Items.Count; ++ix)
                if (ix != e.Index) chkQuyen.SetItemChecked(ix, false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chkQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
