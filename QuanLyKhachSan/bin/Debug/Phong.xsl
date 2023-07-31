<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <title>Danh Sách Phòng</title>
        <style>
            body{
                font-family: Arial;
            }
            table{
                width: 80%;
                border-collapse: collapse;
            }
            table th {
                background-color: #AFEEEE;
                border: 1px solid #ddd;
                padding: 10px;
                text-align: center;
            }
            table td {
                border: 1px solid #ddd;
                padding: 5px 10px;
            }
            h2{
              color: #00CED1	;
            }
        </style>
      </head>
      <body>
        <br />
        <br />
        <center>
          <h2>DANH SÁCH PHÒNG</h2>
        </center>
        <br />
        <br />
        <center>
        <table border="1" width="100%">
          <tr>
            <th>STT</th>
            <th>Mã Phòng</th>
            <th>Tên Phòng</th>
            <th>Mã Loại</th>
            <th>Tình Trạng</th>
            <th>Số Khách Tối Đa</th>
          </tr>

          <xsl:for-each select="//Phong">
              <tr>
                <td>
                  <xsl:value-of select="position()"/>
                </td>
                <td>
                  <xsl:value-of select="@maPhong"/>
                </td>
                <td>
                  <xsl:value-of select="@tenPhong"/>
                </td>
                <td>
                  <xsl:value-of select="@maLoai"/>
                </td>
		            <td>
                  <xsl:value-of select="@tinhTrang"/>
                </td>
                <td>
                  <xsl:value-of select="@soKhachToiDa"/>
                </td>
              </tr>
          </xsl:for-each>
        </table>
        </center>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>