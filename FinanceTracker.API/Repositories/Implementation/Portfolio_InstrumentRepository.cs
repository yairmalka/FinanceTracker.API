using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class Portfolio_InstrumentRepository: IPortfolio_InstrumentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public Portfolio_InstrumentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Portfolio_Instrument> CreatePortfolio_InstrumentEntry(Portfolio_Instrument portfolio_instrument)
        {
            await dbContext.Portfolios_Instruments.AddAsync(portfolio_instrument);
            return portfolio_instrument;
        }
    }
}
