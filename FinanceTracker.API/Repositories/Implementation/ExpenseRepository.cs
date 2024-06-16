using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class ExpenseRepository : IExpenseRepository
    {

        private readonly ApplicationDbContext dbContext;

        public ExpenseRepository(ApplicationDbContext dbContext) { 
        this.dbContext = dbContext;
        }
        public async Task<Expense> CreateAsync(Expense expense)
        {
            await dbContext.Expenses.AddAsync(expense);
            await dbContext.SaveChangesAsync();
            
            return expense;
        }


        public async Task<Expense?> GetExpenseByIdAsync(Guid id)
        {
            return await dbContext.Expenses.FirstOrDefaultAsync(e => e.ExpenseId == id);
        }

        public async Task<Expense?> EditExpense(Expense expense)
        {
            var expenseToEdit = await dbContext.Expenses.FirstOrDefaultAsync(e => e.ExpenseId == expense.ExpenseId);

            if (expenseToEdit == null)
                return null;

            dbContext.Entry(expenseToEdit).CurrentValues.SetValues(expense);
            await dbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await dbContext.Expenses.ToListAsync();
        }
    }
}
