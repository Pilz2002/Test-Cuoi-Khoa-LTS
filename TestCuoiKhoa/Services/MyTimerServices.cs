using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;

namespace TestCuoiKhoa.Services
{
	public class MyTimerServices
	{
		private Timer _timer;
		private readonly AppDbContext _context;

		public MyTimerServices()
		{
			_context = new AppDbContext();
			_timer = new Timer(CheckThoiGianHoc, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));
		}


		private void CheckThoiGianHoc(object state)
		{
			var dangKyHocs = _context.DangKyHocs.Where(x=>x.TinhTrangHocId == 2).ToList();
			var currentTime = DateTime.Now;
            foreach (var item in dangKyHocs)
            {
				if (item.NgayKetThuc < currentTime)
				{
					item.TinhTrangHocId = 3;
					_context.DangKyHocs.Update(item);
					_context.SaveChanges();
				}
            }
        }

	}
}
