using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Thuonghieu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thuonghieu",
                columns: table => new
                {
                    Idth = table.Column<string>(type: "TEXT", nullable: false),
                    Tenth = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuonghieu", x => x.Idth);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thuonghieu");
        }
    }
}
