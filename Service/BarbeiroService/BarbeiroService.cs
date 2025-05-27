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

        public Task<ServiceResponse<List<Barbeiro>>> DeleteBarbeiro(int id)
        {
            throw new NotImplementedException();
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

        public Task<ServiceResponse<List<Barbeiro>>> GetBarbeirosById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Barbeiro>>> InativaBarbeiro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Barbeiro>>> UpdateBarbeiro(Barbeiro editadoBarbeiro)
        {
            throw new NotImplementedException();
        }
    }
}
