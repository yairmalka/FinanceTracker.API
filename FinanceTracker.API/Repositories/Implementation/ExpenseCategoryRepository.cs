using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
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
            await dbContext.ExpenseCategories.AddAsync(expenseCategory);
            await dbContext.SaveChangesAsync();
            return expenseCategory;
        }


        async Task<ExpenseCategory?> IExpenseCategoryRepository.EditExpenseCategory(ExpenseCategory expenseCategory)
        {
            var expenseCategoryToEdit = await dbContext.ExpenseCategories.FirstOrDefaultAsync(ec => ec.ExpenseCategoryId == expenseCategory.ExpenseCategoryId);

            if (expenseCategoryToEdit == null)
                return null;

            dbContext.Entry(expenseCategoryToEdit).CurrentValues.SetValues(expenseCategory);

            await dbContext.SaveChangesAsync();

            return expenseCategoryToEdit;
        }
    

        async Task<IEnumerable<ExpenseCategory>> IExpenseCategoryRepository.GetAllExpenseCategoriesAsync()
        {
            return await dbContext.ExpenseCategories.ToListAsync();
        }

        async Task<ExpenseCategory?> IExpenseCategoryRepository.GetExpenseCategoryByIdAsync(Guid id)
        {
            return await dbContext.ExpenseCategories.FirstOrDefaultAsync(ec => ec.ExpenseCategoryId == id);
        }

        public async Task<IEnumerable<ExpenseCategory>> SeedExpenseCategoriesAsync()
        {
            var expenseCategories = new List<ExpenseCategory>
            {
                new ExpenseCategory { CategoryExpenseName = "Groceries"},
                new ExpenseCategory { CategoryExpenseName = "Utilities"},
                new ExpenseCategory { CategoryExpenseName = "Rent/Mortgage"},
                new ExpenseCategory { CategoryExpenseName = "Transportation"},
                new ExpenseCategory { CategoryExpenseName = "Entertainment"},
                new ExpenseCategory { CategoryExpenseName = "Dining Out"},
                new ExpenseCategory { CategoryExpenseName = "Medical/Healthcare"},
                new ExpenseCategory { CategoryExpenseName = "Insurance"},
                new ExpenseCategory { CategoryExpenseName = "Education"},
                new ExpenseCategory { CategoryExpenseName = "Clothing"},
                new ExpenseCategory { CategoryExpenseName = "Personal Care"},
                new ExpenseCategory { CategoryExpenseName = "Travel"},
                new ExpenseCategory { CategoryExpenseName = "Savings/Investments"},
                new ExpenseCategory { CategoryExpenseName = "Gifts/Donations"},
                new ExpenseCategory { CategoryExpenseName = "Other"},
            };
            // check if the ExpenseCategory table is already seeded
            if(!await dbContext.ExpenseCategories.AnyAsync()) 
            {
                await dbContext.ExpenseCategories.AddRangeAsync(expenseCategories);
                await dbContext.SaveChangesAsync();
            }

            return expenseCategories;
        }
    }
}
