using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTracker.Migrations
{
    /// <inheritdoc />
    public partial class noForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_coins_Portfolios_PortfolioId",
                table: "coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Users_UserName",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_coins_CoinId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_coins",
                table: "coins");

            migrationBuilder.DropIndex(
                name: "IX_coins_PortfolioId",
                table: "coins");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "coins");

            migrationBuilder.RenameTable(
                name: "coins",
                newName: "Coins");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoinId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Portfolios",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioportfpolioId",
                table: "Coins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coins",
                table: "Coins",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Coins_PortfolioportfpolioId",
                table: "Coins",
                column: "PortfolioportfpolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_Portfolios_PortfolioportfpolioId",
                table: "Coins",
                column: "PortfolioportfpolioId",
                principalTable: "Portfolios",
                principalColumn: "portfpolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Users_UserName",
                table: "Portfolios",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Coins_CoinId",
                table: "Transactions",
                column: "CoinId",
                principalTable: "Coins",
                principalColumn: "CoinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_Portfolios_PortfolioportfpolioId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Users_UserName",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Coins_CoinId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coins",
                table: "Coins");

            migrationBuilder.DropIndex(
                name: "IX_Coins_PortfolioportfpolioId",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "PortfolioportfpolioId",
                table: "Coins");

            migrationBuilder.RenameTable(
                name: "Coins",
                newName: "coins");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoinId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Portfolios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PortfolioId",
                table: "coins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_coins",
                table: "coins",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_coins_PortfolioId",
                table: "coins",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_coins_Portfolios_PortfolioId",
                table: "coins",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "portfpolioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Users_UserName",
                table: "Portfolios",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_coins_CoinId",
                table: "Transactions",
                column: "CoinId",
                principalTable: "coins",
                principalColumn: "CoinId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
