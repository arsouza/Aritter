using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aritter.Infra.Data.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "UserAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_ClientId",
                table: "UserAccounts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_Clients",
                table: "UserAccounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_Clients",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_ClientId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "UserAccounts");
        }
    }
}
