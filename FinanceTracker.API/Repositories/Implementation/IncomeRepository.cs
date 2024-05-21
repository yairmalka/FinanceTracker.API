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

        public async Task<Income?> EditIncome(Income income)
        {
            var incomeToEdit = await dbContext.Incomes.FirstOrDefaultAsync(i => i.IncomeId == income.IncomeId);
            if (incomeToEdit == null)
                return null;

            dbContext.Incomes.Entry(incomeToEdit).CurrentValues.SetValues(income);
            await dbContext.SaveChangesAsync();

            return income;
        }

        public async Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            return await dbContext.Incomes.ToListAsync();
        }

        public async Task<Income?> GetIncomeByIdAsync(Guid id)
        {
            return await dbContext.Incomes.FirstOrDefaultAsync(i => i.IncomeId == id);
        }
    }
}
