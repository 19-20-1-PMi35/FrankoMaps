using AutoMapper;
using DataAccess.Entities;
using FrankoMaps.Models;

namespace FrankoMaps.Profiles
{
    public class DistanceProfile : Profile
    {
        public DistanceProfile()
        {
            CreateMap<Distance, DistanceViewModel>();
            CreateMap<DistanceViewModel, Distance>();
        }
    }
}