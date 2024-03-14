using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class ChuDeConverter
	{
		public ChuDe_Response ChuDeEntityToDTO(ChuDe chuDe)
		{
			return new ChuDe_Response
			{
				TenChuDe = chuDe.TenChuDe,
				NoiDung = chuDe.NoiDung
			};
		}
	}
}
