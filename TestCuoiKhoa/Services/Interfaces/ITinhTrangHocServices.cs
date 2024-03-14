using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface ITinhTrangHocServices
	{
		public ResponseObject<TinhTrangHoc_Response> ThemTinhTrangHoc(ThemTinhTrangHoc_Request request);
		public ResponseObject<TinhTrangHoc_Response> SuaTinhTrangHoc(SuaTinhTrangHoc_Request request);
		public ResponseObject<TinhTrangHoc_Response> XoaTinhTrangHoc(int Id);
		public IList<TinhTrangHoc_Response> HienThiTinhTrangHoc(int pageSize, int pageNumber);

	}
}
