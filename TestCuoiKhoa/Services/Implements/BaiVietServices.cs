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
	public class BaiVietServices : IBaiVietServices
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<BaiViet_Response> _response;
		private readonly BaiVietConverter _converter;

		public BaiVietServices()
		{
			_context = new AppDbContext();
			_response = new ResponseObject<BaiViet_Response>();
			_converter = new BaiVietConverter();
		}
		public ResponseObject<BaiViet_Response> SuaBaiViet(SuaBaiViet_Request request)
		{
			var baiViet = _context.BaiViets.FirstOrDefault(x => x.Id == request.Id);
			if (baiViet is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy bài viết", null);
			if (!_context.ChuDes.Any(x => x.Id == request.ChuDeId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy chủ đề", null);
			if (!_context.TaiKhoans.Any(x => x.Id == request.TaiKhoanId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tài khoản", null);
			baiViet.TaiKhoanId = request.TaiKhoanId;
			baiViet.ChuDeId = request.ChuDeId;
			baiViet.HinhAnh = request.HinhAnh;
			baiViet.NoiDungNgan = request.NoiDungNgan;
			baiViet.NoiDung = request.NoiDung;
			baiViet.TenTacGia = request.TenTacGia;
			baiViet.TenBaiViet = request.TenBaiViet;
			_context.BaiViets.Update(baiViet);
			_context.SaveChanges();
			return _response.SuccessResponse("Sửa bài viết thành công", _converter.BaiVietEntityToDTO(baiViet));
		}

		//public ResponseObject<BaiViet_Response> ThemBaiViet(ThemBaiViet_Request request)
		//{
		//	if (!_context.ChuDes.Any(x => x.Id == request.ChuDeId))
		//		return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy chủ đề", null);
		//	if (!_context.TaiKhoans.Any(x => x.Id == request.TaiKhoanId))
		//		return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tài khoản", null);
		//	var baiViet = new BaiViet();
		//	baiViet.TaiKhoanId = request.TaiKhoanId;
		//	baiViet.ChuDeId = request.ChuDeId;
		//	baiViet.HinhAnh = request.HinhAnh;
		//	baiViet.NoiDungNgan = request.NoiDungNgan;
		//	baiViet.NoiDung = request.NoiDung;
		//	baiViet.TenTacGia = request.TenTacGia;
		//	baiViet.TenBaiViet = request.TenBaiViet;
		//	baiViet.ThoiGianTao = DateTime.Now;
		//	_context.BaiViets.Add(baiViet);
		//	_context.SaveChanges();
		//	return _response.SuccessResponse("Thêm bài viết thành công", _converter.BaiVietEntityToDTO(baiViet));
		//}

		public ResponseObject<BaiViet_Response> ThemBaiViet(int taiKhoanId, ThemBaiViet_Request request)
		{
			if (!_context.ChuDes.Any(x => x.Id == request.ChuDeId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy chủ đề", null);
			if (!_context.TaiKhoans.Any(x => x.Id == taiKhoanId))
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tài khoản", null);
			var baiViet = new BaiViet();
			baiViet.TaiKhoanId = taiKhoanId;
			baiViet.ChuDeId = request.ChuDeId;
			baiViet.HinhAnh = request.HinhAnh;
			baiViet.NoiDungNgan = request.NoiDungNgan;
			baiViet.NoiDung = request.NoiDung;
			baiViet.TenTacGia = request.TenTacGia;
			baiViet.TenBaiViet = request.TenBaiViet;
			baiViet.ThoiGianTao = DateTime.Now;
			_context.BaiViets.Add(baiViet);
			_context.SaveChanges();
			return _response.SuccessResponse("Thêm bài viết thành công", _converter.BaiVietEntityToDTO(baiViet));
		}

		public IList<BaiViet_Response> TimBaiViet(string input, int pageSize, int pageNumber)
		{
			var baiViets = _context.BaiViets.Where(x=>x.TenBaiViet.Contains(input)).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			var lst = new List<BaiViet_Response>();
			foreach (var item in baiViets)
			{
				lst.Add(_converter.BaiVietEntityToDTO(item));
			}
			return lst;
		}

		public ResponseObject<BaiViet_Response> XoaBaiViet(int Id)
		{
			var baiViet = _context.BaiViets.FirstOrDefault(x => x.Id == Id);
			if (baiViet is null)
				return _response.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy bài viết", null);
			_context.BaiViets.Remove(baiViet);
			_context.SaveChanges();
			return _response.SuccessResponse("Xóa bài viết thành công", _converter.BaiVietEntityToDTO(baiViet));
		}
	}
}
