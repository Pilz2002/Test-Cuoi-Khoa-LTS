using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TestCuoiKhoa.Services;
using TestCuoiKhoa.Services.Implements;
using TestCuoiKhoa.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		ValidateAudience = false,
		ValidateIssuer = false,
		IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretKey").Value))
	};
});

builder.Services.AddScoped<ILoaiKhoaHocServices, LoaiKhoaHocServices>();
builder.Services.AddScoped<IKhoaHocServices, KhoaHocServices>();
builder.Services.AddScoped<IHocVienServices, HocVienServices>();
builder.Services.AddScoped<ITinhTrangHocServices, TinhTrangHocServices>();
builder.Services.AddScoped<IDangKyHocServices, DangKyHocServices>();
builder.Services.AddScoped<ITaiKhoanVaQuyenHan, TaiKhoanVaQuyenHanServices>();
builder.Services.AddScoped<ILoaiBaiVietServices, LoaiBaiVietServices>();
builder.Services.AddScoped<IChuDeServices, ChuDeServices>();
builder.Services.AddScoped<IBaiVietServices, BaiVietServices>();
builder.Services.AddSingleton<MyTimerServices>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
