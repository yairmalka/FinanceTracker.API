using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.API.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<SavingGoal> SavingGoals { get; set; }
        public ICollection<Portfolio> Portfolios { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
