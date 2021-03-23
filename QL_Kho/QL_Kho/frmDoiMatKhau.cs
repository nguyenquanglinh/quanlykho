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
    public partial class frmDoiMatKhau : Form
    {
        DA_QLYKHOEntities DA_QLYKHOEntities = new DA_QLYKHOEntities();
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
                DANGNHAP dANGNHAP = DA_QLYKHOEntities.DANGNHAPs.FirstOrDefault(x => x.ID == id);
                dANGNHAP.Password = txtMatKhauMoi1.Text;
                DA_QLYKHOEntities.SaveChanges();
                MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không giống nhau!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
