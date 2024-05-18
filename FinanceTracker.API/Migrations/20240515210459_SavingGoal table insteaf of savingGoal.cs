using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class SavingGoaltableinsteafofsavingGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_expenseCategories_ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_savingGoals",
                table: "savingGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenseCategories",
                table: "expenseCategories");

            migrationBuilder.RenameTable(
                name: "savingGoals",
                newName: "SavingGoals");

            migrationBuilder.RenameTable(
                name: "expenseCategories",
                newName: "ExpenseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingGoals",
                table: "SavingGoals",
                column: "GoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories",
                column: "ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "ExpenseCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_ExpenseCategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingGoals",
                table: "SavingGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseCategories",
                table: "ExpenseCategories");

            migrationBuilder.RenameTable(
                name: "SavingGoals",
                newName: "savingGoals");

            migrationBuilder.RenameTable(
                name: "ExpenseCategories",
                newName: "expenseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_savingGoals",
                table: "savingGoals",
                column: "GoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenseCategories",
                table: "expenseCategories",
                column: "ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_expenseCategories_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId",
                principalTable: "expenseCategories",
                principalColumn: "ExpenseCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
