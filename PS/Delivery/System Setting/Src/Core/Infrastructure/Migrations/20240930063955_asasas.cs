using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class asasas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachmentStyle",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsThem",
                table: "PlatformSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThemName",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachmentStyle",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "IsThem",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "ThemName",
                table: "PlatformSettings");
        }
    }
}
