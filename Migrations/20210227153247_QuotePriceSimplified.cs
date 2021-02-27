using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class QuotePriceSimplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RushOrderPrice",
                table: "DeskQuote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RushOrderPrice",
                table: "DeskQuote",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
