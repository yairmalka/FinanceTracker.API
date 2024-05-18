using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class AddSavingGoalDto
    {
        public Guid GoalId { get; set; }
        public string GoalName { get; set; }
        public long TargetAmount { get; set; }
        public long CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }

        public AddSavingGoalDto() { }
        public AddSavingGoalDto(SavingGoal savingGoal)
        {
            GoalId = savingGoal.GoalId;
            GoalName = savingGoal.GoalName;
            TargetAmount = savingGoal.TargetAmount;
            CurrentAmount = savingGoal.CurrentAmount;
            TargetDate = savingGoal.TargetDate;
        }

    }
}
