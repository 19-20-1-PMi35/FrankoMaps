using System.ComponentModel.DataAnnotations;

namespace FrankoMaps.Models
{
    public class DistanceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 1")]
        public int FromPointId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 1")]
        public int ToPointId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 1")]
        public double Weight { get; set; }

        public string UserId { get; set; }
    }
}