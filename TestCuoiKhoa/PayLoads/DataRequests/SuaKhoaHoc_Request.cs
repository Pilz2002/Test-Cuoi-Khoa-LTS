﻿namespace TestCuoiKhoa.PayLoads.DataRequests
{
	public class SuaKhoaHoc_Request
	{
		public int Id { get; set; }
		public string TenKhoaHoc { get; set; }
		public int ThoiGianHoc { get; set; }
		public string GioiThieu { get; set; }
		public string NoiDung { get; set; }
		public double HocPhi { get; set; }
		public int SoHocVien { get; set; }
		public int SoLuongMon { get; set; }
		public string HinhAnh { get; set; }
	}
}
