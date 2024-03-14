using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("QuyenHan_tbl")]
	public class QuyenHan:BaseEntity
	{
		public string TenQuyenHan { get; set; }
		public IEnumerable<TaiKhoan> TaiKhoans { get; set; }
	}
}
