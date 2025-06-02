using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scheduling.Data;
using Scheduling.DTOs.Cliente;
using Scheduling.Models;

namespace Scheduling.Service.ClienteService
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ClienteReadDto>> CreateCliente(ClienteCreateDto dto)
        {
            var response = new ServiceResponse<ClienteReadDto>();
            try
            {
                // Verifica se já existe CPF ou Email igual
                bool cpfExiste = await _context.Clientes.AnyAsync(c => c.Cpf == dto.Cpf);
                if (cpfExiste)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Já existe um cliente com este CPF.";
                    return response;
                }

                bool emailExiste = await _context.Clientes.AnyAsync(c => c.Email == dto.Email);
                if (emailExiste)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Já existe um cliente com este e-mail.";
                    return response;
                }

                var cliente = _mapper.Map<ClienteModel>(dto);
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<ClienteReadDto>(cliente);
                response.Sucesso = true;
                response.Mensagem = "Cliente criado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao criar cliente: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteCliente(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Cliente não encontrado.";
                    response.Dados = false;
                    return response;
                }
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                response.Dados = true;
                response.Sucesso = true;
                response.Mensagem = "Cliente excluído com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Dados = false;
                response.Mensagem = $"Erro ao excluir cliente: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<ClienteReadDto>>> GetClientes()
        {
            var response = new ServiceResponse<List<ClienteReadDto>>();
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                response.Dados = _mapper.Map<List<ClienteReadDto>>(clientes);
                response.Sucesso = true;
                response.Mensagem = "Clientes obtidos com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao obter clientes: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<ClienteReadDto>> GetClienteById(int id)
        {
            var response = new ServiceResponse<ClienteReadDto>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Cliente não encontrado.";
                    return response;
                }
                response.Dados = _mapper.Map<ClienteReadDto>(cliente);
                response.Sucesso = true;
                response.Mensagem = "Cliente obtido com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao obter cliente: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<ClienteReadDto>> UpdateCliente(ClienteUpdateDto editadoCliente)
        {
            var response = new ServiceResponse<ClienteReadDto>();
            try
            {
                var cliente = await _context.Clientes.FindAsync(editadoCliente.Id);
                if (cliente == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Cliente não encontrado.";
                    return response;
                }
                _mapper.Map(editadoCliente, cliente);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<ClienteReadDto>(cliente);
                response.Sucesso = true;
                response.Mensagem = "Cliente atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao atualizar cliente: {ex.Message}";
            }
            return response;
        }
    }
}
