using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migdffd65 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeurationSppinner",
                table: "PlatformSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoSystemLogin",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEvents",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleNews",
                table: "PlatformSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainSettingLogin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSettingLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainSettingLogin_PlatformSettings_MainSettingsId",
                        column: x => x.MainSettingsId,
                        principalTable: "PlatformSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainSettingLogin_MainSettingsId",
                table: "MainSettingLogin",
                column: "MainSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainSettingLogin");

            migrationBuilder.DropColumn(
                name: "DeurationSppinner",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "LogoSystemLogin",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "TitleEvents",
                table: "PlatformSettings");

            migrationBuilder.DropColumn(
                name: "TitleNews",
                table: "PlatformSettings");
        }
    }
}
