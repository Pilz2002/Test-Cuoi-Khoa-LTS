using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class KhoaHocConverter
	{
		public KhoaHoc_Response KhoaHocEntityToDTO(KhoaHoc khoaHoc)
		{
			return new KhoaHoc_Response
			{
				TenKhoaHoc = khoaHoc.TenKhoaHoc,
				ThoiGianHoc = khoaHoc.ThoiGianHoc,
				GioiThieu = khoaHoc.GioiThieu,
				NoiDung = khoaHoc.NoiDung,
				HocPhi = khoaHoc.HocPhi,
				SoHocVien = khoaHoc.SoHocVien,
				SoLuongMon = khoaHoc.SoLuongMon,
				HinhAnh = khoaHoc.HinhAnh
			};
		}
	}
}
