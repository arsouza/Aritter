using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aritter.Infra.Data.Migrations
{
    public partial class SecurityV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "UserUserRoles");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "UserAssignments");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Applications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "UserProfiles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "UserAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "UserUserRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "UserAssignments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Operations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Authorizations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Resources",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Applications",
                nullable: false,
                defaultValue: false);
        }
    }
}
