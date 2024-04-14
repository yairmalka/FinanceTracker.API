using FinanceTracker.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FinanceTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
