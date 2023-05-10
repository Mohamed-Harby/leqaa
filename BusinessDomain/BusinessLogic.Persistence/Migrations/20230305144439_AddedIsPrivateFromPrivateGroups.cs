using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class AddedIsPrivateFromPrivateGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(8015),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 6, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 798, DateTimeKind.Utc).AddTicks(2732),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 27, 1, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(5454),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 6, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c8064a29-1100-48c9-b141-f47c74842615"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("9c78089d-51e6-4679-89c5-3fb6aa14dfc0"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(3268),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 5, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 798, DateTimeKind.Local).AddTicks(1669),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 1, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 796, DateTimeKind.Local).AddTicks(1954),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 21, 20, 26, 999, DateTimeKind.Local).AddTicks(7520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 796, DateTimeKind.Utc).AddTicks(607),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 999, DateTimeKind.Utc).AddTicks(6397));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(9461),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 999, DateTimeKind.Utc).AddTicks(5546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(7410),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 999, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(8421),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 997, DateTimeKind.Utc).AddTicks(6962));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "hubs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(5345),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 997, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Channels",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(4336),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 997, DateTimeKind.Utc).AddTicks(2288));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "hubs");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Channels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 6, DateTimeKind.Local).AddTicks(3313),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 27, 1, DateTimeKind.Utc).AddTicks(7099),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 798, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 6, DateTimeKind.Local).AddTicks(305),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("9c78089d-51e6-4679-89c5-3fb6aa14dfc0"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("c8064a29-1100-48c9-b141-f47c74842615"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 5, DateTimeKind.Local).AddTicks(7767),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(3268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 21, 20, 27, 1, DateTimeKind.Local).AddTicks(5195),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 798, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 21, 20, 26, 999, DateTimeKind.Local).AddTicks(7520),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 796, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 999, DateTimeKind.Utc).AddTicks(6397),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 796, DateTimeKind.Utc).AddTicks(607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 999, DateTimeKind.Utc).AddTicks(5546),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 999, DateTimeKind.Utc).AddTicks(3742),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 997, DateTimeKind.Utc).AddTicks(6962),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 997, DateTimeKind.Utc).AddTicks(3710),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 4, 19, 20, 26, 997, DateTimeKind.Utc).AddTicks(2288),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(4336));
        }
    }
}
