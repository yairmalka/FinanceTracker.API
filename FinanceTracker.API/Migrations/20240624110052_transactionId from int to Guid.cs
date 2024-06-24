using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class transactionIdfrominttoGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            // Drop the existing TransactionId column
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transactions");

            // Add the new TransactionId column with Guid type
            migrationBuilder.AddColumn<Guid>(
                name: "TransactionId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            // Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            // Drop the Guid column
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transactions");

            // Add the old TransactionId column with int type
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");
        }
    }
}
