using Scheduling.Models;

namespace Scheduling.Service.BarbeiroService
{
    public interface IBarbeiroInterface
    {
        Task<ServiceResponse<List<Barbeiro>>> GetBarbeiros();
        Task<ServiceResponse<List<Barbeiro>>> CreateBarbeiro(Barbeiro novoBarbeiro);
        Task<ServiceResponse<List<Barbeiro>>> GetBarbeirosById(int id);
        Task<ServiceResponse<List<Barbeiro>>> UpdateBarbeiro(Barbeiro editadoBarbeiro);
        Task<ServiceResponse<List<Barbeiro>>> DeleteBarbeiro(int id);
        Task<ServiceResponse<List<Barbeiro>>> InativaBarbeiro(int id);
    }
}
