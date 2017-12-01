using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ritter.Samples.Infra.Data.Migrations
{
    public partial class RefactEmployeeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employee",
                newName: "last_name");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "Employee",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_name",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Employee",
                newName: "name");
        }
    }
}
