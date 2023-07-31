using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace QuanLyKhachSan.Controller
{
    class TaoXML
    {
        SqlConnection con;
        SqlCommand command;
        public string strCon = " Data Source = " + Environment.MachineName + "\\SQLExpress" + "; Initial Catalog = QuanLyKhachSan; Integrated Security = True";
        public void taoXML(string sql, string bang, string _FileXML)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable(bang);
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + _FileXML, XmlWriteMode.WriteSchema);
        }
        public void TaoXML3(string bang, string path)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string sql = "Select* from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("'" + bang + "'");
            ad.Fill(dt);
            dt.WriteXml(path, XmlWriteMode.WriteSchema);
        }
        public void TaoXML2(string bang)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string sql = "Select* from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("'" + bang + "'");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\" + bang + ".xml", XmlWriteMode.WriteSchema);
        }
        public DataTable loadDataGridView(string _FileXML)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + _FileXML;
            if (File.Exists(FilePath))
            {
                //tao luong xu ly file xml
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                //doc file xml vao datatable
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File không tồn tại");
            }
            return dt;
        }
        public DataTable getThongKe(string sql)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public Boolean kiemTraDN(string sql)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count == 1)
                return true;
            else
                return false;
        }
        public void Them(string FileXML, string xml)
        {
            try
            {
                XmlTextReader textread = new XmlTextReader(FileXML);
                XmlDocument doc = new XmlDocument();
                doc.Load(textread);
                textread.Close();
                XmlNode currNode;
                XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
                docFrag.InnerXml = xml;
                currNode = doc.DocumentElement;
                currNode.InsertAfter(docFrag, currNode.LastChild);
                doc.Save(FileXML);
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
        }
        public void xoa(string _FileXML, string xml)
        {
            try
            {
                string fileName = Application.StartupPath + _FileXML;
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode nodeCu = doc.SelectSingleNode(xml);
                doc.DocumentElement.RemoveChild(nodeCu);
                doc.Save(fileName);
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
        }
        public void Xoa2(string duongDan, string tenFileXML, string xoaTheoTruong, string giaTriTruong)
        {
            string fileName = Application.StartupPath + "\\" + duongDan;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode nodeCu = doc.SelectSingleNode("/NewDataSet/" + tenFileXML + "[" + xoaTheoTruong + "='" + giaTriTruong + "']");
            doc.DocumentElement.RemoveChild(nodeCu);
            doc.Save(fileName);
        }
        public void sua(string FileXML, string sql, string xml, string bang)
        {
            XmlTextReader reader = new XmlTextReader(FileXML);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldValue;
            XmlElement root = doc.DocumentElement;
            oldValue = root.SelectSingleNode(sql);
            XmlElement newValue = doc.CreateElement(bang);
            newValue.InnerXml = xml;
            root.ReplaceChild(newValue, oldValue);
            doc.Save(FileXML);
        }
        public void Sua2(string duongDan, string tenFile, string suaTheoTruong, string giaTriTruong, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldHang;
            XmlElement root = doc.DocumentElement;
            oldHang = root.SelectSingleNode("/NewDataSet/" + tenFile + "[" + suaTheoTruong + "='" + giaTriTruong + "']");
            XmlElement newhang = doc.CreateElement(tenFile);
            newhang.InnerXml = noiDung;
            root.ReplaceChild(newhang, oldHang);
            doc.Save(duongDan);
        }
        public void TimKiem(string _FileXML, string xml, DataGridView dgv)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Application.StartupPath + _FileXML);
            string xPath = xml;
            XmlNode node = xDoc.SelectSingleNode(xPath);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            XmlNodeReader nr = new XmlNodeReader(node);
            ds.ReadXml(nr);
            dgv.DataSource = ds.Tables[0];
            nr.Close();
        }
        public bool KiemTra(string _FileXML, string truongKiemTra, string giaTriKiemTra)
        {
            DataTable dt = new DataTable();
            dt = loadDataGridView(_FileXML);
            dt.DefaultView.RowFilter = truongKiemTra + " ='" + giaTriKiemTra + "'";
            if (dt.DefaultView.Count > 0)
                return true;
            return false;
        }
        public string maMoi(string tienTo, XDocument doc, string bang, string ma)
        {
            string txtMa = "";
            string maDuoi = tienTo + "00001";
            var list = doc.Descendants(bang);
            foreach (XElement node in list)
            {
                maDuoi = node.Attribute(ma).Value;
            }
            int duoi = int.Parse(maDuoi.Substring(2, 5)) + 1;
            string cuoi = "0000" + duoi;
            txtMa = tienTo + "" + cuoi.Substring(cuoi.Length - 5, 5);

            return txtMa;
        }
        public bool KTMa(string _FileXML, string cotMa, string ma)
        {
            bool kt = true;
            DataTable dt = new DataTable();
            dt = loadDataGridView(_FileXML);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][cotMa].ToString().Trim().Equals(ma))
                {
                    kt = false;
                }
                else
                {
                    kt = true;
                }
            }
            return kt;
        }
        public bool KTDangNhap(string taiKhoan, string matKhau)
        {
            bool kt = true;
            
            return kt;
        }
        public void exCuteNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
        }
        public void themDatabase(string sql)
        {
            try
            {
                exCuteNonQuery(sql);
            }
            catch
            {
                MessageBox.Show("lỗi thêm database");
            }
        }
        public void suaDatabase(string sql)
        {
            try
            {
                exCuteNonQuery(sql);
            }
            catch
            {
                MessageBox.Show("lỗi sửa database");
            }
        }
        public void xoaDatabase(string sql)
        {
            try
            {
                exCuteNonQuery(sql);
            }
            catch
            {
                MessageBox.Show("lỗi xóa database");
            }
        }
        public void ThemSQL(string bang, string noidung)
        {
            con = new SqlConnection(strCon);
            con.Open();
            command = con.CreateCommand();
            command.CommandText = "INSERT INTO " + bang + " VALUES" + noidung;
            command.ExecuteNonQuery();
        }

        public void SuaSQL(string bang, string noidung)
        {
            con = new SqlConnection(strCon);
            con.Open();
            command = con.CreateCommand();
            command.CommandText = "UPDATE " + bang + " SET " + noidung;
            command.ExecuteNonQuery();
        }

        public void XoaSQL(string bang, string noidung)
        {
            con = new SqlConnection(strCon);
            con.Open();
            command = con.CreateCommand();
            command.CommandText = "DELETE FROM " + bang + " WHERE " + noidung;
            command.ExecuteNonQuery();
        }
        public void TimKiemXSLT(string data, string tenFileXML, string tenfileXSLT)
        {
            System.Diagnostics.Process.Start(tenFileXML + ".xml");
        }
    }
}
