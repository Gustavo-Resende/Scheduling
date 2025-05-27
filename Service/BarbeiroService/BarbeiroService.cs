using Scheduling.Data;
using Scheduling.Models;

namespace Scheduling.Service.BarbeiroService
{
    public class BarbeiroService : IBarbeiroInterface
    {
        private readonly AppDbContext _context;
        public BarbeiroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Barbeiro>>> CreateBarbeiro(Barbeiro novoBarbeiro)
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();
            try
            {
                if (novoBarbeiro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Barbeiro não pode ser nulo!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Barbeiros.Add(novoBarbeiro);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Barbeiros.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Barbeiro criado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao criar barbeiro: {ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Barbeiro>>> DeleteBarbeiro(int id)
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();
            try
            {
                var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.Id == id);
                if (barbeiro == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Barbeiro não encontrado.";
                    return serviceResponse;
                }
                _context.Barbeiros.Remove(barbeiro);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Barbeiros.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Barbeiro excluído com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao excluir barbeiro: {ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Barbeiro>>> GetBarbeiros()
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();

            try
            {
                serviceResponse.Dados = _context.Barbeiros.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Lista de barbeiros obtida com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao obter barbeiros: {ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Barbeiro>>> GetBarbeirosById(int id)
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();

            try
            {
                var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.Id == id);
                if (barbeiro == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Barbeiro não encontrado.";
                    return serviceResponse;
                }
                serviceResponse.Dados = new List<Barbeiro> { barbeiro };
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Barbeiro encontrado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao obter barbeiro: {ex.Message}";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Barbeiro>>> InativaBarbeiro(int id)
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();

            try
            {
                var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.Id == id);
                if (barbeiro == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Barbeiro não encontrado.";
                    return serviceResponse;
                }
                barbeiro.Status = false;
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Barbeiros.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Barbeiro inativado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao inativar barbeiro: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Barbeiro>>> UpdateBarbeiro(Barbeiro editadoBarbeiro)
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();
            try
            {
                var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.Id == editadoBarbeiro.Id);
                if (barbeiro == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Barbeiro não encontrado.";
                    return serviceResponse;
                }
                barbeiro.Nome = editadoBarbeiro.Nome;
                barbeiro.Especialidade = editadoBarbeiro.Especialidade;
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Barbeiros.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Barbeiro atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao atualizar barbeiro: {ex.Message}";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Barbeiro>>> AtivaBarbeiro(int id)
        {
            ServiceResponse<List<Barbeiro>> serviceResponse = new ServiceResponse<List<Barbeiro>>();
            try
            {
                var barbeiro = _context.Barbeiros.FirstOrDefault(b => b.Id == id);
                if (barbeiro == null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Barbeiro não encontrado.";
                    return serviceResponse;
                }
                barbeiro.Status = true;
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Barbeiros.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Barbeiro ativado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao ativar barbeiro: {ex.Message}";
            }
            return serviceResponse;
        }
    }
}
