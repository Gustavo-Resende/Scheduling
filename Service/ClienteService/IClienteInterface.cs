using Scheduling.DTOs.Cliente;
using Scheduling.Models;

namespace Scheduling.Service.ClienteService
{
    public interface IClienteInterface
    {
        Task<ServiceResponse<List<ClienteReadDto>>> GetClientes();
        Task<ServiceResponse<ClienteReadDto>> CreateCliente(ClienteCreateDto novoCliente);
        Task<ServiceResponse<ClienteReadDto>> GetClienteById(int id);
        Task<ServiceResponse<ClienteReadDto>> UpdateCliente(ClienteUpdateDto editadoCliente);
        Task<ServiceResponse<bool>> DeleteCliente(int id);
    }
}
