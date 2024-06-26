﻿namespace FinanceTracker.API.Models.Domain
{
    public class InstrumentDto
    {
        public Guid InstrumentId { get; set; }
        public string TickerSymbol { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }

        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Currency { get; set; }

    }
}

