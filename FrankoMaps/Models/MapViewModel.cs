using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrankoMaps.Models
{
    public class MapViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }        
        public int UserId { get; set; }
    }
}
