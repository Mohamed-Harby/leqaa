using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Persistence.Migrations
{
    public partial class AddedSeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_roles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_users_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "users");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "userclaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "roleclaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "userclaims",
                newName: "IX_userclaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "roleclaims",
                newName: "IX_roleclaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userclaims",
                table: "userclaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roleclaims",
                table: "roleclaims",
                column: "Id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea648712-749e-4920-acda-91d0d607cef2", 0, "b504e802-f141-4a42-8faf-cc21a063e509", "Leqaa.Technical@gmail.com", true, 1, false, null, "Leqaa", "LEQAA.TECHNICAL@GMAIL.COM", "LEQAA", "AQAAAAEAACcQAAAAEJNSVXUZb9+D6+//1nUT8l4NQ7MyxQiRpqZ/hJeItejWjmYOqhVLFMfRX/neE0zhQA==", null, false, "73031b93-4497-4ddc-af62-e26ce7597ae9", false, "Leqaa" });

            migrationBuilder.AddForeignKey(
                name: "FK_roleclaims_roles_RoleId",
                table: "roleclaims",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userclaims_users_UserId",
                table: "userclaims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roleclaims_roles_RoleId",
                table: "roleclaims");

            migrationBuilder.DropForeignKey(
                name: "FK_userclaims_users_UserId",
                table: "userclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userclaims",
                table: "userclaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roleclaims",
                table: "roleclaims");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "ea648712-749e-4920-acda-91d0d607cef2");

            migrationBuilder.RenameTable(
                name: "userclaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "roleclaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_userclaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_roleclaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "users",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_roles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_users_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
