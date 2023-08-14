using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlternateKeyEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKeu_Email",
                table: "users",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKeu_Email",
                table: "users");
        }
    }
}
