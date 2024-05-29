using FinanceTracker.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Models.DTO
{
    public class ExpenseDto
    {
        public Guid ExpenseId { get; set; }
        public string UserId { get; set; }
        public Guid ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount { get; set; }
        public string ReceiptImageUrl { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }




        public ExpenseDto(Expense expense)
        {
            ExpenseId = expense.ExpenseId;
            UserId = expense.UserId;
            DateOfExpense = expense.DateOfExpense;
            Amount = expense.Amount;
            ReceiptImageUrl = expense.ReceiptImageUrl;
            Currency = expense.Currency;
            Location = expense.Location;
        }


    }
}
