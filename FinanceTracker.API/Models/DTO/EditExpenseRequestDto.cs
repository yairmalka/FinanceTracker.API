using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class EditExpenseRequestDto
    {
        public Guid ExpenseCategoryId { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount { get; set; }
        public string ReceiptImageUrl { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }
    }
}
