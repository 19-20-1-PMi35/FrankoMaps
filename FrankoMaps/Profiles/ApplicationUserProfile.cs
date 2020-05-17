using FrankoMaps.Areas.Identity.Data;
using FrankoMaps.Models;
using AutoMapper;

namespace FrankoMaps.Profiles
{
	public class ApplicationUserProfile : Profile
	{
		public ApplicationUserProfile()
		{
			CreateMap<ApplicationUser, ApplicationUserViewModel>();
			CreateMap<ApplicationUserViewModel, ApplicationUser>();
		}
	}
}
