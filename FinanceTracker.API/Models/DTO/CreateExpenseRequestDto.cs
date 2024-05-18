using FinanceTracker.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.DTO
{
    public class CreateExpenseRequestDto
    {
       // public Guid UserId { get; set; }
        //public Guid ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount { get; set; }
        public string ReceiptImageUrl { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }
    }
}
