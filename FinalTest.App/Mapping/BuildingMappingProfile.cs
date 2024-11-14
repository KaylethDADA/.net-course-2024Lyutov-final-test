using AutoMapper;
using FinalTest.App.Dtos.Building;
using FinalTest.Domain.Entities;
using System.Linq.Expressions;

namespace FinalTest.App.Mappings
{
    public class BuildingMappingProfile : Profile
    {
        public BuildingMappingProfile()
        {
            CreateMap<CreateBuildingRequest, Building>()
                .ForMember(b => b.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(b => b.Address, opt => opt.MapFrom(src => src.Addres))
                .ForMember(b => b.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UpdateBuildingRequest, Building>()
                .ForMember(b => b.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(b => b.Address, opt => opt.MapFrom(src => src.Addres));

            CreateMap<Building, BuildingResponse>()
                .ForMember(b => b.Sensors, opt => opt.MapFrom(src => src.Sensors));

            CreateMap<PagedBuildingRequest, Expression<Func<Building, bool>>>()
                .ConstructUsing(req => b => string.IsNullOrEmpty(req.Search) || b.Name.Contains(req.Search));
        }
    }
}
