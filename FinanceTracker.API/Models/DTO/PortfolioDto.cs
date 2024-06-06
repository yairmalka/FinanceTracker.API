using FinanceTracker.API.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.DTO
{
    public class PortfolioDto
    {
        public Guid PortfolioId { get; set; }
        public string UserId { get; set; }
        public decimal TotalValue { get; set; }
        public decimal AvailableCash { get; set; }
    }
}
