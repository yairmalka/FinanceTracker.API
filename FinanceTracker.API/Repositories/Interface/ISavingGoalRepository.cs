using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface ISavingGoalRepository
    {

        Task<SavingGoal> AddSavingGoalAsync(SavingGoal savingGoal);
        Task<IEnumerable<SavingGoal>> GetAllSavingGoalAsync();

        Task<SavingGoal?> GetSavingGoalByIdAsync(Guid id);
        Task<SavingGoal?> EditSavingGoal(SavingGoal savingGoal);
    }
}
