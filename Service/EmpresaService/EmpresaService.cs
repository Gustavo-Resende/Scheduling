using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Scheduling.Data;
using Scheduling.DTOs.Empresa;
using Scheduling.Models;

namespace Scheduling.Service.EmpresaService
{
    public class EmpresaService : IEmpresaInterface
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmpresaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<EmpresaReadDto>> CreateEmpresa(EmpresaCreateDto dto)
        {
            var response = new ServiceResponse<EmpresaReadDto>();
            try
            {
                var empresa = _mapper.Map<Empresa>(dto);
                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<EmpresaReadDto>(empresa);
                response.Sucesso = true;
                response.Mensagem = "Empresa criada com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao criar empresa: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<List<EmpresaReadDto>>> GetEmpresas()
        {
            var response = new ServiceResponse<List<EmpresaReadDto>>();
            try
            {
                var empresas = await _context.Empresas.ToListAsync();
                response.Dados = _mapper.Map<List<EmpresaReadDto>>(empresas);
                response.Sucesso = true;
                response.Mensagem = "Empresas encontradas com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao buscar empresas: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<EmpresaReadDto>> GetEmpresaById(int id)
        {
            var response = new ServiceResponse<EmpresaReadDto>();
            try
            {
                var empresa = await _context.Empresas.FindAsync(id);
                if (empresa == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Empresa não encontrada.";
                    return response;
                }
                response.Dados = _mapper.Map<EmpresaReadDto>(empresa);
                response.Sucesso = true;
                response.Mensagem = "Empresa encontrada com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao buscar empresa: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<EmpresaReadDto>> UpdateEmpresa(EmpresaUpdateDto dto)
        {
            var response = new ServiceResponse<EmpresaReadDto>();
            try
            {
                var empresa = await _context.Empresas.FindAsync(dto.Id);
                if (empresa == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Empresa não encontrada.";
                    return response;
                }
                _mapper.Map(dto, empresa);
                await _context.SaveChangesAsync();

                response.Dados = _mapper.Map<EmpresaReadDto>(empresa);
                response.Sucesso = true;
                response.Mensagem = "Empresa atualizada com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Mensagem = $"Erro ao atualizar empresa: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteEmpresa(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var empresa = await _context.Empresas.FindAsync(id);
                if (empresa == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Empresa não encontrada.";
                    response.Dados = false;
                    return response;
                }
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
                response.Dados = true;
                response.Sucesso = true;
                response.Mensagem = "Empresa deletada com sucesso!";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Dados = false;
                response.Mensagem = $"Erro ao deletar empresa: {ex.Message}";
            }
            return response;
        }
    }
}
