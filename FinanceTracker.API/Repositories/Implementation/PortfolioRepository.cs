using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PortfolioRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Portfolio?> GetPortfolioByUserId(string userId)
        {
            return await dbContext.Portfolios.FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
