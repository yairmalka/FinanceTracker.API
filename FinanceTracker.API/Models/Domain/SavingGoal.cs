using FinanceTracker.API.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class SavingGoal
    {
        [Key]
        public Guid GoalId { get; set; }
        public string GoalName { get; set;}
        public long TargetAmount { get; set;}
        public long CurrentAmount { get; set;}
        public DateTime TargetDate { get; set; }


    }

   
}
