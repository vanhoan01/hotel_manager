using QuanLyKhachSan.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhachSan
{
    class KhachHang
    {
        TaoXML Fxml = new TaoXML();

        public XDocument open(string url)
        {
            try
            {
                return XDocument.Load(url);
            }
            catch
            {
                return null;
            }
        }
        public Boolean KiemTraKH(string MaKH, string SDT, string CanCuoc)
        {
            TaoXML txml = new TaoXML();
            string sql = "SELECT * FROM KhachHang WHERE maKH ='" + MaKH + "' OR SDT='" + SDT + "' OR canCuoc='" + CanCuoc + "'";
            return txml.kiemTraDN(sql);
        }
        public void themKH(string maKH, string TenKhachHang, string DiaChi, string SDT, string CanCuoc, string GioiTinh)
        {
            string noiDung = "<KhachHang maKH=\"" + maKH + "\" hoTen=\"" + TenKhachHang + "\" diaChi=\"" 
                + DiaChi + "\" SDT=\"" + SDT + "\" canCuoc=\"" + CanCuoc + "\" gioiTinh=\"" + GioiTinh + "\"/>";

            string values = "('" + maKH+"', N'" + TenKhachHang +"', N'"+ DiaChi+"', '" + SDT +"', '"+ CanCuoc+"', N'" + GioiTinh + "')";
            Fxml.ThemSQL("KhachHang", values);
            Fxml.Them("KhachHang.xml", noiDung);
        }

        public void SuaKH(string maKH, string hoten, string DiaChi, string SDT, string CanCuoc, string GioiTinh, string path)
        {
            XDocument doc = open(path);
            if (doc.Descendants("KhachHang").Where(x => x.Attribute("maKH").Value.Equals(maKH)).Count() == 1)
            {
                XElement ele = doc.Descendants("KhachHang").Where(x => x.Attribute("maKH").Value.Equals(maKH)).First();
                ele.SetAttributeValue("hoTen", hoten);
                ele.SetAttributeValue("diaChi", DiaChi);
                ele.SetAttributeValue("SDT", SDT);
                ele.SetAttributeValue("canCuoc", CanCuoc);
                ele.SetAttributeValue("gioiTinh", GioiTinh);
            }
            string value = "hoTen=N'" + hoten + "',diaChi=N'" + DiaChi + "',SDT='" + SDT + "',canCuoc='" + CanCuoc + "',gioiTinh=N'" + GioiTinh + "' WHERE maKH = '" + maKH + "'";
            Fxml.SuaSQL("KhachHang", value);
            doc.Save(path);
        }
        public bool XoaKH(string maKH, string path)
        {
            string value = "maKH = '" + maKH + "'";
            Fxml.XoaSQL("KhachHang", value);
            XDocument doc = open(path);
            var list = doc.Root.Nodes();
            foreach (XElement el in list)
            {
                if (maKH == el.Attribute("maKH").Value)
                {
                    el.Remove();
                    doc.Save(path);
                    return true;
                }
            }
            return false;
        }
    }
}
