using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Nhaphang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhaphang",
                columns: table => new
                {
                    Idnh = table.Column<string>(type: "TEXT", nullable: false),
                    Mahh = table.Column<string>(type: "TEXT", nullable: false),
                    Mancc = table.Column<string>(type: "TEXT", nullable: false),
                    Makho = table.Column<string>(type: "TEXT", nullable: false),
                    Soluongnh = table.Column<string>(type: "TEXT", nullable: false),
                    ngaynh = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhaphang", x => x.Idnh);
                    table.ForeignKey(
                        name: "FK_Nhaphang_Hanghoa_Mahh",
                        column: x => x.Mahh,
                        principalTable: "Hanghoa",
                        principalColumn: "Mahh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhaphang_Kho_Makho",
                        column: x => x.Makho,
                        principalTable: "Kho",
                        principalColumn: "Makho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhaphang_Nhacungcap_Mancc",
                        column: x => x.Mancc,
                        principalTable: "Nhacungcap",
                        principalColumn: "Mancc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nhaphang_Mahh",
                table: "Nhaphang",
                column: "Mahh");

            migrationBuilder.CreateIndex(
                name: "IX_Nhaphang_Makho",
                table: "Nhaphang",
                column: "Makho");

            migrationBuilder.CreateIndex(
                name: "IX_Nhaphang_Mancc",
                table: "Nhaphang",
                column: "Mancc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhaphang");
        }
    }
}
