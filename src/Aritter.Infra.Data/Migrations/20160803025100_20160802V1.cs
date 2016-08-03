using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aritter.Infra.Data.Migrations
{
    public partial class _20160802V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "UserAssignments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "UserAssignments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Roles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Roles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Permissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Permissions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Operations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Operations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Authorizations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Authorizations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Resources",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Resources",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Applications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UID",
                table: "Persons",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "UserAssignments");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "UserAssignments");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "Persons");
        }
    }
}
