namespace TestCuoiKhoa.PayLoads.DataRequests
{
	public class SuaBaiViet_Request
	{
		public int Id { get; set; }
		public string TenBaiViet { get; set; }
		public DateTime ThoiGianTao { get; set; }
		public string TenTacGia { get; set; }
		public string NoiDung { get; set; }
		public string NoiDungNgan { get; set; }
		public string HinhAnh { get; set; }
		public int ChuDeId { get; set; }
		public int TaiKhoanId { get; set; }
	}
}
