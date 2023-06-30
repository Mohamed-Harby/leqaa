using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class addUserUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 678, DateTimeKind.Utc).AddTicks(1099),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 664, DateTimeKind.Utc).AddTicks(7788),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(3337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 677, DateTimeKind.Utc).AddTicks(8466),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedPost",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("3d0b84dd-1efc-4070-bd08-0e4df9cfc9a2"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("f606d54f-421f-4b0b-a92b-f9772a59b60b"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedPost",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 3, 11, 39, 677, DateTimeKind.Local).AddTicks(5523),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("83489396-2bb9-42f5-92f3-0319fc87ffca"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("bbe6e50a-0907-4208-bb07-2f6bf10ce135"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 3, 11, 39, 677, DateTimeKind.Local).AddTicks(2417),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedChannel",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bfc03eb6-24fd-4eb0-b4ee-9d89ea9475ed"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("97d5448f-0061-474e-81b3-4594c3f3657b"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 3, 11, 39, 676, DateTimeKind.Local).AddTicks(9170),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("9a5a606f-805a-4841-a2d3-467711920082"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("f5397ed4-6ca0-4914-8b5a-cdbb2540ba97"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 676, DateTimeKind.Utc).AddTicks(1933),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("980ba3e7-0a78-4a89-82a9-d49076538b34"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("59c7a755-5919-44ce-b135-0fd87647d363"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 676, DateTimeKind.Utc).AddTicks(5829),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("814016c7-afb2-43f9-9a91-9ff365c3a643"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("c21d81ed-98e1-400c-ae7e-577830d84467"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannelAnnoucement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 662, DateTimeKind.Utc).AddTicks(3113),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 497, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 664, DateTimeKind.Utc).AddTicks(6303),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 660, DateTimeKind.Utc).AddTicks(650),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(9052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 659, DateTimeKind.Utc).AddTicks(8492),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(7392));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 655, DateTimeKind.Utc).AddTicks(543),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(9188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 654, DateTimeKind.Utc).AddTicks(7155),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 645, DateTimeKind.Utc).AddTicks(6604),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 645, DateTimeKind.Utc).AddTicks(3562),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 640, DateTimeKind.Utc).AddTicks(8948),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(8226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "channelAnnouncements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 640, DateTimeKind.Utc).AddTicks(5696),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(3900));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(4894),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 678, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(3337),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 664, DateTimeKind.Utc).AddTicks(7788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(2012),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 677, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedPost",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f606d54f-421f-4b0b-a92b-f9772a59b60b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("3d0b84dd-1efc-4070-bd08-0e4df9cfc9a2"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedPost",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(8812),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 3, 11, 39, 677, DateTimeKind.Local).AddTicks(5523));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bbe6e50a-0907-4208-bb07-2f6bf10ce135"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("83489396-2bb9-42f5-92f3-0319fc87ffca"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(4907),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 3, 11, 39, 677, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedChannel",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("97d5448f-0061-474e-81b3-4594c3f3657b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("bfc03eb6-24fd-4eb0-b4ee-9d89ea9475ed"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(860),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 3, 11, 39, 676, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f5397ed4-6ca0-4914-8b5a-cdbb2540ba97"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("9a5a606f-805a-4841-a2d3-467711920082"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(2428),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 676, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("59c7a755-5919-44ce-b135-0fd87647d363"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("980ba3e7-0a78-4a89-82a9-d49076538b34"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 676, DateTimeKind.Utc).AddTicks(5829));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c21d81ed-98e1-400c-ae7e-577830d84467"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("814016c7-afb2-43f9-9a91-9ff365c3a643"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannelAnnoucement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 497, DateTimeKind.Utc).AddTicks(4065),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 662, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(804),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 664, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(9052),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 660, DateTimeKind.Utc).AddTicks(650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(7392),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 659, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(9188),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 655, DateTimeKind.Utc).AddTicks(543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(6402),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 654, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(4450),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 645, DateTimeKind.Utc).AddTicks(6604));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(2079),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 645, DateTimeKind.Utc).AddTicks(3562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(8226),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 640, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "channelAnnouncements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(3900),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 29, 1, 11, 39, 640, DateTimeKind.Utc).AddTicks(5696));
        }
    }
}
