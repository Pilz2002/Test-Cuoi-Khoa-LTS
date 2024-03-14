using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("LoaiKhoaHoc_tbl")]
	public class LoaiKhoaHoc:BaseEntity
	{
		public string TenLoai { get; set; }
		public IEnumerable<KhoaHoc> KhoaHocs { get; set; }
	}
}
