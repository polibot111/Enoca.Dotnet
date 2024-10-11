using Enoca.ApplicationLayer.Features.Carriers.Command.CreateCarriers;
using Enoca.ApplicationLayer.Features.Carriers.Command.DeleteCarriers;
using Enoca.ApplicationLayer.Features.Carriers.Command.UpdateCarriers;
using Enoca.ApplicationLayer.Features.Carriers.Query.GetAllCarriers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarriersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarriers([FromQuery] GetAllQueryCarriersRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarriers([FromBody] CreateCarriersRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarriers([FromBody] UpdateCarriersRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarriers([FromBody] DeleteCarriersRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
