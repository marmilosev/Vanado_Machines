using Microsoft.AspNetCore.Mvc;
using Vanado_Machines.Models;
using Vanado_Machines.Services;

namespace Vanado_Machines.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FailureController : Controller
    {
        private readonly IFailureService _failureService;
        public FailureController(IFailureService failureService)
        {
            _failureService = failureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFailures()
        {
            var result = await _failureService.GetAllFailures();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFailure(int id)
        {
            var result = await _failureService.GetFailureById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFailure([FromBody] Failure failure)
        {
            var result = await _failureService.CreateFailure(failure);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFailure([FromBody] Failure failure)
        {
            var result = await _failureService.UpdateFailure(failure);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFailure(int id)
        {
            var result = await _failureService.DeleteFailure(id);
            return Ok(result);
        }
    }
}
