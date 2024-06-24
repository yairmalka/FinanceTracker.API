using FinanceTracker.API.Models.Domain;
using Instrument = FinanceTracker.API.Models.Domain.Instrument;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IInstrumentRepository
    {
        public Task<Instrument?> GetInstrumentByTickerSymbol(string tickerSymbol);

        public Task SeedInstrumentsFromCsvAsync(string csvFilePath);

    }
}
