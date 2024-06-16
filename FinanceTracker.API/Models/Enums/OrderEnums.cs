namespace FinanceTracker.API.Models.Enums
{
    public class OrderEnums
    {
        public enum OrderAction
        {
            Buy,
            Sell
        }
        public enum OrderType
        {
            Limit,
            Market
        }

        public enum OrderStatus
        {
            Completed,
            Pending,
            Cancelled
        }
    }
}
