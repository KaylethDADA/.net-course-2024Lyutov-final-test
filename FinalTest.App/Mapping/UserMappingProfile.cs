using AutoMapper;
using FinalTest.App.Dtos.Users;
using FinalTest.Domain.Entities;
using System.Linq.Expressions;

namespace FinalTest.App.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Маппинг для создания пользователя
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Маппинг для обновления пользователя
            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Маппинг для отображения пользователя (DTO)
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Маппинг для фильтрации списка пользователей
            CreateMap<PagedUsersRequest, Expression<Func<User, bool>>>()
                .ConvertUsing((src, dest, context) =>
                {
                    Expression<Func<User, bool>> filter = u => string.IsNullOrEmpty(src.Search) || u.FullName.Contains(src.Search) || u.Email.Contains(src.Search);
                    return filter;
                });
        }
    }
}
