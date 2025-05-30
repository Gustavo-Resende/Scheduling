using Scheduling.DTOs.Barbeiro;
using Scheduling.Models;

namespace Scheduling.Service.BarbeiroService
{
    public interface IBarbeiroInterface
    {
        Task<ServiceResponse<List<BarbeiroReadDto>>> GetBarbeiros();
        Task<ServiceResponse<BarbeiroReadDto>> CreateBarbeiro(BarbeiroCreateDto novoBarbeiro);
        Task<ServiceResponse<BarbeiroReadDto>> GetBarbeiroById(int id);
        Task<ServiceResponse<BarbeiroReadDto>> UpdateBarbeiro(BarbeiroUpdateDto editadoBarbeiro);
        Task<ServiceResponse<bool>> DeleteBarbeiro(int id);
        Task<ServiceResponse<BarbeiroReadDto>> InativaBarbeiro(int id);
        Task<ServiceResponse<BarbeiroReadDto>> AtivaBarbeiro(int id);
    }
}
