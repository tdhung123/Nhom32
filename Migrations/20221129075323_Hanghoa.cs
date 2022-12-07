using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace btlnhom32.Migrations
{
    /// <inheritdoc />
    public partial class Hanghoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hanghoa",
                columns: table => new
                {
                    Mahh = table.Column<string>(type: "TEXT", nullable: false),
                    Tenhh = table.Column<string>(type: "TEXT", nullable: false),
                    Tenth = table.Column<string>(type: "TEXT", nullable: false),
                    Dvtinh = table.Column<string>(type: "TEXT", nullable: false),
                    gvhh = table.Column<decimal>(type: "TEXT", nullable: false),
                    gbhh = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hanghoa", x => x.Mahh);
                    table.ForeignKey(
                        name: "FK_Hanghoa_Thuonghieu_Tenth",
                        column: x => x.Tenth,
                        principalTable: "Thuonghieu",
                        principalColumn: "Idth",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hanghoa_Tenth",
                table: "Hanghoa",
                column: "Tenth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hanghoa");
        }
    }
}
