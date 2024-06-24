using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Models.Domain
{
    public class OrderDto
    {
        public string UserId { get; set; }
        public Guid InstrumentId { get; set; }

        public string TickerSymbol { get; set; }
        public OrderAction OrderAction { get; set; } //Enum of Buy/Sell
        public OrderType OrderType { get; set; } //Enum of Limit/Market
        public decimal LimitPrice { get; set; }
        public decimal Quantity { get; set; }
    }


}
