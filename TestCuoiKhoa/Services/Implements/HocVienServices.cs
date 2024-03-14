using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.Converters;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;
using TestCuoiKhoa.Services.Interfaces;
using TestCuoiKhoa.Handle;
using Azure.Core;

namespace TestCuoiKhoa.Services.Implements
{
	public class HocVienServices : IHocVienServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<HocVien_Response> _response;
		private readonly HocVienConverter _converter;

		public HocVienServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<HocVien_Response>();
			_converter = new HocVienConverter();
		}

		public ResponseObject<HocVien_Response> SuaHocVien(SuaHocVien_Request request)
		{
			var hocVien = _context.HocViens.FirstOrDefault(x => x.Id == request.Id);
			if (hocVien is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Học viên không tồn tại", null);
			hocVien.Email = request.Email;
			if (!EmailValidation.IsValidEmail(request.Email))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Định dạng email không hợp lệ", null);
			hocVien.SoDienThoai = request.SoDienThoai;
			if (_context.HocViens.Any(x => x.Email.Equals(hocVien.Email) || x.SoDienThoai.Equals(hocVien.SoDienThoai)))
				_response.ErrorResponse(StatusCodes.Status400BadRequest, "Số điện thoại hoặc Email đã tồn tại", null);
			hocVien.HinhAnh = request.HinhAnh;
			hocVien.NgaySinh = request.NgaySinh;
			hocVien.TinhThanh = request.TinhThanh;
			hocVien.QuanHuyen = request.QuanHuyen;
			hocVien.PhuongXa = request.PhuongXa;
			hocVien.SoNha = request.SoNha;
			_context.HocViens.Update(hocVien);
			_context.SaveChanges();
			return _response.SuccessResponse("Sửa học viên thành công", _converter.HocVienEntityToDTO(hocVien));
		}

		public ResponseObject<HocVien_Response> ThemHocVien(ThemHocVien_Request request)
		{
			if (!EmailValidation.IsValidEmail(request.Email))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Định dạng email không hợp lệ", null);
			var hocVien = new HocVien();
			hocVien.Email = request.Email;
			hocVien.SoDienThoai = request.SoDienThoai;
			if (_context.HocViens.Any(x => x.Email.Equals(hocVien.Email) || x.SoDienThoai.Equals(hocVien.SoDienThoai)))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Số điện thoại hoặc Email đã tồn tại", null);
			hocVien.HinhAnh = request.HinhAnh;
			hocVien.HoTen = NameValidation.IsValidatedName(request.HoTen);
			hocVien.NgaySinh = request.NgaySinh;
			hocVien.TinhThanh = request.TinhThanh;
			hocVien.QuanHuyen = request.QuanHuyen;
			hocVien.PhuongXa = request.PhuongXa;
			hocVien.SoNha = request.SoNha;
			_context.HocViens.Add(hocVien);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm học viên thành công", _converter.HocVienEntityToDTO(hocVien));
		}

		public IList<HocVien_Response> TimKiemHocVien(TimKiemHocVien_Request request)
		{
			var hocViens = _context.HocViens.Where(x => x.HoTen.Contains(request.HoTen) && x.Email.Contains(request.Email)).ToList();
			if (hocViens is null)
				return null;
			return GetDSHocVien(hocViens, request.PageSize, request.PageNumber);
		}

		private IList<HocVien_Response> GetDSHocVien(List<HocVien> hocViens, int pageSize, int pageNumber)
		{
			var data = hocViens.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
			var res = new List<HocVien_Response>();
			foreach (var item in data)
			{
				res.Add(_converter.HocVienEntityToDTO(item));
			}
			return res;
		}

		public ResponseObject<HocVien_Response> XoaHocVien(int Id)
		{
			var hocVien = _context.HocViens.FirstOrDefault(x => x.Id == Id);
			if (hocVien is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Học viên không tồn tại", null);
			_context.HocViens.Remove(hocVien);
			_context.SaveChanges();
			var khoaHocs = _context.KhoaHocs.ToList();
			foreach(var khoaHoc in khoaHocs)
			{
				khoaHoc.SoHocVien = _context.DangKyHocs.Count(x => x.KhoaHocId == khoaHoc.Id);
				_context.KhoaHocs.Update(khoaHoc);
				_context.SaveChanges();
			}
			return _response.SuccessResponse("Xóa học viên thành công", _converter.HocVienEntityToDTO(hocVien));
		}
	}
}
