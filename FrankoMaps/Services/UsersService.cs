using DataAccess.Repositories;
using AutoMapper;

namespace FrankoMaps.Services
{
    public class UsersService
    {
        private readonly UserRepository repository;
        private readonly IMapper _mapper;

        public UsersService(UserRepository userRepository, IMapper mapper)
        {
            repository = userRepository;
            _mapper = mapper;
        }
    }
}