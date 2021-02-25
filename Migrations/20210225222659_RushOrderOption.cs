using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class RushOrderOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostLarge",
                table: "RushOrderOption",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CostMedium",
                table: "RushOrderOption",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CostSmall",
                table: "RushOrderOption",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostLarge",
                table: "RushOrderOption");

            migrationBuilder.DropColumn(
                name: "CostMedium",
                table: "RushOrderOption");

            migrationBuilder.DropColumn(
                name: "CostSmall",
                table: "RushOrderOption");
        }
    }
}
