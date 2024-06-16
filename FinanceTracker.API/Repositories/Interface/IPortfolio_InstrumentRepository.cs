using FinanceTracker.API.Models.Domain;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IPortfolio_InstrumentRepository
    {
    
        public Task<Portfolio_Instrument?> CreatePortfolio_InstrumentEntry(Portfolio_Instrument portfolio_instrument, OrderAction orderAction);
        public Task<decimal?> GetQuantityOfInstrumentByPortfolioIdAndInstrumentId(Guid portfolioId, Guid instrumentId);
    }
}
