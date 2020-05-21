using AutoMapper;
using DataAccess.Entities;
using FrankoMaps.Models;

namespace FrankoMaps.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Map, MapViewModel>();
            CreateMap<MapViewModel, Map>();
        }
    }
}