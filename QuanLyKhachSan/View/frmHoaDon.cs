using QuanLyKhachSan.Controller;
using QuanLyKhachSan.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhachSan
{
    public partial class frmHoaDon : Form
    {

        TaoXML taoxml = new TaoXML();
        TaoXML hienthi = new TaoXML();
        DataTable dt;
        public string path = "./HoaDon.xml";
        public XDocument doc;
        public int current = 0;
        public int maxRow = 0;

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            //taoxml.TaoXML("HoaDon");
            initGrid();
        }

        public void initGrid()
        {
            dt.Rows.Clear();
            HoaDon lb = new HoaDon();
            dt = lb.LayDuLieu("HoaDon");
            //doc = lb.open(path);
            //string MaHD, MaPhong, MaNV, NgayBatDau, NgayThanhToan, GiaPhong, TinhTrang;
            //var list = doc.Descendants("_x0027_HoaDon_x0027_");
            //foreach (XElement node in list)
            //{
            //        MaHD = node.Element("maHD").Value;
            //        MaPhong = node.Element("maPhong").Value;
            //        MaNV = node.Element("maNV").Value;
            //        NgayBatDau = node.Element("ngayBatDau").Value;
            //        NgayThanhToan = node.Element("ngayThanhToan").Value;
            //        GiaPhong = node.Element("giaPhong").Value;
            //        TinhTrang = node.Element("tinhTrang").Value;
            //        dt.Rows.Add(MaHD, MaPhong, MaNV, NgayBatDau, NgayThanhToan, GiaPhong, TinhTrang);
            //}
            dgvHoaDon.DataSource = dt;
            foreach (DataGridViewColumn column in dgvHoaDon.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public frmHoaDon()
        {
            InitializeComponent();
            dt = new DataTable();
            FillDataTableColumn(dt);
        }

        private void FillDataTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã Hóa Đơn", typeof(object));
            dt.Columns.Add("Mã Phòng", typeof(object));
            dt.Columns.Add("Mã Nhân Viên", typeof(object));
            dt.Columns.Add("Ngày Bắt Đầu", typeof(object));
            dt.Columns.Add("Ngày Thanh Toán", typeof(object));
            dt.Columns.Add("Giá Phòng", typeof(object));
            dt.Columns.Add("Tình Trạng", typeof(object));
        } 

        private void frmKhachHang_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtTimKiem.Text.Trim();
            if (searchValue.Length > 0)
            {
                DataTable searchTable = new DataTable();
                FillDataTableColumn(searchTable);
                //HoaDon lb = new HoaDon();
                //doc = lb.open(path);
                //string MaHD, MaPhong, MaNV, NgayBatDau, NgayThanhToan, GiaPhong, TinhTrang;
                //var list = doc.Descendants("_x0027_HoaDon_x0027_");
                //foreach (XElement node in list)
                //{
                //    MaHD = node.Element("maHD").Value;
                //    MaPhong = node.Element("maPhong").Value;
                //    MaNV = node.Element("maNV").Value;
                //    NgayBatDau = node.Element("ngayBatDau").Value;
                //    NgayThanhToan = node.Element("ngayThanhToan").Value;
                //    GiaPhong = node.Element("giaPhong").Value;
                //    TinhTrang = node.Element("tinhTrang").Value;
                //    if (MaHD.Contains(searchValue)) searchTable.Rows.Add(MaHD, MaPhong, MaNV, NgayBatDau, NgayThanhToan, GiaPhong, TinhTrang);
                //}
                string MaHD, MaPhong, MaNV, NgayBatDau, NgayThanhToan, GiaPhong, TinhTrang;
                if (dt.Rows.Count > 0)
                {
                    foreach( DataRow row in dt.Rows)
                    {
                        MaHD = row[0] + "";
                        MaPhong = row[1] + "";
                        MaNV = row[2] + "";
                        NgayBatDau = row[3] + "";
                        NgayThanhToan = row[4] + "";
                        GiaPhong = row[5] + "";
                        TinhTrang = row[6] + "";
                        if (MaHD.Contains(searchValue)) searchTable.Rows.Add(MaHD, MaPhong, MaNV, NgayBatDau, NgayThanhToan, GiaPhong, TinhTrang);
                    }
                }
                dgvHoaDon.DataSource = searchTable;
                foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            } else
            {
                dgvHoaDon.DataSource = dt;
                foreach (DataGridViewColumn column in dgvHoaDon.Columns)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = dt;
            foreach (DataGridViewColumn column in dgvHoaDon.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            txtTimKiem.Text = "";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog()
            {
                CheckPathExists = true,
                DefaultExt = ".xml",
                Filter = "XML|.*xml",
                Title = "Lưu File",
                ValidateNames = true,
                AddExtension = true,
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                taoxml.TaoXML3("HoaDon", saveFile.FileName);
                MessageBox.Show("In Hóa Đơn Thành Công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thongKeMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe frm = new ThongKe();
            frm.Show();
            this.Hide();
        }

        private void qlPhongMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyPhong frm = new QuanLyPhong();
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
    }
}
