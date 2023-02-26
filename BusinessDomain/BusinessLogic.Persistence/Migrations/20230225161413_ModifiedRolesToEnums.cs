using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class ModifiedRolesToEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 230, DateTimeKind.Local).AddTicks(3198),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 222, DateTimeKind.Utc).AddTicks(2720),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 566, DateTimeKind.Utc).AddTicks(1741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 229, DateTimeKind.Local).AddTicks(8205),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "UserHub",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("1666ca24-48b6-4cdd-9f3a-4c89ccd478a7"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("7620701a-7c3b-46d9-a547-7905bf8bd125"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 226, DateTimeKind.Local).AddTicks(5188),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 569, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 222, DateTimeKind.Local).AddTicks(1693),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 566, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 220, DateTimeKind.Utc).AddTicks(2811),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 220, DateTimeKind.Utc).AddTicks(1659),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 219, DateTimeKind.Utc).AddTicks(9746),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 218, DateTimeKind.Utc).AddTicks(2409),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 217, DateTimeKind.Utc).AddTicks(9674),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 217, DateTimeKind.Utc).AddTicks(8759),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(1289));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(4807),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 230, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 566, DateTimeKind.Utc).AddTicks(1741),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 222, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(1906),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 229, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "UserHub",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("7620701a-7c3b-46d9-a547-7905bf8bd125"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("1666ca24-48b6-4cdd-9f3a-4c89ccd478a7"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 569, DateTimeKind.Local).AddTicks(9058),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 226, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 566, DateTimeKind.Local).AddTicks(480),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 18, 14, 13, 222, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(5938),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 220, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 220, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(2540),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 219, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(5117),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 218, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(2382),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 217, DateTimeKind.Utc).AddTicks(9674));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(1289),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 14, 13, 217, DateTimeKind.Utc).AddTicks(8759));
        }
    }
}
