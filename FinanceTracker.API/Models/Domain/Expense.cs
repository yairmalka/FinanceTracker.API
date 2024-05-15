using FinanceTracker.API.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Expense
    {
        [Key]
        public Guid ExpenseId { get; set; }
        public Guid UserId { get; set; }
        public Guid ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        public ExpenseCategory ExpenseCategory { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount {  get; set; }
        public string Category { get; set; }
        public string ReceiptImageUrl { get; set; }
        public string Currency {  get; set; }
        public string Location { get; set; }   

    }

 
}
