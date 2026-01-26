using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migdfdhdf2532 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleEventsEn",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleNewsEn",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleEventsEn",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "TitleNewsEn",
                table: "PlatformSettings");
        }
    }
}
