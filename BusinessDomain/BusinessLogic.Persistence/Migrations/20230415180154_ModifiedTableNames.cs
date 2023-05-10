using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class ModifiedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_users_UserId",
                table: "Plan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "plans");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_UserId",
                table: "plans",
                newName: "IX_plans_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(4894),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 285, DateTimeKind.Utc).AddTicks(1149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(3337),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 276, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(2012),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 284, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedPost",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f606d54f-421f-4b0b-a92b-f9772a59b60b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("93ac999f-5335-42b5-92c1-7c22cd43a5d2"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedPost",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(8812),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bbe6e50a-0907-4208-bb07-2f6bf10ce135"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("4d5e6f3d-ce9e-4f3d-a5d1-ce9fad2ec653"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(4907),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(4793));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedChannel",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("97d5448f-0061-474e-81b3-4594c3f3657b"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("1eb47a45-8c96-46d8-adde-50f11be926d2"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(860),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f5397ed4-6ca0-4914-8b5a-cdbb2540ba97"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("f298d8ad-ffc3-4ce6-b4fa-8ae8c13511af"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(2428),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(7272));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("59c7a755-5919-44ce-b135-0fd87647d363"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("bb760b43-5383-4977-b3ac-ff1575b18311"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(6164),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c21d81ed-98e1-400c-ae7e-577830d84467"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("56480b08-e9ba-4ca6-b81f-d85522027530"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannelAnnoucement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 497, DateTimeKind.Utc).AddTicks(4065),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 274, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(804),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 275, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(9052),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(7392),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(9188),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(4450),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 262, DateTimeKind.Utc).AddTicks(5887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(2079),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(8226),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "channelAnnouncements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(3900),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(6402),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.AddPrimaryKey(
                name: "PK_plans",
                table: "plans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plans_users_UserId",
                table: "plans",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plans_users_UserId",
                table: "plans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plans",
                table: "plans");

            migrationBuilder.RenameTable(
                name: "plans",
                newName: "Plan");

            migrationBuilder.RenameIndex(
                name: "IX_plans_UserId",
                table: "Plan",
                newName: "IX_Plan_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 285, DateTimeKind.Utc).AddTicks(1149),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 276, DateTimeKind.Utc).AddTicks(346),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(3337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 284, DateTimeKind.Utc).AddTicks(9076),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 529, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedPost",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("93ac999f-5335-42b5-92c1-7c22cd43a5d2"),
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
                defaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(7248),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(8812));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("4d5e6f3d-ce9e-4f3d-a5d1-ce9fad2ec653"),
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
                defaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(4793),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(4907));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedChannel",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("1eb47a45-8c96-46d8-adde-50f11be926d2"),
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
                defaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(2236),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 20, 1, 53, 528, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f298d8ad-ffc3-4ce6-b4fa-8ae8c13511af"),
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
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(7272),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bb760b43-5383-4977-b3ac-ff1575b18311"),
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
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(9685),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 527, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("56480b08-e9ba-4ca6-b81f-d85522027530"),
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
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 274, DateTimeKind.Utc).AddTicks(3096),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 497, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 275, DateTimeKind.Utc).AddTicks(9489),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 512, DateTimeKind.Utc).AddTicks(804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(5828),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(9052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(4593),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 494, DateTimeKind.Utc).AddTicks(7392));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(9188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 262, DateTimeKind.Utc).AddTicks(5887),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 477, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(3748),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(8226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "channelAnnouncements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(2578),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 471, DateTimeKind.Utc).AddTicks(3900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(7624),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 4, 15, 18, 1, 53, 489, DateTimeKind.Utc).AddTicks(6402));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_users_UserId",
                table: "Plan",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
