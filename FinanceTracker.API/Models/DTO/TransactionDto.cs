using FinanceTracker.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.DTO
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }

        public Guid PortfolioId { get; set; }

        public Guid InstrumentId { get; set; }

        public Guid OrderId { get; set; }
        public TransactionType TransactionType { get; set; } //Enum of buy/sell
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal fees { get; set; }
    }
}
