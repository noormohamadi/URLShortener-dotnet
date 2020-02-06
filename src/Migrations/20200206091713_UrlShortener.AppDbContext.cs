using Microsoft.EntityFrameworkCore.Migrations;

namespace src.Migrations
{
    public partial class UrlShortenerAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "url",
                columns: table => new
                {
                    ShortenUrl = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_url", x => x.ShortenUrl);
                });

            migrationBuilder.CreateIndex(
                name: "IX_url_ShortenUrl",
                table: "url",
                column: "ShortenUrl",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "url");
        }
    }
}
