using Scheduling.Data;
using Scheduling.Models;

namespace Scheduling.Service.ClienteService
{
    public class ClienteService : IClienteInterface
    {

        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> CreateCliente(ClienteModel novoCliente)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                if (novoCliente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Cliente não pode ser nulo!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }
                _context.Clientes.Add(novoCliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Cliente criado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao criar cliente: {ex.Message}";
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ClienteModel>>> DeleteCliente(int id)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Cliente não encontrado.";
                    return serviceResponse;
                }
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Cliente excluído com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao excluir cliente: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> GetClientes()
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Clientes obtidos com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao obter clientes: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> GetClientesById(int id)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Cliente não encontrado.";
                    return serviceResponse;
                }
                serviceResponse.Dados = new List<ClienteModel> { cliente };
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Cliente obtido com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao obter cliente: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClienteModel>>> UpdateCliente(ClienteModel editadoCliente)
        {
            ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == editadoCliente.Id);
                if (cliente == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Cliente não encontrado.";
                    return serviceResponse;
                }
                cliente.Nome = editadoCliente.Nome;
                // FAZER LÓGICA TELEFONE 00 00000-0000
                cliente.Telefone = editadoCliente.Telefone;
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Clientes.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Cliente atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao atualizar cliente: {ex.Message}";
            }
            return serviceResponse;
        }
    }
}
