using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class SavingGoalRepository : ISavingGoalRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SavingGoalRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        async Task<SavingGoal> ISavingGoalRepository.AddSavingGoalAsync(SavingGoal savingGoal)
        {
            await dbContext.SavingGoals.AddAsync(savingGoal);
            await dbContext.SaveChangesAsync();

            return savingGoal;

        }

        async Task<IEnumerable<SavingGoal>> ISavingGoalRepository.GetAllSavingGoalAsync()
        {
            return await dbContext.SavingGoals.ToListAsync();
        }

        async Task<SavingGoal?> ISavingGoalRepository.GetSavingGoalByIdAsync(Guid id)
        {
            return await dbContext.SavingGoals.FirstOrDefaultAsync(sg => sg.GoalId == id);
        }
    }
}
