using Microsoft.EntityFrameworkCore.Migrations;

namespace EventTicket.Services.ShoppingBasket.Migrations
{
    public partial class BasketLinePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "BasketLines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BasketLines");
        }
    }
}
