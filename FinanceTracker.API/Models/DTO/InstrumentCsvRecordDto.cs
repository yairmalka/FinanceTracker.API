namespace FinanceTracker.API.Models.DTO
{
    public class InstrumentCsvRecordDto
    {
        public string TickerSymbol { get; set; }
        public string Name { get; set; }
        public string CurrentPrice { get; set; } //this is a string because it includes the '$' sign
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
    }
}
