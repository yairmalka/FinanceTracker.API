using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Portfolio_Instrument
    {
        [Key]
        public Guid Portfolio_InstrumentId { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid InstrumentId { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }
        [ForeignKey("InstrumentId")]
        public virtual Instrument Instrument { get; set; }


    }
}
