using FinanceTracker.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FinanceTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<SavingGoal> SavingGoals { get; set; }




    }
}
