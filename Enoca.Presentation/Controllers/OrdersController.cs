using Enoca.ApplicationLayer.Features.Orders.Command.CreateOrders;
using Enoca.ApplicationLayer.Features.Orders.Command.DeleteOrders;
using Enoca.ApplicationLayer.Features.Orders.Query.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetAllOrdersQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrders([FromBody] CreateOrdersRequest request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrders([FromBody] DeleteOrdersRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
