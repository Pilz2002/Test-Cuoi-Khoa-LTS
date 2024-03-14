using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class LoaiKhoaHocConverter
	{
		public LoaiKhoaHoc_Response LoaiKhoaHocEntityToDTO(LoaiKhoaHoc loaiKhoaHoc)
		{
			return new LoaiKhoaHoc_Response
			{
				TenLoaiKhoaHoc = loaiKhoaHoc.TenLoai,
			};
		}
	}
}
