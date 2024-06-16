using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class Portfolio_InstrumentRepository: IPortfolio_InstrumentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public Portfolio_InstrumentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Portfolio_Instrument> CreatePortfolio_InstrumentEntry(Portfolio_Instrument portfolio_instrument, OrderAction orderAction)
        {
            var existingEntry = await dbContext.Portfolios_Instruments
                .FirstOrDefaultAsync(pi => pi.PortfolioId == portfolio_instrument.PortfolioId && pi.InstrumentId == portfolio_instrument.InstrumentId);
            if (existingEntry != null)
            {
                if (orderAction == OrderAction.Buy)
                    existingEntry.Quantity += portfolio_instrument.Quantity;

                else if (orderAction == OrderAction.Sell)
                    existingEntry.Quantity -= portfolio_instrument.Quantity;
            }
            
            else
            {
                await dbContext.Portfolios_Instruments.AddAsync(portfolio_instrument);
            }

            await dbContext.SaveChangesAsync();

            return portfolio_instrument;
        }

        public async Task<decimal?> GetQuantityOfInstrumentByPortfolioIdAndInstrumentId(Guid portfolioId, Guid instrumentId)
        {
            var desiredPortfolio_instrument = await dbContext.Portfolios_Instruments
                .FirstOrDefaultAsync(pi => pi.PortfolioId == portfolioId && pi.InstrumentId == instrumentId);
            if (desiredPortfolio_instrument == null)
                return 0;

            return desiredPortfolio_instrument.Quantity;
        }
    }
}
