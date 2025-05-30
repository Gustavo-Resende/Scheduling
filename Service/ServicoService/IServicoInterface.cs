using Scheduling.DTOs.Servico;
using Scheduling.Models;

namespace Scheduling.Service.ServicoService
{
    public interface IServicoInterface
    {
        Task<ServiceResponse<List<ServicoReadDto>>> GetServicos();
        Task<ServiceResponse<ServicoReadDto>> CreateServico(ServicoCreateDto novoServico);
        Task<ServiceResponse<ServicoReadDto>> GetServicoById(int id);
        Task<ServiceResponse<ServicoReadDto>> UpdateServico(ServicoUpdateDto editadoServico);
        Task<ServiceResponse<bool>> DeleteServico(int id);
    }
}
