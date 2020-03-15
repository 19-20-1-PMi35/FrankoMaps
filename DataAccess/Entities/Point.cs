using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsVisible { get; set; }
        
        public int AdminId { get; set; }
    }
}
