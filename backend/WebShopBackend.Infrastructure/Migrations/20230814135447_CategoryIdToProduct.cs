using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIdToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "product_category_id",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_products_product_category_id",
                table: "products",
                column: "product_category_id");

            migrationBuilder.AddForeignKey(
                name: "fk_products_product_category_product_category_id",
                table: "products",
                column: "product_category_id",
                principalTable: "product_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_products_product_category_product_category_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "ix_products_product_category_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "product_category_id",
                table: "products");
        }
    }
}
