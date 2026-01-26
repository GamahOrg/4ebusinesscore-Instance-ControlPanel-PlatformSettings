using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WebLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebCover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TemporaryWebCover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainSettingsDepartmentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSettingsDepartmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainSettingsDepartmentItems_MainSettings_MainSettingsId",
                        column: x => x.MainSettingsId,
                        principalTable: "MainSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainSettingsDepartmentsIcons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainSettingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSettingsDepartmentsIcons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainSettingsDepartmentsIcons_MainSettings_MainSettingsId",
                        column: x => x.MainSettingsId,
                        principalTable: "MainSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainSettingsSites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderIndex = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainSettingsSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainSettingsSites_MainSettings_MainSetId",
                        column: x => x.MainSetId,
                        principalTable: "MainSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainSettingsDepartmentItems_MainSettingsId",
                table: "MainSettingsDepartmentItems",
                column: "MainSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_MainSettingsDepartmentsIcons_MainSettingsId",
                table: "MainSettingsDepartmentsIcons",
                column: "MainSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_MainSettingsSites_MainSetId",
                table: "MainSettingsSites",
                column: "MainSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainSettingsDepartmentItems");

            migrationBuilder.DropTable(
                name: "MainSettingsDepartmentsIcons");

            migrationBuilder.DropTable(
                name: "MainSettingsSites");

            migrationBuilder.DropTable(
                name: "MainSettings");
        }
    }
}
