using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class LoaiBaiVietConverter
	{
		public LoaiBaiViet_Response LoaiBaiVietEntityToDTO(LoaiBaiViet loaiBaiViet)
		{
			return new LoaiBaiViet_Response
			{
				TenLoai = loaiBaiViet.TenLoai
			};
		}
	}
}
