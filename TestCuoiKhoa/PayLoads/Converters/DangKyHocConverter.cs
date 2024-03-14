using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class DangKyHocConverter
	{
		private readonly AppDbContext _context;

		public DangKyHocConverter()
		{
			_context = new AppDbContext();
		}

		public DangKyHoc_Response DangKyHocEntityToDTO(DangKyHoc dangKyHoc)
		{
			var hocVien = _context.HocViens.FirstOrDefault(x => x.Id == dangKyHoc.HocVienId);
			var khoaHoc = _context.KhoaHocs.FirstOrDefault(x => x.Id == dangKyHoc.KhoaHocId);
			var tinhTrangHoc = _context.TinhTrangHocs.FirstOrDefault(x => x.Id == dangKyHoc.TinhTrangHocId);
			return new DangKyHoc_Response
			{
				TenKhoaHoc = khoaHoc.TenKhoaHoc,
				HoTenHocVien = hocVien.HoTen,
				SoDienThoai = hocVien.SoDienThoai,
				Email = hocVien.Email,
				TenTinhTrangHoc = tinhTrangHoc.TenTinhTrang,
				NgayDangKy = dangKyHoc.NgayDangKy,
				NgayBatDau = dangKyHoc.NgayBatDau,
				NgayKetThuc = dangKyHoc.NgayKetThuc
			};
		}
	}
}
