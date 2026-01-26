using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class gggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterDescription",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterLogo",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterLogoDarkMode",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemporaryWebCoverDarkMode",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemporaryWebCoverLogin",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebCoverDarkMode",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebCoverLogin",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterDescription",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "FooterLogo",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "FooterLogoDarkMode",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "TemporaryWebCoverDarkMode",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "TemporaryWebCoverLogin",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "WebCoverDarkMode",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "WebCoverLogin",
                table: "PlatformSettings");
        }
    }
}
