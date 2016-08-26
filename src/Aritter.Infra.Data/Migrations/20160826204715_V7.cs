using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aritter.Infra.Data.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClientId = table.Column<int>(nullable: false),
                    UID = table.Column<Guid>(nullable: false),
                    UserAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClients_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserClients_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClients_ClientId",
                table: "UserClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClients_UserAccountId",
                table: "UserClients",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClients_UserAccountId_ClientId",
                table: "UserClients",
                columns: new[] { "UserAccountId", "ClientId" },
                unique: true);
        }
    }
}
