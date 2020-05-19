using System.ComponentModel.DataAnnotations;

namespace FrankoMaps.Models
{
    public class PointViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int X { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Y { get; set; }
        [Required]
        public bool IsVisible { get; set; }
        public string UserId { get; set; }
        public int MapId { get; set; }
    }
}
