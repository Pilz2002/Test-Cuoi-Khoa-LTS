using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface IChuDeServices
	{
		public ResponseObject<ChuDe_Response> ThemChuDe(ThemChuDe_Request request);
		public ResponseObject<ChuDe_Response> SuaChuDe(SuaChuDe_Request request);
		public ResponseObject<ChuDe_Response> XoaChuDe(int Id);
		public IList<ChuDe_Response> XemChuDe(int pageSize, int pageNumber);
	}
}
