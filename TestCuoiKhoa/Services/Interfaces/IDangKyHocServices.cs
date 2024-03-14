using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface IDangKyHocServices
	{
		//public ResponseObject<DangKyHoc_Response> ThemDangKyHoc(ThemDangKyHoc_Request request);
		public ResponseObject<DangKyHoc_Response> SuaDangKyHoc(SuaDangKyHoc_Request request);
		public ResponseObject<DangKyHoc_Response> XoaDangKyHoc(int Id);
		public IList<DangKyHoc_Response> HienThiDangKyHoc(int pageSize,int pageNumber);
		ResponseObject<DangKyHoc_Response> DangKy(int taiKhoanDangKyId, ThemDangKyHoc_Request request);
	}
}
