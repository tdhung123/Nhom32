using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Nhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    Manv = table.Column<string>(type: "TEXT", nullable: false),
                    Tennv = table.Column<string>(type: "TEXT", nullable: false),
                    Gioitinhnv = table.Column<string>(type: "TEXT", nullable: false),
                    ngaynv = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sdtnv = table.Column<string>(type: "TEXT", nullable: false),
                    Diachinv = table.Column<string>(type: "TEXT", nullable: false),
                    Emailnv = table.Column<string>(type: "TEXT", nullable: false),
                    Tencv = table.Column<string>(type: "TEXT", nullable: false),
                    ngaylamnv = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.Manv);
                    table.ForeignKey(
                        name: "FK_Nhanvien_Chucvucv_Tencv",
                        column: x => x.Tencv,
                        principalTable: "Chucvucv",
                        principalColumn: "Idcv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhanvien_Tencv",
                table: "Nhanvien",
                column: "Tencv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhanvien");
        }
    }
}
