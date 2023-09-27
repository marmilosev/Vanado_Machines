using Dapper;
using Vanado_Machines.Context;
using Vanado_Machines.Models;

namespace Vanado_Machines.Services
{
    public class MachineService : IMachineService
    {
        private readonly DapperContext _context;
        public MachineService(DapperContext context) => _context = context;

        public async Task<IEnumerable<Machine>> GetMachines()
        {
            var query = "SELECT * FROM public.machine";
            using (var connection = _context.CreateConnection())
            {
                var machines = await connection.QueryAsync<Machine>(query);
                return machines.ToList();
            }
        }
    }
}
