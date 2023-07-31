<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/QuanLyKhachSan">
		<html>
			<body>
				<br/>
				<br/>
				<center>
					<h1>DANH SÁCH KHÁCH HÀNG</h1>
				</center>
				<br/>
				<br/>
				<table border="1" width="100%">
					<tr>
						<th>Mã khách hàng</th>
						<th>Tên khách hàng</th>
						<th>Địa chỉ</th>
						<th>Số điện thoại</th>
						<th>Căn cước</th>
						<th>Giới tính</th>
					</tr>
					<xsl:for-each select="KhachHang">
						<tr>
							<td> <xsl:value-of select="./@maKH"/> </td>
							<td> <xsl:value-of select="./@hoTen"/> </td>
							<td> <xsl:value-of select="./@diaChi"/> </td>
							<td> <xsl:value-of select="./@SDT"/> </td>
							<td> <xsl:value-of select="./@canCuoc"/> </td>
							<td> <xsl:value-of select="./@gioiTinh"/> </td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>