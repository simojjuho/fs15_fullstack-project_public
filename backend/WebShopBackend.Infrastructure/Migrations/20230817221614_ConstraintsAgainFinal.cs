using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConstraintsAgainFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "products_price_unsigned",
                table: "products");

            migrationBuilder.AddCheckConstraint(
                name: "products_price_unsigned",
                table: "products",
                sql: "Price >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "products_price_unsigned",
                table: "products");

            migrationBuilder.AddCheckConstraint(
                name: "products_price_unsigned",
                table: "products",
                sql: "Inventory >= 0");
        }
    }
}
