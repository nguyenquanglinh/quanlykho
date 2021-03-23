using QL_Kho.Data;
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

namespace QL_Kho
{
    public partial class frmPhieuChuyenKho : Form
    {
        BindingSource bdHangHoa = new BindingSource();
        List<HangHoaChuyen> dsHangHoa = new List<HangHoaChuyen>();
        int soluongtontrenform = 0;
        const string hangsoID = "DC";
        const string hangsoMaDC = "MaDC";

        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();

        string id = string.Empty;

        public frmPhieuChuyenKho()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.PHIEUNHAPs
                .Join(dA_QLYKHOEntities.PHIEUXUATs, x => x.MaPN, y => y.MaPX, (x, y) => new { PhieuNhap = x, TuKho = y.KHO.TenKho })
                .Where(x => x.PhieuNhap.MaPN.StartsWith(hangsoID))
                .Select(x => new { MaDC = x.PhieuNhap.MaPN, NgayDC = x.PhieuNhap.NgayNhap, x.PhieuNhap.NHANVIEN.TenNhanVien, x.TuKho, DenKho = x.PhieuNhap.KHO.TenKho, x.PhieuNhap.GhiChu })
                .ToList();
        }

        private void frmPhieuChuyenKho_Load(object sender, EventArgs e)
        {
            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            LoadData();

            //Load nhân viên
            cbbNhanVien.DataSource = dA_QLYKHOEntities.NHANVIENs.ToList();
            cbbNhanVien.DisplayMember = nameof(NHANVIEN.TenNhanVien);
            cbbNhanVien.ValueMember = nameof(NHANVIEN.MaNV);

            //Load kho
            cbbTuKho.DataSource = dA_QLYKHOEntities.KHOes.ToList();
            cbbTuKho.DisplayMember = nameof(KHO.TenKho);
            cbbTuKho.ValueMember = nameof(KHO.MaKho);

            cbbDenKho.DataSource = dA_QLYKHOEntities.KHOes.ToList();
            cbbDenKho.DisplayMember = nameof(KHO.TenKho);
            cbbDenKho.ValueMember = nameof(KHO.MaKho);

            //Load hàng hóa
            cbbHangHoa.DataSource = dA_QLYKHOEntities.HANGHOAs.ToList();
            cbbHangHoa.DisplayMember = nameof(HANGHOA.TenHangHoa);
            cbbHangHoa.ValueMember = nameof(HANGHOA.MaHH);

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

            cbbHangHoa.SelectedIndex = -1;
            cbbTuKho.SelectedIndex = -1;
            cbbDenKho.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
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

            cbbHangHoa.SelectedIndex = -1;
            cbbTuKho.SelectedIndex = -1;
            cbbDenKho.SelectedIndex = -1;
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
            else if (cbbTuKho.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Kho để chuyển hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbbDenKho.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Kho chuyển hàng tới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbbTuKho.SelectedValue == cbbDenKho.SelectedValue)
            {
                MessageBox.Show("2 Kho không được trùng nhau!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (dsHangHoa.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập Hàng hóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PHIEUXUAT pHIEUXUAT = new PHIEUXUAT();
            PHIEUNHAP pHIEUNHAP = new PHIEUNHAP();

            if (id == string.Empty)
            {
                // Thêm mới
                string newid = NewID();
                pHIEUXUAT = new PHIEUXUAT()
                {
                    MaPX = newid,
                    NgayXuat = txtNgayNhap.Value,
                    MaKH = null,
                    DiaChi = null,
                    MaNV = cbbNhanVien.SelectedValue.ToString(),
                    MaKho = cbbTuKho.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                pHIEUNHAP = new PHIEUNHAP()
                {
                    MaPN = newid,
                    NgayNhap = txtNgayNhap.Value,
                    MaNCC = null,
                    DiaChi = null,
                    MaNV = cbbNhanVien.SelectedValue.ToString(),
                    MaKho = cbbDenKho.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                dA_QLYKHOEntities.PHIEUXUATs.Add(pHIEUXUAT);
                dA_QLYKHOEntities.PHIEUNHAPs.Add(pHIEUNHAP);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                // Sửa
                pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX == id).FirstOrDefault();

                pHIEUNHAP.NgayNhap = txtNgayNhap.Value;
                pHIEUNHAP.MaNCC = null;
                pHIEUNHAP.DiaChi = null;
                pHIEUNHAP.MaNV = cbbNhanVien.SelectedValue.ToString();
                pHIEUNHAP.MaKho = cbbTuKho.SelectedValue.ToString();
                pHIEUNHAP.GhiChu = txtGhiChu.Text;

                pHIEUNHAP = dA_QLYKHOEntities.PHIEUNHAPs.Where(x => x.MaPN == id).FirstOrDefault();

                pHIEUNHAP.NgayNhap = txtNgayNhap.Value;
                pHIEUNHAP.MaNCC = null;
                pHIEUNHAP.DiaChi = null;
                pHIEUNHAP.MaNV = cbbNhanVien.SelectedValue.ToString();
                pHIEUNHAP.MaKho = cbbDenKho.SelectedValue.ToString();
                pHIEUNHAP.GhiChu = txtGhiChu.Text;

                dA_QLYKHOEntities.SaveChanges();
            }

            // Cập nhật chi tiết phiếu
            var lstOldCTPhieuXuat = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaPX == pHIEUXUAT.MaPX);
            dA_QLYKHOEntities.CTPHIEUXUATs.RemoveRange(lstOldCTPhieuXuat);
            var lstCTPhieuXuat = dsHangHoa.Select((x, index) => new CTPHIEUXUAT
            {
                MaCTPX = pHIEUXUAT.MaPX + "CT" + (index + 1).ToString().PadLeft(3, '0'),
                MaPX = pHIEUXUAT.MaPX,
                MaHH = x.MaHH,
                SoLuong = x.SoLuong,
                GiaXuat = 0

            });

            dA_QLYKHOEntities.CTPHIEUXUATs.AddRange(lstCTPhieuXuat);

            var lstOldCTPhieuNhap = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.MaPN == pHIEUNHAP.MaPN);
            dA_QLYKHOEntities.CTPHIEUNHAPs.RemoveRange(lstOldCTPhieuNhap);

            var lstCTPhieuNhap = dsHangHoa.Select((x, index) => new CTPHIEUNHAP
            {
                MaCTPN = pHIEUNHAP.MaPN + "CT" + (index + 1).ToString().PadLeft(3, '0'),
                MaPN = pHIEUNHAP.MaPN,
                MaHH = x.MaHH,
                SoLuong = x.SoLuong,
                GiaNhap = 0
            });

            dA_QLYKHOEntities.CTPHIEUNHAPs.AddRange(lstCTPhieuNhap);
            dA_QLYKHOEntities.SaveChanges();

            // Load data phiếu nhập
            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[hangsoMaDC].Value.ToString();

                // Load phiếu nhập
                PHIEUXUAT pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX == id).FirstOrDefault();
                PHIEUNHAP pHIEUNHAP = dA_QLYKHOEntities.PHIEUNHAPs.Where(x => x.MaPN == id).FirstOrDefault();

                txtNgayNhap.Value = pHIEUNHAP.NgayNhap.Value;
                cbbNhanVien.SelectedValue = pHIEUNHAP.MaNV;
                cbbTuKho.SelectedValue = pHIEUXUAT.MaKho;
                cbbDenKho.SelectedValue = pHIEUNHAP.MaKho;
                txtGhiChu.Text = pHIEUNHAP.GhiChu;

                // Load phiếu nhập chi tiết
                List<HangHoaChuyen> hangHoaNhaps = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.MaPN == id).Select(x => new HangHoaChuyen
                {
                    MaHH = x.MaHH,
                    TenHangHoa = x.HANGHOA.TenHangHoa,
                    SoLuong = x.SoLuong
                }).ToList();

                dsHangHoa.Clear();
                dsHangHoa.AddRange(hangHoaNhaps);
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
            soluongtontrenform = 0;
            txtNgayNhap.ResetText();
            txtGhiChu.ResetText();
            txtSoLuong.ResetText();
            txtSoLuongTon.ResetText();
            cbbHangHoa.SelectedIndex = -1;
            cbbTuKho.SelectedIndex = -1;
            cbbDenKho.SelectedIndex = -1;
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
                string id = dgvDanhSach.SelectedRows[0].Cells[hangsoMaDC].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        var lstOldCTPhieuXuat = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaPX == id);
                        dA_QLYKHOEntities.CTPHIEUXUATs.RemoveRange(lstOldCTPhieuXuat);

                        var lstOldCTPhieuNhap = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.MaPN == id);
                        dA_QLYKHOEntities.CTPHIEUNHAPs.RemoveRange(lstOldCTPhieuNhap);

                        PHIEUXUAT pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX == id).FirstOrDefault();
                        dA_QLYKHOEntities.PHIEUXUATs.Remove(pHIEUXUAT);

                        PHIEUNHAP pHIEUNHAP = dA_QLYKHOEntities.PHIEUNHAPs.Where(x => x.MaPN == id).FirstOrDefault();
                        dA_QLYKHOEntities.PHIEUNHAPs.Remove(pHIEUNHAP);

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
                MessageBox.Show("Bạn Chưa chọn bản ghi.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.PHIEUNHAPs
                .Where(x => x.MaPN.StartsWith(hangsoID) && (x.GhiChu.Contains(txtTimKiem.Text) || x.NHACUNGCAP.TenNCC.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text) || x.NHANVIEN.TenNhanVien.Contains(txtTimKiem.Text) || x.KHO.TenKho.Contains(txtTimKiem.Text)))
            .Join(dA_QLYKHOEntities.PHIEUXUATs, x => x.MaPN, y => y.MaPX, (x, y) => new { PhieuNhap = x, TuKho = y.KHO.TenKho })
                .Select(x => new { MaDC = x.PhieuNhap.MaPN, NgayDC = x.PhieuNhap.NgayNhap, x.PhieuNhap.NHANVIEN.TenNhanVien, x.TuKho, DenKho = x.PhieuNhap.KHO.TenKho, x.PhieuNhap.GhiChu })
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

            int soluongdangxuat = dsHangHoa.Where(x => x.MaHH == cbbHangHoa.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            if (int.Parse(txtSoLuong.Text) + soluongdangxuat > int.Parse(txtSoLuongTon.Text))
            {
                MessageBox.Show("Khổng thể xuất quá số lượng tồn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangHoaChuyen hangHoaChuyen = dsHangHoa.Find(x => x.MaHH == cbbHangHoa.SelectedValue.ToString());
            if (hangHoaChuyen == null)
            {
                hangHoaChuyen = new HangHoaChuyen()
                {
                    MaHH = cbbHangHoa.SelectedValue.ToString(),
                    TenHangHoa = cbbHangHoa.Text,
                    SoLuong = int.Parse(txtSoLuong.Text)
                };
                dsHangHoa.Insert(0, hangHoaChuyen);
            }
            else
            {
                hangHoaChuyen.SoLuong += int.Parse(txtSoLuong.Text);
            }

            //Load Hang Hoa
            bdHangHoa.ResetBindings(true);
            cbbHangHoa.SelectedIndex = -1;
            txtSoLuong.ResetText();
            txtSoLuongTon.ResetText();
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sửa hàng hóa
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                HangHoaChuyen hangHoaChuyen = dsHangHoa[e.RowIndex];
                soluongtontrenform = hangHoaChuyen.SoLuong ?? 0;
                cbbHangHoa.SelectedValue = hangHoaChuyen.MaHH;
                txtSoLuong.Text = hangHoaChuyen.SoLuong.ToString();
                
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
            PHIEUNHAP pHIEUNHAP = dA_QLYKHOEntities.PHIEUNHAPs.Where(x => x.MaPN.StartsWith(hangsoID)).OrderByDescending(x => x.MaPN).FirstOrDefault();
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
                string id = dgvDanhSach.SelectedRows[0].Cells[hangsoMaDC].Value.ToString();

                // Load phiếu nhập chi tiết
                List<HangHoaChuyen> hangHoaNhaps = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.MaPN == id).Select(x => new HangHoaChuyen
                {
                    MaHH = x.MaHH,
                    TenHangHoa = x.HANGHOA.TenHangHoa,
                    SoLuong = x.SoLuong
                }).ToList();

                dsHangHoa.Clear();
                dsHangHoa.AddRange(hangHoaNhaps);
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

        private void TinhSoLuongTon(string mahh)
        {
            DateTime dauthang = DateTime.Today.AddDays(-(DateTime.Today.Day - 1));
            DateTime cuoithang = dauthang.AddMonths(1);
            int soluongtondauky = dA_QLYKHOEntities.TONDAUKies.Where(x => x.MaHH == mahh && x.NgayCapNhat == dauthang && x.MaKho == cbbTuKho.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            int soluongnhap = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.MaHH == mahh && x.PHIEUNHAP.NgayNhap >= dauthang && x.PHIEUNHAP.NgayNhap < cuoithang && x.PHIEUNHAP.MaKho == cbbTuKho.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            int soluongxuat = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaHH == mahh && x.PHIEUXUAT.NgayXuat >= dauthang && x.PHIEUXUAT.NgayXuat < cuoithang && x.PHIEUXUAT.MaKho == cbbTuKho.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            txtSoLuongTon.Text = (soluongtontrenform + soluongtondauky + soluongnhap - soluongxuat).ToString();
        }

        private void cbbTuKho_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbTuKho.SelectedIndex >= 0 && btnLuuLai.Enabled == true)
            {
                if (dsHangHoa.Count > 0)
                {
                    // kiểm tra hàng tồn khi thay đổi kho
                    List<HangHoaChuyen> listHangHoaDelete = new List<HangHoaChuyen>();
                    foreach (var item in dsHangHoa)
                    {
                        TinhSoLuongTon(item.MaHH);
                        int soluongton = int.Parse(txtSoLuongTon.Text);
                        if (item.SoLuong > soluongton)
                        {
                            if (soluongton == 0)
                            {
                                listHangHoaDelete.Add(item);
                            }
                            else
                            {
                                item.SoLuong = soluongton;
                            }
                        }
                    }

                    foreach (var item in listHangHoaDelete)
                    {
                        dsHangHoa.Remove(item);
                    }

                    bdHangHoa.ResetBindings(true);
                }
                if (cbbHangHoa.SelectedIndex >= 0)
                {
                    TinhSoLuongTon(cbbHangHoa.SelectedValue.ToString());
                }
            }
        }

        private void cbbHangHoa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbHangHoa.SelectedIndex >= 0 && btnLuuLai.Enabled == true)
            {
                if (cbbTuKho.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn chưa chọn Kho chuyển hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbHangHoa.SelectedIndex = -1;
                    return;
                }

                var mahh = cbbHangHoa.SelectedValue.ToString();
                TinhSoLuongTon(mahh);
            }
        }
    }

    public class HangHoaChuyen
    {
        public string MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
    }
}
