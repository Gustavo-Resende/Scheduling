using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scheduling.Data;
using Scheduling.DTOs.Agendamento;
using Scheduling.Models;

namespace Scheduling.Service.AgendamentoService
{
    public class AgendamentoService : IAgendamentoInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AgendamentoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AgendamentoReadDto>> CreateAgendamento(AgendamentoCreateDto novoAgendamento)
        {
            var response = new ServiceResponse<AgendamentoReadDto>();
            try
            {
                var agendamento = _mapper.Map<Agendamento>(novoAgendamento);
                _context.Agendamentos.Add(agendamento);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<AgendamentoReadDto>(agendamento);
                response.Sucesso = true;
                response.Mensagem = "Agendamento criado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao criar agendamento: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAgendamento(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var agendamento = await _context.Agendamentos.FindAsync(id);
                if (agendamento == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Agendamento não encontrado.";
                    response.Dados = false;
                    return response;
                }
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
                response.Dados = true;
                response.Sucesso = true;
                response.Mensagem = "Agendamento excluído com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Dados = false;
                response.Mensagem = $"Erro ao excluir agendamento: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<AgendamentoReadDto>>> GetAgendamentos()
        {
            var response = new ServiceResponse<List<AgendamentoReadDto>>();
            try
            {
                var agendamentos = await _context.Agendamentos.ToListAsync();
                response.Dados = _mapper.Map<List<AgendamentoReadDto>>(agendamentos);
                response.Sucesso = true;
                response.Mensagem = "Agendamentos recuperados com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao recuperar agendamentos: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<AgendamentoReadDto>> GetAgendamentoById(int id)
        {
            var response = new ServiceResponse<AgendamentoReadDto>();
            try
            {
                var agendamento = await _context.Agendamentos.FindAsync(id);
                if (agendamento == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Agendamento não encontrado.";
                    return response;
                }
                response.Dados = _mapper.Map<AgendamentoReadDto>(agendamento);
                response.Sucesso = true;
                response.Mensagem = "Agendamento recuperado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao recuperar agendamento: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<AgendamentoReadDto>> UpdateAgendamento(AgendamentoUpdateDto editadoAgendamento)
        {
            var response = new ServiceResponse<AgendamentoReadDto>();
            try
            {
                var agendamento = await _context.Agendamentos.FindAsync(editadoAgendamento.Id);
                if (agendamento == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Agendamento não encontrado.";
                    return response;
                }
                _mapper.Map(editadoAgendamento, agendamento);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<AgendamentoReadDto>(agendamento);
                response.Sucesso = true;
                response.Mensagem = "Agendamento atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao atualizar agendamento: {ex.Message}";
            }
            return response;
        }
    }
}