using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.CreateCarrierConfigurations;
using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.DeleteCarrierConfigurations;
using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.UpdateCarrierConfigurations;
using Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarrierConfigurations([FromQuery] GetAllQueryCarrierConfigurationsRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrierConfigurations([FromBody] CreateCarrierConfigurationsRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrierConfigurations([FromBody] UpdateCarrierConfigurationsRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCarrierConfigurations([FromBody] DeleteCarrierConfigurationsRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
