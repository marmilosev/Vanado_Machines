using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public interface IMachineService
    {
        public Task<IEnumerable<Machine>> GetMachines();
    }
}
