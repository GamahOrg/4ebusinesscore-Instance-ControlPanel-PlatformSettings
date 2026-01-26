using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogoWebCoverLoginMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemporaryWebCoverLogin",
                table: "PlatformSettings",
                newName: "LogoWebCoverLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoWebCoverLogin",
                table: "PlatformSettings",
                newName: "TemporaryWebCoverLogin");
        }
    }
}
