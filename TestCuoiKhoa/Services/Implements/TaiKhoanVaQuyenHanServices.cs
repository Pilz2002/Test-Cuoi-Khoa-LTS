using BCryptNet = BCrypt.Net.BCrypt;
using TestCuoiKhoa.Context;
using TestCuoiKhoa.Entities;
using TestCuoiKhoa.PayLoads.Converters;
using TestCuoiKhoa.PayLoads.DataRequests;
using TestCuoiKhoa.PayLoads.DataResponses;
using TestCuoiKhoa.PayLoads.Responses;
using TestCuoiKhoa.Services.Interfaces;
using TestCuoiKhoa.Handle;
using Azure.Core;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace TestCuoiKhoa.Services.Implements
{
	public class TaiKhoanVaQuyenHanServices : ITaiKhoanVaQuyenHan
	{
		private readonly AppDbContext _context;
		private readonly ResponseObject<TaiKhoan_Response> _taiKhoanResponse;
		private readonly ResponseObject<QuyenHan_Response> _quyenHanResponse;
		private readonly ResponseObject<Token_Response> _tokenResponse;
		private readonly QuyenHanConverter _quyenHanConverter;
		private readonly TaiKhoanConverter _taiKhoanConverter;
		private readonly IConfiguration _configuration;

		public TaiKhoanVaQuyenHanServices(IConfiguration configuration)
		{
			_configuration = configuration;
			_tokenResponse = new ResponseObject<Token_Response>();
			_context = new AppDbContext();
			_taiKhoanResponse = new ResponseObject<TaiKhoan_Response>();
			_quyenHanResponse = new ResponseObject<QuyenHan_Response>();
			_quyenHanConverter = new QuyenHanConverter();
			_taiKhoanConverter = new TaiKhoanConverter();
		}
		public ResponseObject<QuyenHan_Response> SuaQuyenHan(SuaQuyenHan_Request request)
		{
			var quyenHan = _context.QuyenHans.FirstOrDefault(x => x.Id == request.Id);
			if(quyenHan is null)
				return _quyenHanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy quyền hạn", null);
			quyenHan.TenQuyenHan = request.TenQuyenHan;
			if (_context.QuyenHans.Any(x => x.TenQuyenHan == quyenHan.TenQuyenHan))
				return _quyenHanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Tên quyền hạn đã tồn tại", null);
			_context.QuyenHans.Update(quyenHan);
			_context.SaveChanges();
			return _quyenHanResponse.SuccessResponse("Sửa quyền hạn thành công", _quyenHanConverter.QuyenHanEntityToDTO(quyenHan));

		}

		public ResponseObject<TaiKhoan_Response> SuaTaiKhoan(SuaTaiKhoan_Request request)
		{
			var taiKhoan = _context.TaiKhoans.FirstOrDefault(x => x.Id == request.Id);
			if (taiKhoan is null)
				return _taiKhoanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tài khoản", null);
			taiKhoan.TenNguoiDung = request.TenNguoiDung;
			if (!PasswordValidation.IsPasswordValid(request.MatKhau))
				return _taiKhoanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Mật khẩu cần có chữ và số", null);
			taiKhoan.MatKhau = BCryptNet.HashPassword(request.MatKhau);
			_context.TaiKhoans.Update(taiKhoan);
			_context.SaveChanges();
			return _taiKhoanResponse.SuccessResponse("Sửa tài khoản thành công", _taiKhoanConverter.TaiKhoanEntityToDTO(taiKhoan));
		}

		public ResponseObject<QuyenHan_Response> ThemQuyenHan(ThemQuyenHan_Request request)
		{
			var quyenHan = new QuyenHan();
			quyenHan.TenQuyenHan = request.TenQuyenHan;
			if (_context.QuyenHans.Any(x => x.TenQuyenHan == quyenHan.TenQuyenHan))
				return _quyenHanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Tên quyền hạn đã tồn tại", null);
			_context.QuyenHans.Add(quyenHan);
			_context.SaveChanges();
			return _quyenHanResponse.SuccessResponse("Thêm quyền hạn thành công", _quyenHanConverter.QuyenHanEntityToDTO(quyenHan));
		}

		public ResponseObject<TaiKhoan_Response> ThemTaiKhoan(ThemTaiKhoan_Request request)
		{
			var taiKhoan = new TaiKhoan();
			taiKhoan.TenNguoiDung = request.TenNguoiDung;
			taiKhoan.TenTaiKhoan = request.TenTaiKhoan;
			if (_context.TaiKhoans.Any(x => x.TenTaiKhoan == request.TenTaiKhoan))
				return _taiKhoanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Tên tài khoản đã tồn tại", null);
			if(!PasswordValidation.IsPasswordValid(request.MatKhau))
				return _taiKhoanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Mật khẩu cần có chữ và số", null);
			taiKhoan.MatKhau = BCryptNet.HashPassword(request.MatKhau);
			taiKhoan.QuyenHanId = 1;
			_context.TaiKhoans.Add(taiKhoan);
			_context.SaveChanges();
			return _taiKhoanResponse.SuccessResponse("Thêm tài khoản thành công", _taiKhoanConverter.TaiKhoanEntityToDTO(taiKhoan));
		}

		public IList<TaiKhoan_Response> TimTaiKhoan(string input)
		{
			var taiKhoans = _context.TaiKhoans.Where(x=>x.TenTaiKhoan.Contains(input));
			var lst = new List<TaiKhoan_Response>();
			foreach (var item in taiKhoans)
			{
				lst.Add(_taiKhoanConverter.TaiKhoanEntityToDTO(item));
			}
			return lst;
		}

		public IList<QuyenHan_Response> XemQuyenHan(int pageSize, int pageNumber)
		{
			var quyenHans = _context.QuyenHans.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			var lst = new List<QuyenHan_Response>();
			foreach (var item in quyenHans)
			{
				lst.Add(_quyenHanConverter.QuyenHanEntityToDTO(item));
			}
			return lst;
		}

		public IList<TaiKhoan_Response> XemTaiKhoan(int pageSize, int pageNumber)
		{
			var taiKhoans = _context.TaiKhoans.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
			var lst = new List<TaiKhoan_Response>();
			foreach (var item in taiKhoans)
			{
				lst.Add(_taiKhoanConverter.TaiKhoanEntityToDTO(item));
			}
			return lst;
		}

		public ResponseObject<QuyenHan_Response> XoaQuyenHan(int Id)
		{
			var quyenHan = _context.QuyenHans.FirstOrDefault(x => x.Id == Id);
			if (quyenHan is null)
				return _quyenHanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy quyền hạn", null);
			_context.QuyenHans.Remove(quyenHan);
			_context.SaveChanges();
			return _quyenHanResponse.SuccessResponse("Xóa quyền hạn thành công", _quyenHanConverter.QuyenHanEntityToDTO(quyenHan));
		}

		public ResponseObject<TaiKhoan_Response> XoaTaiKhoan(int Id)
		{
			var taiKhoan = _context.TaiKhoans.FirstOrDefault(x => x.Id == Id);
			if (taiKhoan is null)
				return _taiKhoanResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Không tìm thấy tài khoản", null);
			_context.TaiKhoans.Remove(taiKhoan);
			_context.SaveChanges();
			return _taiKhoanResponse.SuccessResponse("Xóa tài khoản thành công", _taiKhoanConverter.TaiKhoanEntityToDTO(taiKhoan));
		}


		private string GenerateRefreshToken()
		{
			var random = new byte[32];
			using (var item = RandomNumberGenerator.Create())
			{
				item.GetBytes(random);
				return Convert.ToBase64String(random);
			}
		}

		public Token_Response GenerateAccessToken(TaiKhoan taiKhoan)
		{
			var jwtTokenHandler = new JwtSecurityTokenHandler();
			var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);

			var role = _context.QuyenHans.FirstOrDefault(x => x.Id == taiKhoan.QuyenHanId);
			var tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new System.Security.Claims.ClaimsIdentity(new[]
				{
					new Claim("Id",taiKhoan.Id.ToString()),
					new Claim("Username", taiKhoan.TenTaiKhoan),
					new Claim(ClaimTypes.Role, role?.TenQuyenHan ?? "")
				}),
				Expires = DateTime.Now.AddHours(12),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = jwtTokenHandler.CreateToken(tokenDescription);
			var accessToken = jwtTokenHandler.WriteToken(token);
			var refreshToken = GenerateRefreshToken();

			RefreshToken rf = new RefreshToken
			{
				Token = refreshToken,
				ExpiredTime = DateTime.Now.AddDays(1),
				TaiKhoanId = taiKhoan.Id
			};

			_context.RefreshTokens.Add(rf);
			_context.SaveChanges();

			Token_Response result = new Token_Response
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			};
			return result;
		}

		public ResponseObject<Token_Response> Login(Login_Request request)
		{
			var user = _context.TaiKhoans.FirstOrDefault(x => x.TenTaiKhoan.Equals(request.UserName));
			if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
			{
				return _tokenResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Vui long dien day du thong tin", null);
			}
			bool checkPass = BCryptNet.Verify(request.Password, user.MatKhau);
			if (!checkPass)
			{
				return _tokenResponse.ErrorResponse(StatusCodes.Status400BadRequest, "Mat khau sai", null);
			}
			return _tokenResponse.SuccessResponse("Dang nhap thanh cong", GenerateAccessToken(user));
		}

	}
}
