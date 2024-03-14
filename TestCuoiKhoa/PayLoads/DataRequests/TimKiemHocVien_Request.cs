namespace TestCuoiKhoa.PayLoads.DataRequests
{
	public class TimKiemHocVien_Request
	{
		public string Email { get; set; }
		public string HoTen { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
