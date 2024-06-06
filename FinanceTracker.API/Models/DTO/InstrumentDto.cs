namespace FinanceTracker.API.Models.Domain
{
    public class InstrumentDto
    {
        public Guid InstrumentId { get; set; }
        public string TickerSymbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Currency { get; set; }

    }
}

