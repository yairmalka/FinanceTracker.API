using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Services.Interface
{
    public interface IInstrumentService
    {
        public Task<Dictionary<string, object>> GetInstrumentDataByTickerSymbol(string tickerSymbol);
       // public Task<Instrument> 
    }
}
