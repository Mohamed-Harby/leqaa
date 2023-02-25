using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class ModifiedTableToUsePlanTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "users",
                newName: "ProfilePicture");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 831, DateTimeKind.Local).AddTicks(1646),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 827, DateTimeKind.Local).AddTicks(895),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 509, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 830, DateTimeKind.Local).AddTicks(9271),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 829, DateTimeKind.Local).AddTicks(738),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 512, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 822, DateTimeKind.Local).AddTicks(5967),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 505, DateTimeKind.Local).AddTicks(198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(1313),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(316),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(9122),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(5733),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(4673),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(7606));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "users",
                newName: "ProfileImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(9355),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 831, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 509, DateTimeKind.Local).AddTicks(3549),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 827, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 515, DateTimeKind.Local).AddTicks(4789),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 830, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 512, DateTimeKind.Local).AddTicks(3518),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 829, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 505, DateTimeKind.Local).AddTicks(198),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 822, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(8504),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(7399),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(1313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(5975),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plan",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 502, DateTimeKind.Local).AddTicks(4611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(9638),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 20, 35, 52, 501, DateTimeKind.Local).AddTicks(7606),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(4673));
        }
    }
}
