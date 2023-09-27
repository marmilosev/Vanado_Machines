using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vanado_Machines.Services;

namespace Vanado_Machines.Controllers
{
    [Route("api/machines")]
    [ApiController]
    public class MachineController : ControllerBase
    {

        private readonly IMachineService _machineService;
        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMachines()
        {
            try { 
            var machines = await _machineService.GetMachines();
            return Ok(machines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
