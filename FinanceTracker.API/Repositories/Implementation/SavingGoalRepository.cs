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

        public async Task<SavingGoal?> EditSavingGoal(SavingGoal savingGoal)
        {
            var savingGoalToEdit = await dbContext.SavingGoals.FirstOrDefaultAsync(s => s.GoalId == savingGoal.GoalId);
            if (savingGoalToEdit == null)
                return null;

           dbContext.SavingGoals.Entry(savingGoalToEdit).CurrentValues.SetValues(savingGoal);
            await dbContext.SaveChangesAsync();
            return savingGoal;
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
