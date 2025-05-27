using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ServiceResponse<List<Barbeiro>>>> GetBarbeiros()
        {
            return Ok(await _barbeiroInterface.GetBarbeiros());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Barbeiro>>>> CreateBarbeiro(Barbeiro novoBarbeiro)
        {
            return Ok(await _barbeiroInterface.CreateBarbeiro(novoBarbeiro));
        }
    }
}
