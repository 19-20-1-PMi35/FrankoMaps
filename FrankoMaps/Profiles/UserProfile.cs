using AutoMapper;
using DataAccess.Entities;
using FrankoMaps.Models;

namespace FrankoMaps.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}