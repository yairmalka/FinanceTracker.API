using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Instrument
    {
        [Key]
        public Guid InstrumentId { get; set; }
        public string TickerSymbol { get; set; }
        public decimal CurrentPrice { get; set; }


    }
}

