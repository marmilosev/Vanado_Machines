﻿using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public class MachineService : IMachineService
    {
        private readonly IDbService _dbService;
        private readonly string _connectionString;
        public MachineService(IDbService dbService, IConfiguration configuration)
        {
            _dbService = dbService;
#pragma warning disable CS8601 // Possible null reference assignment.
            _connectionString = configuration.GetConnectionString("MachineDBConnection");
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        public async Task<bool> CreateMachine(Machine machine)
        {
            var result =
                await _dbService.EditData(
                       "INSERT INTO public.machine (id, name) VALUES (@Id, @Name)",
                       machine);
            return true;
        }

        public async Task<bool> DeleteMachine(int id)
        {
            var deleteMachine = await _dbService.EditData("DELETE FROM public.machine WHERE id=@Id", new { id });
            return true;
        }

        public async Task<List<Machine>> GetAllMachines()
        {
            var machineList = await _dbService.GetAll<Machine>("SELECT * FROM public.machine", new { });
            return machineList;
        }

        public async Task<Machine> GetMachineById(int id)
        {
            var machineById = await _dbService.GetAsync<Machine>("SELECT * FROM public.machine where id=@Id", new { id });
            return machineById;
        }

        public async Task<Machine> UpdateMachine(Machine machine)
        {
            var updateMachine =
                await _dbService.EditData(
                    "UPDATE public.machine SET name=@Name WHERE id=@Id",
                    machine);
            return machine;
        }

       public async Task<List<Failure>> GetFailuresForMachine (int machineId)
        {
            var failuresList = await _dbService.GetAll<Failure>(
                "SELECT f.* FROM failure f INNER JOIN failure_machine fm ON f.id = fm.failure_id WHERE fm.machine_id = @MachineId",
                new { MachineId = machineId });
            return failuresList;
        }

           
    }
}
