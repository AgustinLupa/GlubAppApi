using GlubApp.Entities;
using GlubApp.Entities.DTOs;
using GlubApp.Utils.Contracts;
using Microsoft.AspNetCore.Components.Web;
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
        public async Task<IActionResult> CreateAircraft([FromBody] NewAircraftDTO aircraft)
        {
            await _glubRepo.CreateAircraft(aircraft);

            return Ok();
        }

        [HttpPut("{plate}")]
        public async Task<IActionResult> ChangeFlyingState(string plate)
        {
            var search = await _glubRepo.GetAircraftByPlate(plate);
            if (search is null)
                return NotFound();

            await _glubRepo.ChangeFlyingState(plate);

            return Ok();
        }

        [HttpDelete("{plate}")]
        public async Task<IActionResult> DeleteAircraft(string plate)
        {
            var aircraft = await _glubRepo.GetAircraftByPlate(plate);
            if (aircraft is null)
                return NotFound();

            await _glubRepo.DeleteAircraft(plate);

            return Ok();
        }

        [HttpGet("{plate}", Name = "GetByPlate")]
        public async Task<IActionResult> GetAircraftByPlate(string plate)
        {
            var aircraft= await _glubRepo.GetAircraftByPlate(plate);
            if (aircraft is null)
                return NotFound();

            return Ok(aircraft);
        }

        [Route("getallflying")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlyingAircraft()
        {
            var aircraft = await _glubRepo.GetAllFlyingAircrafts();

            return Ok(aircraft);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAircraft([FromBody]AircraftDTO aircraft)
        {
            var search = await _glubRepo.GetAircraftByPlate(aircraft.Plate);
            if (search is null)
                return NotFound();

            await _glubRepo.UpdateAircraft(aircraft);
            return Ok();
        }

        [HttpPut]
        [Route("geolocation")]
        public async Task<IActionResult> UpdatePosition([FromBody] PositionDTO position)
        {
            var search = await _glubRepo.GetAircraftByPlate(position.Plate);
            if (search is null)
                return NotFound();

            await _glubRepo.UpdatePosition(position);
            return Ok();
        }
    }
}
