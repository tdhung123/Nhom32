using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Xuathang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Xuathang",
                columns: table => new
                {
                    Idxh = table.Column<string>(type: "TEXT", nullable: false),
                    Manv = table.Column<string>(type: "TEXT", nullable: false),
                    Makh = table.Column<string>(type: "TEXT", nullable: false),
                    ngayxh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    trangtxh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xuathang", x => x.Idxh);
                    table.ForeignKey(
                        name: "FK_Xuathang_Khachhang_Makh",
                        column: x => x.Makh,
                        principalTable: "Khachhang",
                        principalColumn: "Makh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xuathang_Nhanvien_Manv",
                        column: x => x.Manv,
                        principalTable: "Nhanvien",
                        principalColumn: "Manv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Xuathang_Makh",
                table: "Xuathang",
                column: "Makh");

            migrationBuilder.CreateIndex(
                name: "IX_Xuathang_Manv",
                table: "Xuathang",
                column: "Manv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Xuathang");
        }
    }
}
