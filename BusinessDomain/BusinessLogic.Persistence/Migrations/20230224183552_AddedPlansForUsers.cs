using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class AddedPlansForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_users_Username",
                table: "users",
                newName: "IX_users_UserName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(9355),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 509, DateTimeKind.Local).AddTicks(3549),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 739, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(4789),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserRoom",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 512, DateTimeKind.Local).AddTicks(3518),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserHub",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 505, DateTimeKind.Local).AddTicks(198),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserChannel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(8504),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(7399),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(8058));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "hubs",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "hubs",
                type: "varchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(4611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(9638),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(7606),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(5975))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_UserId",
                table: "Plan",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserRoom");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserHub");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserChannel");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_users_UserName",
                table: "users",
                newName: "IX_users_Username");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 739, DateTimeKind.Local).AddTicks(2062),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 509, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 512, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 505, DateTimeKind.Local).AddTicks(198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(8861),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(8058),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "hubs",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "hubs",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(6932),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(4576),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 17, 43, 55, 733, DateTimeKind.Local).AddTicks(3615),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(7606));
        }
    }
}
