using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Implementation;
using FinanceTracker.API.Repositories.Interface;
using FinanceTracker.API.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Services.Implementation
{
    public class OrderService: IOrderService
    {
        public const int COMMISION_RATE = 0;

        private readonly IInstrumentService instrumentService;
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IPortfolio_InstrumentRepository portfolio_InstrumentRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly ApplicationDbContext dbContext;

        public OrderService(IInstrumentService instrumentService, IPortfolioRepository portfolioRepository,
            IOrderRepository orderRepository, IPortfolio_InstrumentRepository portfolio_InstrumentRepository,
            ITransactionRepository transactionRepository, ApplicationDbContext dbContext)
        {
            this.instrumentService = instrumentService;
            this.portfolioRepository = portfolioRepository;
            this.orderRepository = orderRepository;
            this.portfolio_InstrumentRepository = portfolio_InstrumentRepository;
            this.transactionRepository = transactionRepository;
            this.dbContext = dbContext;
        }
        public async Task<Order> PlaceAnOrder(Order order)
        {
            // I think it won't work the order.Instrument.TickerSymbol but lets give it a try
            var instrumentData = await instrumentService.GetInstrumentDataByName(order.Instrument.TickerSymbol);
            if (instrumentData == null || !instrumentData.ContainsKey("RegularMarketPrice"))
            {
                throw new InvalidOperationException("Instrument not found");
            }
            double regularMarketPrice = (double)instrumentData["RegularMarketPrice"];
            Portfolio? portfolio = await portfolioRepository.GetPortfolioByUserId(order.UserId);

            if (portfolio == null)
            {
                throw new InvalidOperationException("Portfolio not found");
            }

            if(order.OrderAction == OrderAction.Buy)
            {
                decimal totalCost = order.Quantity * (decimal)regularMarketPrice;

                if(order.OrderType == OrderType.Market)
                {
                    await ExecuteOrder(order, totalCost);
                }

                else if(order.OrderType == OrderType.Limit)
                {
                    if(order.LimitPrice <= (decimal)regularMarketPrice)
                    {
                        await ExecuteOrder(order, totalCost);
                    }
                }
            }
            //FIX IT: return something else rather than the order, please think about what should be returned later on.
            return order;
        }

        public async Task CheckLimitOrders(CancellationToken cancellationToken)
        {
            var limitOrders = await GetPendingLimitOrders();
            foreach(var order in limitOrders)
            {
                var instrumentData = await instrumentService.GetInstrumentDataByName(order.Instrument.TickerSymbol);
                if(instrumentData != null && instrumentData.ContainsKey("RegularMarketPrice"))
                {
                    double regularMarketPrice = (double)instrumentData["RegularMarketPrice"];
                    if(order.OrderAction == OrderAction.Buy && regularMarketPrice <= (double)order.LimitPrice)
                    {
                        await ExecuteOrder(order, (decimal)regularMarketPrice);
                    }

                    else if(order.OrderAction == OrderAction.Sell && regularMarketPrice >= (double)order.LimitPrice)
                    {
                        await ExecuteOrder(order, (decimal)regularMarketPrice);
                    }
                    if(DateTime.UtcNow - order.CreatedAt > TimeSpan.FromHours(12))
                    {
                        await CancelOrder(order);
                    }
                }
            }
        }

        private async Task<Order> ExecuteOrder(Order order, decimal totalCost)
        {
            Portfolio? portfolio = await portfolioRepository.GetPortfolioByUserId(order.UserId);
            if (portfolio == null)
            {
                throw new InvalidOperationException("Portfolio not found");
            }

            if(order.OrderAction == OrderAction.Buy)
            {
                if(portfolio.AvailableCash >= totalCost)          
                    portfolio.AvailableCash -= totalCost;

                else
                   throw new InvalidOperationException("There is no enough cash to complete the order.");
            }

            else if(order.OrderAction == OrderAction.Sell)
            {
                var quantityToSell = await portfolio_InstrumentRepository.GetQuantityOfInstrumentByPortfolioIdAndInstrumentId(portfolio.PortfolioId, order.InstrumentId);
                if (quantityToSell == 0) // there is no quantity at all
                    throw new InvalidOperationException("There is no such an instrument in your portfolio.");

                else if (quantityToSell < order.Quantity)
                {
                        throw new InvalidOperationException("Insufficient quantity in your portfolio to complete the order.");
                }
            }

            var portfolio_instrumentEntry = new Portfolio_Instrument
            {
                        PortfolioId = portfolio.PortfolioId,
                        InstrumentId = order.InstrumentId,
                        Quantity = order.Quantity
            };


            var transactionEntry = new Transaction
            {
                UserId = portfolio.UserId,
                PortfolioId = portfolio.PortfolioId,
                InstrumentId = order.InstrumentId,
                OrderId = order.OrderId,
                OrderAction = order.OrderAction,
                Date = DateTime.Now,
                Quantity = order.Quantity,
                Price = totalCost,
                fees = COMMISION_RATE
            };

            await portfolio_InstrumentRepository.CreatePortfolio_InstrumentEntry(portfolio_instrumentEntry, order.OrderAction);
            await transactionRepository.CreateNewTransactionAsync(transactionEntry);
            await orderRepository.CompleteOrder(order);

            await dbContext.SaveChangesAsync();
            return order;
        }

        private async Task<Order?> CancelOrder(Order order)
        {
            return await orderRepository.CancelOrder(order);
        }

        private async Task<IEnumerable<Order?>> GetPendingLimitOrders()
        {
           return await orderRepository.GetPendingLimitOrders();
        }
    }
}
