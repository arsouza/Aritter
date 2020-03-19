using Microsoft.EntityFrameworkCore.Migrations;

namespace Ritter.Samples.Infra.Data.Migrations
{
    public partial class _02UpdateIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_uid",
                table: "People",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_uid",
                table: "Documents",
                column: "uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_uid",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_Documents_uid",
                table: "Documents");
        }
    }
}
