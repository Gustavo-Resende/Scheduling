using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling.Models;
using Scheduling.Service.ServicoService;

namespace Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoInterface _servicoService;
        public ServicoController(IServicoInterface servicoService)
        {
            _servicoService = servicoService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Servico>>>> GetServicos()
        {
            return Ok(await _servicoService.GetServicos());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Servico>>>> CreateServico(Servico novoServico)
        {
            return Ok(await _servicoService.CreateServico(novoServico));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Servico>>>> GetServicoById(int id)
        {
            return Ok(await _servicoService.GetServicoById(id));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Servico>>>> UpdateServico(Servico editadoServico)
        {
            return Ok(await _servicoService.UpdateServico(editadoServico));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Servico>>>> DeleteServico(int id)
        {
            return Ok(await _servicoService.DeleteServico(id));
        }
    }
}
