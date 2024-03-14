using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class TaiKhoanConverter
	{
	private readonly AppDbContext _context;

		public TaiKhoanConverter()
		{
			_context = new AppDbContext();
		}

		public TaiKhoan_Response TaiKhoanEntityToDTO(TaiKhoan taiKhoan)
		{
			var quyenHan = _context.QuyenHans.FirstOrDefault(x => x.Id == taiKhoan.QuyenHanId);
			return new TaiKhoan_Response
			{
				TenNguoiDung = taiKhoan.TenNguoiDung,
				TenTaiKhoan = taiKhoan.TenTaiKhoan,
				MatKhau = taiKhoan.MatKhau,
				TenQuyenHan = quyenHan.TenQuyenHan
			};
		}
	}
}
