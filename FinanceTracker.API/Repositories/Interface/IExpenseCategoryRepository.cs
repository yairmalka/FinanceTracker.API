using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IExpenseCategoryRepository
    {
        Task<ExpenseCategory> AddExpenseCategoryAsync(ExpenseCategory expenseCategory);
        Task<IEnumerable<ExpenseCategory>> GetAllExpenseCategoriesAsync();
        Task<ExpenseCategory?> GetExpenseCategoryByIdAsync(Guid id);
    }
}
