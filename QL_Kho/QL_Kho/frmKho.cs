using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSource.DTO;

namespace QL_Kho
{
    public partial class frmKho : Form
    {
        string id = string.Empty;

        public frmKho()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = DataManager.Instance.ListKho.Select(x => new { x.MaKho, x.TenKho, x.DiaChi }).ToList();
            bingding();
        }
        public void bingding()
        {
            txtMaKho.DataBindings.Clear();
            txtMaKho.DataBindings.Add("Text", dgvDanhSach.DataSource, "MaKho");
            txtTenKho.DataBindings.Clear();
            txtTenKho.DataBindings.Add("Text", dgvDanhSach.DataSource, "TenKho");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvDanhSach.DataSource, "DiaChi");
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
            txtMaKho.Text = NewID();
            id = string.Empty;
            txtDiaChi.ResetText();
            txtTenKho.ResetText();
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
            if (txtTenKho.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == string.Empty)
            {

                Kho kHO = new Kho()
                {
                    MaKho = NewID(),
                    TenKho = txtTenKho.Text,
                    DiaChi = txtDiaChi.Text
                };
                DataManager.Instance.PostKho(kHO);
            }
            else
            {
                Kho kHO = DataManager.Instance.ListKho.FirstOrDefault(x => x.MaKho == txtMaKho.Text);
                kHO.TenKho = txtTenKho.Text;
                kHO.DiaChi = txtDiaChi.Text;
                DataManager.Instance.PutKho(kHO);
            }

            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(Kho.MaKho)].Value.ToString();
                Kho kHO = DataManager.Instance.ListKho.FirstOrDefault(x => x.MaKho == id);
                txtMaKho.Text = kHO.MaKho;
                txtDiaChi.Text = kHO.DiaChi;
                txtTenKho.Text = kHO.TenKho;

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
            txtMaKho.ResetText();
            txtDiaChi.ResetText();
            txtTenKho.ResetText();

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
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(Kho.MaKho)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        Kho kHO = DataManager.Instance.ListKho.FirstOrDefault(x => x.MaKho == id);
                        DataManager.Instance.DeleteKho(kHO);
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
            dgvDanhSach.DataSource = DataManager.Instance.ListKho
                .Select(x=> new { x.MaKho, x.TenKho, x.DiaChi})
                .Where(x => x.TenKho.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text))
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
            string hangsoID = "KHO";
            string oldID = "0";
            Kho kHO = DataManager.Instance.ListKho.OrderByDescending(x => x.MaKho).FirstOrDefault();
            if (kHO != null)
            {
                oldID = kHO.MaKho.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }
    }
}
