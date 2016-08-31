using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aritter.Infra.Data.Migrations
{
    public partial class RoleMembersV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAssignments");

            migrationBuilder.CreateTable(
                name: "RoleMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMembers_UserAccounts_MemberId",
                        column: x => x.MemberId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMembers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_MemberId",
                table: "RoleMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_RoleId",
                table: "RoleMembers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMembers_RoleId_MemberId",
                table: "RoleMembers",
                columns: new[] { "RoleId", "MemberId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMembers");

            migrationBuilder.CreateTable(
                name: "RoleAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountMemberId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    RoleMemberId = table.Column<int>(nullable: true),
                    UID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAssignments_UserAccounts_AccountMemberId",
                        column: x => x.AccountMemberId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleAssignments_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleAssignments_Roles_RoleMemberId",
                        column: x => x.RoleMemberId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_AccountMemberId",
                table: "RoleAssignments",
                column: "AccountMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_RoleId",
                table: "RoleAssignments",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_RoleMemberId",
                table: "RoleAssignments",
                column: "RoleMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAssignments_RoleId_RoleMemberId_AccountMemberId",
                table: "RoleAssignments",
                columns: new[] { "RoleId", "RoleMemberId", "AccountMemberId" },
                unique: true);
        }
    }
}
