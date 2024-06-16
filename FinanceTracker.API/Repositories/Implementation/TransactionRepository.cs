using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Transaction?> CreateNewTransactionAsync(Transaction transaction)
        {
            await dbContext.Transactions.AddAsync(transaction);
            // save changes will occur in one command with multiple tables
            return transaction;
        }
    }
}
