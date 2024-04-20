using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class ExpenseDto
    {
        public Guid ExpenseId { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        //public User UserID { get; set; }
        public string ReceiptImageUrl { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }


        public ExpenseDto(Expense expense)
        {
            ExpenseId = expense.ExpenseId;
            DateOfExpense = expense.DateOfExpense;
            Amount = expense.Amount;
            Category = expense.Category;
            ReceiptImageUrl = expense.ReceiptImageUrl;
            Currency = expense.Currency;
            Location = expense.Location;
        }


    }
}
