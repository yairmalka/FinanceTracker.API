using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IIncomeRepository
    {
        Task<Income> AddIncomeAsync(Income income);
    }
}
