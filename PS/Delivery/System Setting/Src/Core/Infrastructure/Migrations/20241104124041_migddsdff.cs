using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migddsdff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChatBotIsVisible",
                table: "PlatformSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChatBotName",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatBotIsVisible",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "ChatBotName",
                table: "PlatformSettings");
        }
    }
}
