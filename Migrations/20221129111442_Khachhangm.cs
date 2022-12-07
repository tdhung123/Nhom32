using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Khachhangm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khachhang",
                columns: table => new
                {
                    Makh = table.Column<string>(type: "TEXT", nullable: false),
                    Tenkh = table.Column<string>(type: "TEXT", nullable: false),
                    Diachikh = table.Column<string>(type: "TEXT", nullable: false),
                    Sdtkh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhang", x => x.Makh);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khachhang");
        }
    }
}
