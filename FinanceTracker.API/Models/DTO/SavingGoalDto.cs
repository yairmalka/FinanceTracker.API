using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class SavingGoalDto
    {

        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public string UserId { get; set; }
        public long TargetAmount { get; set; }
        public long CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }

        public SavingGoalDto(SavingGoal savingGoal)
        {
            GoalId = savingGoal.GoalId;
            GoalName = savingGoal.GoalName;
            UserId = savingGoal.UserId;
            TargetAmount = savingGoal.TargetAmount;
            CurrentAmount = savingGoal.CurrentAmount;
            TargetDate = savingGoal.TargetDate;
        }

        
    }
}
