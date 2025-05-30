using Scheduling.DTOs.Empresa;
using Scheduling.Models;

namespace Scheduling.Service.EmpresaService
{
    public interface IEmpresaInterface
    {
        Task<ServiceResponse<List<EmpresaReadDto>>> GetEmpresas();
        Task<ServiceResponse<EmpresaReadDto>> CreateEmpresa(EmpresaCreateDto dto);
        Task<ServiceResponse<EmpresaReadDto>> GetEmpresaById(int id);
        Task<ServiceResponse<EmpresaReadDto>> UpdateEmpresa(EmpresaUpdateDto dto);
        Task<ServiceResponse<bool>> DeleteEmpresa(int id);
    }
}
