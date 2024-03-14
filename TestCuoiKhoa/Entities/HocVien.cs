using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("HocVien_tbl")]
	public class HocVien : BaseEntity
	{
		public string HinhAnh { get; set; }
		public string HoTen { get; set; }
		public DateTime NgaySinh { get; set; }
		public string SoDienThoai { get; set; }
		public string Email { get; set; }
		public string TinhThanh { get; set; }
		public string QuanHuyen { get; set; }
		public string PhuongXa { get; set; }
		public string SoNha { get; set; }
		public IEnumerable<DangKyHoc> DangKyHocs { get; set; }
	}
}
