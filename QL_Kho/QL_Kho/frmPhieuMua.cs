using QL_Kho.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSource.DTO;

namespace QL_Kho
{
    public partial class frmPhieuMua : Form
    {
        BindingSource bdHangHoa = new BindingSource();
        List<HangHoaMua> dsHangHoa = new List<HangHoaMua>();


        string id = string.Empty;

        public frmPhieuMua()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = DataManager.Instance.ListPhieuMua;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();

            //Load nhân viên
            cbbNhanVien.DataSource = DataManager.Instance.ListNhanVien.ToList();
            cbbNhanVien.DisplayMember = "TenNhanVien";
            cbbNhanVien.ValueMember = "MaNV";

            //Load hàng hóa
            cbbHangHoa.DataSource = DataManager.Instance.ListHangHoa.ToList();
            cbbHangHoa.DisplayMember = "TenHangHoa";
            cbbHangHoa.ValueMember = "MaHH";

            //Khởi tạo grid hàng hóa
            bdHangHoa.DataSource = dsHangHoa;
            dgvHangHoa.DataSource = bdHangHoa;
            dgvHangHoa.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Sua",
                Image = Resources.pencil_edit,
                Name = "Edit",
                MinimumWidth = 30,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            });
            dgvHangHoa.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Xoa",
                Image = Resources.delete_2,
                Name = "Delete",
                MinimumWidth = 30,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
            });

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            cbbHangHoa.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lấy id tự tạo mới nhất
            txtMaPM.Text = NewID();

            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;

            cbbHangHoa.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);

            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (cbbNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dsHangHoa.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập Hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuMua pHIEUMUA = new PhieuMua();
            if (id == string.Empty)
            {
                // Thêm mới
                pHIEUMUA = new PhieuMua()
                {
                    MaPM = NewID(),
                    NgayLap = txtNgayNhap.Value.ToString(),
                    MaNV = cbbNhanVien.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                DataManager.Instance.PostPhieuMua(pHIEUMUA);
            }
            else
            {
                // Sửa
                pHIEUMUA = DataManager.Instance.ListPhieuMua.Where(x => x.MaPM == id).FirstOrDefault();

                pHIEUMUA.NgayLap = txtNgayNhap.Value.ToString();
                pHIEUMUA.MaNV = cbbNhanVien.SelectedValue.ToString();
                pHIEUMUA.GhiChu = txtGhiChu.Text;

                DataManager.Instance.PutPhieuMua(pHIEUMUA);
            }

            // Cập nhật chi tiết phiếu mua
            var lstOldCTPhieuMua = DataManager.Instance.ListCTPhieuMua.Where(x => x.MaPM == pHIEUMUA.MaPM).ToList();
            for (int i = 0; i < lstOldCTPhieuMua.Count(); i++)
            {
                DataManager.Instance.DeleteCTPhieuMua(lstOldCTPhieuMua[i]);
            }

            var lstCTPhieuMua = dsHangHoa.Select((x, index) => new CTPhieuMua
            {
                MaCTPM = pHIEUMUA.MaPM + "CT" + (index + 1).ToString().PadLeft(3, '0'),
                MaPM = pHIEUMUA.MaPM,
                MaHH = x.MaHH,
                SoLuong = x.SoLuong.ToString()
            }).ToList();
            for (int i = 0; i < lstCTPhieuMua.Count(); i++)
            {
                DataManager.Instance.PostCTPhieuMua(lstCTPhieuMua[i]);
            }

            // Load data phiếu mua
            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(PhieuMua.MaPM)].Value.ToString();

                // Load phiếu mua
                PhieuMua pHIEUMUA = DataManager.Instance.ListPhieuMua.Where(x => x.MaPM == id).FirstOrDefault();

                txtMaPM.Text = pHIEUMUA.MaPM;
                txtNgayNhap.Value = DateTime.Parse(pHIEUMUA.NgayLap);
                cbbNhanVien.SelectedValue = pHIEUMUA.MaNV;
                txtGhiChu.Text = pHIEUMUA.GhiChu;

                // Load phiếu mua chi tiết


                dsHangHoa.Clear();
                bdHangHoa.ResetBindings(true);

                //bật tắt các nút
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuuLai.Enabled = true;
                btnHuy.Enabled = true;
                groupThaoTac.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bạn Chưa chọn bản ghi.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        void huy()
        {
            id = string.Empty;
            txtMaPM.ResetText();
            txtNgayNhap.ResetText();
            txtGhiChu.ResetText();
            txtSoLuong.ResetText();
            cbbHangHoa.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);

            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            cbbHangHoa.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PhieuMua.MaPM)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        // Cập nhật chi tiết phiếu mua
                        var lstOldCTPhieuMua = DataManager.Instance.ListCTPhieuMua.Where(x => x.MaPM == id).ToList();
                        for (int i = 0; i < lstOldCTPhieuMua.Count; i++)
                        {
                            DataManager.Instance.DeleteCTPhieuMua(lstOldCTPhieuMua[i]);
                        }


                        PhieuMua pHIEUMUA = DataManager.Instance.ListPhieuMua.Where(x => x.MaPM == id).FirstOrDefault();
                        DataManager.Instance.DeletePhieuMua(pHIEUMUA);

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
                MessageBox.Show("Bạn Chưa chọn bản ghi.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = DataManager.Instance.ListPhieuMua
                .Where(x => x.GhiChu.Contains(txtTimKiem.Text))
                .Select(x => new { x.MaPM, x.NgayLap, x.GhiChu })
                .ToList();
            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);
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

        private void btnThenHangHoa_Click(object sender, EventArgs e)
        {
            if (cbbHangHoa.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtSoLuong.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangHoaMua hangHoaMua = dsHangHoa.Find(x => x.MaHH == cbbHangHoa.SelectedValue.ToString());
            if (hangHoaMua == null)
            {
                hangHoaMua = new HangHoaMua()
                {
                    MaHH = cbbHangHoa.SelectedValue.ToString(),
                    TenHangHoa = cbbHangHoa.Text,
                    SoLuong = int.Parse(txtSoLuong.Text)
                };
                dsHangHoa.Insert(0, hangHoaMua);
            }
            else
            {
                hangHoaMua.SoLuong += int.Parse(txtSoLuong.Text);
            }

            //Load Hang Hoa
            bdHangHoa.ResetBindings(true);
            cbbHangHoa.SelectedIndex = -1;
            txtSoLuong.ResetText();
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sửa hàng hóa
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                HangHoaMua hangHoaMua = dsHangHoa[e.RowIndex];
                cbbHangHoa.SelectedValue = hangHoaMua.MaHH;
                txtSoLuong.Text = hangHoaMua.SoLuong.ToString();
                dsHangHoa.RemoveAt(e.RowIndex);
                //Load Hang Hoa
                bdHangHoa.ResetBindings(true);
            }
            // Xóa hàng hóa
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                dsHangHoa.RemoveAt(e.RowIndex);
                //Load Hang Hoa
                bdHangHoa.ResetBindings(true);
            }
        }

        private string NewID()
        {
            string hangsoID = "PM";
            string oldID = "0";
            PhieuMua pHIEUMUA = DataManager.Instance.ListPhieuMua.OrderByDescending(x => x.MaPM).FirstOrDefault();
            if (pHIEUMUA != null)
            {
                oldID = pHIEUMUA.MaPM.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }

        private void dgvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PhieuMua.MaPM)].Value.ToString();

                // Load phiếu mua chi tiết

                dsHangHoa.Clear();
                bdHangHoa.ResetBindings(true);
            }
        }

        private void dgvDanhSach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void dgvHangHoa_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvHangHoa.ClearSelection();
        }
    }

    public class HangHoaMua
    {
        public string MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
    }
}
