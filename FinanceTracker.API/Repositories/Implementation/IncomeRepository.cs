using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class IncomeRepository : IIncomeRepository
    {

        readonly DbContext dbContext;
        public IncomeRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Income> AddIncomeAsync(Income income)
        {
            dbContext.AddAsync(income);
            dbContext.SaveChangesAsync();

            return income;
        }
    }
}
