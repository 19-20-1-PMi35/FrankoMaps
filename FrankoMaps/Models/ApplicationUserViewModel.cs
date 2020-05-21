using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrankoMaps.Models
{
	public class ApplicationUserViewModel
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
	}
}
