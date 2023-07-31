using QuanLyKhachSan.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhachSan.Model
{
    class LoaiPhong
    {
        private string maLoai;
        private string tenLoai;
        private long giaPhong;
        public LoaiPhong()
        {
            
        }
        public LoaiPhong(String maLoai, String tenLoai, long giaPhong)
        {
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
            this.giaPhong = giaPhong;
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
        public void getAllLoaiPhong(TaoXML txml, string path)
        {
            string sql = "Select * from LoaiPhong for xml auto";
            txml.taoXML(sql, "LoaiPhong", path);
            DataTable dt = txml.loadDataGridView(path);
            string xml = "<?xml version='1.0'?><QuanLyKhachSan>";
            xml += dt.Rows[0].ItemArray[0].ToString() + "</QuanLyKhachSan>";
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(xml); // nạp chuổi XML vào cây XML
            XmlDoc.Save(path);
        }
    }
}
