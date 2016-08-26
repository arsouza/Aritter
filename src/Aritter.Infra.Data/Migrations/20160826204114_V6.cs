using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aritter.Infra.Data.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_Username",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "UserAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Username",
                table: "UserAccounts",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_Username",
                table: "UserAccounts");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "UserAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Email",
                table: "UserAccounts",
                columns: new[] { "Email", "ClientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_Username",
                table: "UserAccounts",
                columns: new[] { "Username", "ClientId" },
                unique: true);
        }
    }
}
