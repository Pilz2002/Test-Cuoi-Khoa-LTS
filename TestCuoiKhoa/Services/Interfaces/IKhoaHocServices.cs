using System.ComponentModel;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface IKhoaHocServices
	{
		public ResponseObject<KhoaHoc_Response> ThemKhoaHoc(ThemKhoaHoc_Request request);
		public ResponseObject<KhoaHoc_Response> SuaKhoaHoc(SuaKhoaHoc_Request request);
		public ResponseObject<KhoaHoc_Response> XoaKhoaHoc(int Id);
		public IList<KhoaHoc_Response> LayKhoaHoc(int pageSize, int pageNumber);
		public IList<KhoaHoc_Response> TimTheoTen(string ten,int pageSize, int pageNumber);

	}
}
