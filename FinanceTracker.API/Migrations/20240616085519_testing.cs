using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Assets_InstrumentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Assets_InstrumentId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "Instrument");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transactions",
                newName: "OrderAction");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument",
                column: "InstrumentId");

            migrationBuilder.CreateTable(
                name: "Portfolios_Instruments",
                columns: table => new
                {
                    Portfolio_InstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios_Instruments", x => x.Portfolio_InstrumentId);
                    table.ForeignKey(
                        name: "FK_Portfolios_Instruments_Instrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Instruments_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_Instruments_InstrumentId",
                table: "Portfolios_Instruments",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_Instruments_PortfolioId",
                table: "Portfolios_Instruments",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Instrument_InstrumentId",
                table: "Orders",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Instrument_InstrumentId",
                table: "Transactions",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Instrument_InstrumentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Instrument_InstrumentId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Portfolios_Instruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instrument",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Instrument",
                newName: "Assets");

            migrationBuilder.RenameColumn(
                name: "OrderAction",
                table: "Transactions",
                newName: "TransactionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Assets_InstrumentId",
                table: "Orders",
                column: "InstrumentId",
                principalTable: "Assets",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Assets_InstrumentId",
                table: "Transactions",
                column: "InstrumentId",
                principalTable: "Assets",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
