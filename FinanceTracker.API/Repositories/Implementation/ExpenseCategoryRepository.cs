using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseCategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ExpenseCategory> AddExpenseCategoryAsync(ExpenseCategory expenseCategory)
        {
            await dbContext.expenseCategories.AddAsync(expenseCategory);
            await dbContext.SaveChangesAsync();
            return expenseCategory;
        }
    }
}
