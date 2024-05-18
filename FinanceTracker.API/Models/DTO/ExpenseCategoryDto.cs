using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class ExpenseCategoryDto
    {
        public Guid ExpenseCategoryId { get; set; }
        public string CategoryExpenseName { get; set; }

        public ExpenseCategoryDto(ExpenseCategory expenseCategory)
        {
            ExpenseCategoryId = expenseCategory.ExpenseCategoryId;
            CategoryExpenseName = expenseCategory.CategoryExpenseName;
        }


    }
}
