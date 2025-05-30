using Microsoft.AspNetCore.Mvc;
using Scheduling.DTOs.Servico;
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
        public async Task<ActionResult<ServiceResponse<List<ServicoReadDto>>>> GetServicos()
        {
            var result = await _servicoService.GetServicos();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ServicoReadDto>>> CreateServico([FromBody] ServicoCreateDto novoServico)
        {
            var result = await _servicoService.CreateServico(novoServico);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ServicoReadDto>>> GetServicoById(int id)
        {
            var result = await _servicoService.GetServicoById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ServicoReadDto>>> UpdateServico([FromBody] ServicoUpdateDto editadoServico)
        {
            var result = await _servicoService.UpdateServico(editadoServico);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteServico(int id)
        {
            var result = await _servicoService.DeleteServico(id);
            return Ok(result);
        }
    }
}
