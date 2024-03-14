using System.ComponentModel.DataAnnotations.Schema;

namespace TestCuoiKhoa.Entities
{
	[Table("TinhTrangHoc_tbl")]
	public class TinhTrangHoc: BaseEntity
	{
		public string TenTinhTrang { get; set; }
		public IEnumerable<DangKyHoc> DangKyHocs { get; set; }
	}
}
