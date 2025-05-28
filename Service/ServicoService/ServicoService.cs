using Scheduling.Data;
using Scheduling.Models;

namespace Scheduling.Service.ServicoService
{
    public class ServicoService : IServicoInterface
    {
        private readonly AppDbContext _context;
        public ServicoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Servico>>> CreateServico(Servico novoServico)
        {
            ServiceResponse<List<Servico>> serviceResponse = new ServiceResponse<List<Servico>>();
            try
            {
                _context.Servicos.Add(novoServico);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Servicos.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Serviço criado com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao criar serviço: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Servico>>> DeleteServico(int id)
        {
            ServiceResponse<List<Servico>> serviceResponse = new ServiceResponse<List<Servico>>();
            try
            {
                var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);
                if (servico != null)
                {
                    _context.Servicos.Remove(servico);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Servicos.ToList();
                    serviceResponse.Sucesso = true;
                    serviceResponse.Mensagem = "Serviço deletado com sucesso.";
                }
                else
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Serviço não encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao deletar serviço: {ex.Message}";
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<Servico>>> GetServicoById(int id)
        {
            ServiceResponse<List<Servico>> serviceResponse = new ServiceResponse<List<Servico>>();
            try
            {
                var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);
                if (servico != null)
                {
                    serviceResponse.Dados = new List<Servico> { servico };
                    serviceResponse.Sucesso = true;
                    serviceResponse.Mensagem = "Serviço obtido com sucesso.";
                }
                else
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Serviço não encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao obter serviço: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Servico>>> GetServicos()
        {
            ServiceResponse<List<Servico>> serviceResponse = new ServiceResponse<List<Servico>>();
            try
            {
                serviceResponse.Dados = _context.Servicos.ToList();
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Serviços obtidos com sucesso.";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao obter serviços: {ex.Message}";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Servico>>> UpdateServico(Servico editadoServico)
        {
            ServiceResponse<List<Servico>> serviceResponse = new ServiceResponse<List<Servico>>();
            try
            {
                var servico = _context.Servicos.FirstOrDefault(s => s.Id == editadoServico.Id);
                if (servico != null)
                {
                    servico.Tipo = editadoServico.Tipo;
                    servico.Preco = editadoServico.Preco;
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Servicos.ToList();
                    serviceResponse.Sucesso = true;
                    serviceResponse.Mensagem = "Serviço atualizado com sucesso.";
                }
                else
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Serviço não encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = $"Erro ao atualizar serviço: {ex.Message}";
            }
            return serviceResponse;
        }
    }
}
