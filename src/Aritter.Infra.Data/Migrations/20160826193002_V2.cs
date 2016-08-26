using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aritter.Infra.Data.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Applications",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Applications",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Applications",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_ApplicationId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Operations_ApplicationId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ApplicationId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "UserRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Operations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Resources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ClientId",
                table: "UserRoles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ClientId",
                table: "Operations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ClientId",
                table: "Resources",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Name",
                table: "Clients",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Clients",
                table: "Operations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Clients",
                table: "Resources",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Clients",
                table: "UserRoles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Clients",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Clients",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Clients",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_ClientId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ClientId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Operations_ClientId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "UserRoles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Resources",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Operations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_ApplicationId",
                table: "UserRoles",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ApplicationId",
                table: "Resources",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ApplicationId",
                table: "Operations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_Name",
                table: "Applications",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Applications",
                table: "Resources",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Applications",
                table: "Operations",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Applications",
                table: "UserRoles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
