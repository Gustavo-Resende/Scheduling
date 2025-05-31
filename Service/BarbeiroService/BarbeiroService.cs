using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scheduling.Data;
using Scheduling.DTOs.Barbeiro;
using Scheduling.Models;

namespace Scheduling.Service.BarbeiroService
{
    public class BarbeiroService : IBarbeiroInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BarbeiroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BarbeiroReadDto>> CreateBarbeiro(BarbeiroCreateDto novoBarbeiro)
        {
            var response = new ServiceResponse<BarbeiroReadDto>();
            try
            {
                var barbeiro = _mapper.Map<Barbeiro>(novoBarbeiro);
                _context.Barbeiros.Add(barbeiro);
                await _context.SaveChangesAsync();

                // Após salvar o barbeiro:
                foreach (var servicoId in novoBarbeiro.ServicoIds)
                {
                    // Valide se o serviço pertence à empresa do barbeiro
                    var servico = await _context.Servicos
                        .FirstOrDefaultAsync(s => s.Id == servicoId && s.EmpresaId == barbeiro.EmpresaId);
                    if (servico != null)
                    {
                        _context.BarbeiroServicos.Add(new BarbeiroServico
                        {
                            BarbeiroId = barbeiro.Id,
                            ServicoId = servicoId
                        });
                    }
                }
                await _context.SaveChangesAsync();
                response.Dados = _mapper.Map<BarbeiroReadDto>(barbeiro);
                response.Sucesso = true;
                response.Mensagem = "Barbeiro criado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao criar barbeiro: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBarbeiro(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var barbeiro = await _context.Barbeiros.FindAsync(id);
                if (barbeiro == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Barbeiro não encontrado.";
                    response.Dados = false;
                    return response;
                }
                _context.Barbeiros.Remove(barbeiro);
                await _context.SaveChangesAsync();
                response.Dados = true;
                response.Sucesso = true;
                response.Mensagem = "Barbeiro excluído com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Dados = false;
                response.Mensagem = $"Erro ao excluir barbeiro: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<BarbeiroReadDto>>> GetBarbeiros()
        {
            var response = new ServiceResponse<List<BarbeiroReadDto>>();
            try
            {
                var barbeiros = await _context.Barbeiros
                    .Include(b => b.BarbeiroServicos)
                    .ToListAsync();
                response.Dados = _mapper.Map<List<BarbeiroReadDto>>(barbeiros);
                response.Sucesso = true;
                response.Mensagem = "Barbeiros recuperados com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao recuperar barbeiros: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<BarbeiroReadDto>> GetBarbeiroById(int id)
        {
            var response = new ServiceResponse<BarbeiroReadDto>();
            try
            {
                var barbeiro = await _context.Barbeiros
                    .Include(b => b.BarbeiroServicos)
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (barbeiro == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Barbeiro não encontrado.";
                    return response;
                }
                response.Dados = _mapper.Map<BarbeiroReadDto>(barbeiro);
                response.Sucesso = true;
                response.Mensagem = "Barbeiro recuperado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao recuperar barbeiro: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<BarbeiroReadDto>> UpdateBarbeiro(BarbeiroUpdateDto editadoBarbeiro)
        {
            var response = new ServiceResponse<BarbeiroReadDto>();
            try
            {
                var barbeiro = await _context.Barbeiros
                    .Include(b => b.BarbeiroServicos)
                    .FirstOrDefaultAsync(b => b.Id == editadoBarbeiro.Id);

                if (barbeiro == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Barbeiro não encontrado.";
                    return response;
                }

                // Atualiza os dados básicos
                _mapper.Map(editadoBarbeiro, barbeiro);

                // Remove todos os relacionamentos antigos
                var antigos = _context.BarbeiroServicos.Where(bs => bs.BarbeiroId == barbeiro.Id);
                _context.BarbeiroServicos.RemoveRange(antigos);

                // Adiciona os novos relacionamentos
                foreach (var servicoId in editadoBarbeiro.ServicoIds)
                {
                    // Valide se o serviço pertence à empresa do barbeiro
                    var servico = await _context.Servicos
                        .FirstOrDefaultAsync(s => s.Id == servicoId && s.EmpresaId == barbeiro.EmpresaId);
                    if (servico != null)
                    {
                        _context.BarbeiroServicos.Add(new BarbeiroServico
                        {
                            BarbeiroId = barbeiro.Id,
                            ServicoId = servicoId
                        });
                    }
                }

                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<BarbeiroReadDto>(barbeiro);
                response.Sucesso = true;
                response.Mensagem = "Barbeiro atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao atualizar barbeiro: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<BarbeiroReadDto>> InativaBarbeiro(int id)
        {
            var response = new ServiceResponse<BarbeiroReadDto>();
            try
            {
                var barbeiro = await _context.Barbeiros.FindAsync(id);
                if (barbeiro == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Barbeiro não encontrado.";
                    return response;
                }
                barbeiro.Status = false;
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<BarbeiroReadDto>(barbeiro);
                response.Sucesso = true;
                response.Mensagem = "Barbeiro inativado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao inativar barbeiro: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<BarbeiroReadDto>> AtivaBarbeiro(int id)
        {
            var response = new ServiceResponse<BarbeiroReadDto>();
            try
            {
                var barbeiro = await _context.Barbeiros.FindAsync(id);
                if (barbeiro == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Barbeiro não encontrado.";
                    return response;
                }
                barbeiro.Status = true;
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<BarbeiroReadDto>(barbeiro);
                response.Sucesso = true;
                response.Mensagem = "Barbeiro ativado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao ativar barbeiro: {ex.Message}";
            }
            return response;
        }
    }
}