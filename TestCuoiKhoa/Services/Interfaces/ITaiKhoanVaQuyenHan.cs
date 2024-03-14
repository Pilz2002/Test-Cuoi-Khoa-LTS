using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;

namespace TestCuoiKhoa.Services.Interfaces
{
	public interface ITaiKhoanVaQuyenHan
	{
		public ResponseObject<TaiKhoan_Response> ThemTaiKhoan(ThemTaiKhoan_Request request);
		public ResponseObject<TaiKhoan_Response> SuaTaiKhoan(SuaTaiKhoan_Request request);
		public ResponseObject<TaiKhoan_Response> XoaTaiKhoan(int Id);
		public IList<TaiKhoan_Response> XemTaiKhoan(int pageSize,int pageNumber);
		public IList<TaiKhoan_Response> TimTaiKhoan(string input);

		public ResponseObject<QuyenHan_Response> ThemQuyenHan(ThemQuyenHan_Request request);
		public ResponseObject<QuyenHan_Response> SuaQuyenHan(SuaQuyenHan_Request request);
		public ResponseObject<QuyenHan_Response> XoaQuyenHan(int Id);
		public IList<QuyenHan_Response> XemQuyenHan(int pageSize, int pageNumber);

		public ResponseObject<Token_Response> Login(Login_Request request);

	}
}
