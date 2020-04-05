using AutoMapper;
using DataAccess.Entities;
using FrankoMaps.Models;

namespace FrankoMaps.Profiles
{
    public class PointProfile : Profile
    {
        public PointProfile()
        {
            CreateMap<Point, PointViewModel>();
            CreateMap<PointViewModel, Point>();
        }
    }
}