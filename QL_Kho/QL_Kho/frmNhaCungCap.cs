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
    public partial class frmNhaCungCap : Form
    {
        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();
        string id = string.Empty;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.NHACUNGCAPs.Select(x=> new { x.MaNCC, x.TenNCC, x.DiaChi, x.SDT, x.Email }).ToList();
            bingding();
        }
        public void bingding()
        {
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaNCC");
            txtTenNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenNCC");
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
            txtMaNCC.Text = NewID();
            id = string.Empty;
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtTenNCC.ResetText();
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
            if (txtTenNCC.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhà cung cấp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {
                NHACUNGCAP nHACUNGCAP = new NHACUNGCAP()
                {
                    MaNCC = NewID(),
                    TenNCC = txtTenNCC.Text,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    Email = txtEmail.Text,
                };
                dA_QLYKHOEntities.NHACUNGCAPs.Add(nHACUNGCAP);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                NHACUNGCAP nHACUNGCAP = dA_QLYKHOEntities.NHACUNGCAPs.FirstOrDefault(x => x.MaNCC == txtMaNCC.Text);
                nHACUNGCAP.TenNCC = txtTenNCC.Text;
                nHACUNGCAP.DiaChi = txtDiaChi.Text;
                nHACUNGCAP.SDT = txtSDT.Text;
                nHACUNGCAP.Email = txtEmail.Text;
                dA_QLYKHOEntities.SaveChanges();
            }

            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells["MaNCC"].Value.ToString();
                NHACUNGCAP nHACUNGCAP = dA_QLYKHOEntities.NHACUNGCAPs.FirstOrDefault(x => x.MaNCC == id);
                txtMaNCC.Text = nHACUNGCAP.MaNCC;
                txtDiaChi.Text = nHACUNGCAP.DiaChi;
                txtSDT.Text = nHACUNGCAP.SDT;
                txtTenNCC.Text = nHACUNGCAP.TenNCC;
                txtEmail.Text = nHACUNGCAP.Email;

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
            txtMaNCC.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtTenNCC.ResetText();
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
                string id = dgvDanhSach.SelectedRows[0].Cells["MaNCC"].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        NHACUNGCAP nHACUNGCAP = dA_QLYKHOEntities.NHACUNGCAPs.FirstOrDefault(x => x.MaNCC == id);
                        dA_QLYKHOEntities.NHACUNGCAPs.Remove(nHACUNGCAP);
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
            dgvDanhSach.DataSource = dA_QLYKHOEntities.NHACUNGCAPs
                .Where(x => x.TenNCC.Contains(txtTimKiem.Text))
                .Select(x => new { x.MaNCC, x.TenNCC, x.DiaChi, x.SDT, x.Email })
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
            string hangsoID = "NCC";
            string oldID = "0";
            NHACUNGCAP nHACUNGCAP = dA_QLYKHOEntities.NHACUNGCAPs.OrderByDescending(x => x.MaNCC).FirstOrDefault();
            if (nHACUNGCAP != null)
            {
                oldID = nHACUNGCAP.MaNCC.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }

    }
}
