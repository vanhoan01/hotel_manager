
namespace QuanLyKhachSan
{
    partial class frmHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDon));
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AllowUserToResizeColumns = false;
            this.dgvHoaDon.AllowUserToResizeRows = false;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 86);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(998, 414);
            this.dgvHoaDon.TabIndex = 2;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.Location = new System.Drawing.Point(175, 39);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(353, 26);
            this.txtTimKiem.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tìm kiếm hóa đơn:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(553, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(38, 38);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.Location = new System.Drawing.Point(614, 34);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(38, 38);
            this.btnReset.TabIndex = 16;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(848, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 40);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "In Hóa Đơn";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btDangXuat);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 32);
            this.panel1.TabIndex = 18;
            // 
            // btDangXuat
            // 
            this.btDangXuat.BackColor = System.Drawing.Color.IndianRed;
            this.btDangXuat.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btDangXuat.Location = new System.Drawing.Point(933, 3);
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
            this.pictureBox2.Location = new System.Drawing.Point(904, 3);
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
            this.hoaDonMenuItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.hoaDonMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hoaDonMenuItem.Name = "hoaDonMenuItem";
            this.hoaDonMenuItem.Size = new System.Drawing.Size(91, 27);
            this.hoaDonMenuItem.Text = "Hóa Đơn";
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
            this.taiKhoanMenuItem.Name = "taiKhoanMenuItem";
            this.taiKhoanMenuItem.Size = new System.Drawing.Size(96, 27);
            this.taiKhoanMenuItem.Text = "Tài Khoản";
            this.taiKhoanMenuItem.Click += new System.EventHandler(this.taiKhoanMenuItem_Click);
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 512);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "frmHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Hóa đơn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_FormClosing_1);
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel1;
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
    }
}