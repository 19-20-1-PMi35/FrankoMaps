using AutoMapper;
using FrankoMaps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrankoMaps.Services
{
	public class ApplicationUserService
	{
        private readonly ApplicationUserRepository repository;
        private readonly IMapper _mapper;

        public ApplicationUserService(ApplicationUserRepository mapRepository, IMapper mapper)
        {
            repository = mapRepository;
            _mapper = mapper;
        }
    }
}
