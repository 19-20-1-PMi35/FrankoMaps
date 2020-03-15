using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Distance
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public double Weight { get; set; }

        public int AdminId { get; set; }
        public List<Point> Points { get; set; }
    }
}
