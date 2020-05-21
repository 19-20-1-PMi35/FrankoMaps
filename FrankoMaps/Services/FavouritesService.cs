using DataAccess.Repositories;
using AutoMapper;
using System.Collections.Generic;
using FrankoMaps.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FrankoMaps.Services
{
    public class FavouritesService
    {
        private readonly FavouriteRepository repository;
        private readonly IMapper _mapper;
     

        public FavouritesService(FavouriteRepository favouriteRepository, IMapper mapper)
        {
            repository = favouriteRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public void Create(FavouriteViewModel favourite)
        {
            Favourite newFavourite = _mapper.Map<Favourite>(favourite);
            repository.Create(newFavourite);
        }
        public void UpdateFavourite(FavouriteViewModel favourite)
        {
            Favourite newFavourite = _mapper.Map<Favourite>(favourite);

            repository.UpdateAsync(newFavourite);
        }
        public FavouriteViewModel GetFavourite(int id)
        {
            Favourite favourite = repository.GetItem(id);
            FavouriteViewModel favouriteViewModel = _mapper.Map<FavouriteViewModel>(favourite);
            return favouriteViewModel;
        }
        public List<FavouriteViewModel> GetFavourites()
        {
            List<Favourite> favourites = repository.GetItems();
            List<FavouriteViewModel> favouriteViewModels = _mapper.Map<List<FavouriteViewModel>>(favourites);
            return favouriteViewModels;
        }
    }
}