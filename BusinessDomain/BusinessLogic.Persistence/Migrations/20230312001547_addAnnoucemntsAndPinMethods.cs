using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class addAnnoucemntsAndPinMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "announcements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 285, DateTimeKind.Utc).AddTicks(1149),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(8015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 276, DateTimeKind.Utc).AddTicks(346),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 798, DateTimeKind.Utc).AddTicks(2732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 284, DateTimeKind.Utc).AddTicks(9076),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("bb760b43-5383-4977-b3ac-ff1575b18311"),
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
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(9685),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(3268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 275, DateTimeKind.Utc).AddTicks(9489),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 798, DateTimeKind.Local).AddTicks(1669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(5828),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 796, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(4593),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 796, DateTimeKind.Utc).AddTicks(607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(7624),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 262, DateTimeKind.Utc).AddTicks(5887),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(3748),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Channels",
                type: "longblob",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "channelAnnouncements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(2578))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channelAnnouncements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_channelAnnouncements_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_channelAnnouncements_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HubAnnouncement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    HubId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubAnnouncement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubAnnouncement_hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HubAnnouncement_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPinnedChannel",
                columns: table => new
                {
                    UserPinnedId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("1eb47a45-8c96-46d8-adde-50f11be926d2"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(2236))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedChannel", x => new { x.UserPinnedId, x.PinnedChannelId });
                    table.ForeignKey(
                        name: "FK_UserPinnedChannel_Channels_PinnedChannelId",
                        column: x => x.PinnedChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedChannel_users_UserPinnedId",
                        column: x => x.UserPinnedId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPinnedHub",
                columns: table => new
                {
                    UserPinnedid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedHubId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("4d5e6f3d-ce9e-4f3d-a5d1-ce9fad2ec653"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(4793))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedHub", x => new { x.UserPinnedid, x.PinnedHubId });
                    table.ForeignKey(
                        name: "FK_UserPinnedHub_hubs_PinnedHubId",
                        column: x => x.PinnedHubId,
                        principalTable: "hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedHub_users_UserPinnedid",
                        column: x => x.UserPinnedid,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPinnedPost",
                columns: table => new
                {
                    UserPinnedId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedPostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("93ac999f-5335-42b5-92c1-7c22cd43a5d2"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 12, 2, 15, 47, 284, DateTimeKind.Local).AddTicks(7248))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedPost", x => new { x.UserPinnedId, x.PinnedPostId });
                    table.ForeignKey(
                        name: "FK_UserPinnedPost_posts_PinnedPostId",
                        column: x => x.PinnedPostId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedPost_users_UserPinnedId",
                        column: x => x.UserPinnedId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserChannelAnnoucement",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChannelAnnouncementId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("56480b08-e9ba-4ca6-b81f-d85522027530"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 274, DateTimeKind.Utc).AddTicks(3096))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChannelAnnoucement", x => new { x.UserId, x.ChannelAnnouncementId });
                    table.ForeignKey(
                        name: "FK_UserChannelAnnoucement_channelAnnouncements_ChannelAnnouncem~",
                        column: x => x.ChannelAnnouncementId,
                        principalTable: "channelAnnouncements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChannelAnnoucement_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserHubAnnouncement",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    HubAnnouncementId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("f298d8ad-ffc3-4ce6-b4fa-8ae8c13511af"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(7272))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHubAnnouncement", x => new { x.UserId, x.HubAnnouncementId });
                    table.ForeignKey(
                        name: "FK_UserHubAnnouncement_HubAnnouncement_HubAnnouncementId",
                        column: x => x.HubAnnouncementId,
                        principalTable: "HubAnnouncement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHubAnnouncement_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_channelAnnouncements_ChannelId",
                table: "channelAnnouncements",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_channelAnnouncements_UserId",
                table: "channelAnnouncements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HubAnnouncement_HubId",
                table: "HubAnnouncement",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_HubAnnouncement_UserId",
                table: "HubAnnouncement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChannelAnnoucement_ChannelAnnouncementId",
                table: "UserChannelAnnoucement",
                column: "ChannelAnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHubAnnouncement_HubAnnouncementId",
                table: "UserHubAnnouncement",
                column: "HubAnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPinnedChannel_PinnedChannelId",
                table: "UserPinnedChannel",
                column: "PinnedChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPinnedHub_PinnedHubId",
                table: "UserPinnedHub",
                column: "PinnedHubId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPinnedPost_PinnedPostId",
                table: "UserPinnedPost",
                column: "PinnedPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChannelAnnoucement");

            migrationBuilder.DropTable(
                name: "UserHubAnnouncement");

            migrationBuilder.DropTable(
                name: "UserPinnedChannel");

            migrationBuilder.DropTable(
                name: "UserPinnedHub");

            migrationBuilder.DropTable(
                name: "UserPinnedPost");

            migrationBuilder.DropTable(
                name: "channelAnnouncements");

            migrationBuilder.DropTable(
                name: "HubAnnouncement");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Channels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(8015),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 285, DateTimeKind.Utc).AddTicks(1149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 798, DateTimeKind.Utc).AddTicks(2732),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 276, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(5454),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 284, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("c8064a29-1100-48c9-b141-f47c74842615"),
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
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 804, DateTimeKind.Local).AddTicks(3268),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 283, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 798, DateTimeKind.Local).AddTicks(1669),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 275, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 16, 44, 38, 796, DateTimeKind.Local).AddTicks(1954),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 796, DateTimeKind.Utc).AddTicks(607),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 272, DateTimeKind.Utc).AddTicks(4593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(9461),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 795, DateTimeKind.Utc).AddTicks(7410),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 268, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(8421),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 262, DateTimeKind.Utc).AddTicks(5887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(5345),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 12, 0, 15, 47, 259, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.CreateTable(
                name: "announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 5, 14, 44, 38, 793, DateTimeKind.Utc).AddTicks(4336)),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_announcements_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_announcements_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_announcements_ChannelId",
                table: "announcements",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_announcements_UserId",
                table: "announcements",
                column: "UserId");
        }
    }
}
