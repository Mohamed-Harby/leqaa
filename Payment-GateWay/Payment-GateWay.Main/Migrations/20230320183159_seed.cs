using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Gateway.main.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "PlanType", "Price", "User" },
                values: new object[,]
                {
                    { 15, "Premium", 15L, "palnUserName" },
                    { 20, "Premium", 20L, "palnUserName" },
                    { 25, "Premium", 25L, "palnUserName" },
                    { 30, "Premium", 30L, "palnUserName" },
                    { 35, "Premium", 35L, "palnUserName" },
                    { 40, "Premium", 40L, "palnUserName" },
                    { 45, "Premium", 45L, "palnUserName" },
                    { 50, "Premium", 50L, "palnUserName" },
                    { 55, "Premium", 55L, "palnUserName" },
                    { 60, "Premium", 60L, "palnUserName" },
                    { 65, "Premium", 65L, "palnUserName" },
                    { 70, "Premium", 70L, "palnUserName" },
                    { 75, "Premium", 75L, "palnUserName" },
                    { 80, "Premium", 80L, "palnUserName" },
                    { 85, "Premium", 85L, "palnUserName" },
                    { 90, "Premium", 90L, "palnUserName" },
                    { 95, "Premium", 95L, "palnUserName" },
                    { 100, "Premium", 100L, "palnUserName" }
                });
        }
    }
}
