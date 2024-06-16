using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

        public async Task SeedInstrumentsFromCsvAsync(string csvFilePath)
        {
            if(!await dbContext.Instruments.AnyAsync())
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                }))
                {
                    var records = csv.GetRecords<InstrumentCsvRecordDto>().ToList();
                    var instruments = records.Select(record => new Instrument
                    {
                        TickerSymbol = record.TickerSymbol,
                        CurrentPrice = decimal.Parse(record.CurrentPrice.Replace("$", string.Empty)),
                        Country = record.Country,
                        Industry = record.Industry,
                        Name = record.Name,
                        Sector = record.Sector,
                        Currency = "USD"
                    }).ToList();

                    await dbContext.Instruments.AddRangeAsync(instruments);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
