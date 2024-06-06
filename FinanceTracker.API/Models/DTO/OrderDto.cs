using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class OrderDto
    {
        public Guid OrderTypeId { get; set; }
        public string UserId { get; set; }
        public Guid InstrumentId { get; set; }
        public OrderAction OrderAction { get; set; } //Enum of Buy/Sell
        public OrderType OrderType { get; set; } //Enum of Limit/Market
        public decimal LimitPrice { get; set; }
        public decimal Quantity { get; set; }
    }


}
