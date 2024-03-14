using Azure.Core;
using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.Converters;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;
using TestCuoiKhoa.Services.Interfaces;

namespace TestCuoiKhoa.Services.Implements
{
	public class DangKyHocServices : IDangKyHocServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<DangKyHoc_Response> _response;
		private readonly DangKyHocConverter _converter;
		
		public DangKyHocServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<DangKyHoc_Response>();
			_converter = new DangKyHocConverter();
		}

		public ResponseObject<DangKyHoc_Response> DangKy(int taiKhoanDangKyId, ThemDangKyHoc_Request request)
		{
			var dangKyHoc = new DangKyHoc();
			dangKyHoc.KhoaHocId = request.KhoaHocId;
			if (!_context.KhoaHocs.Any(x => x.Id == dangKyHoc.KhoaHocId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Khóa học không tồn tại", null);
			dangKyHoc.NgayDangKy = DateTime.Now;
			dangKyHoc.TinhTrangHocId = 1;
			dangKyHoc.TaiKhoanId = taiKhoanDangKyId;
			dangKyHoc.HocVienId = 8;
			if (!_context.TaiKhoans.Any(x => x.Id == dangKyHoc.TaiKhoanId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tài khoản không tồn tại", null);
			if (_context.DangKyHocs.Any(x => x.TaiKhoanId == taiKhoanDangKyId && x.KhoaHocId == request.KhoaHocId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tài khoản này đã đăng ký môn học này", null);
			_context.DangKyHocs.Add(dangKyHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Đăng ký học thành công", _converter.DangKyHocEntityToDTO(dangKyHoc));
		}

		public IList<DangKyHoc_Response> HienThiDangKyHoc(int pageSize, int pageNumber)
		{
			var dangKyHocs = _context.DangKyHocs.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			var lst = new List<DangKyHoc_Response>();
			foreach (var item in dangKyHocs)
            {
				lst.Add(_converter.DangKyHocEntityToDTO(item));
            }
			return lst;
        }

		public ResponseObject<DangKyHoc_Response> SuaDangKyHoc(SuaDangKyHoc_Request request)
		{
			var dangKyHoc = _context.DangKyHocs.FirstOrDefault(x => x.Id == request.Id);
			if(dangKyHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Đăng ký học không tồn tại", null);
			dangKyHoc.TinhTrangHocId = request.TinhTrangHocId;
			switch (dangKyHoc.TinhTrangHocId)
			{
				case 2:
					dangKyHoc.NgayBatDau = DateTime.Now;
					dangKyHoc.HocVienId = request.HocVienId;
					dangKyHoc.TaiKhoanId = request.TaiKhoanId;
					var khoaHoc = _context.KhoaHocs.FirstOrDefault(x => x.Id == dangKyHoc.KhoaHocId);
					khoaHoc.SoHocVien += 1;
					_context.KhoaHocs.Update(khoaHoc);
					_context.SaveChanges();
					int thoiGianHoc = khoaHoc.ThoiGianHoc;
					dangKyHoc.NgayKetThuc = dangKyHoc.NgayBatDau.AddHours(thoiGianHoc);
					break;
				case 4:
					dangKyHoc.TinhTrangHocId = 4;
					break;
				default:
					break;
			}
			_context.DangKyHocs.Update(dangKyHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Cập nhật đăng ký học thành công!", _converter.DangKyHocEntityToDTO(dangKyHoc));
		}

		//public ResponseObject<DangKyHoc_Response> ThemDangKyHoc(ThemDangKyHoc_Request request)
		//{
		//	var dangKyHoc = new DangKyHoc();
		//	dangKyHoc.HocVienId = request.HocVienId;
		//	if (!_context.HocViens.Any(x => x.Id == dangKyHoc.HocVienId))
		//		return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Học viên không tồn tại", null);
		//	dangKyHoc.KhoaHocId = request.KhoaHocId;
		//	if (!_context.KhoaHocs.Any(x => x.Id == dangKyHoc.KhoaHocId))
		//		return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Khóa học không tồn tại", null);
		//	dangKyHoc.NgayDangKy = DateTime.Now;
		//	dangKyHoc.TinhTrangHocId = 1;
		//	dangKyHoc.TaiKhoanId = request.TaiKhoanId;
		//	if (!_context.TaiKhoans.Any(x => x.Id == dangKyHoc.TaiKhoanId))
		//		return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tài khoản không tồn tại", null);
		//	if (_context.DangKyHocs.Any(x=>x.HocVienId == request.HocVienId && x.KhoaHocId == request.KhoaHocId))
		//		return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Học viên này đã đăng ký môn học này", null);
		//	_context.DangKyHocs.Add(dangKyHoc);
		//	_context.SaveChanges();
		//	return _response.SuccessResponse("Đăng ký học thành công", _converter.DangKyHocEntityToDTO(dangKyHoc));
		//}

		public ResponseObject<DangKyHoc_Response> XoaDangKyHoc(int Id)
		{
			var dangKyHoc = _context.DangKyHocs.FirstOrDefault(x => x.Id == Id);
			if(dangKyHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Đăng ký học không tồn tại", null);
			_context.DangKyHocs.Remove(dangKyHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Xóa đăng ký học thành công", _converter.DangKyHocEntityToDTO(dangKyHoc));
		}

	}
}
