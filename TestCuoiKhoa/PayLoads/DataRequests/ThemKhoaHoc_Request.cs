using TestCuoiKhoa.Entities;

namespace TestCuoiKhoa.PayLoads.DataRequests
{
	public class ThemKhoaHoc_Request
	{
		public int LoaiKhoaHocId { get; set; }
		public string TenKhoaHoc { get; set; }
		public int ThoiGianHoc { get; set; }
		public string GioiThieu { get; set; }
		public string NoiDung { get; set; }
		public double HocPhi { get; set; }
		public int SoLuongMon { get; set; }
		public string HinhAnh { get; set; }
	}
}
