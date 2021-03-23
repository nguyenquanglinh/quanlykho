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
    public partial class frmPhieuXuatKho : Form
    {
        BindingSource bdHangHoa = new BindingSource();
        List<HangHoaXuat> dsHangHoa = new List<HangHoaXuat>();
        const string hangsoID = "PX";

        DA_QLYKHOEntities dA_QLYKHOEntities = new DA_QLYKHOEntities();

        string id = string.Empty;
        int soluongtontrenform = 0;

        public frmPhieuXuatKho()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDanhSach.DataSource = dA_QLYKHOEntities.PHIEUXUATs
                .Where(x=>x.MaPX.StartsWith(hangsoID))
                .Select(x => new { x.MaPX, x.NgayXuat, x.KHACHHANG.TenKhachHang, x.DiaChi, x.NHANVIEN.TenNhanVien, x.KHO.TenKho, x.GhiChu })
                .ToList();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
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

            //Load khách hàng
            cbbKhachHang.DataSource = dA_QLYKHOEntities.KHACHHANGs.ToList();
            cbbKhachHang.DisplayMember = nameof(KHACHHANG.TenKhachHang);
            cbbKhachHang.ValueMember = nameof(KHACHHANG.MaKH);

            //Load kho
            cbbKho.DataSource = dA_QLYKHOEntities.KHOes.ToList();
            cbbKho.DisplayMember = nameof(KHO.TenKho);
            cbbKho.ValueMember = nameof(KHO.MaKho);

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
            cbbKho.SelectedIndex = -1;
            cbbKhachHang.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lấy id tự tạo mới nhất
            txtMaPX.Text = NewID();

            //bật tắt các nút
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuuLai.Enabled = true;
            btnHuy.Enabled = true;
            groupThaoTac.Enabled = true;

            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
            cbbKhachHang.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);
            TinhTongTien();

            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (cbbKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn Khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            PHIEUXUAT pHIEUXUAT = new PHIEUXUAT();
            if (id == string.Empty)
            {
                // Thêm mới
                pHIEUXUAT = new PHIEUXUAT()
                {
                    MaPX = NewID(),
                    NgayXuat = txtNgayNhap.Value,
                    MaKH = cbbKhachHang.SelectedValue.ToString(),
                    DiaChi = txtDiaChi.Text,
                    MaNV = cbbNhanVien.SelectedValue.ToString(),
                    MaKho = cbbKho.SelectedValue.ToString(),
                    GhiChu = txtGhiChu.Text
                };

                dA_QLYKHOEntities.PHIEUXUATs.Add(pHIEUXUAT);
                dA_QLYKHOEntities.SaveChanges();
            }
            else
            {
                // Sửa
                pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX == id).FirstOrDefault();

                pHIEUXUAT.NgayXuat = txtNgayNhap.Value;
                pHIEUXUAT.MaKH = cbbKhachHang.SelectedValue.ToString();
                pHIEUXUAT.DiaChi = txtDiaChi.Text;
                pHIEUXUAT.MaNV = cbbNhanVien.SelectedValue.ToString();
                pHIEUXUAT.MaKho = cbbKho.SelectedValue.ToString();
                pHIEUXUAT.GhiChu = txtGhiChu.Text;

                dA_QLYKHOEntities.SaveChanges();
            }

            // Cập nhật chi tiết phiếu xuất
            var lstOldCTPhieuXuat = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaPX == pHIEUXUAT.MaPX);
            dA_QLYKHOEntities.CTPHIEUXUATs.RemoveRange(lstOldCTPhieuXuat);

            var lstCTPhieuNhap = dsHangHoa.Select((x, index) => new CTPHIEUXUAT
            {
                MaCTPX = pHIEUXUAT.MaPX + "CT" + (index + 1).ToString().PadLeft(3, '0'),
                MaPX = pHIEUXUAT.MaPX,
                MaHH = x.MaHH,
                SoLuong = x.SoLuong,
                GiaXuat = x.GiaXuat
            });

            dA_QLYKHOEntities.CTPHIEUXUATs.AddRange(lstCTPhieuNhap);
            dA_QLYKHOEntities.SaveChanges();

            // Load data phiếu xuất
            LoadData();

            huy();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                id = dgvDanhSach.SelectedRows[0].Cells[nameof(PHIEUXUAT.MaPX)].Value.ToString();

                // Load phiếu nhập
                PHIEUXUAT pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX == id).FirstOrDefault();

                txtMaPX.Text = pHIEUXUAT.MaPX;
                txtNgayNhap.Value = pHIEUXUAT.NgayXuat.Value;
                cbbKhachHang.SelectedValue = pHIEUXUAT.MaKH;
                txtDiaChi.Text = pHIEUXUAT.DiaChi;
                cbbNhanVien.SelectedValue = pHIEUXUAT.MaNV;
                cbbKho.SelectedValue = pHIEUXUAT.MaKho;
                txtGhiChu.Text = pHIEUXUAT.GhiChu;

                // Load phiếu nhập chi tiết
                List<HangHoaXuat> hangHoaNhaps = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaPX == id).Select(x => new HangHoaXuat
                {
                    MaHH = x.MaHH,
                    TenHangHoa = x.HANGHOA.TenHangHoa,
                    SoLuong = x.SoLuong,
                    GiaXuat = x.GiaXuat
                }).ToList();

                dsHangHoa.Clear();
                dsHangHoa.AddRange(hangHoaNhaps);
                bdHangHoa.ResetBindings(true);
                TinhTongTien();

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
            txtMaPX.ResetText();
            txtNgayNhap.ResetText();
            txtDiaChi.ResetText();
            txtGhiChu.ResetText();
            txtSoLuong.ResetText();
            txtSoLuongTon.ResetText();
            txtGiaXuat.ResetText();
            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
            cbbKhachHang.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);
            TinhTongTien();


            //bật tắt các nút
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuuLai.Enabled = false;
            btnHuy.Enabled = false;
            groupThaoTac.Enabled = false;

            cbbHangHoa.SelectedIndex = -1;
            cbbKho.SelectedIndex = -1;
            cbbKhachHang.SelectedIndex = -1;
            cbbNhanVien.SelectedIndex = -1;

            dgvDanhSach.ClearSelection();
            dgvDanhSach.CurrentCell = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PHIEUXUAT.MaPX)].Value.ToString();
                DialogResult dlgresult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgresult == DialogResult.Yes)
                {
                    try
                    {
                        var lstOldCTPhieuXuat = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaPX == id);
                        dA_QLYKHOEntities.CTPHIEUXUATs.RemoveRange(lstOldCTPhieuXuat);

                        PHIEUXUAT pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX == id).FirstOrDefault();
                        dA_QLYKHOEntities.PHIEUXUATs.Remove(pHIEUXUAT);
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
            dgvDanhSach.DataSource = dA_QLYKHOEntities.PHIEUXUATs
                .Where(x => x.MaPX.StartsWith(hangsoID) && (x.GhiChu.Contains(txtTimKiem.Text) || x.KHACHHANG.TenKhachHang.Contains(txtTimKiem.Text) || x.DiaChi.Contains(txtTimKiem.Text) || x.NHANVIEN.TenNhanVien.Contains(txtTimKiem.Text) || x.KHO.TenKho.Contains(txtTimKiem.Text)))
                .Select(x => new { x.MaPX, x.NgayXuat, x.KHACHHANG.TenKhachHang, x.DiaChi, x.NHANVIEN.TenNhanVien, x.KHO.TenKho, x.GhiChu })
                .ToList();
            //Load Hang Hoa
            dsHangHoa.Clear();
            bdHangHoa.ResetBindings(true);
            TinhTongTien();
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
            else if (txtGiaXuat.Text == string.Empty)
            {
                MessageBox.Show("Giá xuất không được để trống!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soluongdangxuat = dsHangHoa.Where(x => x.MaHH == cbbHangHoa.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            if (int.Parse(txtSoLuong.Text) + soluongdangxuat > int.Parse(txtSoLuongTon.Text))
            {
                MessageBox.Show("Khổng thể xuất quá số lượng tồn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangHoaXuat HangHoaXuat = dsHangHoa.Find(x => x.MaHH == cbbHangHoa.SelectedValue.ToString());
            if (HangHoaXuat == null)
            {
                HangHoaXuat = new HangHoaXuat()
                {
                    MaHH = cbbHangHoa.SelectedValue.ToString(),
                    TenHangHoa = cbbHangHoa.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    GiaXuat = decimal.Parse(txtGiaXuat.Text)
                };
                dsHangHoa.Insert(0, HangHoaXuat);
            }
            else
            {
                HangHoaXuat.SoLuong += int.Parse(txtSoLuong.Text);
                HangHoaXuat.GiaXuat = decimal.Parse(txtGiaXuat.Text);
            }

            //Load Hang Hoa
            bdHangHoa.ResetBindings(true);
            TinhTongTien();
            cbbHangHoa.SelectedIndex = -1;
            txtSoLuong.ResetText();
            txtSoLuongTon.ResetText();
            txtGiaXuat.ResetText();
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sửa hàng hóa
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (cbbKho.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn chưa chọn Kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbHangHoa.SelectedIndex = -1;
                    return;
                }
                HangHoaXuat HangHoaXuat = dsHangHoa[e.RowIndex];
                soluongtontrenform = HangHoaXuat.SoLuong ?? 0;
                cbbHangHoa.SelectedValue = HangHoaXuat.MaHH;
                txtSoLuong.Text = HangHoaXuat.SoLuong.ToString();
                txtGiaXuat.Text = HangHoaXuat.GiaXuat.ToString();
                dsHangHoa.RemoveAt(e.RowIndex);
                //Load Hang Hoa
                bdHangHoa.ResetBindings(true);
                TinhTongTien();
            }
            // Xóa hàng hóa
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                dsHangHoa.RemoveAt(e.RowIndex);
                //Load Hang Hoa
                bdHangHoa.ResetBindings(true);
                TinhTongTien();
            }
        }
        private string NewID()
        {
            string oldID = "0";
            PHIEUXUAT pHIEUXUAT = dA_QLYKHOEntities.PHIEUXUATs.Where(x => x.MaPX.StartsWith(hangsoID)).OrderByDescending(x => x.MaPX).FirstOrDefault();
            if (pHIEUXUAT != null)
            {
                oldID = pHIEUXUAT.MaPX.Replace(hangsoID, string.Empty);
            }

            string newID = hangsoID + (int.Parse(oldID) + 1).ToString().PadLeft(3, '0');
            return newID;
        }

        private void dgvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                string id = dgvDanhSach.SelectedRows[0].Cells[nameof(PHIEUXUAT.MaPX)].Value.ToString();

                // Load phiếu nhập chi tiết
                List<HangHoaXuat> hangHoaNhaps = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaPX == id).Select(x => new HangHoaXuat
                {
                    MaHH = x.MaHH,
                    TenHangHoa = x.HANGHOA.TenHangHoa,
                    SoLuong = x.SoLuong,
                    GiaXuat = x.GiaXuat
                }).ToList();

                dsHangHoa.Clear();
                dsHangHoa.AddRange(hangHoaNhaps);
                bdHangHoa.ResetBindings(true);
                TinhTongTien();
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

        private void TinhTongTien()
        {
            lblTongTien.Text = (dsHangHoa.Sum(x => x.SoLuong * x.GiaXuat) ?? 0).ToString();
        }

        private void TinhSoLuongTon(string mahh)
        {
            DateTime dauthang = DateTime.Today.AddDays(-(DateTime.Today.Day - 1));
            DateTime cuoithang = dauthang.AddMonths(1);
            int soluongtondauky = dA_QLYKHOEntities.TONDAUKies.Where(x => x.MaHH == mahh && x.NgayCapNhat == dauthang && x.MaKho == cbbKho.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            int soluongnhap = dA_QLYKHOEntities.CTPHIEUNHAPs.Where(x => x.MaHH == mahh && x.PHIEUNHAP.NgayNhap >= dauthang && x.PHIEUNHAP.NgayNhap < cuoithang && x.PHIEUNHAP.MaKho == cbbKho.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            int soluongxuat = dA_QLYKHOEntities.CTPHIEUXUATs.Where(x => x.MaHH == mahh && x.PHIEUXUAT.NgayXuat >= dauthang && x.PHIEUXUAT.NgayXuat < cuoithang && x.PHIEUXUAT.MaKho == cbbKho.SelectedValue.ToString()).Sum(x => x.SoLuong) ?? 0;
            txtSoLuongTon.Text = (soluongtontrenform + soluongtondauky + soluongnhap - soluongxuat).ToString();
        }

        private void cbbKho_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbKho.SelectedIndex >= 0 && btnLuuLai.Enabled == true)
            {
                if (dsHangHoa.Count > 0)
                {
                    // kiểm tra hàng tồn khi thay đổi kho
                    List<HangHoaXuat> listHangHoaDelete = new List<HangHoaXuat>();
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
                if (cbbKho.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn chưa chọn Kho!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbHangHoa.SelectedIndex = -1;
                    return;
                }
                var mahh = cbbHangHoa.SelectedValue.ToString();
                var giaxuat = dA_QLYKHOEntities.HANGHOAs.Where(x => x.MaHH == mahh).Select(x => x.GiaVon).FirstOrDefault();
                txtGiaXuat.Text = (giaxuat ?? 0).ToString();

                TinhSoLuongTon(mahh);
            }
            else
            {
                txtGiaXuat.ResetText();
            }
        }
    }

    public class HangHoaXuat
    {
        public string MaHH { get; set; }
        public string TenHangHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> GiaXuat { get; set; }
    }
}
