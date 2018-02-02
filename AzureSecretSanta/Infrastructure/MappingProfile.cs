using AutoMapper;
using AzureSecretSanta.Models;
using AzureSecretSanta.ViewModels;
using System;

namespace AzureSecretSanta.Infrastructure
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebProfile());
                cfg.AddProfile(new BLProfile());
            });

            return config;
        }
    }

    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateUserViewModel, UserModel>();
            CreateMap<UserModel, UserViewModel>().ForMember(dest => dest.SantaOf,
                opt => opt.MapFrom(src => src.SantaOf == null ? default(int?) : src.SantaOf.UserId));
        }
    }

    public class BLProfile : Profile
    {
        public BLProfile()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
        }
    }
}