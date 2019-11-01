using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteBuilder.DataEntity.Migrations
{
    public partial class ChangeSiteSettingsTenantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteSettings_Tenants_TenantId1",
                table: "SiteSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteSettings_TenantId1",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "SiteSettings");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "SiteSettings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteSettings_Tenants_TenantId",
                table: "SiteSettings",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteSettings_Tenants_TenantId",
                table: "SiteSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "SiteSettings",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId1",
                table: "SiteSettings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_TenantId1",
                table: "SiteSettings",
                column: "TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteSettings_Tenants_TenantId1",
                table: "SiteSettings",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
