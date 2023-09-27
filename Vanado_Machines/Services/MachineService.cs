using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public class MachineService : IMachineService
    {
        private readonly IDbService _dbService;
        public MachineService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateMachine(Machine machine)
        {
            var existingMachine = await _dbService.GetAsync<Machine>("SELECT * FROM public.machine WHERE name = @Name", new { machine.Name });

            if (existingMachine != null)
            {
                return false;
            }

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
            //var machine = await _dbService.GetAsync<Machine>("SELECT * FROM public.machine WHERE id = @Id", new { id });
            //if (machine == null)
            //{
            //    return null;
            //}

            //var failures = await _failureService.GetFailuresById(id);
            //machine.failures = failures;

            //double averageDuration = failures.Average(failure => (failure.EndTime - failure.StartTime).TotalHours);
            //machine.AverageFailureDuration = averageDuration;

            //return machine;
        }

        public async Task<Machine> UpdateMachine(Machine machine)
        {
            var updateMachine =
                await _dbService.EditData(
                    "UPDATE public.machine SET name=@Name WHERE id=@Id",
                    machine);
            return machine;
        }
    }
}