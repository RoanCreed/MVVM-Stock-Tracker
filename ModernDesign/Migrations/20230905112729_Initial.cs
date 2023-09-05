using Microsoft.EntityFrameworkCore.Migrations;

namespace ModernDesign.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockName = table.Column<string>(nullable: false),
                    Shares = table.Column<int>(nullable: false),
                    ReturnInvestment = table.Column<float>(nullable: false),
                    AvgBuyPrice = table.Column<float>(nullable: false),
                    CurrentBuyPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
