using QuanLyKhachSan.Controller;
using QuanLyKhachSan.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhachSan
{
    public partial class frmNhanVien : Form
    {
        NhanVien nv = new NhanVien();
        TaoXML taoxml = new TaoXML();
        TaoXML hienthi = new TaoXML();
        string MaNV, TenNV, DiaChi, SDT, CanCuoc, GioiTinh, MatKhau, HoatDong, MucLuong, MaCV;
        string path = "NhanVien.xml";
        public XDocument doc;
        public int current = 0;
        public int maxRow = 0;
        public string gr = "All";
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void GetAllNhanVien(TaoXML taoxml, string path)
        {
            string sql = "select * from NhanVien for xml auto";
            taoxml.taoXML(sql, "NhanVien", path);
            DataTable dt = taoxml.loadDataGridView(path);
            string xml = "<?xml version='1.0'?> <?xml-stylesheet type='text/xsl' href='NhanVien.xsl'?> <QuanLyKhachSan>";
            xml += dt.Rows[0].ItemArray[0].ToString() + "</QuanLyKhachSan>";
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(xml);
            XmlDoc.Save(path);
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            GetAllNhanVien(taoxml,path);
            initGrid(gr);
            settext(0);
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dgvNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvNhanVien.Rows[d].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[d].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[d].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[d].Cells[3].Value.ToString();
            txtCanCuoc.Text = dgvNhanVien.Rows[d].Cells[4].Value.ToString();
            cbbGioiTinh.Text = dgvNhanVien.Rows[d].Cells[5].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[d].Cells[6].Value.ToString();
            txtHoatDong.Text = dgvNhanVien.Rows[d].Cells[7].Value.ToString();
            txtLuong.Text = dgvNhanVien.Rows[d].Cells[8].Value.ToString();
            txtMaCV.Text = dgvNhanVien.Rows[d].Cells[9].Value.ToString();
            if (cbbGioiTinh.Text == "Nam")
            {
                cbbGioiTinh.Items.Clear();
                cbbGioiTinh.Items.Add("Nữ");
            }
            if (cbbGioiTinh.Text == "Nữ")
            {
                cbbGioiTinh.Items.Clear();
                cbbGioiTinh.Items.Add("Nam");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            LoadData();
            if (nv.KiemTraNV(MaNV,SDT,CanCuoc) == true)
            {
                MessageBox.Show("Nhân viên đã tồn tại");
            }
            else
            {
                nv.themNV(MaNV, TenNV, DiaChi, SDT, CanCuoc, GioiTinh, MatKhau, HoatDong, MucLuong, MaCV);
                MessageBox.Show("Thêm thành công");
                initGrid(gr);
                settext(0);
                txtMaNV.Focus();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
            nv.suaNV(MaNV, TenNV, DiaChi, SDT, CanCuoc, GioiTinh, MatKhau, HoatDong, MucLuong, MaCV,path);
            MessageBox.Show("Sửa thành công");
            initGrid(gr);
            settext(0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewXML(path);
        }

        private void thongKeMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe frm = new ThongKe();
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

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LoadData();
            nv.xoaNV(MaNV,path);
            MessageBox.Show("Xóa thành công");
            initGrid(gr);
            settext(0);
        }
        public void initGrid(string gr)
        {
            this.dgvNhanVien.ColumnCount = 10;
            this.dgvNhanVien.Columns[0].Name = "Mã nhân viên";
            this.dgvNhanVien.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNhanVien.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNhanVien.Columns[0].Width = 120;

            this.dgvNhanVien.Columns[1].Name = "Họ tên";
            this.dgvNhanVien.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNhanVien.Columns[1].Width = 120;
                 
            this.dgvNhanVien.Columns[2].Name = "Địa chỉ";
            this.dgvNhanVien.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvNhanVien.Columns[2].Width = 180;
                 
            this.dgvNhanVien.Columns[3].Name = "Số điện thoại";
            this.dgvNhanVien.Columns[3].Width = 100;
            this.dgvNhanVien.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNhanVien.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                 
            this.dgvNhanVien.Columns[4].Name = "Căn cước";
            this.dgvNhanVien.Columns[4].Width = 100;
            this.dgvNhanVien.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                 
            this.dgvNhanVien.Columns[5].Name = "Giới tính";
            this.dgvNhanVien.Columns[5].Width = 80;
            this.dgvNhanVien.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvNhanVien.Columns[6].Name = "Mật khẩu";
            this.dgvNhanVien.Columns[6].Width = 80;
            this.dgvNhanVien.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvNhanVien.Columns[7].Name = "Hoạt động";
            this.dgvNhanVien.Columns[7].Width = 100;
            this.dgvNhanVien.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvNhanVien.Columns[8].Name = "Mức lương";
            this.dgvNhanVien.Columns[8].Width = 100;
            this.dgvNhanVien.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgvNhanVien.Columns[9].Name = "Mã chức vụ";
            this.dgvNhanVien.Columns[9].Width = 100;
            this.dgvNhanVien.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            NhanVien lb = new NhanVien();
            doc = lb.open(path);
            var list = doc.Descendants("NhanVien");
            string MaNV, name, address, sdt, cc, gt, mk, hd, ml,macv;
            this.dgvNhanVien.Rows.Clear();
            foreach (XElement node in list)
            {
                MaNV = node.Attribute("maNV").Value.ToString();
                if (gr == MaNV || gr == "All")
                {
                    name = node.Attribute("hoTen").Value;
                    address = node.Attribute("diaChi").Value;
                    sdt = node.Attribute("SDT").Value;
                    cc = node.Attribute("canCuoc").Value;
                    gt = node.Attribute("gioiTinh").Value;
                    mk = node.Attribute("matKhau").Value;
                    hd = node.Attribute("hoatDong").Value;
                    ml = node.Attribute("mucLuong").Value;
                    macv = node.Attribute("maCV").Value;
                    this.dgvNhanVien.Rows.Add(MaNV, name, address, sdt, cc, gt, mk, hd, ml, macv);
                }
            }
            maxRow = this.dgvNhanVien.RowCount - 1;
            initCombo();
        }
        public void LoadData()
        {
            MaNV = txtMaNV.Text;
            TenNV = txtTenNV.Text;
            DiaChi = txtDiaChi.Text;
            SDT = txtSDT.Text;
            CanCuoc = txtCanCuoc.Text;
            GioiTinh = cbbGioiTinh.Text;
            MatKhau = txtMatKhau.Text;
            HoatDong = txtHoatDong.Text;
            MucLuong = txtLuong.Text;
            MaCV = txtMaCV.Text;
        }
        public void settext(int cur)
        {
            this.txtMaNV.Text = this.dgvNhanVien.Rows[cur].Cells[0].Value.ToString();
            this.txtTenNV.Text = this.dgvNhanVien.Rows[cur].Cells[1].Value.ToString();
            this.txtDiaChi.Text = this.dgvNhanVien.Rows[cur].Cells[2].Value.ToString();
            this.txtSDT.Text = this.dgvNhanVien.Rows[cur].Cells[3].Value.ToString();
            this.txtCanCuoc.Text = this.dgvNhanVien.Rows[cur].Cells[4].Value.ToString();
            this.cbbGioiTinh.Text = this.dgvNhanVien.Rows[cur].Cells[5].Value.ToString();
            this.txtMatKhau.Text = this.dgvNhanVien.Rows[cur].Cells[6].Value.ToString();
            this.txtHoatDong.Text = this.dgvNhanVien.Rows[cur].Cells[7].Value.ToString();
            this.txtLuong.Text = this.dgvNhanVien.Rows[cur].Cells[8].Value.ToString();
            this.txtMaCV.Text = this.dgvNhanVien.Rows[cur].Cells[9].Value.ToString();
        }
        public void initCombo()
        {
            doc = XDocument.Load(path);
            var list = doc.Descendants("NhanVien");
            string tmp = "All";
            this.cbbLocNhanVien.Items.Clear();
            this.cbbLocNhanVien.Items.Add("All");
            string group;
            ArrayList myClass = new ArrayList();
            foreach (XElement node in list)
            {
                group = node.Attribute("maNV").Value.ToString();
                if (!tmp.Contains(group))
                {
                    tmp = tmp + "," + group;
                    myClass.Add(group);
                }
            }
            myClass.Sort();
            for (int i = 0; i < myClass.Count; i++)
            {
                this.cbbLocNhanVien.Items.Add(myClass[i]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("NhanVien.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "hoTen";
            reader.Close();
            int index = dv.Find(txtTimKiem.Text);
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                txtTimKiem.Text = "";
                txtTimKiem.Focus();
            }
            else
            {
                this.dgvNhanVien.Columns.Clear();
                this.dgvNhanVien.Rows.Clear();
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã nhân viên");
                dt.Columns.Add("Họ tên");
                dt.Columns.Add("Địa chỉ");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("Căn cước");
                dt.Columns.Add("Giới tính");
                dt.Columns.Add("Mật khẩu");
                dt.Columns.Add("Hoạt động");
                dt.Columns.Add("Mức lương");
                dt.Columns.Add("Mã chức vụ");
                object[] list = { dv[index]["maNV"], dv[index]["hoTen"], dv[index]["diaChi"], dv[index]["SDT"], dv[index]["canCuoc"], dv[index]["gioiTinh"], dv[index]["matKhau"], dv[index]["hoatDong"], dv[index]["mucLuong"], dv[index]["maCV"] };
                dt.Rows.Add(list);
                dgvNhanVien.DataSource = dt;
                settext(0);
                txtTimKiem.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbLocNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            gr = this.cbbLocNhanVien.Text;
            initGrid(gr);
            settext(0);
        }
        void ViewXML(string path)
        {
            var fullpath = Path.GetFullPath(path);
            Process.Start("Explorer.exe", fullpath);
        }
    }
}
