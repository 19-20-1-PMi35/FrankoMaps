namespace FrankoMaps.Models
{
    public class PointViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsVisible { get; set; }
        public string UserId { get; set; }
        public int MapId { get; set; }
    }
}
