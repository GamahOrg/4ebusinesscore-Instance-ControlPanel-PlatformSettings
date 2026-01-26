using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FooterDescription",
                table: "PlatformSettings",
                newName: "FooterDescriptionEn");

            migrationBuilder.AddColumn<string>(
                name: "FooterDescriptionAr",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconTitle",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebLogoDarkMode",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "headerCoverDarkMode",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterDescriptionAr",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "IconTitle",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "WebLogoDarkMode",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "headerCoverDarkMode",
                table: "PlatformSettings");

            migrationBuilder.RenameColumn(
                name: "FooterDescriptionEn",
                table: "PlatformSettings",
                newName: "FooterDescription");
        }
    }
}
