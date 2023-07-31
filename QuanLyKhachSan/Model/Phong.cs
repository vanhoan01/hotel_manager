using QuanLyKhachSan.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhachSan.Model
{
    class Phong
    {
        private String maPhong;
        private String tenPhong;
        private String maLoai;
        private String tinhTrang;
        private int soKhachToiDa;

        public Phong()
        {

        }

        public Phong(String maPhong, String tenPhong, String maLoai, int soKhachToiDa, String tinhTrang)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.maLoai = maLoai;
            this.tinhTrang = tinhTrang;
            this.soKhachToiDa = soKhachToiDa;
        }

        public XDocument open(string url)
        {
            //Hầm load một file xml vào đối tượng XDocument
            try
            {
                return XDocument.Load(url);
            }
            catch
            {
                return null;
            }
        }

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int SoKhachToiDa { get => soKhachToiDa; set => soKhachToiDa = value; }

        public void getAllPhong(TaoXML txml, string path)
        {
            string sql = "Select * from Phong for xml auto";
            txml.taoXML(sql, "Phong", path);
            DataTable dt = txml.loadDataGridView(path);
            string xml = "<?xml version='1.0'?> <?xml-stylesheet type='text/xsl' href='Phong.xsl'?> <QuanLyKhachSan> ";
            xml += dt.Rows[0].ItemArray[0].ToString() + "</QuanLyKhachSan>";
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(xml); // nạp chuổi XML vào cây XML
            XmlDoc.Save(path);
        }
        public void insert(string path)
        {
            XDocument doc = open(path);
            doc.Descendants("QuanLyKhachSan").Elements("Phong").Last().AddAfterSelf(new XElement("Phong",
            new XAttribute("maPhong", maPhong),
            new XAttribute("tenPhong", tenPhong),
            new XAttribute("maLoai", maLoai),
            new XAttribute("tinhTrang", tinhTrang),
            new XAttribute("soKhachToiDa", soKhachToiDa)
            ));
            doc.Save(path);
        }
        public String insertDatabase()
        {
            string sql = "insert into Phong values('" + maPhong + "', N'" + tenPhong + "', '" + maLoai
                + "', N'"+ tinhTrang + "', " + soKhachToiDa + ")";
            return sql;
        }

        public String insertXML()
        {
            String xml = "<Phong maPhong='" + maPhong + "' tenPhong='" + tenPhong + "' maLoai='";
            xml += maLoai + "' tinhTrang='" + tinhTrang + "' soKhachToiDa='" + soKhachToiDa + "' />";
            return xml;
        }
        public String updateDatabase()
        {
            string sql = "UPDATE Phong "
                    + "SET tenPhong = N'" + tenPhong + "', maLoai = '" + maLoai + "', tinhTrang = N'" + tinhTrang + "', soKhachToiDa = " + soKhachToiDa
                    + "WHERE maPhong = '"+ maPhong + "'";
            return sql;
        }

        public void update(string FileXML)
        {
            string sql = "/QuanLyKhachSan/Phong[@maPhong='"+ maPhong+"']";
            String xml = "maPhong='" + maPhong + "' tenPhong='" + tenPhong + "' maLoai='";
            xml += maLoai + "' tinhTrang='" + tinhTrang + "' soKhachToiDa='" + soKhachToiDa;
            new TaoXML().sua(FileXML, sql, xml, "Phong");
        }
        
        public void updateXML(string path)
        {
            XDocument doc = open(path);
            if (doc.Descendants("Phong").Where(x => x.Attribute("maPhong").Value.Equals(maPhong)).Count() == 1)
            {
                //Nếu đã tồn tại sản phẩm có ID này rồi thì thực hiện cập nhật
                XElement ele = doc.Descendants("Phong").Where(x => x.Attribute("maPhong").Value.Equals(maPhong)).First();
                ele.SetAttributeValue("tenPhong", tenPhong);
                ele.SetAttributeValue("maLoai", maLoai);
                ele.SetAttributeValue("tinhTrang", tinhTrang);
                ele.SetAttributeValue("soKhachToiDa", soKhachToiDa);
            }
            doc.Save(path);
        }
        public XElement find(string scode, string path)
        {
            XDocument doc = open(path);

            var list = doc.Root.Nodes();

            foreach (XElement el in list)
            {
                if (scode == el.Attribute("code").Value)
                {
                    return el;

                }

            }
            return null;

        } // end of method
        public bool deleteXML(string scode, string path)
        {
            XDocument doc = open(path);
            var list = doc.Root.Nodes();
            foreach (XElement el in list)
            {
                if (scode == el.Attribute("maPhong").Value)
                {
                    // el.RemoveAll();
                    el.Remove();
                    doc.Save(path);
                    // el.Element("student").Remove(); sai
                    // el.Element("student").RemoveNodes();
                    return true;
                }

            }
            return false;
        } // end of method
        public String deleteDatabase()
        {
            string sql = "DELETE FROM Phong "
                    + "WHERE maPhong = '" + maPhong + "'";
            return sql;
        }
    }
}
