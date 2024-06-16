using FinanceTracker.API.Services.Interface;

namespace FinanceTracker.API.Services.Implementation
{
    public class LimitOrderService : BackgroundService
    {
        private readonly IOrderService orderService;

        public LimitOrderService(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await orderService.CheckLimitOrders(stoppingToken);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); //check every minute
            }
        }

    }
}
