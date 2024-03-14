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
	public class LoaiBaiVietServices : ILoaiBaiVietServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<LoaiBaiViet_Response> _response;
		private readonly LoaiBaiVietConverter _converter;

		public LoaiBaiVietServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<LoaiBaiViet_Response>();
			_converter = new LoaiBaiVietConverter();
		}
		public ResponseObject<LoaiBaiViet_Response> SuaLoaiBaiViet(SuaLoaiBaiViet_Request request)
		{
			var loaiBaiViet = _context.LoaiBaiViets.FirstOrDefault(x => x.Id == request.Id);
			if (loaiBaiViet is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Loại bài viết không tồn tại", null);
			if (_context.LoaiBaiViets.Any(x => x.TenLoai == request.TenLoai))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên loại bài viết đã tồn tại", null);
			loaiBaiViet.TenLoai = request.TenLoai;
			_context.LoaiBaiViets.Update(loaiBaiViet);
			_context.SaveChanges();
			return _response.SuccessResponse("Sửa loại bài viết thành công", _converter.LoaiBaiVietEntityToDTO(loaiBaiViet));
		}

		public ResponseObject<LoaiBaiViet_Response> ThemLoaiBaiViet(ThemLoaiBaiViet_Request request)
		{
			var loaiBaiViet = new LoaiBaiViet();
			if (_context.LoaiBaiViets.Any(x => x.TenLoai == request.TenLoai))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên loại bài viết đã tồn tại", null);
			loaiBaiViet.TenLoai = request.TenLoai;
			_context.LoaiBaiViets.Add(loaiBaiViet);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm loại bài viết thành công", _converter.LoaiBaiVietEntityToDTO(loaiBaiViet));
		}

		public IList<LoaiBaiViet_Response> XemLoaiBaiViet(int pageSize, int pageNumber)
		{
			var loaiBaiViets = _context.LoaiBaiViets.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			var lst = new List<LoaiBaiViet_Response>();
			foreach (var item in loaiBaiViets)
			{
				lst.Add(_converter.LoaiBaiVietEntityToDTO(item));
			}
			return lst;
		}

		public ResponseObject<LoaiBaiViet_Response> XoaLoaiBaiViet(int Id)
		{
			var loaiBaiViet = _context.LoaiBaiViets.FirstOrDefault(x => x.Id == Id);
			if (loaiBaiViet is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Loại bài viết không tồn tại", null);
			_context.LoaiBaiViets.Remove(loaiBaiViet);
			_context.SaveChanges();
			return _response.SuccessResponse("Xóa loại bài viết thành công", _converter.LoaiBaiVietEntityToDTO(loaiBaiViet));
		}
	}
}
