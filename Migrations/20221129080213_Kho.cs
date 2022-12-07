using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Kho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    Makho = table.Column<string>(type: "TEXT", nullable: false),
                    Dckho = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kho", x => x.Makho);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kho");
        }
    }
}
