using Microsoft.AspNetCore.Mvc;
using Scheduling.DTOs.Agendamento;
using Scheduling.Models;
using Scheduling.Service.AgendamentoService;

namespace Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoInterface _agendamentoInterface;

        public AgendamentoController(IAgendamentoInterface agendamentoInterface)
        {
            _agendamentoInterface = agendamentoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AgendamentoReadDto>>>> GetAgendamentos()
        {
            var result = await _agendamentoInterface.GetAgendamentos();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AgendamentoReadDto>>> CreateAgendamento([FromBody] AgendamentoCreateDto novoAgendamento)
        {
            var result = await _agendamentoInterface.CreateAgendamento(novoAgendamento);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AgendamentoReadDto>>> GetAgendamentoById(int id)
        {
            var result = await _agendamentoInterface.GetAgendamentoById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<AgendamentoReadDto>>> UpdateAgendamento([FromBody] AgendamentoUpdateDto editadoAgendamento)
        {
            var result = await _agendamentoInterface.UpdateAgendamento(editadoAgendamento);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAgendamento(int id)
        {
            var result = await _agendamentoInterface.DeleteAgendamento(id);
            return Ok(result);
        }
    }
}
