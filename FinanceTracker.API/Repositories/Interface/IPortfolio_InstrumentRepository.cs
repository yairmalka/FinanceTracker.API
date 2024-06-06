using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IPortfolio_InstrumentRepository
    {
    
        public Task<Portfolio_Instrument?> CreatePortfolio_InstrumentEntry(Portfolio_Instrument portfolio_instrument);
    }
}
