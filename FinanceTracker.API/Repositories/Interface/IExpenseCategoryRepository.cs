using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IExpenseCategoryRepository
    {
        Task<ExpenseCategory> AddExpenseCategoryAsync(ExpenseCategory expenseCategory);
        Task<IEnumerable<ExpenseCategory>> GetAllExpenseCategoriesAsync();
        Task<ExpenseCategory?> GetExpenseCategoryByIdAsync(Guid id);
        Task<ExpenseCategory?> EditExpenseCategory(ExpenseCategory expenseCategory);
        Task<IEnumerable<ExpenseCategory>> SeedExpenseCategoriesAsync();
    }
}
