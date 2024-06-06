using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Services.Interface
{
    public interface IInstrumentService
    {
        public Task<Dictionary<string, object>> GetInstrumentDataByName(string tickerSymbol);
       // public Task<Instrument> 
    }
}
