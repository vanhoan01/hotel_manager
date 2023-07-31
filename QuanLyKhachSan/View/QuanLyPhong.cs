using QuanLyKhachSan.Controller;
using QuanLyKhachSan.Model;
using QuanLyKhachSan.View;
using System;
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
    public partial class QuanLyPhong : Form
    {
        string sql = "";
        string path = "Phong.xml";
        public XDocument doc;
        public int maxRow = 0;
        private TaoXML txml;
        private Phong phong;
        private LoaiPhong loaiPhong;

        public QuanLyPhong()
        {
            InitializeComponent();
            txml = new TaoXML();
            phong = new Phong();
            loaiPhong = new LoaiPhong();
            btnLuu.Visible = false;
            phong.getAllPhong(txml, path);
            InitGrid(dgvPhong);
            setCBBLoaiPhong();
        }
        private void InitGrid(DataGridView dgv)
        {
            // Định dạng DataGridView
            if (dgv.Name == "dgvPhong")
            {
                dgv.ColumnCount = 6;
                dgv.Columns[0].Name = "STT";
                dgv.Columns[1].Name = "Mã Phòng";
                dgv.Columns[2].Name = "Tên Phòng";
                dgv.Columns[3].Name = "Mã Loại";
                dgv.Columns[4].Name = "Tình Trạng";
                dgv.Columns[5].Name = "Số Khách Tối Đa";
            }
            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 90;
            dgv.Columns[4].Width = 150;
            dgv.Columns[5].Width = 155;
            resetRow();
        }

        private void resetRow()
        {
            Phong phong = new Phong();
            doc = phong.open(path);
            var list = doc.Descendants("Phong");
            string maPhong, tenPhong, maLoai, tinhTrang = "";
            int soKhachToiDa = 1;
            dgvPhong.Rows.Clear();
            int stt = 1;
            foreach (XElement node in list)
            {
                maPhong = node.Attribute("maPhong").Value;
                tenPhong = node.Attribute("tenPhong").Value;
                maLoai = node.Attribute("maLoai").Value;
                tinhTrang = node.Attribute("tinhTrang").Value;
                soKhachToiDa = int.Parse(node.Attribute("soKhachToiDa").Value);
                dgvPhong.Rows.Add(stt, maPhong, tenPhong, maLoai, tinhTrang, soKhachToiDa);
                stt++;
            }
            maxRow = dgvPhong.RowCount - 1; // trừ dòng tiêu đề
        }
        private void locLoaiPhong(string maLoai)
        {
            Phong phong = new Phong();
            doc = phong.open(path);
            var list = doc.Descendants("Phong").Where(x => x.Attribute("maLoai").Value.Equals(maLoai));
            string maPhong, tenPhong, tinhTrang = "";
            int soKhachToiDa = 1;
            dgvPhong.Rows.Clear();
            int stt = 1;
            foreach (XElement node in list)
            {
                maPhong = node.Attribute("maPhong").Value;
                tenPhong = node.Attribute("tenPhong").Value;
                maLoai = node.Attribute("maLoai").Value;
                tinhTrang = node.Attribute("tinhTrang").Value;
                soKhachToiDa = int.Parse(node.Attribute("soKhachToiDa").Value);
                dgvPhong.Rows.Add(stt, maPhong, tenPhong, maLoai, tinhTrang, soKhachToiDa);
                stt++;
            }
            maxRow = dgvPhong.RowCount - 1; // trừ dòng tiêu đề
        }
        private void timKiem(string tukhoa)
        {
            Phong phong = new Phong();
            doc = phong.open(path);
            var list = doc.Descendants("Phong").Where(x => x.Attribute("tenPhong").Value.Contains(tukhoa));
            string maPhong, maLoai, tenPhong, tinhTrang = "";
            int soKhachToiDa = 1;
            dgvPhong.Rows.Clear();
            int stt = 1;
            foreach (XElement node in list)
            {
                maPhong = node.Attribute("maPhong").Value;
                tenPhong = node.Attribute("tenPhong").Value;
                maLoai = node.Attribute("maLoai").Value;
                tinhTrang = node.Attribute("tinhTrang").Value;
                soKhachToiDa = int.Parse(node.Attribute("soKhachToiDa").Value);
                dgvPhong.Rows.Add(stt, maPhong, tenPhong, maLoai, tinhTrang, soKhachToiDa);
                stt++;
            }
            maxRow = dgvPhong.RowCount - 1; // trừ dòng tiêu đề
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong();
            doc = phong.open(path);
            txml = new TaoXML();
            emptyTextBox();
            this.txtMaPhong.Text = txml.maMoi("PH", doc, "Phong", "maPhong");
            this.btnLuu.Visible = true;
            this.btnLuu.Text = "Thêm";
            this.btnLuu.BackColor = Color.Green;
            this.txtTenPhong.Focus();
        }
        private void setCBBLoaiPhong()
        {
            TaoXML txml2 = new TaoXML();
            loaiPhong.getAllLoaiPhong(txml2, "LoaiPhong.xml");
            DataTable dt = txml.loadDataGridView("LoaiPhong.xml");
            doc = loaiPhong.open("LoaiPhong.xml");
            var list = doc.Descendants("LoaiPhong");
            cbbLocLoaiPhong.Items.Add("Tất cả");
            foreach (XElement node in list)
            {
                cbbLoaiPhong.Items.Add(node.Attribute("maLoai").Value + " - " + node.Attribute("tenLoai").Value);
                cbbLocLoaiPhong.Items.Add(node.Attribute("maLoai").Value + " - " + node.Attribute("tenLoai").Value);
            }
            cbbLocLoaiPhong.SelectedIndex = 0;
            //cbbLoaiPhong.DataSource = dt;
            //cbbLoaiPhong.ValueMember = "maLoai";
            //cbbLoaiPhong.DisplayMember = "tenLoai";
        }
        private Phong getPhong()
        {
            Phong phong = new Phong(txtMaPhong.Text, txtTenPhong.Text, this.cbbLoaiPhong.SelectedItem.ToString().Substring(0, 7),
                int.Parse(txtSoKhachToiDa.Text), cbbTinhTrang.SelectedItem.ToString());
            return phong;
        }
        private void emptyTextBox()
        {
            this.txtMaPhong.Text = "";
            this.txtTenPhong.Text = "";
            this.cbbLoaiPhong.ResetText();
            this.cbbLoaiPhong.SelectedIndex = -1;
            this.txtSoKhachToiDa.Text = "";
            this.cbbTinhTrang.ResetText();
            this.cbbTinhTrang.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(btnLuu.Text == "Thêm")
            {
                if (txtTenPhong.Text != "" && txtSoKhachToiDa.Text != "" && cbbLoaiPhong.SelectedIndex != -1 && cbbTinhTrang.SelectedIndex != -1)
                {
                    this.btnLuu.Visible = false;
                    Phong ph = getPhong();
                    txml.Them(path, ph.insertXML());
                    //initGrid(gr);
                    txml.themDatabase(ph.insertDatabase());
                    emptyTextBox();
                    //phong.getAllPhong(txml, path);
                    resetRow();
                }
                else
                {
                    MessageBox.Show("Không để trống mọi fiels");
                    this.txtTenPhong.Focus();
                }
            }
            else
                if (btnLuu.Text == "Lưu")
                {
                    if (txtTenPhong.Text != "" && txtSoKhachToiDa.Text != "" && cbbLoaiPhong.SelectedIndex != -1 && cbbTinhTrang.SelectedIndex != -1)
                    {
                        this.btnLuu.Visible = false;
                        Phong ph = getPhong();
                        ph.updateXML(path);
                        txml.suaDatabase(ph.updateDatabase());
                        emptyTextBox();
                        //phong.getAllPhong(txml, path);
                        resetRow();
                    }
                    else
                    {
                        MessageBox.Show("Không để trống mọi fiels");
                        this.txtTenPhong.Focus();
                    }
                }
        }


        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvPhong.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txtMaPhong.Text = row.Cells[1].Value.ToString();
                txtTenPhong.Text = row.Cells[2].Value.ToString();
                cbbLoaiPhong.SelectedIndex = int.Parse(row.Cells[3].Value.ToString().Substring(2, 5)) - 1;
                txtSoKhachToiDa.Text = row.Cells[5].Value.ToString();
                cbbTinhTrang.SelectedItem = row.Cells[4].Value.ToString();
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            this.btnLuu.Visible = true;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.BackColor = Color.Yellow;
            this.txtTenPhong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa phòng "+txtTenPhong.Text+"?",
            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Phong ph = getPhong();
                if(ph.deleteXML(txtMaPhong.Text, path))
                    MessageBox.Show("Xóa thành công!");
                txml.xoaDatabase(ph.deleteDatabase());
                emptyTextBox();
                //phong.getAllPhong(txml, path);
                resetRow();
            }
        }

        private void cbbLocLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbLocLoaiPhong.SelectedItem.ToString().Equals("Tất cả"))
            {
                resetRow();
            }
            else
            {
                string maLoai = cbbLocLoaiPhong.SelectedItem.ToString().Substring(0, 7);
                locLoaiPhong(maLoai);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiem(nhapTuKhoa.Text);
        }

        private void nhapTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timKiem(nhapTuKhoa.Text);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txml = new TaoXML();
            doc = phong.open(path);
            var list = doc.Descendants("Phong");
            string data = "";
            foreach (XElement node in list)
            {
                data += "<Phong> ";
                data += "<maPhong>" + node.Attribute("maPhong").Value +"</maPhong> ";
                data += "<tenPhong>" + node.Attribute("tenPhong").Value + "</tenPhong> ";
                data += "<maLoai>" + node.Attribute("maLoai").Value + "</maLoai> ";
                data += "<tinhTrang>" + node.Attribute("tinhTrang").Value + "</tinhTrang> ";
                data += "<soKhachToiDa>" + node.Attribute("soKhachToiDa").Value + "</soKhachToiDa> ";
                data += "</Phong> ";
            }
            txml.TimKiemXSLT(data, "Phong", "Phong");
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
        private void QuanLyPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
