using FinanceTracker.API.Models.DTO;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Expense
    {
        [Key]
        public Guid ExpenseId { get; set; }
        public Guid ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        public ExpenseCategory ExpenseCategory { get; set; }
        public string UserId { get; set; }
       
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount {  get; set; }
        public string ReceiptImageUrl { get; set; }
        public string Currency {  get; set; }
        public string Location { get; set; }   




    }

    
}
