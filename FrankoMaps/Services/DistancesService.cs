using DataAccess.Repositories;
using AutoMapper;

namespace FrankoMaps.Services
{
    public class DistancesService
    {
        private readonly DistanceRepository repository;
        private readonly IMapper _mapper;

        public DistancesService(DistanceRepository distanceRepository, IMapper mapper)
        {
            repository = distanceRepository;
            _mapper = mapper;
        }
    }
}