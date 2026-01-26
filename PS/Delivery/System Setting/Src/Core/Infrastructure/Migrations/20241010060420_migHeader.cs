using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "MainSettingHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "CanDelete",
                table: "MainSettingHeaders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHide",
                table: "MainSettingHeaders",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Squence",
                table: "MainSettingHeaders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanDelete",
                table: "MainSettingHeaders");

            migrationBuilder.DropColumn(
                name: "IsHide",
                table: "MainSettingHeaders");

            migrationBuilder.DropColumn(
                name: "Squence",
                table: "MainSettingHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "MainSettingHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
