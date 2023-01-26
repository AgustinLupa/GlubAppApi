using GlubApp.Entities.DTOs;
using GlubApp.Utils.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlubApp.API.Controllers
{
    [Route("api/aircrafts")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IGlubRepository _glubRepo;

        public AircraftController(IGlubRepository glubRepo) => _glubRepo = glubRepo;

        [HttpGet]
        public async Task<IActionResult> GetAllAircraft()
        {
            var aircraft = await _glubRepo.GetAllAircrafts();

            return Ok(aircraft);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAircraft([FromBody] AircraftDTO aircraft)
        {
            await _glubRepo.CreateAircraft(aircraft);

            return Ok();
        }


    }
}
