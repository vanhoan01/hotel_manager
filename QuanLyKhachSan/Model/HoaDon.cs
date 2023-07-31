using QuanLyKhachSan.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyKhachSan
{
    public class HoaDon
    {
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
        TaoXML Fxml = new TaoXML();

        public DataTable LayDuLieu(string bang)
        {
            SqlConnection con = new SqlConnection(Fxml.strCon);
            con.Open();
            string sql = "Select* from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("'" + bang + "'");
            ad.Fill(dt);
            return dt;
        }

        public bool kiemtra(string MaHD)
        {
            XmlTextReader reader = new XmlTextReader("HoaDon.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNode node = doc.SelectSingleNode("NewDataSet/_x0027_HoaDon_x0027_[maHD='" + MaHD + "']");
            reader.Close();
            bool kq = true;
            if (node != null)
            {
                return kq = true;
            }
            else
            {
                return kq = false;
            }
        }

        public void themHD(string maHD, string maPhong, string maNV, string ngayBatDau, string ngayThanhToan, string giaPhong, string tinhTrang)
        {
            string noiDung = "<_x0027_HoaDon_x0027_>" +
                    "<maHD>" + maHD + "</maHD>" +
                    "<maPhong>" + maPhong + "</maPhong>" +
                    "<maNV>" + maNV + "</maNV>" +
                    "<ngayBatDau>" + ngayBatDau + "</ngayBatDau>" +
                    "<ngayThanhToan>" + ngayThanhToan + "</ngayThanhToan>" +
                    "<giaPhong>" + giaPhong + "</giaPhong>" +
                    "<tinhTrang>" + tinhTrang + "</tinhTrang>" +
                    "</_x0027_HoaDon_x0027_>";
            Fxml.Them("HoaDon.xml", noiDung);
        }

        public void suaHD(string maHD, string maPhong, string maNV, string ngayBatDau, string ngayThanhToan, string giaPhong, string tinhTrang)
        {
            string noiDung = "<maHD>" + maHD + "</maHD>" +
                    "<maPhong>" + maPhong + "</maPhong>" +
                    "<maNV>" + maNV + "</maNV>" +
                    "<ngayBatDau>" + ngayBatDau + "</ngayBatDau>" +
                    "<ngayThanhToan>" + ngayThanhToan + "</ngayThanhToan>" +
                    "<giaPhong>" + giaPhong + "</giaPhong>" +
                    "<tinhTrang>" + tinhTrang + "</tinhTrang>";
            Fxml.Sua2("HoaDon.xml", "_x0027_HoaDon_x0027_", "maHD", maHD, noiDung);
        }
        public void xoaHD(string maHD)
        {
            Fxml.Xoa2("HoaDon.xml", "_x0027_HoaDon_x0027_", "maHD", maHD);
        }
    }
}
