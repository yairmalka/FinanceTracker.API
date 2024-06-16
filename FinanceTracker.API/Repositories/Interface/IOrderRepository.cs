using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IOrderRepository
    {
        public Task<Order?> SaveOrder(Order order);

        public Task<IEnumerable<Order?>> GetPendingLimitOrders();
        public Task<Order?> CancelOrder(Order order);
        public Task<Order?> CompleteOrder(Order order);
    }
}
