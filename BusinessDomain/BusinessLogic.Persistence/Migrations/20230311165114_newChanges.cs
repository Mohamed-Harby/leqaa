using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Persistence.Migrations
{
    public partial class newChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(3968),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 689, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(2803),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 682, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(66),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 689, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("46a9900b-81d9-4db6-acae-1d6cfcbc25c4"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("7b6f130e-ad15-4345-9570-26cf2f523212"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHubAnnouncement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(6333),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 688, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("f95ef831-68d3-4d06-94e0-92a399d96fde"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("9ff08917-ca2e-4af3-8eec-981c893699cf"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserHub",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(8767),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 688, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("44de3b70-377a-4817-9376-86dfcbd4becc"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValue: new Guid("7fae3ca9-c8b0-4741-a78a-6b86d6485cc0"))
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannelAnnoucement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 605, DateTimeKind.Utc).AddTicks(2256),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 681, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(1767),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 682, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 603, DateTimeKind.Utc).AddTicks(574),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 679, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(8468),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 679, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(6494),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 679, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.AddColumn<Guid>(
                name: "PinnedPostId",
                table: "posts",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(3308),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 679, DateTimeKind.Utc).AddTicks(719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(2953),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 677, DateTimeKind.Utc).AddTicks(3391));

            migrationBuilder.AddColumn<Guid>(
                name: "PinnedHubId",
                table: "hubs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(27),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 677, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.CreateTable(
                name: "pinnedChannel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPinnedChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPinnedId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 599, DateTimeKind.Utc).AddTicks(801))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pinnedChannel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pinnedChannel_users_UserPinnedId",
                        column: x => x.UserPinnedId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pinnedHups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPinnedChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPinnedId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 600, DateTimeKind.Utc).AddTicks(4271))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pinnedHups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pinnedHups_users_UserPinnedId",
                        column: x => x.UserPinnedId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PinnedPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPinnedChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserPinnedId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinnedPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PinnedPost_users_UserPinnedId",
                        column: x => x.UserPinnedId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChannelPinnedChannel",
                columns: table => new
                {
                    ChannelsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedChannelsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPinnedChannel", x => new { x.ChannelsId, x.PinnedChannelsId });
                    table.ForeignKey(
                        name: "FK_ChannelPinnedChannel_Channels_ChannelsId",
                        column: x => x.ChannelsId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelPinnedChannel_pinnedChannel_PinnedChannelsId",
                        column: x => x.PinnedChannelsId,
                        principalTable: "pinnedChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPinnedChannel",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedChannelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("5f1bfaa7-7871-4d79-b088-2dfe86f2f0b5"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 614, DateTimeKind.Local).AddTicks(8480))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedChannel", x => new { x.UserId, x.PinnedChannelId });
                    table.ForeignKey(
                        name: "FK_UserPinnedChannel_pinnedChannel_PinnedChannelId",
                        column: x => x.PinnedChannelId,
                        principalTable: "pinnedChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedChannel_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPinnedHub",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedHubId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("724631b1-f957-4c12-a630-5ce5f0d3de8f"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 616, DateTimeKind.Local).AddTicks(4924))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedHub", x => new { x.UserId, x.PinnedHubId });
                    table.ForeignKey(
                        name: "FK_UserPinnedHub_pinnedHups_PinnedHubId",
                        column: x => x.PinnedHubId,
                        principalTable: "pinnedHups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedHub_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPinnedPost",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PinnedPostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValue: new Guid("58681103-64e8-4d9d-91df-de732c8ee484"), collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 3, 11, 18, 51, 13, 618, DateTimeKind.Local).AddTicks(6225))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedPost", x => new { x.UserId, x.PinnedPostId });
                    table.ForeignKey(
                        name: "FK_UserPinnedPost_PinnedPost_PinnedPostId",
                        column: x => x.PinnedPostId,
                        principalTable: "PinnedPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedPost_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_posts_PinnedPostId",
                table: "posts",
                column: "PinnedPostId");

            migrationBuilder.CreateIndex(
                name: "IX_hubs_PinnedHubId",
                table: "hubs",
                column: "PinnedHubId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPinnedChannel_PinnedChannelsId",
                table: "ChannelPinnedChannel",
                column: "PinnedChannelsId");

            migrationBuilder.CreateIndex(
                name: "IX_pinnedChannel_UserPinnedId",
                table: "pinnedChannel",
                column: "UserPinnedId");

            migrationBuilder.CreateIndex(
                name: "IX_pinnedHups_UserPinnedId",
                table: "pinnedHups",
                column: "UserPinnedId");

            migrationBuilder.CreateIndex(
                name: "IX_PinnedPost_UserPinnedId",
                table: "PinnedPost",
                column: "UserPinnedId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_hubs_pinnedHups_PinnedHubId",
                table: "hubs",
                column: "PinnedHubId",
                principalTable: "pinnedHups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_PinnedPost_PinnedPostId",
                table: "posts",
                column: "PinnedPostId",
                principalTable: "PinnedPost",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hubs_pinnedHups_PinnedHubId",
                table: "hubs");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_PinnedPost_PinnedPostId",
                table: "posts");

            migrationBuilder.DropTable(
                name: "ChannelPinnedChannel");

            migrationBuilder.DropTable(
                name: "UserPinnedChannel");

            migrationBuilder.DropTable(
                name: "UserPinnedHub");

            migrationBuilder.DropTable(
                name: "UserPinnedPost");

            migrationBuilder.DropTable(
                name: "pinnedChannel");

            migrationBuilder.DropTable(
                name: "pinnedHups");

            migrationBuilder.DropTable(
                name: "PinnedPost");

            migrationBuilder.DropIndex(
                name: "IX_posts_PinnedPostId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_hubs_PinnedHubId",
                table: "hubs");

            migrationBuilder.DropColumn(
                name: "PinnedPostId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "PinnedHubId",
                table: "hubs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserUser",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 689, DateTimeKind.Local).AddTicks(3090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 682, DateTimeKind.Utc).AddTicks(9355),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(2803));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserRoom",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 689, DateTimeKind.Local).AddTicks(1062),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 619, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHubAnnouncement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("7b6f130e-ad15-4345-9570-26cf2f523212"),
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
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 688, DateTimeKind.Local).AddTicks(6595),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserHub",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("9ff08917-ca2e-4af3-8eec-981c893699cf"),
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
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 688, DateTimeKind.Local).AddTicks(9093),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 612, DateTimeKind.Utc).AddTicks(8767));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserChannelAnnoucement",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("7fae3ca9-c8b0-4741-a78a-6b86d6485cc0"),
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
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 681, DateTimeKind.Local).AddTicks(1813),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 605, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserChannel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 682, DateTimeKind.Local).AddTicks(8400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 607, DateTimeKind.Utc).AddTicks(1767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 16, 25, 0, 679, DateTimeKind.Local).AddTicks(4935),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 603, DateTimeKind.Utc).AddTicks(574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 679, DateTimeKind.Utc).AddTicks(3628),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 679, DateTimeKind.Utc).AddTicks(2650),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Plan",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 679, DateTimeKind.Utc).AddTicks(719),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 602, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "hubs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 677, DateTimeKind.Utc).AddTicks(3391),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(2953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Channels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 10, 14, 25, 0, 677, DateTimeKind.Utc).AddTicks(592),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 11, 16, 51, 13, 597, DateTimeKind.Utc).AddTicks(27));
        }
    }
}
