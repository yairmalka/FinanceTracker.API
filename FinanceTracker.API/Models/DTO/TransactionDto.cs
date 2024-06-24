using FinanceTracker.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Models.DTO
{
    public class TransactionDto
    {
        public string UserId { get; set; }

        public Guid PortfolioId { get; set; }

        public Guid InstrumentId { get; set; }

        public Guid OrderId { get; set; }
        public OrderAction OrderAction {  get; set; } 
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal fees { get; set; }
    }
}
