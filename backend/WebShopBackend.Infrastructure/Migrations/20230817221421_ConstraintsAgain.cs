using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConstraintsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "products",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddCheckConstraint(
                name: "products_inventory_unsigned",
                table: "products",
                sql: "Inventory >= 0 AND Inventory < 65536");

            migrationBuilder.AddCheckConstraint(
                name: "products_price_unsigned",
                table: "products",
                sql: "Inventory >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "products_inventory_unsigned",
                table: "products");

            migrationBuilder.DropCheckConstraint(
                name: "products_price_unsigned",
                table: "products");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "products",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
