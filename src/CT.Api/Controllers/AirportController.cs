using System;
using System.Linq;
using System.Threading.Tasks;
using CT.Api.Models;
using CT.Common;
using CT.Common.Extensions;
using CT.Service;
using Microsoft.AspNetCore.Mvc;

namespace CT.Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly AirportService _service;

        public AirportController(AirportService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CaculateDistance([FromBody] DistanceInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sourceAir = await _service.GetAirport(model.SourceCode) ?? throw new Exception("Source entry is null");
            var targetAir = await _service.GetAirport(model.TargetCode) ?? throw new Exception("Target entry is null");
            var betweenDist = sourceAir.location.GetDistance(targetAir.location);

            return Ok(betweenDist);
        }

    }
}
