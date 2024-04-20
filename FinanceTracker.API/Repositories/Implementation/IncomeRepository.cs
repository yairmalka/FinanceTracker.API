using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.API.Data;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class IncomeRepository : IIncomeRepository
    {

        readonly ApplicationDbContext dbContext;
        public IncomeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Income> AddIncomeAsync(Income income)
        {
            await dbContext.Incomes.AddAsync(income);
            await dbContext.SaveChangesAsync();

            return income;
        }
    }
}
