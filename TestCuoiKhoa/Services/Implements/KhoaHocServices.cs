using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.Converters;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;
using TestCuoiKhoa.Services.Interfaces;

namespace TestCuoiKhoa.Services.Implements
{
	public class KhoaHocServices : IKhoaHocServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<KhoaHoc_Response> _response;
		private readonly KhoaHocConverter _converter;

		public KhoaHocServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<KhoaHoc_Response>();
			_converter = new KhoaHocConverter();
		}
		public IList<KhoaHoc_Response> LayKhoaHoc(int pageSize,int pageNumber)
		{
			if (_context.KhoaHocs.Count() == 0)
				return null;
			var khoaHocs = _context.KhoaHocs.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			List<KhoaHoc_Response> lst = new List<KhoaHoc_Response>();
            foreach (var khoaHoc in khoaHocs)
            {
				lst.Add(_converter.KhoaHocEntityToDTO(khoaHoc));
            }
			return lst;
        }

		public ResponseObject<KhoaHoc_Response> SuaKhoaHoc(SuaKhoaHoc_Request request)
		{
			var khoaHoc = _context.KhoaHocs.FirstOrDefault(x => x.Id == request.Id);
			if (khoaHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy khóa học", null);
			khoaHoc.TenKhoaHoc = request.TenKhoaHoc;
			if (_context.KhoaHocs.Any(x => x.TenKhoaHoc == request.TenKhoaHoc))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên Khóa học đã tồn tại", null);
			khoaHoc.ThoiGianHoc = request.ThoiGianHoc;
			khoaHoc.GioiThieu = request.GioiThieu;
			khoaHoc.NoiDung = request.NoiDung;
			khoaHoc.HocPhi = request.HocPhi;
			khoaHoc.SoLuongMon = request.SoLuongMon;
			khoaHoc.SoHocVien = request.SoHocVien;
			khoaHoc.HinhAnh = request.HinhAnh;
			_context.KhoaHocs.Update(khoaHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Sửa khóa học thành công", _converter.KhoaHocEntityToDTO(khoaHoc));
		}

		public ResponseObject<KhoaHoc_Response> ThemKhoaHoc(ThemKhoaHoc_Request request)
		{
			if (_context.KhoaHocs.Any(x => x.TenKhoaHoc == request.TenKhoaHoc))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên Khóa học đã tồn tại", null);
			if (!_context.LoaiKhoaHocs.Any(x => x.Id == request.LoaiKhoaHocId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy loại khóa học", null);
			var khoaHoc = new KhoaHoc();
			khoaHoc.TenKhoaHoc = request.TenKhoaHoc;
			khoaHoc.ThoiGianHoc = request.ThoiGianHoc;
			khoaHoc.GioiThieu = request.GioiThieu;
			khoaHoc.NoiDung = request.NoiDung;
			khoaHoc.HocPhi = request.HocPhi;
			khoaHoc.SoHocVien = 0;
			khoaHoc.SoLuongMon = request.SoLuongMon;
			khoaHoc.HinhAnh = request.HinhAnh;
			khoaHoc.LoaiKhoaHocId = request.LoaiKhoaHocId;
			_context.KhoaHocs.Add(khoaHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm khóa học thành công", _converter.KhoaHocEntityToDTO(khoaHoc));
		}

		public IList<KhoaHoc_Response> TimTheoTen(string ten, int pageSize, int pageNumber)
		{
			var khoaHocs = _context.KhoaHocs.Where(x => x.TenKhoaHoc.Contains(ten)).ToList().Skip(pageSize * (pageNumber - 1)).Take(pageSize);
			if (khoaHocs is null)
				return null;
			List<KhoaHoc_Response> lst = new List<KhoaHoc_Response>();
			foreach (var khoaHoc in khoaHocs)
			{
				lst.Add(_converter.KhoaHocEntityToDTO(khoaHoc));
			}
			return lst;
		}

		public ResponseObject<KhoaHoc_Response> XoaKhoaHoc(int Id)
		{
			var khoaHoc = _context.KhoaHocs.FirstOrDefault(x => x.Id == Id);
			if(khoaHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy khóa học", null);
			_context.KhoaHocs.Remove(khoaHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm khóa học thành công", _converter.KhoaHocEntityToDTO(khoaHoc));
		}
	}
}
