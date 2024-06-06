using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IPortfolioRepository
    {
       public Task<Portfolio?> GetPortfolioByUserId(string userId);
    }
}
