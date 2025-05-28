using Scheduling.Models;

namespace Scheduling.Service.ServicoService
{
    public interface IServicoInterface
    {
        Task<ServiceResponse<List<Servico>>> GetServicos();
        Task<ServiceResponse<List<Servico>>> CreateServico(Servico novoServico);
        Task<ServiceResponse<List<Servico>>> GetServicoById(int id);
        Task<ServiceResponse<List<Servico>>> UpdateServico(Servico editadoServico);
        Task<ServiceResponse<List<Servico>>> DeleteServico(int id);

    }
}
