using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IExpenseCategoryRepository
    {
        Task<ExpenseCategory> AddExpenseCategoryAsync(ExpenseCategory expenseCategory);
    }
}
