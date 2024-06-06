using FinanceTracker.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.DTO
{
    public class Portfolio_InstrumentDto
    {
            public Guid Portfolio_InstrumentId { get; set; }
            public Guid PortfolioId { get; set; }
            public decimal Quantity { get; set; }
            public Guid InstrumentId { get; set; }
    }
}
