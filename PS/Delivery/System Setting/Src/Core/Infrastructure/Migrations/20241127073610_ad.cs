using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSignInDynamic",
                table: "PlatformSettings");

            migrationBuilder.AddColumn<int>(
                name: "SignInMode",
                table: "PlatformSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignInMode",
                table: "PlatformSettings");

            migrationBuilder.AddColumn<bool>(
                name: "isSignInDynamic",
                table: "PlatformSettings",
                type: "bit",
                nullable: true);
        }
    }
}
