using AutoMapper;
using Scheduling.DTOs.Barbeiro;
using Scheduling.Models;

namespace Scheduling.Profiles
{
    public class BarbeiroProfile : Profile
    {
        public BarbeiroProfile()
        {
            CreateMap<BarbeiroCreateDto, Barbeiro>();
            CreateMap<BarbeiroUpdateDto, Barbeiro>();
            CreateMap<Barbeiro, BarbeiroReadDto>();
            CreateMap<Barbeiro, BarbeiroReadDto>()
                .ForMember(dest => dest.ServicoIds,
                opt => opt.MapFrom(src => src.BarbeiroServicos.Select(bs => bs.ServicoId).ToList()));

        }
    }
}
