using AutoMapper;
using LaptopFinder.Core.Entities;
using LaptopFinderAPI.Dtos;

namespace LaptopFinderAPI.MappingProfiles
{
    public class CaseMappingProfile : Profile
    {
        public CaseMappingProfile()
        {
            CreateMap<CaseDataDto,Case>();
        }
    }
}
