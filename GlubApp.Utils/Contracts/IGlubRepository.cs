using GlubApp.Entities;
using GlubApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Utils.Contracts
{
    public interface IGlubRepository
    {
        public Task<IEnumerable<Aircraft>> GetAllAircrafts();
        public Task<IEnumerable<Aircraft>> GetAllFlyingAircrafts();
        public Task<Aircraft> GetAircraftByPlate(string plate);
        public Task CreateAircraft(AircraftDTO aircraft);
        public Task UpdateAircraft(AircraftDTO aircraft);
        public Task ChangeFlyingState(string plate);
        public Task DeleteAircraft(string plate);

    }
}
