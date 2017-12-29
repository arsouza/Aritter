using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ritter.Samples.Infra.Data.Migrations
{
    public partial class ChangeCpfLengthTo11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Employee",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Employee",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11);
        }
    }
}
