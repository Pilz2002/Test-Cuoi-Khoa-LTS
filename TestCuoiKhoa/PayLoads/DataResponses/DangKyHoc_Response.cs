using TestCuoiKhoa.Entities;

namespace TestCuoiKhoa.PayLoads.DataResponses
{
	public class DangKyHoc_Response
	{
		public string TenKhoaHoc { get; set; }
		public string? HoTenHocVien { get; set; }
		public string? SoDienThoai { get; set; }
		public string? Email { get; set; }
		public string TenTinhTrangHoc { get; set; }
		public DateTime? NgayDangKy { get; set; }
		public DateTime? NgayBatDau { get; set; }
		public DateTime? NgayKetThuc { get; set; }
	}
}
