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
    }
}
