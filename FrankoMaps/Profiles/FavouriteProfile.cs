using AutoMapper;
using DataAccess.Entities;
using FrankoMaps.Models;

namespace FrankoMaps.Profiles
{
    public class FavouriteProfile : Profile
    {
        public FavouriteProfile()
        {
            CreateMap<Favourite, FavouriteViewModel>();
            CreateMap<FavouriteViewModel, Favourite>();
        }
    }
}