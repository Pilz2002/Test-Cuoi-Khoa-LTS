using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("TaiKhoan_tbl")]
	public class TaiKhoan:BaseEntity
	{
		public string TenNguoiDung { get; set; }
		public string TenTaiKhoan { get; set; }
		public string MatKhau { get; set; }
		public int QuyenHanId { get; set; }
		public QuyenHan? QuyenHan { get; set; }
		public IEnumerable<DangKyHoc> DangKyHocs { get; set; }
		public IEnumerable<BaiViet> BaiViets { get; set; }
		public IEnumerable<RefreshToken> RefreshTokens { get; set; }
	}
}
