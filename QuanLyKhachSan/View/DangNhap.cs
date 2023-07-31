using QuanLyKhachSan.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.View
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            tbMatKhau.UseSystemPasswordChar = true;
        }

        public Boolean kiemTraDN(string taiKhoan, string matKhau)
        {
            TaoXML txml = new TaoXML();
            string sql = "SELECT maNV"
                        +" FROM NhanVien, ChucVu"
                        +" WHERE NhanVien.maCV = ChucVu.maCV AND ChucVu.maCV = 'CV00001'"
                        +" AND maNV = '"+ taiKhoan + "' AND matKhau = '"+ matKhau + "'";
            return txml.kiemTraDN(sql);
        }
        private void dangnhap()
        {
            string taikhoan = tbTaiKhoan.Text.Trim();
            string matkhau = tbMatKhau.Text.Trim();
            if (taikhoan.Equals("") || matkhau.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu!");
            }
            else
            {
                if (kiemTraDN(taikhoan, matkhau))
                {
                    ThongKe tk = new ThongKe();
                    tk.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai!");
                }
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void chbAnHien_CheckedChanged(object sender, EventArgs e)
        {
            if(chbAnHien.Checked == true)
            {
                tbMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                tbMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tbMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dangnhap();
            }
        }
    }
}
