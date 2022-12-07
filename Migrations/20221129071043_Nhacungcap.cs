using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Nhacungcap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhacungcap",
                columns: table => new
                {
                    Mancc = table.Column<string>(type: "TEXT", nullable: false),
                    Tenncc = table.Column<string>(type: "TEXT", nullable: false),
                    Diachincc = table.Column<string>(type: "TEXT", nullable: false),
                    Sdtncc = table.Column<string>(type: "TEXT", nullable: false),
                    Emailncc = table.Column<string>(type: "TEXT", nullable: false),
                    ngayncc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhacungcap", x => x.Mancc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhacungcap");
        }
    }
}
