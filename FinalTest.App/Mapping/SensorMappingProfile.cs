using AutoMapper;
using FinalTest.App.Dtos.Sensors;
using FinalTest.Domain.Entities;

namespace FinalTest.App.Mappings
{
    public class SensorMappingProfile : Profile
    {
        public SensorMappingProfile()
        {
            CreateMap<CreateSensorRequest, Sensor>()
                .ForMember(s => s.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(s => s.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(s => s.X, opt => opt.MapFrom(src => src.X))
                .ForMember(s => s.Y, opt => opt.MapFrom(src => src.Y))
                .ForMember(s => s.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                .ForMember(s => s.DataType, opt => opt.MapFrom(src => src.DataType))
                .ForMember(s => s.MinThreshold, opt => opt.MapFrom(src => src.MinThreshold))
                .ForMember(s => s.MaxThreshold, opt => opt.MapFrom(src => src.MaxThreshold));

            CreateMap<UpdateSensorRequest, Sensor>()
                .ForMember(s => s.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(s => s.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(s => s.X, opt => opt.MapFrom(src => src.X))
                .ForMember(s => s.Y, opt => opt.MapFrom(src => src.Y))
                .ForMember(s => s.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                .ForMember(s => s.DataType, opt => opt.MapFrom(src => src.DataType))
                .ForMember(s => s.MinThreshold, opt => opt.MapFrom(src => src.MinThreshold))
                .ForMember(s => s.MaxThreshold, opt => opt.MapFrom(src => src.MaxThreshold));

            CreateMap<Sensor, SensorResponse>()
                .ForMember(s => s.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(s => s.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(s => s.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(s => s.X, opt => opt.MapFrom(src => src.X))
                .ForMember(s => s.Y, opt => opt.MapFrom(src => src.Y))
                .ForMember(s => s.BuildingId, opt => opt.MapFrom(src => src.BuildingId))
                .ForMember(s => s.DataType, opt => opt.MapFrom(src => src.DataType))
                .ForMember(s => s.MinThreshold, opt => opt.MapFrom(src => src.MinThreshold))
                .ForMember(s => s.MaxThreshold, opt => opt.MapFrom(src => src.MaxThreshold));

            CreateMap<Sensor, SensorDataResponse>()
                .ForMember(sd => sd.Timestamp, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(sd => sd.Value, opt => opt.MapFrom(src => 0f));
        }
    }
}
