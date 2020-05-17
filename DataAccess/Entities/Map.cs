using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Map
    {
        public int Id { get; set; }
        public string Image { get; set; }        
        public int UserId { get; set; }

        public List<Point> Points { get; set; }
    }
}
