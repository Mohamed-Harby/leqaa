using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Gateway.main.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "PlanType", "Price" },
                values: new object[,]
                {
                    { 5, "Premium", 1000L },
                    { 10, "Premium", 2000L },
                    { 15, "Premium", 3000L },
                    { 20, "Premium", 4000L },
                    { 25, "Premium", 5000L },
                    { 30, "Premium", 6000L },
                    { 35, "Premium", 7000L },
                    { 40, "Premium", 8000L },
                    { 45, "Premium", 9000L },
                    { 50, "Premium", 10000L },
                    { 55, "Premium", 11000L },
                    { 60, "Premium", 12000L },
                    { 65, "Premium", 13000L },
                    { 70, "Premium", 14000L },
                    { 75, "Premium", 15000L },
                    { 80, "Premium", 16000L },
                    { 85, "Premium", 17000L },
                    { 90, "Premium", 18000L },
                    { 95, "Premium", 19000L },
                    { 100, "Premium", 20000L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
