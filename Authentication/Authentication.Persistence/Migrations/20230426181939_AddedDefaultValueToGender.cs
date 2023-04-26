using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Persistence.Migrations
{
    public partial class AddedDefaultValueToGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "ea648712-749e-4920-acda-91d0d607cef2");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7ccb0dbc-d6eb-49d5-acc5-0a8e8edf0562", 0, "93fe0601-70c3-460b-b25e-44e5e2465577", "Leqaa.Technical@gmail.com", true, 1, false, null, "Leqaa", "LEQAA.TECHNICAL@GMAIL.COM", "LEQAA", "AQAAAAEAACcQAAAAEEY/U+TJJH9maa1kyfDK6BefsxtHw6v5YUgMjWlZmjN1hYHUysb6BzTdEUk6CXeY1A==", null, false, "cec4f653-257f-4853-b9bc-11bee51b56ad", false, "Leqaa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: "7ccb0dbc-d6eb-49d5-acc5-0a8e8edf0562");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea648712-749e-4920-acda-91d0d607cef2", 0, "b504e802-f141-4a42-8faf-cc21a063e509", "Leqaa.Technical@gmail.com", true, 1, false, null, "Leqaa", "LEQAA.TECHNICAL@GMAIL.COM", "LEQAA", "AQAAAAEAACcQAAAAEJNSVXUZb9+D6+//1nUT8l4NQ7MyxQiRpqZ/hJeItejWjmYOqhVLFMfRX/neE0zhQA==", null, false, "73031b93-4497-4ddc-af62-e26ce7597ae9", false, "Leqaa" });
        }
    }
}
