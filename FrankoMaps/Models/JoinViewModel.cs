using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrankoMaps.Models
{
	public class JoinViewModel
	{
		public int Id { get; set; }
		public int FromPointId { get; set; }
		[Required]
		public string NameFrom { get; set; }
		public int ToPointId { get; set; }
		[Required]
		public string NameTo { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 1")]
		public double Weight { get; set; }
		public string UserId { get; set; }
	}
}
