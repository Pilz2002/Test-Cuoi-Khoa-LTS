using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestCuoiKhoa.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocVien_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhThanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuongXa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoNha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocVien_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiBaiViet_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBaiViet_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKhoaHoc_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKhoaHoc_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHan_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenHan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHan_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangHoc_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangHoc_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChuDe_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiBaiVietId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChuDe_tbl_LoaiBaiViet_tbl_LoaiBaiVietId",
                        column: x => x.LoaiBaiVietId,
                        principalTable: "LoaiBaiViet_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHoc_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianHoc = table.Column<DateOnly>(type: "date", nullable: false),
                    GioiThieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HocPhi = table.Column<double>(type: "float", nullable: false),
                    SoHocVien = table.Column<int>(type: "int", nullable: false),
                    SoLuongMon = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiKhoaHocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHoc_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoaHoc_tbl_LoaiKhoaHoc_tbl_LoaiKhoaHocId",
                        column: x => x.LoaiKhoaHocId,
                        principalTable: "LoaiKhoaHoc_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuyenHanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_tbl_QuyenHan_tbl_QuyenHanId",
                        column: x => x.QuyenHanId,
                        principalTable: "QuyenHan_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenTacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDungNgan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuDeId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaiViet_tbl_ChuDe_tbl_ChuDeId",
                        column: x => x.ChuDeId,
                        principalTable: "ChuDe_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaiViet_tbl_TaiKhoan_tbl_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangKyHoc_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoaHocId = table.Column<int>(type: "int", nullable: false),
                    HocVienId = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangHocId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyHoc_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_tbl_HocVien_tbl_HocVienId",
                        column: x => x.HocVienId,
                        principalTable: "HocVien_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_tbl_KhoaHoc_tbl_KhoaHocId",
                        column: x => x.KhoaHocId,
                        principalTable: "KhoaHoc_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_tbl_TaiKhoan_tbl_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyHoc_tbl_TinhTrangHoc_tbl_TinhTrangHocId",
                        column: x => x.TinhTrangHocId,
                        principalTable: "TinhTrangHoc_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaiKhoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_tbl_TaiKhoan_tbl_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_tbl_ChuDeId",
                table: "BaiViet_tbl",
                column: "ChuDeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_tbl_TaiKhoanId",
                table: "BaiViet_tbl",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChuDe_tbl_LoaiBaiVietId",
                table: "ChuDe_tbl",
                column: "LoaiBaiVietId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_tbl_HocVienId",
                table: "DangKyHoc_tbl",
                column: "HocVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_tbl_KhoaHocId",
                table: "DangKyHoc_tbl",
                column: "KhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_tbl_TaiKhoanId",
                table: "DangKyHoc_tbl",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyHoc_tbl_TinhTrangHocId",
                table: "DangKyHoc_tbl",
                column: "TinhTrangHocId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoaHoc_tbl_LoaiKhoaHocId",
                table: "KhoaHoc_tbl",
                column: "LoaiKhoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_tbl_TaiKhoanId",
                table: "RefreshToken_tbl",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_tbl_QuyenHanId",
                table: "TaiKhoan_tbl",
                column: "QuyenHanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet_tbl");

            migrationBuilder.DropTable(
                name: "DangKyHoc_tbl");

            migrationBuilder.DropTable(
                name: "RefreshToken_tbl");

            migrationBuilder.DropTable(
                name: "ChuDe_tbl");

            migrationBuilder.DropTable(
                name: "HocVien_tbl");

            migrationBuilder.DropTable(
                name: "KhoaHoc_tbl");

            migrationBuilder.DropTable(
                name: "TinhTrangHoc_tbl");

            migrationBuilder.DropTable(
                name: "TaiKhoan_tbl");

            migrationBuilder.DropTable(
                name: "LoaiBaiViet_tbl");

            migrationBuilder.DropTable(
                name: "LoaiKhoaHoc_tbl");

            migrationBuilder.DropTable(
                name: "QuyenHan_tbl");
        }
    }
}
