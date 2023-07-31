using QuanLyKhachSan.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyKhachSan.Model
{
    class ThongKeClass
    {

        public ThongKeClass()
        {

        }
        public void getDataLK7Day(Chart chart)
        {
            string date;
            string ngay;
            DateTime aDateTime = DateTime.Now;
            TimeSpan aInterval = new System.TimeSpan(6, 0, 0, 0);
            aDateTime = aDateTime.Subtract(aInterval);
            for (int i = 1; i <= 7; i++)
            {
                date = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + aDateTime.Day.ToString();
                ngay = aDateTime.Day.ToString() + " / " + aDateTime.Month.ToString();
                getDataLuongKhachDay(date, ngay, chart);
                aInterval = new System.TimeSpan(1, 0, 0, 0);
                aDateTime = aDateTime.Add(aInterval);
            }
            
        }
        public void getDataLuongKhachDay(string date, string ngay, Chart chart)
        {
            TaoXML txml = new TaoXML();
            string sql = "SELECT COUNT(*) AS 'LuongKhach' "
                        + " FROM HoaDon, ChiTietHoaDon, KhachHang "
                        + " WHERE HoaDon.maHD = ChiTietHoaDon.maHD AND ChiTietHoaDon.maKH = KhachHang.maKH AND ngayThanhToan = '" + date + "'"
                        + " GROUP BY ngayThanhToan";
            DataTable dt = txml.getThongKe(sql);
            int sl = 0;
            foreach (DataRow row in dt.Rows)
            {
                sl = int.Parse(row["LuongKhach"].ToString());
                break;
            }
            chart.Series["Số lượng"].Points.AddXY(ngay, sl);
        }
        public void getDataDT7Day(Chart chart)
        {
            string date;
            string ngay;
            DateTime aDateTime = DateTime.Now;
            TimeSpan aInterval = new System.TimeSpan(6, 0, 0, 0);
            aDateTime = aDateTime.Subtract(aInterval);
            for (int i = 1; i <= 7; i++)
            {
                date = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + aDateTime.Day.ToString();
                ngay = aDateTime.Day.ToString() + " / " + aDateTime.Month.ToString();
                chart.Series["Doanh thu"].Points.AddXY(ngay, getDataDoanhThuDay(date));
                aInterval = new System.TimeSpan(1, 0, 0, 0);
                aDateTime = aDateTime.Add(aInterval);
            }

        }
        public int getDataDoanhThuDay(string date)
        {
            TaoXML txml = new TaoXML();
            string sql = "SELECT SUM(giaPhong*DATEDIFF(day ,ngayBatDau, ngayThanhToan)) AS 'DoanhThu'"
                        + " FROM HoaDon "
                        + " WHERE ngayThanhToan = '" + date + "'"
                        + " GROUP BY ngayThanhToan";
            DataTable dt = txml.getThongKe(sql);
            int idt = 0;
            string sdt = "";
            foreach (DataRow row in dt.Rows)
            {
                sdt = row["DoanhThu"].ToString();
                idt = int.Parse(sdt.Substring(0, sdt.Length - 5));
                break;
            }
            return idt;
            //chart.Titles.Add(sdt);
        }
        public int getDoanhThuHomNay()
        {
            string date;
            DateTime aDateTime = DateTime.Now;
            date = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + aDateTime.Day.ToString();
            return getDataDoanhThuDay(date);
        }
        public int getDoanhThuHomQua()
        {
            string date;
            DateTime aDateTime = DateTime.Now;
            TimeSpan aInterval = new System.TimeSpan(1, 0, 0, 0);
            aDateTime = aDateTime.Subtract(aInterval);
            date = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + aDateTime.Day.ToString();
            return getDataDoanhThuDay(date);
        }
        public int getDoanhThuThang()
        {
            string datebd;
            string datekt;
            DateTime aDateTime = DateTime.Now;
            datebd = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + "01";
            datekt = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + aDateTime.Day.ToString();
            TaoXML txml = new TaoXML();
            string sql = "SELECT SUM(giaPhong*DATEDIFF(day ,ngayBatDau, ngayThanhToan)) AS 'DoanhThu'"
                        + " FROM HoaDon "
                        + " WHERE ngayThanhToan BETWEEN '" + datebd + "' AND '" + datekt + "'";
            DataTable dt = txml.getThongKe(sql);
            int idt = 0;
            string sdt = "";
            foreach (DataRow row in dt.Rows)
            {
                sdt = row["DoanhThu"].ToString();
                idt = int.Parse(sdt.Substring(0, sdt.Length - 5));
                break;
            }
            return idt;
        }
        public int getKhachHangThang()
        {
            string datebd;
            string datekt;
            DateTime aDateTime = DateTime.Now;
            datebd = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + "01";
            datekt = aDateTime.Year.ToString() + "-" + aDateTime.Month.ToString() + "-" + aDateTime.Day.ToString();
            TaoXML txml = new TaoXML();
            string sql = "SELECT COUNT(*) AS 'LuongKhach' "
                        + " FROM HoaDon, ChiTietHoaDon, KhachHang "
                        + " WHERE HoaDon.maHD = ChiTietHoaDon.maHD AND ChiTietHoaDon.maKH = KhachHang.maKH AND ngayThanhToan BETWEEN '" + datebd + "' AND '" + datekt + "'";
            DataTable dt = txml.getThongKe(sql);
            int sl = 0;
            foreach (DataRow row in dt.Rows)
            {
                sl = int.Parse(row["LuongKhach"].ToString());
                break;
            }
            return sl;
        }
    }
}
