using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
            setSoLieu();
            fillChartLuongKhach();
            fillChartDoanhThu();
        }

        private void fillChartLuongKhach()
        {
            ThongKeClass tk = new ThongKeClass();
            tk.getDataLK7Day(chartLuongKhach);
        }
        private void fillChartDoanhThu()
        {
            ThongKeClass tk = new ThongKeClass();
            tk.getDataDT7Day(chartDoanhThu);
        }
        private void setSoLieu()
        {
            ThongKeClass tk = new ThongKeClass();
            int hnay = tk.getDoanhThuHomNay();
            int hqua = tk.getDoanhThuHomQua();
            lbDoanhThuNgay.Text = hnay.ToString() + " VNĐ";
            if (hqua == 0)
                lbSoHomQua.Text = "0%";
            else
            {
                float tile = (float)(hnay * 100.0 / hqua);
                lbSoHomQua.Text = tile.ToString() + " %";
            }
            lbDoanhThuThang.Text = tk.getDoanhThuThang().ToString() + " VNĐ";
            lbKhachHang.Text = tk.getKhachHangThang().ToString();
        }

        private void qlPhongMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyPhong frm = new QuanLyPhong();
            frm.Show();
            this.Hide();
        }

        private void hoaDonMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.Show();
            this.Hide();
        }

        private void khachHangMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
            this.Hide();
        }

        private void nhanVienMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
            this.Hide();
        }

        private void taiKhoanMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan frm = new frmTaiKhoan();
            frm.Show();
            this.Hide();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap frm = new DangNhap();
            frm.Show();
            this.Hide();
        }

        private void ThongKe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
