using Scheduling.Models;

namespace Scheduling.Service.ClienteService
{
    public interface IClienteInterface
    {
        Task<ServiceResponse<List<ClienteModel>>> GetClientes();
        Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente);
        Task<ServiceResponse<List<ClienteModel>>> GetClientesById(int id);
        Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel editadoCliente);
        Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int id);
    }
}
