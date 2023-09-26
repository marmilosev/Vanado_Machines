using Microsoft.AspNetCore.Mvc;
using Vanado_Machines.Models;
using Vanado_Machines.Services;

namespace Vanado_Machines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;
        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            var result = await _machineService.GetAllMachines();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMachine(int id)
        {
            var result = await _machineService.GetMachineById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMachine([FromBody] Machine machine)
        {
            var result = await _machineService.CreateMachine(machine);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMachine([FromBody] Machine machine)
        {
            var result = await _machineService.UpdateMachine(machine);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var result = await _machineService.DeleteMachine(id);
            return Ok(result);
        }

        [HttpGet("{id:int}/failures")]
        public async Task<IActionResult> GetMachineFailures(int id)
        {
            var machine = await _machineService.GetMachineById(id);
            if(machine == null)
            {
                return NotFound();
            }
            var failures = await _machineService.GetFailuresForMachine(id);
            var averageDuration = failures.Any()
                ? TimeSpan.FromTicks((long)failures.Average(f => f.EndTime.Ticks - f.StartTime.Ticks))
                :TimeSpan.Zero;
            var result = new
            {
                Machine = machine,
                Failures = failures,
                averageDuration = averageDuration
            };
            return Ok(result);
        }
    }
}
