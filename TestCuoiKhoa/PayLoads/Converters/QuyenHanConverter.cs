using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.DataResponses;

namespace TestCuoiKhoa.PayLoads.Converters
{
	public class QuyenHanConverter
	{
		public QuyenHan_Response QuyenHanEntityToDTO(QuyenHan quyenHan)
		{
			return new QuyenHan_Response
			{
				TenQuyenHan = quyenHan.TenQuyenHan
			};
		}
	}
}
