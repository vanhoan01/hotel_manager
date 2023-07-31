
namespace QuanLyKhachSan
{
    partial class frmTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.bindingButt = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btDangXuat = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thongKeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qlPhongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hoaDonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khachHangMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhanVienMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taiKhoanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.txtRole);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Location = new System.Drawing.Point(782, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 462);
            this.panel1.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.statusLabel.Location = new System.Drawing.Point(3, 439);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(84, 20);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Trạng Thái";
            // 
            // txtRole
            // 
            this.txtRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRole.FormattingEnabled = true;
            this.txtRole.Items.AddRange(new object[] {
            "BQT",
            "CCH",
            "NV"});
            this.txtRole.Location = new System.Drawing.Point(101, 154);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(125, 21);
            this.txtRole.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(2, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Quyền Hạn:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUsername.Location = new System.Drawing.Point(87, 60);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(139, 26);
            this.txtUsername.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(2, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tài Khoản:";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPass.Location = new System.Drawing.Point(87, 105);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(139, 26);
            this.txtPass.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(2, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mật khẩu:";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(188, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 38);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Location = new System.Drawing.Point(64, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(38, 38);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(125, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(38, 38);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreate.BackgroundImage")));
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreate.Location = new System.Drawing.Point(3, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(38, 38);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.AllowUserToResizeColumns = false;
            this.dgvTaiKhoan.AllowUserToResizeRows = false;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(12, 86);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(755, 414);
            this.dgvTaiKhoan.TabIndex = 2;
            this.dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellContentClick);
            // 
            // bindingButt
            // 
            this.bindingButt.AutoSize = true;
            this.bindingButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingButt.Location = new System.Drawing.Point(611, 44);
            this.bindingButt.Name = "bindingButt";
            this.bindingButt.Size = new System.Drawing.Size(156, 20);
            this.bindingButt.TabIndex = 7;
            this.bindingButt.Text = "Kết nối dữ liệu từ bảng";
            this.bindingButt.UseVisualStyleBackColor = true;
            this.bindingButt.CheckedChanged += new System.EventHandler(this.bingdingButt_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.btDangXuat);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 32);
            this.panel2.TabIndex = 8;
            // 
            // btDangXuat
            // 
            this.btDangXuat.BackColor = System.Drawing.Color.IndianRed;
            this.btDangXuat.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btDangXuat.Location = new System.Drawing.Point(935, 3);
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.Size = new System.Drawing.Size(80, 26);
            this.btDangXuat.TabIndex = 2;
            this.btDangXuat.Text = "Đăng xuất";
            this.btDangXuat.UseVisualStyleBackColor = false;
            this.btDangXuat.Click += new System.EventHandler(this.btDangXuat_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyKhachSan.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(906, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyKhachSan.Properties.Resources.hotel;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongKeMenuItem,
            this.qlPhongMenuItem,
            this.hoaDonMenuItem,
            this.khachHangMenuItem,
            this.nhanVienMenuItem,
            this.taiKhoanMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(32, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(583, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thongKeMenuItem
            // 
            this.thongKeMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.thongKeMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.thongKeMenuItem.Name = "thongKeMenuItem";
            this.thongKeMenuItem.Size = new System.Drawing.Size(95, 27);
            this.thongKeMenuItem.Text = "Thống Kê";
            this.thongKeMenuItem.Click += new System.EventHandler(this.thongKeMenuItem_Click);
            // 
            // qlPhongMenuItem
            // 
            this.qlPhongMenuItem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qlPhongMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.qlPhongMenuItem.Name = "qlPhongMenuItem";
            this.qlPhongMenuItem.Size = new System.Drawing.Size(72, 27);
            this.qlPhongMenuItem.Text = "Phòng";
            this.qlPhongMenuItem.Click += new System.EventHandler(this.qlPhongMenuItem_Click);
            // 
            // hoaDonMenuItem
            // 
            this.hoaDonMenuItem.Name = "hoaDonMenuItem";
            this.hoaDonMenuItem.Size = new System.Drawing.Size(91, 27);
            this.hoaDonMenuItem.Text = "Hóa Đơn";
            this.hoaDonMenuItem.Click += new System.EventHandler(this.hoaDonMenuItem_Click);
            // 
            // khachHangMenuItem
            // 
            this.khachHangMenuItem.Name = "khachHangMenuItem";
            this.khachHangMenuItem.Size = new System.Drawing.Size(116, 27);
            this.khachHangMenuItem.Text = "Khách Hàng";
            this.khachHangMenuItem.Click += new System.EventHandler(this.khachHangMenuItem_Click);
            // 
            // nhanVienMenuItem
            // 
            this.nhanVienMenuItem.Name = "nhanVienMenuItem";
            this.nhanVienMenuItem.Size = new System.Drawing.Size(103, 27);
            this.nhanVienMenuItem.Text = "Nhân Viên";
            this.nhanVienMenuItem.Click += new System.EventHandler(this.nhanVienMenuItem_Click);
            // 
            // taiKhoanMenuItem
            // 
            this.taiKhoanMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.taiKhoanMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.taiKhoanMenuItem.Name = "taiKhoanMenuItem";
            this.taiKhoanMenuItem.Size = new System.Drawing.Size(96, 27);
            this.taiKhoanMenuItem.Text = "Tài Khoản";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quản lý Tài khoản";
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.bindingButt);
            this.Controls.Add(this.panel1);
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_FormClosing);
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox bindingButt;
        private System.Windows.Forms.ComboBox txtRole;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btDangXuat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thongKeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qlPhongMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoaDonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khachHangMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhanVienMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taiKhoanMenuItem;
        private System.Windows.Forms.Label label1;
    }
}