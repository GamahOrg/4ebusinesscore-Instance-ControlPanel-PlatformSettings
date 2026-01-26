using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class efhdgfdh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAr",
                table: "MainSettingLogin");

            migrationBuilder.RenameColumn(
                name: "ImageEn",
                table: "MainSettingLogin",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "MainSettingLogin",
                newName: "ImageEn");

            migrationBuilder.AddColumn<string>(
                name: "ImageAr",
                table: "MainSettingLogin",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
