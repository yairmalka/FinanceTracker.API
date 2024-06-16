using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateAsync(Expense expense);
        Task<Expense?> GetExpenseByIdAsync(Guid id);
        Task<Expense?> EditExpense(Expense expense);
        Task<IEnumerable<Expense>> GetAllExpensesAsync(); 
    }
}
