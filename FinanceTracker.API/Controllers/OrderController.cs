using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Repositories.Implementation;
using FinanceTracker.API.Repositories.Interface;
using FinanceTracker.API.Services.Implementation;
using FinanceTracker.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderService orderService, IOrderRepository orderRepository)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
        }

        [HttpPost("PlaceAnOrder")]
        public async Task<IActionResult> PlaceAnOrder(OrderDto request)
        {
            var order = new Order
            {
                UserId = request.UserId,
                InstrumentId = request.InstrumentId,
                TickerSymbol = request.TickerSymbol,
                OrderAction = request.OrderAction,
                OrderType = request.OrderType,
                OrderStatus = OrderStatus.Pending,
                LimitPrice = request.LimitPrice,
                Quantity = request.Quantity,
                CreatedAt = DateTime.Now,
                StatusMessage = ""
            };

            try
            {
                order = await orderRepository.AddNewOrder(order);

                var orderResponseDto = await orderService.PlaceAnOrder(order);
                return Ok(orderResponseDto);
            

            } catch (InvalidOperationException ex) {
                order.StatusMessage = ex.Message;
                await orderRepository.CancelOrder(order);
                return BadRequest(ex.Message);

            } catch (DivideByZeroException ex)
            {
                order.StatusMessage = ex.Message;
                await orderRepository.CancelOrder(order);
                return BadRequest(ex.Message);
            }

        }


    }
}
