using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface IHocVienServices
	{
		public ResponseObject<HocVien_Response> ThemHocVien(ThemHocVien_Request request);
		public ResponseObject<HocVien_Response> SuaHocVien(SuaHocVien_Request request);
		public ResponseObject<HocVien_Response> XoaHocVien(int Id);
		public IList<HocVien_Response> TimKiemHocVien(TimKiemHocVien_Request request);

	}
}
