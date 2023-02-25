using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class AddedDefaultValueToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HubUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(4807),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 831, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 566, DateTimeKind.Utc).AddTicks(1741),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 827, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(1906),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 830, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("7620701a-7c3b-46d9-a547-7905bf8bd125"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 569, DateTimeKind.Local).AddTicks(9058),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 829, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 566, DateTimeKind.Local).AddTicks(480),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 822, DateTimeKind.Local).AddTicks(5967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(5938),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(1313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(2540),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(5117),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(2382),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(1289),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(4673));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 831, DateTimeKind.Local).AddTicks(1646),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 827, DateTimeKind.Local).AddTicks(895),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 566, DateTimeKind.Utc).AddTicks(1741));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 830, DateTimeKind.Local).AddTicks(9271),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 572, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
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
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 829, DateTimeKind.Local).AddTicks(738),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 569, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 822, DateTimeKind.Local).AddTicks(5967),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 16, 3, 14, 566, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(2252),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(1313),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 820, DateTimeKind.Local).AddTicks(316),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 563, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(9122),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(5733),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "announcements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 25, 13, 10, 44, 819, DateTimeKind.Local).AddTicks(4673),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 2, 25, 14, 3, 14, 561, DateTimeKind.Utc).AddTicks(1289));

            migrationBuilder.CreateTable(
                name: "HubUser",
                columns: table => new
                {
                    HubsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubUser", x => new { x.HubsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_HubUser_hubs_HubsId",
                        column: x => x.HubsId,
                        principalTable: "hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HubUser_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HubUser_UsersId",
                table: "HubUser",
                column: "UsersId");
        }
    }
}
