using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;

namespace FinanceTracker.API.Services.Interface
{
    public interface IOrderService
    {
        public Task<OrderResonseDto> PlaceAnOrder(Order order);
        public Task<OrderResonseDto> CheckLimitOrders(CancellationToken cancellationToken);
    }
}
