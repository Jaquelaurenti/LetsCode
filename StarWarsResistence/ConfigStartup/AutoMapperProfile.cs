using AutoMapper;
using StarWarsResistence.Models;
using StarWarsResistence.DTO;
using StarWarsResistence.Services;
using StarWarsResistence.Controllers;

namespace StarWarsResistence.ConfigStartup
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rebelde, RebeldeDTO>().ReverseMap();
        }
    }
}
