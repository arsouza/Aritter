using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ritter.Samples.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    person_id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uid = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: true),
                    last_name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    person_id = table.Column<long>(nullable: false),
                    uid = table.Column<Guid>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    number = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.person_id);
                    table.ForeignKey(
                        name: "FK_Documents_People_person_id",
                        column: x => x.person_id,
                        principalTable: "People",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_uid",
                table: "Documents",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_uid",
                table: "People",
                column: "uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
