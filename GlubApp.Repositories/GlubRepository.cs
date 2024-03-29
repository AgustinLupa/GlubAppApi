﻿using Dapper;
using GlubApp.Data;
using GlubApp.Entities;
using GlubApp.Entities.DTOs;
using GlubApp.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GlubApp.Repositories
{
    public class GlubRepository : IGlubRepository
    {
        private readonly GlubContext _context;
        public GlubRepository(GlubContext context)
        {
            _context = context;
        }

        public async Task ChangeFlyingState(string plate)
        {
            const string procedureName = "ChangeFlyingState";
            var parameters = new DynamicParameters();
            parameters.Add("plate", plate, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task CreateAircraft(NewAircraftDTO aircraft)
        {
            const string procedureName = "NewAircraft";
            var parameters = new DynamicParameters();
            parameters.Add("plate", aircraft.Plate, DbType.String, ParameterDirection.Input);
            //parameters.Add("newplate", aircraft.NewPlate, DbType.String, ParameterDirection.Input);
            parameters.Add("airType", aircraft.AircraftType, DbType.Boolean, ParameterDirection.Input);
            parameters.Add("isFlying", aircraft.isFlying, DbType.Boolean, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteAircraft(string plate)
        {
            const string procedureName = "DeleteAircraft";
            var parameters = new DynamicParameters();
            parameters.Add("plate", plate, DbType.String, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Aircraft> GetAircraftByPlate(string plate)
        {
            plate = plate.Trim().ToUpper();
            const string procedureName= "GetAircraftFromPlate";
            var parameters = new DynamicParameters();
            parameters.Add("plate", plate, DbType.String, ParameterDirection.Input);

            using (var cnn = _context.CreateConnection())
            {
                var aircraft = await cnn.QuerySingleOrDefaultAsync<Aircraft>(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);

                return aircraft;
            }
        }

        public async Task<IEnumerable<Aircraft>> GetAllAircrafts()
        {
            const string procedureName= "GetAircraft";

            using (var connection = _context.CreateConnection())
            {
                var aircrafts = await connection.QueryAsync<Aircraft>(procedureName,
                    commandType: CommandType.StoredProcedure);

                return aircrafts.ToList();
            }
        }

        public async Task<IEnumerable<Aircraft>> GetAllFlyingAircrafts()
        {
            const string procedureName= "GetAircraftFlying";

            using (var cnn = _context.CreateConnection())
            {
                var aircrafts = await cnn.QueryAsync<Aircraft>(procedureName, 
                    commandType: CommandType.StoredProcedure);

                return aircrafts.ToList();
            }
        }

        public async Task UpdateAircraft(AircraftDTO aircraft)
        {
            const string procedureName= "ModifAircraft";
            var parameters = new DynamicParameters();
            parameters.Add("plate", aircraft.Plate, DbType.String, ParameterDirection.Input);
            parameters.Add("newplate", aircraft.NewPlate, DbType.String, ParameterDirection.Input);
            parameters.Add("airType", aircraft.AircraftType, DbType.Byte, ParameterDirection.Input);

            using (var cnn = _context.CreateConnection())
            {
                await cnn.ExecuteAsync(procedureName, parameters, 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdatePosition(PositionDTO position)
        {
            const string procedureName = "UpdatePosition";
            var parameters = new DynamicParameters();
            parameters.Add("plate", position.Plate, DbType.String, ParameterDirection.Input);
            parameters.Add("latitude", position.Latitude, DbType.Double, ParameterDirection.Input);
            parameters.Add("longitude", position.Longitude, DbType.Double, ParameterDirection.Input);            

            using (var cnn = _context.CreateConnection())
            {
                await cnn.ExecuteAsync(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
