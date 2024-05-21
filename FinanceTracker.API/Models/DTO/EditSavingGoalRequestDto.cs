namespace FinanceTracker.API.Models.DTO
{
    public class EditSavingGoalRequestDto
    {
        public string GoalName { get; set; }
        public long TargetAmount { get; set; }
        public long CurrentAmount { get; set; }
        public DateTime TargetDate { get; set; }

    }
}
