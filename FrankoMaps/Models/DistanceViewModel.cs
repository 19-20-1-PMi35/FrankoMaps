namespace FrankoMaps.Models
{
    public class DistanceViewModel
    {
        public int Id { get; set; }
        public int FromPointId { get; set; }
        public int ToPointId { get; set; }
        public double Weight { get; set; }
        public string UserId { get; set; }
    }
}