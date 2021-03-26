using System;
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
    public partial class frmDoiMatKhau : Form
    {
        string id;

        public frmDoiMatKhau(string tentaikhoan)
        {
            InitializeComponent();
            id = tentaikhoan;
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi1.Text == txtMatKhauMoi2.Text)
            {
                DangNhap dANGNHAP = DataManager.Instance.ListDangNhap.FirstOrDefault(x => x.ID == id);
                dANGNHAP.Password = txtMatKhauMoi1.Text;
                if (DataManager.Instance.PutDangNhap(dANGNHAP))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show("Thay đổi mật khẩu không thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không giống nhau!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
