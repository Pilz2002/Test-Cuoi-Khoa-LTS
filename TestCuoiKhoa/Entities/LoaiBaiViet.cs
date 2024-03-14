using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("LoaiBaiViet_tbl")]
	public class LoaiBaiViet:BaseEntity
	{
		public string TenLoai { get; set; }
		public IEnumerable<ChuDe> ChuDes { get; set; }
	}
}
