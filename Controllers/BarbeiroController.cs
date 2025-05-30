using Microsoft.AspNetCore.Mvc;
using Scheduling.DTOs.Barbeiro;
using Scheduling.Models;
using Scheduling.Service.BarbeiroService;

namespace Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeiroController : ControllerBase
    {
        private readonly IBarbeiroInterface _barbeiroInterface;
        public BarbeiroController(IBarbeiroInterface barbeiroInterface)
        {
            _barbeiroInterface = barbeiroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BarbeiroReadDto>>>> GetBarbeiros()
        {
            var result = await _barbeiroInterface.GetBarbeiros();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BarbeiroReadDto>>> CreateBarbeiro([FromBody] BarbeiroCreateDto novoBarbeiro)
        {
            var result = await _barbeiroInterface.CreateBarbeiro(novoBarbeiro);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBarbeiro(int id)
        {
            var result = await _barbeiroInterface.DeleteBarbeiro(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BarbeiroReadDto>>> GetBarbeiroById(int id)
        {
            var result = await _barbeiroInterface.GetBarbeiroById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BarbeiroReadDto>>> UpdateBarbeiro([FromBody] BarbeiroUpdateDto editadoBarbeiro)
        {
            var result = await _barbeiroInterface.UpdateBarbeiro(editadoBarbeiro);
            return Ok(result);
        }

        [HttpPut("Inativa/{id}")]
        public async Task<ActionResult<ServiceResponse<BarbeiroReadDto>>> InativaBarbeiro(int id)
        {
            var result = await _barbeiroInterface.InativaBarbeiro(id);
            return Ok(result);
        }

        [HttpPut("Ativa/{id}")]
        public async Task<ActionResult<ServiceResponse<BarbeiroReadDto>>> AtivaBarbeiro(int id)
        {
            var result = await _barbeiroInterface.AtivaBarbeiro(id);
            return Ok(result);
        }
    }
}
