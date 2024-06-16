using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Services.Interface
{
    public interface IOrderService
    {
        public Task<Order> PlaceAnOrder(Order order);

        public Task CheckLimitOrders(CancellationToken cancellationToken);
    }
}
