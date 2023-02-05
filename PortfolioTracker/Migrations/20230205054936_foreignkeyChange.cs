using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTracker.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_Portfolios_PortfolioportfpolioId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Users_UserName",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Coins_PortfolioportfpolioId",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "PortfolioportfpolioId",
                table: "Coins");

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
                table: "Coins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Coins_PortfolioId",
                table: "Coins",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coins_Portfolios_PortfolioId",
                table: "Coins",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coins_Portfolios_PortfolioId",
                table: "Coins");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Users_UserName",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Coins_PortfolioId",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Coins");

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
        }
    }
}
