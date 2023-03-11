using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class ConfigurationOfChannelAnnouncements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelAnnouncement_Channels_ChannelId",
                table: "ChannelAnnouncement");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelAnnouncement_users_UserId",
                table: "ChannelAnnouncement");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannelAnnoucement_ChannelAnnouncement_ChannelAnnounceme~",
                table: "UserChannelAnnoucement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChannelAnnouncement",
                table: "ChannelAnnouncement");

            migrationBuilder.RenameTable(
                name: "ChannelAnnouncement",
                newName: "channelAnnouncements");

            migrationBuilder.RenameIndex(
                name: "IX_ChannelAnnouncement_UserId",
                table: "channelAnnouncements",
                newName: "IX_channelAnnouncements_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ChannelAnnouncement_ChannelId",
                table: "channelAnnouncements",
                newName: "IX_channelAnnouncements_ChannelId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 820, DateTimeKind.Utc).AddTicks(2752),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 806, DateTimeKind.Utc).AddTicks(4315),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(2803));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 820, DateTimeKind.Utc).AddTicks(636),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedPost",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("28bd2381-7afe-42bb-a7aa-105df4a5c400"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("58681103-64e8-4d9d-91df-de732c8ee484"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedPost",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 20, 0, 45, 819, DateTimeKind.Local).AddTicks(8424),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 618, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("254a7c78-7d1d-4ff0-b164-50f088305f16"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("724631b1-f957-4c12-a630-5ce5f0d3de8f"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 20, 0, 45, 817, DateTimeKind.Local).AddTicks(9769),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 616, DateTimeKind.Local).AddTicks(4924));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedChannel",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("862fb34d-aba5-4e29-a952-5f257897e093"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("5f1bfaa7-7871-4d79-b088-2dfe86f2f0b5"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 20, 0, 45, 815, DateTimeKind.Local).AddTicks(8835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 614, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("050c6da9-e6a4-48d5-8882-33a9534bc2ec"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("46a9900b-81d9-4db6-acae-1d6cfcbc25c4"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 812, DateTimeKind.Utc).AddTicks(7196),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("a674fb42-34e8-4ae2-823d-4046255f485d"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("f95ef831-68d3-4d06-94e0-92a399d96fde"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 813, DateTimeKind.Utc).AddTicks(122),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("6bdb2823-7f2c-4132-b862-f023de659a0e"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("44de3b70-377a-4817-9376-86dfcbd4becc"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannelAnnoucement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 804, DateTimeKind.Utc).AddTicks(5167),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 605, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 806, DateTimeKind.Utc).AddTicks(3400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(1767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(7331),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 603, DateTimeKind.Utc).AddTicks(574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(6177),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(5166),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(2267),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "pinnedHups",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 799, DateTimeKind.Utc).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 600, DateTimeKind.Utc).AddTicks(4271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "pinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 797, DateTimeKind.Utc).AddTicks(3343),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 599, DateTimeKind.Utc).AddTicks(801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 794, DateTimeKind.Utc).AddTicks(8725),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(2953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 794, DateTimeKind.Utc).AddTicks(6077),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "channelAnnouncements",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 794, DateTimeKind.Utc).AddTicks(5051),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_channelAnnouncements",
                table: "channelAnnouncements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_channelAnnouncements_Channels_ChannelId",
                table: "channelAnnouncements",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_channelAnnouncements_users_UserId",
                table: "channelAnnouncements",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannelAnnoucement_channelAnnouncements_ChannelAnnouncem~",
                table: "UserChannelAnnoucement",
                column: "ChannelAnnouncementId",
                principalTable: "channelAnnouncements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_channelAnnouncements_Channels_ChannelId",
                table: "channelAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_channelAnnouncements_users_UserId",
                table: "channelAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannelAnnoucement_channelAnnouncements_ChannelAnnouncem~",
                table: "UserChannelAnnoucement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_channelAnnouncements",
                table: "channelAnnouncements");

            migrationBuilder.RenameTable(
                name: "channelAnnouncements",
                newName: "ChannelAnnouncement");

            migrationBuilder.RenameIndex(
                name: "IX_channelAnnouncements_UserId",
                table: "ChannelAnnouncement",
                newName: "IX_ChannelAnnouncement_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_channelAnnouncements_ChannelId",
                table: "ChannelAnnouncement",
                newName: "IX_ChannelAnnouncement_ChannelId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(3968),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 820, DateTimeKind.Utc).AddTicks(2752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(2803),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 806, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(66),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 820, DateTimeKind.Utc).AddTicks(636));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedPost",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("58681103-64e8-4d9d-91df-de732c8ee484"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("28bd2381-7afe-42bb-a7aa-105df4a5c400"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedPost",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 618, DateTimeKind.Local).AddTicks(6225),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 20, 0, 45, 819, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("724631b1-f957-4c12-a630-5ce5f0d3de8f"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("254a7c78-7d1d-4ff0-b164-50f088305f16"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 616, DateTimeKind.Local).AddTicks(4924),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 20, 0, 45, 817, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPinnedChannel",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("5f1bfaa7-7871-4d79-b088-2dfe86f2f0b5"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("862fb34d-aba5-4e29-a952-5f257897e093"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserPinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 614, DateTimeKind.Local).AddTicks(8480),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 20, 0, 45, 815, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("46a9900b-81d9-4db6-acae-1d6cfcbc25c4"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("050c6da9-e6a4-48d5-8882-33a9534bc2ec"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(6333),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 812, DateTimeKind.Utc).AddTicks(7196));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f95ef831-68d3-4d06-94e0-92a399d96fde"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("a674fb42-34e8-4ae2-823d-4046255f485d"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(8767),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 813, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("44de3b70-377a-4817-9376-86dfcbd4becc"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("6bdb2823-7f2c-4132-b862-f023de659a0e"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannelAnnoucement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 605, DateTimeKind.Utc).AddTicks(2256),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 804, DateTimeKind.Utc).AddTicks(5167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(1767),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 806, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 603, DateTimeKind.Utc).AddTicks(574),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(7331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(8468),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(6494),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(5166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(3308),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 802, DateTimeKind.Utc).AddTicks(2267));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "pinnedHups",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 600, DateTimeKind.Utc).AddTicks(4271),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 799, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "pinnedChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 599, DateTimeKind.Utc).AddTicks(801),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 797, DateTimeKind.Utc).AddTicks(3343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(2953),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 794, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(27),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 794, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ChannelAnnouncement",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 18, 0, 45, 794, DateTimeKind.Utc).AddTicks(5051));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChannelAnnouncement",
                table: "ChannelAnnouncement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelAnnouncement_Channels_ChannelId",
                table: "ChannelAnnouncement",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelAnnouncement_users_UserId",
                table: "ChannelAnnouncement",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannelAnnoucement_ChannelAnnouncement_ChannelAnnounceme~",
                table: "UserChannelAnnoucement",
                column: "ChannelAnnouncementId",
                principalTable: "ChannelAnnouncement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
