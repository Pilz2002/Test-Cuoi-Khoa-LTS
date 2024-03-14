using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.Converters;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;
using TestCuoiKhoa.Services.Interfaces;

namespace TestCuoiKhoa.Services.Implements
{
	public class LoaiKhoaHocServices : ILoaiKhoaHocServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<LoaiKhoaHoc_Response> _response;
		private readonly LoaiKhoaHocConverter _converter;

		public LoaiKhoaHocServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<LoaiKhoaHoc_Response>();
			_converter = new LoaiKhoaHocConverter();
		}

		public ResponseObject<LoaiKhoaHoc_Response> SuaLoaiKhoaHoc(SuaLoaiKhoaHoc_Request request)
		{
			var loaiKhoaHoc = _context.LoaiKhoaHocs.FirstOrDefault(x => x.Id == request.Id);
			if(loaiKhoaHoc == null)
			{
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm được loại khóa học", null);
			}
			loaiKhoaHoc.TenLoai = request.TenLoaiKhoaHoc;
			if (_context.LoaiKhoaHocs.Any(x => x.TenLoai == request.TenLoaiKhoaHoc))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên loại khóa học này đã tồn tại", null);
			_context.LoaiKhoaHocs.Update(loaiKhoaHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Sua thong tin loai khoa hoc thanh cong", _converter.LoaiKhoaHocEntityToDTO(loaiKhoaHoc));
		}

		public ResponseObject<LoaiKhoaHoc_Response> ThemLoaiKhoaHoc(ThemLoaiKhoaHoc_Request request)
		{
			if (_context.LoaiKhoaHocs.Any(x => x.TenLoai == request.TenLoaiKhoaHoc))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên loại khóa học này đã tồn tại", null);
			var loaiKhoaHocMoi = new LoaiKhoaHoc();
			loaiKhoaHocMoi.TenLoai = request.TenLoaiKhoaHoc;
			_context.LoaiKhoaHocs.Add(loaiKhoaHocMoi);
			_context.SaveChanges();
			return _response.SuccessResponse("Them loai khoa hoc thanh cong", _converter.LoaiKhoaHocEntityToDTO(loaiKhoaHocMoi));
		}

		public ResponseObject<LoaiKhoaHoc_Response> XoaLoaiKhoaHoc(int loaiKhoaHocId)
		{
			var loaiKhoaHoc = _context.LoaiKhoaHocs.FirstOrDefault(x => x.Id == loaiKhoaHocId);
			if (loaiKhoaHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy loại khóa học", null);
			_context.LoaiKhoaHocs.Remove(loaiKhoaHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Xoa loai khoa hoc thanh cong", _converter.LoaiKhoaHocEntityToDTO(loaiKhoaHoc));
		}
	}
}
