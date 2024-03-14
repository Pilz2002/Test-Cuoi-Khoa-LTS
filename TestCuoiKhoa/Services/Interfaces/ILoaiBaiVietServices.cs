using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface ILoaiBaiVietServices
	{
		public ResponseObject<LoaiBaiViet_Response> ThemLoaiBaiViet(ThemLoaiBaiViet_Request request);
		public ResponseObject<LoaiBaiViet_Response> SuaLoaiBaiViet(SuaLoaiBaiViet_Request request);
		public ResponseObject<LoaiBaiViet_Response> XoaLoaiBaiViet(int Id);
		public IList<LoaiBaiViet_Response> XemLoaiBaiViet(int pageSize, int pageNumber);
	}
}
