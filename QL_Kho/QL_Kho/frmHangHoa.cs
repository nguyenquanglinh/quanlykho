﻿using System;
using DataSource.DTO;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Kho
{
    public partial class frmHangHoa : Form
    {
        string id = string.Empty;

        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = DataManager.Instance.ListHangHoa.ToList();
            bingding();
        }
        public void bingding()
        {
            txtMaHH.DataBindings.Clear();
            txtMaHH.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaHH");
            txtTenHangHoa.DataBindings.Clear();
            txtTenHangHoa.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenHangHoa");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", dgvDanhSach.DataSource, "MoTa");
            txtDonViTinh.DataBindings.Clear();
            txtDonViTinh.DataBindings.Add("Text", dgvDanhSach.DataSource, "DVT");
            cbbNhomHang.DataBindings.Clear();
            cbbNhomHang.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenNhomHang");
            cbbNhaCungCap.DataBindings.Clear();
            cbbNhaCungCap.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenNCC");
            txtGiaVon.DataBindings.Clear();
            txtGiaVon.DataBindings.Add("Text", dgvDanhSach.DataSource, "GiaVon");
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();

            //Load nhóm hàng
            cbbNhomHang.DataSource = DataManager.Instance.ListNhomHang.ToList();
            cbbNhomHang.DisplayMember = nameof(NhomHang.TenNhomHang);
            cbbNhomHang.ValueMember = nameof(NhomHang.MaNH);

            //Load nhà cung cấp
            cbbNhaCungCap.DataSource = DataManager.Instance.ListNhaCC.ToList();
            cbbNhaCungCap.DisplayMember = nameof(NhaCungCap.TenNCC);
            cbbNhaCungCap.ValueMember = nameof(NhaCungCap.MaNCC);

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            cbbNhomHang.SelectedIndex = -1;
            cbbNhaCungCap.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            id = string.Empty;
            txtMaHH.ResetText();
            txtTenHangHoa.ResetText();
            txtDonViTinh.ResetText();
            txtMoTa.ResetText();
            txtGiaVon.ResetText();
            txtGiaVon.ResetText();
            cbbNhomHang.SelectedIndex = -1;
            cbbNhaCungCap.SelectedIndex = -1;
            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;
            cbbNhomHang.Enabled = true;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (cbbNhomHang.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhóm hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTenHangHoa.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtDonViTinh.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập đơn vị tính!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtGiaVon.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập giá vốn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbbNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {
                // Set lại ID tự tăng
                cbbNhomHang_SelectedIndexChanged(null, null);

                HangHoa hANGHOA = new HangHoa()
                {
                    MaHH = txtMaHH.Text,
                    TenHangHoa = txtTenHangHoa.Text,
                    MoTa = txtMoTa.Text,
                    DVT = txtDonViTinh.Text,
                    MaNH = cbbNhomHang.SelectedValue == null ? null : cbbNhomHang.SelectedValue.ToString(),
                    MaNCC = cbbNhaCungCap.SelectedValue == null ? null : cbbNhaCungCap.SelectedValue.ToString(),
                    GiaVon = txtGiaVon.Text,
                    NgayCapNhat = DateTime.Now.ToString()
                };
                //TODO: theem hang hoas
                DataManager.Instance.PostHangHoa(hANGHOA);
            }
            else
            {
                HangHoa hANGHOA = DataManager.Instance.ListHangHoa.FirstOrDefault(x => x.MaHH == txtMaHH.Text);
                hANGHOA.TenHangHoa = txtTenHangHoa.Text;
                hANGHOA.MoTa = txtMoTa.Text;
                hANGHOA.DVT = txtDonViTinh.Text;
                hANGHOA.MaNH = cbbNhomHang.SelectedValue == null ? null : cbbNhomHang.SelectedValue.ToString();
                hANGHOA.MaNCC = cbbNhaCungCap.SelectedValue == null ? null : cbbNhaCungCap.SelectedValue.ToString();
                hANGHOA.GiaVon = txtGiaVon.Text;
                hANGHOA.NgayCapNhat = DateTime.Now.ToString();
                //TODO: sua hang hoa
                DataManager.Instance.PutHangHoa(hANGHOA);
            }
            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(HangHoa.MaHH)].Value.ToString();
                HangHoa hANGHOA = DataManager.Instance.ListHangHoa.FirstOrDefault(x => x.MaHH == id);

                txtMaHH.Text = hANGHOA.MaHH;
                txtTenHangHoa.Text = hANGHOA.TenHangHoa;
                txtMoTa.Text = hANGHOA.MoTa;
                txtDonViTinh.Text = hANGHOA.DVT;
                cbbNhomHang.SelectedValue = hANGHOA.MaNH ?? string.Empty;
                cbbNhaCungCap.SelectedValue = hANGHOA.MaNCC ?? string.Empty;
                txtGiaVon.Text = hANGHOA.GiaVon.ToString();


                //bật tắt các nút
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuuLai.Enabled = true;
                btnHuy.Enabled = true;
                groupThaoTac.Enabled = true;
                cbbNhomHang.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        void huy()
        {
            id = string.Empty;
            txtMaHH.ResetText();
            txtTenHangHoa.ResetText();
            txtDonViTinh.ResetText();
            txtMoTa.ResetText();
            txtGiaVon.ResetText();
            txtGiaVon.ResetText();
            cbbNhomHang.SelectedIndex = -1;
            cbbNhaCungCap.SelectedIndex = -1;

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;
            cbbNhomHang.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(HangHoa.MaHH)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        //TODO: xoas hang hoa
                        HangHoa hANGHOA = DataManager.Instance.ListHangHoa.FirstOrDefault(x => x.MaHH == id);
                        DataManager.Instance.DeleteHangHoa(hANGHOA);
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
            dgvDanhSach.DataSource = DataManager.Instance.ListHangHoa
                .Where(x => x.TenHangHoa.Contains(txtTimKiem.Text)).ToList();
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

        private string NewID(string hangsoID)
        {
            string oldID = "0";
            HangHoa hANGHOA = DataManager.Instance.ListHangHoa.Where(x => x.MaHH.StartsWith(hangsoID)).OrderByDescending(x => x.MaHH).FirstOrDefault();
            if (hANGHOA != null)
            {
                oldID = hANGHOA.MaHH.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }

        private void cbbNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái đang thêm mới thì tạo id tự sinh
            if (id == string.Empty)
            {
                if (cbbNhomHang.SelectedIndex >= 0)
                {
                    txtMaHH.Text = NewID(cbbNhomHang.SelectedValue.ToString());
                }
                else
                {
                    txtMaHH.ResetText();
                }
            }
        }
    }
}
