using FinanceTracker.API.Models.Domain;
using System.Collections;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateAsync(Expense expense);
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(Guid id);
        Task<Expense?> EditExpense(Expense expense);
    }
}
