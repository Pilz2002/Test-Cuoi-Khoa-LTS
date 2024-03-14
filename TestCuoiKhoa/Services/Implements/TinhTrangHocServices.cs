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
	public class TinhTrangHocServices : ITinhTrangHocServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<TinhTrangHoc_Response> _response;
		private readonly TinhTrangHocConverter _converter;

		public TinhTrangHocServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<TinhTrangHoc_Response>();
			_converter = new TinhTrangHocConverter();
		}

		public IList<TinhTrangHoc_Response> HienThiTinhTrangHoc(int pageSize,int pageNumber)
		{
			if (_context.TinhTrangHocs.Count() == 0)
				return null;
			var tinhTrangHocs = _context.TinhTrangHocs.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			List<TinhTrangHoc_Response> lst = new List<TinhTrangHoc_Response>();
			foreach (var item in tinhTrangHocs)
			{
				lst.Add(_converter.TinhTrangHocEntityToDTO(item));
			}
			return lst;
		}

		public ResponseObject<TinhTrangHoc_Response> SuaTinhTrangHoc(SuaTinhTrangHoc_Request request)
		{
			var tinhTrangHoc = _context.TinhTrangHocs.FirstOrDefault(x => x.Id == request.Id);
			if (tinhTrangHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tình trạng học đã tồn tại", null);
			tinhTrangHoc.TenTinhTrang = request.TenTinhTrangHoc;
			if (_context.TinhTrangHocs.Any(x => x.TenTinhTrang == request.TenTinhTrangHoc))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên tình trạng học đã tồn tại", null);
			_context.TinhTrangHocs.Update(tinhTrangHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Sửa tình trạng học thành công", _converter.TinhTrangHocEntityToDTO(tinhTrangHoc));
		}

		public ResponseObject<TinhTrangHoc_Response> ThemTinhTrangHoc(ThemTinhTrangHoc_Request request)
		{
			if (_context.TinhTrangHocs.Any(x => x.TenTinhTrang == request.TenTinhTrangHoc))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên tình trạng học đã tồn tại", null);
			var tinhTrangHoc = new TinhTrangHoc();
			tinhTrangHoc.TenTinhTrang = request.TenTinhTrangHoc;
			_context.TinhTrangHocs.Add(tinhTrangHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm tình trạng học thành công", _converter.TinhTrangHocEntityToDTO(tinhTrangHoc));
		}

		public ResponseObject<TinhTrangHoc_Response> XoaTinhTrangHoc(int Id)
		{
			var tinhTrangHoc = _context.TinhTrangHocs.FirstOrDefault(x => x.Id == Id);
			if (tinhTrangHoc is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tình trạng học đã tồn tại", null);
			_context.TinhTrangHocs.Remove(tinhTrangHoc);
			_context.SaveChanges();
			return _response.SuccessResponse("Xóa tình trạng học thành công", _converter.TinhTrangHocEntityToDTO(tinhTrangHoc));
	}
	}
}
