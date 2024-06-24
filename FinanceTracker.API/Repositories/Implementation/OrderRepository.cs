using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        public async Task<Order?> AddNewOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order?>> GetPendingLimitOrders()
        {
         return await dbContext.Orders.Where(o=> o.OrderStatus == OrderStatus.Pending && o.OrderType == OrderType.Limit).ToListAsync();
        }

        public async Task<Order?> CancelOrder(Order order)
        {
            order.OrderStatus = OrderStatus.Cancelled;
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> CompleteOrder(Order order)
        {
            order.OrderStatus = OrderStatus.Completed;
            order.StatusMessage = "Completed Successfully.";

            return order;
        }
    }
}
