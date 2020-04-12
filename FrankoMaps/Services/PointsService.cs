using DataAccess.Repositories;
using AutoMapper;
using System.Collections.Generic;
using FrankoMaps.Models;
using DataAccess.Entities;

namespace FrankoMaps.Services
{
    public class PointsService
    {
        private readonly PointRepository repository;
        private readonly IMapper _mapper;

        public PointsService(PointRepository pointRepository, IMapper mapper)
        {
            repository = pointRepository;
            _mapper = mapper;
        }

        public List<PointViewModel> GetPoints()
        {
            List<Point> points = repository.GetItems();
            List<PointViewModel> pointViewModels = _mapper.Map<List<PointViewModel>>(points);
            return pointViewModels;
        }
    }
}