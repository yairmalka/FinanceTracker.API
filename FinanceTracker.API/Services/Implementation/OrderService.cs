using FinanceTracker.API.Data;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
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
        public async Task<OrderResonseDto> PlaceAnOrder(Order order)
        {
            if(order.Quantity == 0)
                throw new DivideByZeroException("Quaintity is 0, Order can't be completed.");

            if (order.Quantity < 0)
                throw new InvalidOperationException("Quantity must be positive.");

            var instrumentData = await instrumentService.GetInstrumentDataByTickerSymbol(order.TickerSymbol);
            if (instrumentData == null || !instrumentData.ContainsKey("RegularMarketPrice"))
            {
                throw new InvalidOperationException("Instrument not found.");
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
                   return await ExecuteOrder(order, totalCost);
                }

                else if(order.OrderType == OrderType.Limit)
                {
                    if(order.LimitPrice <= (decimal)regularMarketPrice)
                    {
                        return await ExecuteOrder(order, totalCost);
                    }
                }
            }

            //FIX IT:
            return new OrderResonseDto();

        }

        public async Task<OrderResonseDto> CheckLimitOrders(CancellationToken cancellationToken)
        {
            var limitOrders = await GetPendingLimitOrders();
            foreach(var order in limitOrders)
            {
                var instrumentData = await instrumentService.GetInstrumentDataByTickerSymbol(order.TickerSymbol);
                if(instrumentData != null && instrumentData.ContainsKey("RegularMarketPrice"))
                {
                    double regularMarketPrice = (double)instrumentData["RegularMarketPrice"];
                    if(order.OrderAction == OrderAction.Buy && regularMarketPrice <= (double)order.LimitPrice)
                    {
                        return await ExecuteOrder(order, (decimal)regularMarketPrice);
                    }

                    else if(order.OrderAction == OrderAction.Sell && regularMarketPrice >= (double)order.LimitPrice)
                    {
                        return await ExecuteOrder(order, (decimal)regularMarketPrice);
                    }
                    if(DateTime.UtcNow - order.CreatedAt > TimeSpan.FromHours(12))
                    {
                        return await CancelOrder(order);
                    }
                }
            }
            //FIX IT:
            return new OrderResonseDto();
        }

        private async Task<OrderResonseDto> ExecuteOrder(Order order, decimal totalCost)
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
            
            return new OrderResonseDto
            {
                TickerSymbol = order.TickerSymbol,
                OrderId = order.OrderId.ToString(),
                OrderAction = order.OrderAction,
                OrderType = order.OrderType,
                OrderStatus = OrderStatus.Completed,
                SharePrice = (totalCost / order.Quantity),
                Quantity = order.Quantity,
                ExecutedAt = DateTime.Now,
                StatusMessage = "Order completed succesfully."
            };
        }

        private async Task<OrderResonseDto> CancelOrder(Order order)
        {
             await orderRepository.CancelOrder(order);
            return new OrderResonseDto
            {
                TickerSymbol = order.TickerSymbol,
                OrderId = order.OrderId.ToString(),
                OrderAction = order.OrderAction,
                OrderStatus = OrderStatus.Cancelled,
                StatusMessage = "Order not completed."
            };
        }

        private async Task<IEnumerable<Order?>> GetPendingLimitOrders()
        {
           return await orderRepository.GetPendingLimitOrders();
        }
    }
}
