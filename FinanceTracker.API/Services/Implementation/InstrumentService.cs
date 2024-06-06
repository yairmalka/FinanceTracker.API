using FinanceTracker.API.Services.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using YahooFinanceApi;

namespace FinanceTracker.API.Services.Implementation
{
    public class InstrumentService: IInstrumentService
    {
        public async Task<Dictionary<string, object>> GetInstrumentDataByName(string tickerSymbol)
        {
            try
            {
                var fields = new[]
                {
                    Field.Symbol,
                    Field.RegularMarketPrice,
                    Field.Currency
                };
                var securities = await Yahoo.Symbols(tickerSymbol).Fields(fields).QueryAsync();
                var security = securities[tickerSymbol];

                var stockData = new Dictionary<string, object>
                {
                    { "symbol", security[Field.Symbol] },
                    { "RegularMarketPrice", security[Field.RegularMarketPrice]},
                    { "Currency", security[Field.Currency] }
                };
                return stockData;
            }
            //FIX IT: need to do it using logger and not by using Console.writeLine
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching stock data: {ex.Message}");
                return null;
            }
        }
    }
}
