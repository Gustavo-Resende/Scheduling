using Scheduling.DTOs.Agendamento;
using Scheduling.Models;

namespace Scheduling.Service.AgendamentoService
{
    public interface IAgendamentoInterface
    {
        Task<ServiceResponse<List<AgendamentoReadDto>>> GetAgendamentos();
        Task<ServiceResponse<AgendamentoReadDto>> CreateAgendamento(AgendamentoCreateDto novoAgendamento);
        Task<ServiceResponse<AgendamentoReadDto>> GetAgendamentoById(int id);
        Task<ServiceResponse<AgendamentoReadDto>> UpdateAgendamento(AgendamentoUpdateDto editadoAgendamento);
        Task<ServiceResponse<bool>> DeleteAgendamento(int id);
    }
}
