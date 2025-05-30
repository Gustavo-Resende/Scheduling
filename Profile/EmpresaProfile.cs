using AutoMapper;
using Scheduling.DTOs.Empresa;
using Scheduling.Models;

namespace Scheduling.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<EmpresaCreateDto, Empresa>();
            CreateMap<Empresa, EmpresaReadDto>();
            CreateMap<EmpresaUpdateDto, Empresa>();
        }
    }
}
