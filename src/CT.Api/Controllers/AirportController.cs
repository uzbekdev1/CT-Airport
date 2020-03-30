using System;
using System.Collections.Generic;
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
        private readonly RestService _service;

        public AirportController(RestService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Values()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("calc-dist")]
        public async Task<IActionResult> CaculateDistance([FromBody]DistanceInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sourceAir = await _service.GetAirport(model.SourceCode) ?? throw new AppException("Source entry is null");
            var targetAir = await _service.GetAirport(model.TargetCode) ?? throw new AppException("Target entry is null");

            var betweenDist = sourceAir.location.GetDistance(targetAir.location);

            return Ok($"{betweenDist:0.######}");
        }

    }
}
