using DataAccess.Repositories;
using AutoMapper;
using DataAccess.Entities;
using FrankoMaps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FrankoMaps.Areas.Identity.Data;
using System.Collections.Generic;

namespace FrankoMaps.Services
{
    public class MapsService
    {
        private readonly MapRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public MapsService(MapRepository mapRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _repository = mapRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public void Create(MapViewModel map, string userId)
        {
            Map newMap = _mapper.Map<Map>(map);
            newMap.UserId = userId;

            _repository.Create(newMap);
        }
        public List<MapViewModel> GetMaps()
        {
            List<Map> maps = _repository.GetItems();
            List<MapViewModel> mapViewModels = _mapper.Map<List<MapViewModel>>(maps);
            return mapViewModels;
        }
    }
}