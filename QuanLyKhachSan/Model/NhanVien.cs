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
    class NhanVien
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

        public Boolean KiemTraNV(string MaNV,string SDT, string CanCuoc)
        {
            TaoXML txml = new TaoXML();
            string sql = "SELECT * FROM NhanVien WHERE maNV ='" + MaNV + "' OR SDT='" + SDT + "' OR canCuoc='" + CanCuoc + "'";
            return txml.kiemTraDN(sql);
        }
        public void themNV(string maNV, string HoTen, string DiaChi, string SDT, string CanCuoc, string GioiTinh, string MatKhau, string HoatDong, string MucLuong, string MaCV)
        {
            string noiDung = "<NhanVien maNV=\"" + maNV + "\" hoTen=\"" + HoTen + "\" diaChi=\"" + DiaChi +
                "\" SDT=\"" + SDT + "\" canCuoc=\"" + CanCuoc + "\" gioiTinh=\"" + GioiTinh + "\" matKhau=\"" + MatKhau
                + "\" hoatDong=\"" + HoatDong + "\" mucLuong=\"" + MucLuong + "\" maCV=\"" + MaCV + "\"/>";

            string values = "('" + maNV + "', N'" + HoTen + "', N'" + DiaChi + "', '" + SDT + "', '" + CanCuoc +
                "', N'" + GioiTinh + "', '" + MatKhau + "', " + HoatDong + ", " + MucLuong + ", '" + MaCV + "')";
            Fxml.ThemSQL("NhanVien", values);
            Fxml.Them("NhanVien.xml", noiDung);
        }

        public void suaNV(string maNV, string HoTen, string DiaChi, string SDT, string CanCuoc, string GioiTinh, string MatKhau, string HoatDong, string MucLuong, string MaCV, string path)
        {
            XDocument doc = open(path);
            if (doc.Descendants("NhanVien").Where(x => x.Attribute("maNV").Value.Equals(maNV)).Count() == 1)
            {
                XElement ele = doc.Descendants("NhanVien").Where(x => x.Attribute("maNV").Value.Equals(maNV)).First();
                ele.SetAttributeValue("hoTen", HoTen);
                ele.SetAttributeValue("diaChi", DiaChi);
                ele.SetAttributeValue("SDT", SDT);
                ele.SetAttributeValue("canCuoc", CanCuoc);
                ele.SetAttributeValue("gioiTinh", GioiTinh);
                ele.SetAttributeValue("matKhau", MatKhau);
                ele.SetAttributeValue("hoatDong", HoatDong);
                ele.SetAttributeValue("mucLuong", MucLuong);
                ele.SetAttributeValue("maCV", MaCV);
            }

            string value = "hoTen=N'" + HoTen + "',diaChi=N'" + DiaChi + "',SDT='" + SDT + "',canCuoc='" +
                CanCuoc + "',gioiTinh=N'" + GioiTinh + "', matKhau = '" + MatKhau + "', hoatDong = " +
                HoatDong + ", mucLuong = " + MucLuong + ",maCV = '" + MaCV + "' WHERE maNV = '" + maNV + "'";
            Fxml.SuaSQL("NhanVien", value);
            doc.Save(path);
        }
        public bool xoaNV(string maNV, string path)
        {
            string value = "maNV = '" + maNV + "'";
            Fxml.XoaSQL("NhanVien", value);
            XDocument doc = open(path);
            var list = doc.Root.Nodes();
            foreach (XElement el in list)
            {
                if (maNV == el.Attribute("maNV").Value)
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
