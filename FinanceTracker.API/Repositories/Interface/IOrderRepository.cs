using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface IOrderRepository
    {
        public Task<Order?> Addorder(Order order);
    }
}
