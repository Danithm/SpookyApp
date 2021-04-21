using AutoMapper;
using SpookyApp.Dtos;
using SpookyApp.Models;

namespace SpookyApp.Profiles
{
    public class SpookysProfile : Profile
    {
        public SpookysProfile()
        {
            //Source -> Client
            CreateMap<Spooky, SpookyReadDto>();

            CreateMap<Spooky, SpookyUpdateDto>();

            //Client -> Source
            CreateMap<SpookyCreateDto, Spooky>();

            CreateMap<SpookyUpdateDto, Spooky>();
        }
    }
}
