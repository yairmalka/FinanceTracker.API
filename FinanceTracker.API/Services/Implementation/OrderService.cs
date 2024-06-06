using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Implementation;
using FinanceTracker.API.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinanceTracker.API.Services.Implementation
{
    public class OrderService: IOrderService
    {
        private readonly InstrumentService _instrumentSerive;
        private readonly PortfolioRepository portfolioRepository;
        private readonly InstrumentRepository instrumentRepository;

        public OrderService(InstrumentService instrumentSerive, PortfolioRepository portfolioRepository, InstrumentRepository instrumentRepository)
        {
            _instrumentSerive = instrumentSerive;
            this.portfolioRepository = portfolioRepository;
            this.instrumentRepository = instrumentRepository;
        }
        public async Task<Order> PlaceAnOrder(Order order)
        {
            // I think it won't work the order.Instrument.TickerSymbol but lets give it a try
            var instrumentData = await _instrumentSerive.GetInstrumentDataByName(order.Instrument.TickerSymbol);
            
            if (order.OrderAction == OrderAction.Buy)
            {
                if(order.OrderType == OrderType.Market)
                {

                    if (instrumentData != null && instrumentData.ContainsKey("RegularMarketPrice"))
                    {
                        double regularMarketPrice = (double)instrumentData["RegularMarketPrice"];
                        decimal totalCost = order.Quantity * (decimal)regularMarketPrice;

                        Portfolio? portfolio = await portfolioRepository.GetPortfolioByUserId(order.UserId);
                        if (portfolio != null)
                        {
                            if(portfolio.AvailableCash >= totalCost)
                            {
                                portfolio.AvailableCash -= totalCost;
                                Instrument? instrument = await instrumentRepository.GetInstrumentByTickerSymbol(order.Instrument.TickerSymbol);
                                if(instrument == null)
                                {
                                    throw new InvalidOperationException("Instrument not found in the database");
                                }
                                Portfolio_Instrument portfolio_InstrumentEntry = new Portfolio_Instrument
                                {
                                    PortfolioId = portfolio.PortfolioId,
                                    InstrumentId = instrument.InstrumentId,
                                    Quantity = order.Quantity

                                };
                            }
                            else
                            {
                                throw new InvalidOperationException("Insufficient  funds");
                            }
                        }
                    }
                }
            }

        }
    }
}
