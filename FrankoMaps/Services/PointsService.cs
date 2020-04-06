using DataAccess.Repositories;
using AutoMapper;

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
    }
}