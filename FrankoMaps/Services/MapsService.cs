using DataAccess.Repositories;
using AutoMapper;

namespace FrankoMaps.Services
{
    public class MapsService
    {
        private readonly MapRepository repository;
        private readonly IMapper _mapper;

        public MapsService(MapRepository mapRepository, IMapper mapper)
        {
            repository = mapRepository;
            _mapper = mapper;
        }
    }
}