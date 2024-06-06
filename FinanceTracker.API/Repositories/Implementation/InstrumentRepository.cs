using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class InstrumentRepository: IInstrumentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public InstrumentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Instrument?> GetInstrumentByTickerSymbol(string tickerSymbol)
        {
            return await dbContext.Instruments.FirstOrDefaultAsync(i => i.TickerSymbol == tickerSymbol);
        }
    }
}
