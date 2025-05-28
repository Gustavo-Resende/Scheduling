using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Models;
using Scheduling.Service.BarbeiroService;
using Scheduling.Service.ClienteService;
using System.Threading.Tasks;

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
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> GetClientes()
        {
            return Ok(await _clienteInterface.GetClientes());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> CreateCliente(ClienteModel novoCliente)
        {
            return Ok(await _clienteInterface.CreateCliente(novoCliente));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> DeleteCliente(int id)
        {
            return Ok(await _clienteInterface.DeleteCliente(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> GetClientesById(int id)
        {
            return Ok(await _clienteInterface.GetClientesById(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> UpdateCliente(ClienteModel editadoCliente)
        {
            return Ok(await _clienteInterface.UpdateCliente(editadoCliente));
        }
    }
}
