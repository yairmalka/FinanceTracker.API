﻿using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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
    }
}