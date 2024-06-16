
using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface ITransactionRepository
    {
        public Task<Transaction?> CreateNewTransactionAsync(Transaction transaction);
    }
}
