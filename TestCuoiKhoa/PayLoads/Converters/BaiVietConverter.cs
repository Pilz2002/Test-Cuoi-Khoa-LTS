using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class BaiVietConverter
	{
		private readonly AppDbContext _context;
		public BaiVietConverter()
		{
			_context = new AppDbContext();
		}

		public BaiViet_Response BaiVietEntityToDTO(BaiViet baiViet)
		{
			var chuDe = _context.ChuDes.FirstOrDefault(x => x.Id == baiViet.ChuDeId);
			var taiKhoan = _context.TaiKhoans.FirstOrDefault(x => x.Id == baiViet.TaiKhoanId);
			return new BaiViet_Response 
			{
				TenChuDe = chuDe.TenChuDe,
				TenBaiViet = baiViet.TenBaiViet,
				TenTaiKhoan = taiKhoan.TenTaiKhoan,
				TenTacGia = baiViet.TenTacGia,
				ThoiGianTao = baiViet.ThoiGianTao,
				HinhAnh = baiViet.HinhAnh,
				NoiDung = baiViet.NoiDung,
				NoiDungNgan = baiViet.NoiDungNgan
			};
		}
	}
}
