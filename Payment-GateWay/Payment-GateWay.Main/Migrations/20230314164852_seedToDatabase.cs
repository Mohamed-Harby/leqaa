using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Gateway.main.Migrations
{
    public partial class seedToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlanType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "PlanType", "Price", "User" },
                values: new object[,]
                {
                    { 5, "Premium", 5L, "palnUserName" },
                    { 10, "Premium", 10L, "palnUserName" },
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
