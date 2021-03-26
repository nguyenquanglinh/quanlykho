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
    public partial class frmPhieuNhapKho : Form
    {
        BindingSource bdHangHoa = new BindingSource();
        List<HangHoaNhap> dsHangHoa = new List<HangHoaNhap>();
        const string hangsoID = "PN";

        string id = string.Empty;

        public frmPhieuNhapKho()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = DataManager.Instance.ListPhieuNhap
                .Where(x => x.MaPN.StartsWith(hangsoID))
                .ToList();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();

            //Load nhân viên
            cbbNhanVien.DataSource = DataManager.Instance.ListNhanVien.ToList();
            cbbNhanVien.DisplayMember = nameof(NhanVien.TenNhanVien);
            cbbNhanVien.ValueMember = nameof(NhanVien.MaNV);

            //Load nhà cung cấp
            cbbNCC.DataSource = DataManager.Instance.ListNhaCC;
            cbbNCC.DisplayMember = nameof(NhaCungCap.TenNCC);
            cbbNCC.ValueMember = nameof(NhaCungCap.MaNCC);

            //Load kho
            cbbKho.DataSource = DataManager.Instance.ListKho;
            cbbKho.DisplayMember = nameof(Kho.TenKho);
            cbbKho.ValueMember = nameof(Kho.MaKho);

            //Load hàng hóa
            cbbHangHoa.DataSource = DataManager.Instance.ListHangHoa;
            cbbHangHoa.DisplayMember = nameof(HangHoa.TenHangHoa);
            cbbHangHoa.ValueMember = nameof(HangHoa.MaHH);

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
            cbbKho.SelectedIndex = -1;
            cbbNCC.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lấy id tự tạo mới nhất
            txtMaPN.Text = NewID();

            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;

            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
            cbbNCC.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);

            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (cbbNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhà cung cấp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbbNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbbKho.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dsHangHoa.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập Hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuNhap pHIEUNHAP = new PhieuNhap();
            if (id == string.Empty)
            {
                // Thêm mới
                pHIEUNHAP = new PhieuNhap()
                {
                    MaPN = NewID(),
                    NgayNhap = txtNgayNhap.Value.ToString(),
                    MaNCC = cbbNCC.SelectedValue.ToString(),
                    DiaChi = txtDiaChi.Text,
                    MaNV = cbbNhanVien.SelectedValue.ToString(),
                    MaKho = cbbKho.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };
                DataManager.Instance.PostPhieuNhap(pHIEUNHAP);
            }
            else
            {
                // Sửa
                pHIEUNHAP = DataManager.Instance.ListPhieuNhap.Where(x => x.MaPN == id).FirstOrDefault();

                pHIEUNHAP.NgayNhap = txtNgayNhap.Value.ToString();
                pHIEUNHAP.MaNCC = cbbNCC.SelectedValue.ToString();
                pHIEUNHAP.DiaChi = txtDiaChi.Text;
                pHIEUNHAP.MaNV = cbbNhanVien.SelectedValue.ToString();
                pHIEUNHAP.MaKho = cbbKho.SelectedValue.ToString();
                pHIEUNHAP.GhiChu = txtGhiChu.Text;

                DataManager.Instance.PutPhieuNhap(pHIEUNHAP);
            }

            // Cập nhật chi tiết phiếu nhập
            var lstOldCTPhieuNhap = DataManager.Instance.ListCTPhieuNhap.Where(x => x.MaPN == pHIEUNHAP.MaPN).ToList();
            for (int i = 0; i < lstOldCTPhieuNhap.Count(); i++)
            {
                DataManager.Instance.DeleteCTPhieuNhap(lstOldCTPhieuNhap[i]);
            }

            var lstCTPhieuNhap = dsHangHoa.Select((x, index) => new CTPhieuNhap
            {
                MaCTPN = pHIEUNHAP.MaPN + "CT" + (index + 1).ToString().PadLeft(3, '0'),
                MaPN = pHIEUNHAP.MaPN,
                MaHH = x.MaHH,
                SoLuong = x.SoLuong.ToString(),
                GiaNhap = x.GiaNhap.ToString()
            }).ToList();

            for (int i = 0; i < lstCTPhieuNhap.Count(); i++)
            {
                DataManager.Instance.PostCTPhieuNhap(lstCTPhieuNhap[i]);
            }

            // Load data phiếu nhập
            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(PhieuNhap.MaPN)].Value.ToString();

                // Load phiếu nhập
                PhieuNhap pHIEUNHAP = DataManager.Instance.ListPhieuNhap.Where(x => x.MaPN == id).FirstOrDefault();

                txtMaPN.Text = pHIEUNHAP.MaPN;
                txtNgayNhap.Value = DateTime.Parse(pHIEUNHAP.NgayNhap);
                cbbNCC.SelectedValue = pHIEUNHAP.MaNCC;
                txtDiaChi.Text = pHIEUNHAP.DiaChi;
                cbbNhanVien.SelectedValue = pHIEUNHAP.MaNV;
                cbbKho.SelectedValue = pHIEUNHAP.MaKho;
                txtGhiChu.Text = pHIEUNHAP.GhiChu;

                // Load phiếu nhập chi tiết


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
            txtMaPN.ResetText();
            txtNgayNhap.ResetText();
            txtDiaChi.ResetText();
            txtGhiChu.ResetText();
            txtSoLuong.ResetText();
            txtGiaNhap.ResetText();
            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
            cbbNCC.SelectedIndex = -1;
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

            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PhieuNhap.MaPN)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        var lstOldCTPhieuNhap = DataManager.Instance.ListCTPhieuNhap.Where(x => x.MaPN == id).ToList();
                        for (int i = 0; i < lstOldCTPhieuNhap.Count(); i++)
                        {
                            DataManager.Instance.DeleteCTPhieuNhap(lstOldCTPhieuNhap[i]);
                        }
                        PhieuNhap pHIEUNHAP = DataManager.Instance.ListPhieuNhap.Where(x => x.MaPN == id).FirstOrDefault();
                        DataManager.Instance.DeletePhieuNhap(pHIEUNHAP);
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
            dgvDanhSach.DataSource = DataManager.Instance.ListPhieuNhap
                .Where(x => x.MaPN.StartsWith(hangsoID) && (x.GhiChu.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text)))
                .Select(x => new { x.MaPN, x.NgayNhap, x.DiaChi, x.GhiChu })
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
            else if (txtGiaNhap.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập giá nhập!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangHoaNhap hangHoaNhap = dsHangHoa.Find(x => x.MaHH == cbbHangHoa.SelectedValue.ToString());
            if (hangHoaNhap == null)
            {
                hangHoaNhap = new HangHoaNhap()
                {
                    MaHH = cbbHangHoa.SelectedValue.ToString(),
                    TenHangHoa = cbbHangHoa.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    GiaNhap = decimal.Parse(txtGiaNhap.Text)
                };
                dsHangHoa.Insert(0, hangHoaNhap);
            }
            else
            {
                hangHoaNhap.SoLuong += int.Parse(txtSoLuong.Text);
                hangHoaNhap.GiaNhap = decimal.Parse(txtGiaNhap.Text);
            }

            //Load Hang Hoa
            bdHangHoa.ResetBindings(true);
            cbbHangHoa.SelectedIndex = -1;
            txtSoLuong.ResetText();
            txtGiaNhap.ResetText();
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sửa hàng hóa
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                HangHoaNhap hangHoaNhap = dsHangHoa[e.RowIndex];
                cbbHangHoa.SelectedValue = hangHoaNhap.MaHH;
                txtSoLuong.Text = hangHoaNhap.SoLuong.ToString();
                txtGiaNhap.Text = hangHoaNhap.GiaNhap.ToString();
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
            string oldID = "0";
            PhieuNhap pHIEUNHAP = DataManager.Instance.ListPhieuNhap.Where(x => x.MaPN.StartsWith(hangsoID)).OrderByDescending(x => x.MaPN).FirstOrDefault();
            if (pHIEUNHAP != null)
            {
                oldID = pHIEUNHAP.MaPN.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }

        private void dgvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PhieuNhap.MaPN)].Value.ToString();

               
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

    public class HangHoaNhap
    {
        public string MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> GiaNhap { get; set; }
    }
}
