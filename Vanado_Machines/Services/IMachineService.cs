using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public interface IMachineService
    {
        Task<bool> CreateMachine(Machine machine);
        Task<List<Machine>> GetAllMachines();
        Task<Machine> UpdateMachine(Machine machine);
        Task<bool> DeleteMachine(int key);
    }
}
