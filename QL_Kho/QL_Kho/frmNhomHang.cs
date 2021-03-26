﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSource.DTO;

namespace QL_Kho
{
    public partial class frmNhomHang : Form
    {
        string id = string.Empty;

        public frmNhomHang()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = DataManager.Instance.ListNhomHang.Select(x => new { x.MaNH, x.TenNhomHang, x.MoTa }).ToList();
            bingding();
        }
        public void bingding()
        {
            txtMaNH.DataBindings.Clear();
            txtMaNH.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaNH");
            txtTenNhomHang.DataBindings.Clear();
            txtTenNhomHang.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenNhomHang");
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", dgvDanhSach.DataSource, "MoTa");
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
            id = string.Empty;
            txtMaNH.ResetText();
            txtMoTa.ResetText();
            txtTenNhomHang.ResetText();
            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;

            txtMaNH.Enabled = true;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (txtMaNH.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Mã nhóm hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtTenNhomHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên nhóm hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {
                // Kiểm tra Mã nhóm hàng bị trùng?
                bool tontai = DataManager.Instance.ListNhomHang.Any(x => x.MaNH == txtMaNH.Text.Trim());
                if (tontai == true)
                {
                    MessageBox.Show("Mã nhóm hàng này đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhomHang nHOMHANG = new NhomHang()
                {
                    MaNH = txtMaNH.Text.Trim(),
                    TenNhomHang = txtTenNhomHang.Text,
                    MoTa = txtMoTa.Text
                };
                DataManager.Instance.PostNhomHang(nHOMHANG);
            }
            else
            {
                NhomHang nHOMHANG = DataManager.Instance.ListNhomHang.FirstOrDefault(x => x.MaNH == txtMaNH.Text);
                nHOMHANG.TenNhomHang = txtTenNhomHang.Text;
                nHOMHANG.MoTa = txtMoTa.Text;
                DataManager.Instance.PutNhomHang(nHOMHANG);
            }

            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(NhomHang.MaNH)].Value.ToString();
                NhomHang nHOMHANG = DataManager.Instance.ListNhomHang.FirstOrDefault(x => x.MaNH == id);
                txtMaNH.Text = nHOMHANG.MaNH;
                txtMoTa.Text = nHOMHANG.MoTa;
                txtTenNhomHang.Text = nHOMHANG.TenNhomHang;

                //bật tắt các nút
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuuLai.Enabled = true;
                btnHuy.Enabled = true;
                groupThaoTac.Enabled = true;
                txtMaNH.Enabled = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        void huy()
        {
            id = string.Empty;
            txtMaNH.ResetText();
            txtMoTa.ResetText();
            txtTenNhomHang.ResetText();

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;
            txtMaNH.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(NhomHang.MaNH)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        NhomHang nHOMHANG = DataManager.Instance.ListNhomHang.FirstOrDefault(x => x.MaNH == id);
                        DataManager.Instance.DeleteNhomHang(nHOMHANG);
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
            dgvDanhSach.DataSource = DataManager.Instance.ListNhomHang
                .Where(x => x.TenNhomHang.Contains(txtTimKiem.Text) || x.MoTa.Contains(txtTimKiem.Text))
                .Select(x=> new { x.MaNH, x.TenNhomHang, x.MoTa })
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

    }
}
