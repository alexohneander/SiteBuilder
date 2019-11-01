using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteBuilder.DataEntity.Migrations
{
    public partial class removesitesettingsfromtenantmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_TenantId",
                table: "SiteSettings",
                column: "TenantId",
                unique: true);
        }
    }
}
