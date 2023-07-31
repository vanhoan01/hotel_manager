using QuanLyKhachSan.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmTaiKhoan : Form
    {
        public class TaiKhoan
        {
            public TaiKhoan() { }
            public TaiKhoan(string username, string password, string role)
            {
                Username = username;
                Password = password;
                Role = role;
            }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }

        }

        
        DataTable dt;
        BindingSource bs;
        public static string path = "./TaiKhoan.xml";
        public readonly string tableName = "TaiKhoan";
        private List<TaiKhoan> list = new List<TaiKhoan>();
        public XDocument doc;
        bool isBiding = false;
        public frmTaiKhoan()
        {
            InitializeComponent();
            
            dt = new DataTable(tableName);
            bs = new BindingSource();
            dt.Columns.Add("TenTaiKhoan", typeof(object));
            dt.Columns.Add("MatKhau", typeof(object));
            dt.Columns.Add("QuyenHan", typeof(object));
            statusLabel.Text = "Trạng Thái: Thêm Tài Khoản";
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            if(!File.Exists(path)) TaoXmlFile(tableName);
            doc = XDocument.Load(path);
            var list = doc.Descendants("TaiKhoan");
            if (list.Count() > 0)
            {
                foreach (XElement node in list)
                {
                    TaiKhoan tk = new TaiKhoan()
                    {
                        Username = node.Element("TenTaiKhoan").Value,
                        Password = node.Element("MatKhau").Value,
                        Role = node.Element("QuyenHan").Value,
                    };
                    this.list.Add(tk);
                }
            }
            LoadGrid();
            txtRole.SelectedIndex = 2;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void TaoXmlFile(string bang)
        {
            dt.WriteXml(Application.StartupPath + "\\" + bang + ".xml", XmlWriteMode.WriteSchema);
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public bool CheckInput()
        {
            if(txtUsername.Text.Length <= 0)
            {
                MessageBox.Show("Nhập vào ô tài khoản!!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(txtPass.Text.Length <= 0)
            {
                MessageBox.Show("Nhập vào ô Mật Khẩu!!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(!CheckInput()) return;
            var username = txtUsername.Text.Trim();
            var password = txtPass.Text.Trim();
            var role = txtRole.Text;
            if(TimTaiKhoan(username) != null || username.ToLower().Equals("admin"))
            {
                MessageBox.Show("Tên Tài Khoản Đã Tồn Tại!!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            list.Add(new TaiKhoan(username, password, role));
            LoadGrid();
            TaoXmlFile(tableName);
            ResetData();

        }

        private TaiKhoan TimTaiKhoan(string username)
        {
            if(list.Count > 0)
            {
                foreach(var tk in list)
                {
                    if (tk.Username.ToLower().Equals(username.ToLower())) return tk;
                }
            }
            return null;
        }

        private bool SuaTaiKhoan(TaiKhoan tk)
        {
            TaiKhoan tkInList = TimTaiKhoan(tk.Username);
            if (tkInList != null)
            {
                int index = list.IndexOf(tkInList);
                list.RemoveAt(index);
                list.Insert(index, tk);
                return true;
            }
            else return false;
        }

        private bool XoaTaiKhoan(string username)
        {
            TaiKhoan tkInList = TimTaiKhoan(username);
            if (tkInList != null)
            {
                list.Remove(tkInList);
                return true;
            }
            else return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan()
            {
                Username = txtUsername.Text,
                Password = txtPass.Text,
                Role = txtRole.Text,
            };
            if(SuaTaiKhoan(tk))
            {
                MessageBox.Show("Sửa Thành Công", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                TaoXmlFile(tableName);
            } else MessageBox.Show("Không Tìm Thấy Tài Khoản!!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XoaTaiKhoan(txtUsername.Text))
            {
                MessageBox.Show("Xóa Thành Công", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                if (list.Count <= 0) dt.Rows.Clear();
                TaoXmlFile(tableName);
                LoadGrid();
            }
            else MessageBox.Show("Không Tìm Thấy Tài Khoản!!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void AddBinding()
        {
            if (!isBiding)
            {
                statusLabel.Text = "Trạng Thái: Xóa, Sửa Tài Khoản";
                txtUsername.Enabled = false;
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                txtUsername.DataBindings.Add("Text", bs.DataSource, "TenTaiKhoan", true, DataSourceUpdateMode.OnPropertyChanged);
                txtPass.DataBindings.Add("Text", bs.DataSource, "MatKhau", true, DataSourceUpdateMode.OnPropertyChanged);
                txtRole.DataBindings.Add("Text", bs.DataSource, "QuyenHan", true, DataSourceUpdateMode.OnPropertyChanged);
                isBiding = true;
            }
        }

        public void ClearBinding()
        {
            if(isBiding)
            {
                statusLabel.Text = "Trạng Thái: Thêm Tài Khoản";
                txtUsername.Enabled = true;
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                txtUsername.DataBindings.Clear();
                txtRole.DataBindings.Clear();
                txtPass.DataBindings.Clear();
                isBiding = false;
                ResetData();
            }
        }
        public void LoadGrid()
        {
            dt.Rows.Clear();
            if(list.Count > 0)
            {
                foreach(var tk in list)
                {
                    dt.Rows.Add(tk.Username, tk.Password, tk.Role);
                }
            }
            else
            {
                dt.Rows.Add("", "", "");
            }
            bs.DataSource = dt;
            dgvTaiKhoan.DataSource = bs.DataSource;
            foreach (DataGridViewColumn column in dgvTaiKhoan.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void LoadData()
        {

        }

        public void ResetData()
        {
            txtRole.SelectedIndex = 2;
            txtUsername.Text = "";
            txtPass.Text = "";
        }

        private void bingdingButt_CheckedChanged(object sender, EventArgs e)
        {
            if (bindingButt.Checked)
            {
                AddBinding();
            }
            else ClearBinding();
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

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            DangNhap frm = new DangNhap();
            frm.Show();
            this.Hide();
        }
    }
}
