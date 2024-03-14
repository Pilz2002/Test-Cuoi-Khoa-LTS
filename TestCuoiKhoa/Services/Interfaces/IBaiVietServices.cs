using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface IBaiVietServices
	{
		ResponseObject<BaiViet_Response> ThemBaiViet(int taiKhoanId, ThemBaiViet_Request request);
	//	public ResponseObject<BaiViet_Response> ThemBaiViet(ThemBaiViet_Request request);
		public ResponseObject<BaiViet_Response> SuaBaiViet(SuaBaiViet_Request request);
		public ResponseObject<BaiViet_Response> XoaBaiViet(int Id);
		public IList<BaiViet_Response> TimBaiViet(string input, int pageSize, int pageNumber);
	}
}
