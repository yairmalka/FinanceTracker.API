using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Models.Domain
{
    public class ExpenseCategory
    {
     [Key]
     public Guid ExpenseCategoryId {  get; set; }
     public string CategoryExpenseName { get; set; }

    }
}

