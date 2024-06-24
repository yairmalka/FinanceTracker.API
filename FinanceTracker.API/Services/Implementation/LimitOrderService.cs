using FinanceTracker.API.Services.Interface;

namespace FinanceTracker.API.Services.Implementation
{
    public class LimitOrderService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        public LimitOrderService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using(var scope = serviceProvider.CreateScope())
                {
                    var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();
                    await orderService.CheckLimitOrders(stoppingToken);
                }
                
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); //check every minute
            }
        }


    }
}

