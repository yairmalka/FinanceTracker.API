using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public enum TransactionType
    {
        Buy,
        Sell
    }
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public Guid PortfolioId { get; set; }
        [ForeignKey("PortfolioId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Portfolio Portfolio { get; set; }
        public Guid InstrumentId { get; set; }
        [ForeignKey("InstrumentId")]
        public virtual Instrument Instrument { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Order Order { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal fees { get; set; }
    }


}
