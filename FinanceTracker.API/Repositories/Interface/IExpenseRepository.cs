using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateAsync(Expense expense);

    }
}
