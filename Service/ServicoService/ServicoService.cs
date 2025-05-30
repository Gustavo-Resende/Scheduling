using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scheduling.Data;
using Scheduling.DTOs.Servico;
using Scheduling.Models;

namespace Scheduling.Service.ServicoService
{
    public class ServicoService : IServicoInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServicoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ServicoReadDto>> CreateServico(ServicoCreateDto novoServico)
        {
            var response = new ServiceResponse<ServicoReadDto>();
            try
            {
                var servico = _mapper.Map<Servico>(novoServico);
                _context.Servicos.Add(servico);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<ServicoReadDto>(servico);
                response.Sucesso = true;
                response.Mensagem = "Serviço criado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao criar serviço: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteServico(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var servico = await _context.Servicos.FindAsync(id);
                if (servico == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Serviço não encontrado.";
                    response.Dados = false;
                    return response;
                }
                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
                response.Dados = true;
                response.Sucesso = true;
                response.Mensagem = "Serviço deletado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Dados = false;
                response.Mensagem = $"Erro ao deletar serviço: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<ServicoReadDto>>> GetServicos()
        {
            var response = new ServiceResponse<List<ServicoReadDto>>();
            try
            {
                var servicos = await _context.Servicos.ToListAsync();
                response.Dados = _mapper.Map<List<ServicoReadDto>>(servicos);
                response.Sucesso = true;
                response.Mensagem = "Serviços obtidos com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao obter serviços: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<ServicoReadDto>> GetServicoById(int id)
        {
            var response = new ServiceResponse<ServicoReadDto>();
            try
            {
                var servico = await _context.Servicos.FindAsync(id);
                if (servico == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Serviço não encontrado.";
                    return response;
                }
                response.Dados = _mapper.Map<ServicoReadDto>(servico);
                response.Sucesso = true;
                response.Mensagem = "Serviço obtido com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao obter serviço: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<ServicoReadDto>> UpdateServico(ServicoUpdateDto editadoServico)
        {
            var response = new ServiceResponse<ServicoReadDto>();
            try
            {
                var servico = await _context.Servicos.FindAsync(editadoServico.Id);
                if (servico == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Serviço não encontrado.";
                    return response;
                }
                _mapper.Map(editadoServico, servico);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<ServicoReadDto>(servico);
                response.Sucesso = true;
                response.Mensagem = "Serviço atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao atualizar serviço: {ex.Message}";
            }
            return response;
        }
    }
}
