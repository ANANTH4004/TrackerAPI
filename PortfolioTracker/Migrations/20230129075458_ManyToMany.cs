using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTracker.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Portfolios",
                newName: "portfpolioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "coins",
                newName: "CoinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "portfpolioId",
                table: "Portfolios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CoinId",
                table: "coins",
                newName: "Id");
        }
    }
}
