using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformSettings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabaseNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainSettingsDepartmentItems_MainSettings_MainSettingsId",
                table: "MainSettingsDepartmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSettingsDepartmentsIcons_MainSettings_MainSettingsId",
                table: "MainSettingsDepartmentsIcons");

            migrationBuilder.DropForeignKey(
                name: "FK_MainSettingsSites_MainSettings_MainSetId",
                table: "MainSettingsSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainSettingsSites",
                table: "MainSettingsSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainSettingsDepartmentsIcons",
                table: "MainSettingsDepartmentsIcons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainSettingsDepartmentItems",
                table: "MainSettingsDepartmentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainSettings",
                table: "MainSettings");

            migrationBuilder.RenameTable(
                name: "MainSettingsSites",
                newName: "PlatformSettingsSites");

            migrationBuilder.RenameTable(
                name: "MainSettingsDepartmentsIcons",
                newName: "PlatformSettingsDepartmentsIcons");

            migrationBuilder.RenameTable(
                name: "MainSettingsDepartmentItems",
                newName: "PlatformSettingsDepartmentItems");

            migrationBuilder.RenameTable(
                name: "MainSettings",
                newName: "PlatformSettings");

            migrationBuilder.RenameIndex(
                name: "IX_MainSettingsSites_MainSetId",
                table: "PlatformSettingsSites",
                newName: "IX_PlatformSettingsSites_MainSetId");

            migrationBuilder.RenameIndex(
                name: "IX_MainSettingsDepartmentsIcons_MainSettingsId",
                table: "PlatformSettingsDepartmentsIcons",
                newName: "IX_PlatformSettingsDepartmentsIcons_MainSettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_MainSettingsDepartmentItems_MainSettingsId",
                table: "PlatformSettingsDepartmentItems",
                newName: "IX_PlatformSettingsDepartmentItems_MainSettingsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformSettingsSites",
                table: "PlatformSettingsSites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformSettingsDepartmentsIcons",
                table: "PlatformSettingsDepartmentsIcons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformSettingsDepartmentItems",
                table: "PlatformSettingsDepartmentItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatformSettings",
                table: "PlatformSettings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSettingsDepartmentItems_PlatformSettings_MainSettingsId",
                table: "PlatformSettingsDepartmentItems",
                column: "MainSettingsId",
                principalTable: "PlatformSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSettingsDepartmentsIcons_PlatformSettings_MainSettingsId",
                table: "PlatformSettingsDepartmentsIcons",
                column: "MainSettingsId",
                principalTable: "PlatformSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatformSettingsSites_PlatformSettings_MainSetId",
                table: "PlatformSettingsSites",
                column: "MainSetId",
                principalTable: "PlatformSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSettingsDepartmentItems_PlatformSettings_MainSettingsId",
                table: "PlatformSettingsDepartmentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSettingsDepartmentsIcons_PlatformSettings_MainSettingsId",
                table: "PlatformSettingsDepartmentsIcons");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatformSettingsSites_PlatformSettings_MainSetId",
                table: "PlatformSettingsSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformSettingsSites",
                table: "PlatformSettingsSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformSettingsDepartmentsIcons",
                table: "PlatformSettingsDepartmentsIcons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformSettingsDepartmentItems",
                table: "PlatformSettingsDepartmentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatformSettings",
                table: "PlatformSettings");

            migrationBuilder.RenameTable(
                name: "PlatformSettingsSites",
                newName: "MainSettingsSites");

            migrationBuilder.RenameTable(
                name: "PlatformSettingsDepartmentsIcons",
                newName: "MainSettingsDepartmentsIcons");

            migrationBuilder.RenameTable(
                name: "PlatformSettingsDepartmentItems",
                newName: "MainSettingsDepartmentItems");

            migrationBuilder.RenameTable(
                name: "PlatformSettings",
                newName: "MainSettings");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformSettingsSites_MainSetId",
                table: "MainSettingsSites",
                newName: "IX_MainSettingsSites_MainSetId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformSettingsDepartmentsIcons_MainSettingsId",
                table: "MainSettingsDepartmentsIcons",
                newName: "IX_MainSettingsDepartmentsIcons_MainSettingsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatformSettingsDepartmentItems_MainSettingsId",
                table: "MainSettingsDepartmentItems",
                newName: "IX_MainSettingsDepartmentItems_MainSettingsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainSettingsSites",
                table: "MainSettingsSites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainSettingsDepartmentsIcons",
                table: "MainSettingsDepartmentsIcons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainSettingsDepartmentItems",
                table: "MainSettingsDepartmentItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainSettings",
                table: "MainSettings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSettingsDepartmentItems_MainSettings_MainSettingsId",
                table: "MainSettingsDepartmentItems",
                column: "MainSettingsId",
                principalTable: "MainSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSettingsDepartmentsIcons_MainSettings_MainSettingsId",
                table: "MainSettingsDepartmentsIcons",
                column: "MainSettingsId",
                principalTable: "MainSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainSettingsSites_MainSettings_MainSetId",
                table: "MainSettingsSites",
                column: "MainSetId",
                principalTable: "MainSettings",
                principalColumn: "Id");
        }
    }
}
