using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("BaiViet_tbl")]
	public class BaiViet:BaseEntity
	{
		public string TenBaiViet { get; set; }
		public DateTime ThoiGianTao { get; set; }
		public string TenTacGia { get; set; }
		public string NoiDung { get; set; }
		public string NoiDungNgan { get; set; }
		public string HinhAnh { get; set; }
		public int ChuDeId { get; set; }
		public ChuDe ChuDe { get; set; }
		public int TaiKhoanId { get; set; }
		public TaiKhoan TaiKhoan { get; set; }

	}
}
