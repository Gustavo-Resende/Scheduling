using AutoMapper;
using Scheduling.DTOs.Servico;
using Scheduling.Models;

namespace Scheduling.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<ServicoCreateDto, Servico>();
            CreateMap<ServicoUpdateDto, Servico>();
            CreateMap<Servico, ServicoReadDto>();
        }
    }
}
