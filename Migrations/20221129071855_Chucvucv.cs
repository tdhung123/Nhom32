using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Chucvucv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chucvucv",
                columns: table => new
                {
                    Idcv = table.Column<string>(type: "TEXT", nullable: false),
                    Tencv = table.Column<string>(type: "TEXT", nullable: false),
                    Motacn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chucvucv", x => x.Idcv);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chucvucv");
        }
    }
}
