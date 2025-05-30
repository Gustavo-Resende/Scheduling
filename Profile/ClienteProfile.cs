using AutoMapper;
using Scheduling.DTOs.Cliente;
using Scheduling.Models;

namespace Scheduling.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteCreateDto, ClienteModel>();
            CreateMap<ClienteUpdateDto, ClienteModel>();
            CreateMap<ClienteModel, ClienteReadDto>();
        }
    }
}
