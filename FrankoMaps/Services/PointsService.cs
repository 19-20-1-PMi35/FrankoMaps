using DataAccess.Repositories;
using AutoMapper;
using System.Collections.Generic;
using FrankoMaps.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        public void Create(PointViewModel point, string userId)
        {
            Point newPoint = _mapper.Map<Point>(point);
            newPoint.UserId = userId;

            repository.Create(newPoint);
        }

        public PointViewModel GetPoint(int id)
        {
            Point distance = repository.GetItem(id);
            PointViewModel distanceViewModel = _mapper.Map<PointViewModel>(distance);
            return distanceViewModel;
        }
        public List<PointViewModel> GetPoints()
        {
            List<Point> points = repository.GetItems();
            List<PointViewModel> pointViewModels = _mapper.Map<List<PointViewModel>>(points);
            return pointViewModels;
        }
    }
}