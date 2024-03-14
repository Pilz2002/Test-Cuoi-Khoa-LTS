using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("RefreshToken_tbl")]
	public class RefreshToken:BaseEntity
	{
		public string Token { get; set; }
		public DateTime ExpiredTime { get; set; }
		public int TaiKhoanId { get; set; }
		public TaiKhoan TaiKhoan { get; set; }
	}
}
