using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface ILoaiKhoaHocServices
	{
		public ResponseObject<LoaiKhoaHoc_Response> ThemLoaiKhoaHoc(ThemLoaiKhoaHoc_Request request);
		public ResponseObject<LoaiKhoaHoc_Response> SuaLoaiKhoaHoc(SuaLoaiKhoaHoc_Request request);
		public ResponseObject<LoaiKhoaHoc_Response> XoaLoaiKhoaHoc(int loaiKhoaHocId);
	}
}
