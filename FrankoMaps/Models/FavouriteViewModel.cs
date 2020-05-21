using System.ComponentModel.DataAnnotations;

namespace FrankoMaps.Models
{
    public class FavouriteViewModel
    {
        public int Id { get; set; }
        public int PointA_Id { get; set; }
        public int PointB_Id { get; set; }
        public string User_Id { get; set; }
    }
}
