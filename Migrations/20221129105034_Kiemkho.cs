using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Kiemkho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kiemkho",
                columns: table => new
                {
                    Idkk = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaykk = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Mahh = table.Column<string>(type: "TEXT", nullable: false),
                    Makho = table.Column<string>(type: "TEXT", nullable: false),
                    Sluongkk = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiemkho", x => x.Idkk);
                    table.ForeignKey(
                        name: "FK_Kiemkho_Hanghoa_Mahh",
                        column: x => x.Mahh,
                        principalTable: "Hanghoa",
                        principalColumn: "Mahh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kiemkho_Kho_Makho",
                        column: x => x.Makho,
                        principalTable: "Kho",
                        principalColumn: "Makho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kiemkho_Mahh",
                table: "Kiemkho",
                column: "Mahh");

            migrationBuilder.CreateIndex(
                name: "IX_Kiemkho_Makho",
                table: "Kiemkho",
                column: "Makho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kiemkho");
        }
    }
}
