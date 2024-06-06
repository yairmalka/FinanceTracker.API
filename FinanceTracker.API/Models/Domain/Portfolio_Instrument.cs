using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Portfolio_Instrument
    {
        public Guid Portfolio_InstrumentId { get; set; }
        public Guid PortfolioId { get; set; }
        public decimal Quantity { get; set; }
        public Guid InstrumentId { get; set; }
        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }
        [ForeignKey("InstrumentId")]
        public virtual Instrument Instrument { get; set; }
    }
}
