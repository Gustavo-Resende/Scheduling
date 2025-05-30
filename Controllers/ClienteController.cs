using Microsoft.AspNetCore.Mvc;
using Scheduling.DTOs.Cliente;
using Scheduling.Models;
using Scheduling.Service.ClienteService;

namespace Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;
        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ClienteReadDto>>>> GetClientes()
        {
            var result = await _clienteInterface.GetClientes();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ClienteReadDto>>> CreateCliente([FromBody] ClienteCreateDto novoCliente)
        {
            var result = await _clienteInterface.CreateCliente(novoCliente);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteCliente(int id)
        {
            var result = await _clienteInterface.DeleteCliente(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ClienteReadDto>>> GetClienteById(int id)
        {
            var result = await _clienteInterface.GetClienteById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ClienteReadDto>>> UpdateCliente([FromBody] ClienteUpdateDto editadoCliente)
        {
            var result = await _clienteInterface.UpdateCliente(editadoCliente);
            return Ok(result);
        }
    }
}
