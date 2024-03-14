using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.Services;
using TestCuoiKhoa.Services.Interfaces;

namespace TestCuoiKhoa.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly ILoaiKhoaHocServices _loaiKhoaHocServices;
		private readonly IKhoaHocServices _khoaHocServices;
		private readonly IHocVienServices _hocVienServices;
		private readonly ITinhTrangHocServices _tinhTrangHocServices;
		private readonly IDangKyHocServices _dangKyHocServices;
		private readonly ITaiKhoanVaQuyenHan _taiKhoanVaQuyenHanServices;
		private readonly ILoaiBaiVietServices _loaiBaiVietServices;
		private readonly IChuDeServices _chuDeServices;
		private readonly IBaiVietServices _baiVietServices;
		private readonly MyTimerServices _myTimerServices;

		public ServicesController(ILoaiKhoaHocServices loaiKhoaHocServices, IKhoaHocServices khoaHocServices,
			IHocVienServices hocVienServices, ITinhTrangHocServices tinhTrangHocServices, IDangKyHocServices dangKyHocServices,
			ITaiKhoanVaQuyenHan taiKhoanVaQuyenHanServices, ILoaiBaiVietServices loaiBaiVietServices,
			IChuDeServices chuDeServices, IBaiVietServices baiVietServices)
		{
			_loaiKhoaHocServices = loaiKhoaHocServices;
			_khoaHocServices = khoaHocServices;
			_hocVienServices = hocVienServices;
			_tinhTrangHocServices = tinhTrangHocServices;
			_dangKyHocServices = dangKyHocServices;
			_taiKhoanVaQuyenHanServices = taiKhoanVaQuyenHanServices;
			_loaiBaiVietServices = loaiBaiVietServices;
			_chuDeServices = chuDeServices;
			_baiVietServices = baiVietServices;
			_myTimerServices = new MyTimerServices();
		}


		[HttpPost("/api/LoaiKhoaHocServices/ThemLoaiKhoaHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult ThemLoaiKhoaHoc([FromBody]ThemLoaiKhoaHoc_Request request)
		{
			return Ok(_loaiKhoaHocServices.ThemLoaiKhoaHoc(request));
		}

		[HttpPut("/api/LoaiKhoaHocServices/SuaLoaiKhoaHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult SuaLoaiKhoaHoc([FromBody] SuaLoaiKhoaHoc_Request request)
		{
			return Ok(_loaiKhoaHocServices.SuaLoaiKhoaHoc(request));
		}

		[HttpDelete("/api/LoaiKhoaHocServices/XoaLoaiKhoaHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult XoaLoaiKhoaHoc(int Id)
		{
			return Ok(_loaiKhoaHocServices.XoaLoaiKhoaHoc(Id));
		}

		[HttpPost("/api/KhoaHocServices/ThemKhoaHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult ThemKhoaHoc([FromBody] ThemKhoaHoc_Request request)
		{
			return Ok(_khoaHocServices.ThemKhoaHoc(request));
		}

		[HttpPut("/api/KhoaHocServices/SuaKhoaHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult SuaKhoaHoc([FromBody] SuaKhoaHoc_Request request)
		{
			return Ok(_khoaHocServices.SuaKhoaHoc(request));
		}

		[HttpDelete("/api/KhoaHocServices/XoaKhoaHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult XoaKhoaHoc(int Id)
		{
			return Ok(_khoaHocServices.XoaKhoaHoc(Id));
		}

		[HttpGet("/api/KhoaHocServices/LayKhoaHoc")]
		public IActionResult LayKhoaHoc(int pageSize, int pageNumber)
		{
			return Ok(_khoaHocServices.LayKhoaHoc(pageSize, pageNumber));
		}

		[HttpPost("/api/KhoaHocServices/TimTenKhoaHoc")]
		public IActionResult TimTenKhoaHoc(string ten, int pageSize, int pageNumber)
		{
			return Ok(_khoaHocServices.TimTheoTen(ten, pageSize, pageNumber));
		}

		[HttpPost("/api/HocVienServices/ThemHocVien")]
		[Authorize(Roles = "Mod")]
		public IActionResult ThemHocVien([FromBody] ThemHocVien_Request request)
		{
			return Ok(_hocVienServices.ThemHocVien(request));
		}

		[HttpPut("/api/HocVienServices/SuaHocVien")]
		public IActionResult SuaHocVien([FromBody] SuaHocVien_Request request)
		{
			return Ok(_hocVienServices.SuaHocVien(request));
		}

		[HttpDelete("/api/HocVienServices/XoaHocVien")]
		[Authorize(Roles = "Mod")]
		public IActionResult XoaHocVien(int Id)
		{
			return Ok(_hocVienServices.XoaHocVien(Id));
		}

		[HttpPost("/api/HocVienServices/TimKiemHocVien")]
		[Authorize(Roles = "Mod")]
		public IActionResult TimKiemHocVien([FromBody] TimKiemHocVien_Request request)
		{
			return Ok(_hocVienServices.TimKiemHocVien(request));
		}

		[HttpPost("/api/TinhTrangHocServices/ThemTinhTrangHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult ThemTinhTrangHoc([FromBody] ThemTinhTrangHoc_Request request)
		{
			return Ok(_tinhTrangHocServices.ThemTinhTrangHoc(request));
		}

		[HttpPut("/api/TinhTrangHocServices/SuaTinhTrangHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult SuaTinhTrangHoc([FromBody] SuaTinhTrangHoc_Request request)
		{
			return Ok(_tinhTrangHocServices.SuaTinhTrangHoc(request));
		}

		[HttpDelete("/api/TinhTrangHocServices/XoaTinhTrangHoc")]
		[Authorize(Roles = "Admin")]
		public IActionResult XoaTinhTrangHoc(int Id)
		{
			return Ok(_tinhTrangHocServices.XoaTinhTrangHoc(Id));
		}

		[HttpPost("/api/TinhTrangHocServices/HienThiTinhTrangHoc")]
		[Authorize(Roles = "Mod")]
		public IActionResult ThemTinhTrangHoc(int pageNumber, int pageSize)
		{
			return Ok(_tinhTrangHocServices.HienThiTinhTrangHoc(pageSize, pageNumber));
		}

		[HttpPost("/api/DangKyHocServices/ThemDangKyHoc")]
		[Authorize(Roles = "Mod")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult ThemDangKy([FromBody] ThemDangKyHoc_Request request)
		{
			int id = int.Parse(HttpContext.User.FindFirst("Id").Value);
			return Ok(_dangKyHocServices.DangKy(id, request));
		}

		[HttpPut("/api/DangKyHocServices/SuaDangKyHoc")]
		[Authorize(Roles = "Mod")]
		public IActionResult SuaDangKy([FromBody] SuaDangKyHoc_Request request)
		{
			return Ok(_dangKyHocServices.SuaDangKyHoc(request));
		}

		[HttpDelete("/api/DangKyHocServices/XoaDangKyHoc")]
		[Authorize(Roles = "Mod")]
		public IActionResult XoaDangKy(int Id)
		{
			return Ok(_dangKyHocServices.XoaDangKyHoc(Id));
		}

		[HttpPost("/api/DangKyHocServices/HienThiDangKyHoc")]
		public IActionResult HienThiDangKy(int pageSize, int pageNumber)
		{
			return Ok(_dangKyHocServices.HienThiDangKyHoc(pageSize, pageNumber));
		}

		[HttpPost("/api/TaiKhoanVaQuyenHan/DangKy")]
		public IActionResult ThemTaiKhoan([FromForm]ThemTaiKhoan_Request request)
		{
			return Ok(_taiKhoanVaQuyenHanServices.ThemTaiKhoan(request));
		}

		[HttpPost("/api/TaiKhoanVaQuyenHan/DangNhap")]
		public IActionResult DangNhap([FromForm]Login_Request request)
		{
			return Ok(_taiKhoanVaQuyenHanServices.Login(request));
		}

		[HttpPut("/api/TaiKhoanVaQuyenHan/SuaTaiKhoan")]
		public IActionResult SuaTaiKhoan([FromBody] SuaTaiKhoan_Request request)
		{
			return Ok(_taiKhoanVaQuyenHanServices.SuaTaiKhoan(request));
		}
		
		[HttpDelete("/api/TaiKhoanVaQuyenHan/XoaTaiKhoan")]
		[Authorize(Roles = "Admin")]
		public IActionResult XoaTaiKhoan(int Id)
		{
			return Ok(_taiKhoanVaQuyenHanServices.XoaTaiKhoan(Id));
		}
		
		[HttpPost("/api/TaiKhoanVaQuyenHan/XemTaiKhoan")]
		public IActionResult XemTaiKhoan(int pageSize, int pageNumber)
		{
			return Ok(_taiKhoanVaQuyenHanServices.XemTaiKhoan(pageSize, pageNumber));
		}
		
		[HttpPost("/api/TaiKhoanVaQuyenHan/TimTaiKhoan")]
		[Authorize(Roles = "Mod")]
		public IActionResult ThemTaiKhoan(string input)
		{
			return Ok(_taiKhoanVaQuyenHanServices.TimTaiKhoan(input));
		}

		[HttpPost("/api/TaiKhoanVaQuyenHan/ThemQuyenHan")]
		[Authorize(Roles = "Admin")]
		public IActionResult ThemQuyenHan([FromBody] ThemQuyenHan_Request request)
		{
			return Ok(_taiKhoanVaQuyenHanServices.ThemQuyenHan(request));
		}

		[HttpPut("/api/TaiKhoanVaQuyenHan/SuaQuyenHan")]
		[Authorize(Roles = "Admin")]
		public IActionResult SuaQuyenHan([FromBody] SuaQuyenHan_Request request)
		{
			return Ok(_taiKhoanVaQuyenHanServices.SuaQuyenHan(request));
		}

		[HttpDelete("/api/TaiKhoanVaQuyenHan/XoaQuyenHan")]
		[Authorize(Roles = "Admin")]
		public IActionResult XoaQuyenHan(int Id)
		{
			return Ok(_taiKhoanVaQuyenHanServices.XoaQuyenHan(Id));
		}

		[HttpPost("/api/TaiKhoanVaQuyenHan/XemQuyenHan")]
		[Authorize(Roles = "Admin")]
		public IActionResult XemQuyenHan(int pageSize,int pageNumber)
		{
			return Ok(_taiKhoanVaQuyenHanServices.XemQuyenHan(pageSize,pageNumber));
		}

		[HttpPost("/api/LoaiBaiViet/ThemLoaiBaiViet")]
		[Authorize(Roles = "Mod")]
		public IActionResult ThemLoaiBaiViet(ThemLoaiBaiViet_Request request)
		{
			return Ok(_loaiBaiVietServices.ThemLoaiBaiViet(request));
		}

		[HttpPut("/api/LoaiBaiViet/SuaLoaiBaiViet")]
		[Authorize(Roles = "Mod")]
		public IActionResult SuaLoaiBaiViet(SuaLoaiBaiViet_Request request)
		{
			return Ok(_loaiBaiVietServices.SuaLoaiBaiViet(request));
		}

		[HttpDelete("/api/LoaiBaiViet/XoaLoaiBaiViet")]
		[Authorize(Roles = "Mod")]
		public IActionResult XoaLoaiBaiViet(int Id)
		{
			return Ok(_loaiBaiVietServices.XoaLoaiBaiViet(Id));
		}

		[HttpPost("/api/LoaiBaiViet/XemLoaiBaiViet")]
		public IActionResult XemLoaiBaiViet(int pageSize,int pageNumber)
		{
			return Ok(_loaiBaiVietServices.XemLoaiBaiViet(pageSize,pageNumber));
		}

		[HttpPost("/api/ChuDe/ThemChuDe")]
		public IActionResult ThemChuDe(ThemChuDe_Request request)
		{
			return Ok(_chuDeServices.ThemChuDe(request));
		}

		[HttpPut("/api/ChuDe/SuaChuDe")]
		[Authorize(Roles = "Mod")]
		public IActionResult SuaChuDe(SuaChuDe_Request request)
		{
			return Ok(_chuDeServices.SuaChuDe(request));
		}

		[HttpDelete("/api/ChuDe/XoaChuDe")]
		[Authorize(Roles = "Mod")]
		public IActionResult XoaChuDe(int Id)
		{
			return Ok(_chuDeServices.XoaChuDe(Id));
		}

		[HttpPost("/api/ChuDe/XemChuDe")]
		public IActionResult XemChuDe(int pageSize, int pageNumber)
		{
			return Ok(_chuDeServices.XemChuDe(pageSize,pageNumber));
		}

		[HttpPost("/api/BaiViet/ThemBaiViet")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult ThemBaiViet(ThemBaiViet_Request request)
		{
			int taiKhoanId = int.Parse(HttpContext.User.FindFirst("Id").Value);
			return Ok(_baiVietServices.ThemBaiViet(taiKhoanId,request));
		}

		[HttpPut("/api/BaiViet/SuaBaiViet")]
		public IActionResult SuaBaiViet(SuaBaiViet_Request request)
		{
			return Ok(_baiVietServices.SuaBaiViet(request));
		}

		[HttpDelete("/api/BaiViet/XoaBaiViet")]
		public IActionResult XoaBaiViet(int Id)
		{
			return Ok(_baiVietServices.XoaBaiViet(Id));
		}

		[HttpPost("/api/BaiViet/TimBaiViet")]
		public IActionResult TimBaiViet(string input,int pageSize, int pageNumber)
		{
			return Ok(_baiVietServices.TimBaiViet(input,pageSize,pageNumber));
		}

	}
}
