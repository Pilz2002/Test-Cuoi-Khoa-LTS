using Microsoft.EntityFrameworkCore;
using TestCuoiKhoa.Entities;

namespace TestCuoiKhoa.Context
{
	public class AppDbContext:DbContext
	{
		public virtual DbSet<BaiViet> BaiViets { get; set; }
		public virtual DbSet<ChuDe> ChuDes { get; set; }
		public virtual DbSet<DangKyHoc> DangKyHocs { get; set; }
		public virtual DbSet<HocVien> HocViens { get; set; }
		public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
		public virtual DbSet<LoaiBaiViet> LoaiBaiViets { get; set; }
		public virtual DbSet<LoaiKhoaHoc> LoaiKhoaHocs { get; set; }
		public virtual DbSet<QuyenHan> QuyenHans { get; set; }
		public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
		public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
		public virtual DbSet<TinhTrangHoc> TinhTrangHocs { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = QUYEN; Database = QuanLyTrungTam; Trusted_Connection = True; TrustServerCertificate=True");
		}
	}
}
