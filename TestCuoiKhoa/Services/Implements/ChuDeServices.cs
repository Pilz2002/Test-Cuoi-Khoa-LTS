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
	public class ChuDeServices : IChuDeServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<ChuDe_Response> _response;
		private readonly ChuDeConverter _converter;

		public ChuDeServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<ChuDe_Response>();
			_converter = new ChuDeConverter();
		}
		public ResponseObject<ChuDe_Response> SuaChuDe(SuaChuDe_Request request)
		{
			var chuDe = _context.ChuDes.FirstOrDefault(x => x.Id == request.Id);
			if (chuDe is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Chủ đề không tồn tại", null);
			if (_context.ChuDes.Any(x => x.TenChuDe == request.TenChuDe))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên chủ đề đã tồn tại", null);
			chuDe.TenChuDe = request.TenChuDe;
			_context.ChuDes.Update(chuDe);
			_context.SaveChanges();
			return _response.SuccessResponse("Sửa chủ đề thành công", _converter.ChuDeEntityToDTO(chuDe));
		}

		public ResponseObject<ChuDe_Response> ThemChuDe(ThemChuDe_Request request)
		{
			if (!_context.LoaiBaiViets.Any(x => x.Id == request.LoaiBaiVietId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Loại bài viết không tồn tại", null);
			if (_context.ChuDes.Any(x => x.TenChuDe == request.TenChuDe))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Tên chủ đề đã tồn tại", null);
			var chuDe = new ChuDe();
			chuDe.TenChuDe = request.TenChuDe;
			chuDe.NoiDung = request.NoiDung;
			_context.ChuDes.Add(chuDe);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm chủ đề thành công", _converter.ChuDeEntityToDTO(chuDe));
		}

		public IList<ChuDe_Response> XemChuDe(int pageSize, int pageNumber)
		{
			var chuDes = _context.ChuDes.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			var lst = new List<ChuDe_Response>();
			foreach (var item in chuDes)
			{
				lst.Add(_converter.ChuDeEntityToDTO(item));
			}
			return lst;
		}

		public ResponseObject<ChuDe_Response> XoaChuDe(int Id)
		{
			var chuDe = _context.ChuDes.FirstOrDefault(x => x.Id == Id);
			if (chuDe is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Chủ đề không tồn tại", null);
			_context.ChuDes.Remove(chuDe);
			_context.SaveChanges();
			return _response.SuccessResponse("Xóa chủ đề thành công", _converter.ChuDeEntityToDTO(chuDe));
		}
	}
}
