using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class HocVienConverter
	{
		public HocVien_Response HocVienEntityToDTO(HocVien hocVien)
		{
			return new HocVien_Response
			{
				HinhAnh = hocVien.HinhAnh,
				HoTen = hocVien.HoTen,
				NgaySinh = hocVien.NgaySinh,
				SoDienThoai = hocVien.SoDienThoai,
				Email = hocVien.Email,
				TinhThanh = hocVien.TinhThanh,
				QuanHuyen = hocVien.QuanHuyen,
				PhuongXa = hocVien.PhuongXa,
				SoNha = hocVien.SoNha
			};
		}
	}
}
