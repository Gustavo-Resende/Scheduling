using AutoMapper;
using Scheduling.DTOs.Agendamento;
using Scheduling.Models;

namespace Scheduling.Profiles
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<AgendamentoCreateDto, Agendamento>();
            CreateMap<AgendamentoUpdateDto, Agendamento>();
            CreateMap<Agendamento, AgendamentoReadDto>();
        }
    }
}
