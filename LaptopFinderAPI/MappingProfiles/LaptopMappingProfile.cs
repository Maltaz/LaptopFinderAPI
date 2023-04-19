using AutoMapper;
using LaptopFinder.Core.Entities;
using LaptopFinderAPI.Dtos;

namespace LaptopFinderAPI.MappingProfiles
{
    public class LaptopMappingProfile : Profile
    {
        public LaptopMappingProfile()
        {
            CreateMap<Laptop, LaptopDto>();
        }
    }
}
