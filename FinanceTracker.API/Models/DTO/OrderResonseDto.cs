using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Models.DTO
{
    public class OrderResonseDto
    {
        public string TickerSymbol { get; set; }
        public string OrderId { get; set; }
        public OrderAction OrderAction { get; set; }
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal SharePrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ExecutedAt { get; set; }
        public string StatusMessage { get; set; }



    }
}
