using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("ChuDe_tbl")]
	public class ChuDe:BaseEntity
	{
		public string TenChuDe { get; set; }
		public string NoiDung { get; set; }
		public int LoaiBaiVietId { get; set; }
		public LoaiBaiViet LoaiBaiViet { get; set; }
		public IEnumerable<BaiViet> BaiViets { get; set; }
	}
}
