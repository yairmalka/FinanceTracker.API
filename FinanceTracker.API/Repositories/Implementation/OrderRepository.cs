using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories.Implementation
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        public async Task<Order?> Addorder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            // saveChanges will be combined by UnitOfWork Repo
            return order;
        }

        
    }
}
