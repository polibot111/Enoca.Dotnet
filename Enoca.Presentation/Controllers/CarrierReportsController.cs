using Enoca.ApplicationLayer.Features.CarrierReports.Command.CreateCarrierReports;
using Enoca.ApplicationLayer.Features.CarrierReports.Query.GetAllCarrierReports;
using Enoca.ApplicationLayer.Features.Carriers.Command.CreateCarriers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarrierReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarrierConfigurations([FromQuery] GetAllQueryCarrierReportsRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarriers([FromBody] CreateCarrierReportsRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
