using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class TinhTrangHocConverter
	{
		public string TenTinhTrangHoc { get; set; }
		public TinhTrangHoc_Response TinhTrangHocEntityToDTO(TinhTrangHoc tinhTrangHoc)
		{
			return new TinhTrangHoc_Response
			{
				TenTinhTrangHoc = tinhTrangHoc.TenTinhTrang
			};
		}
	}
}
