using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Distance
    {
        public int Id { get; set; }
        public int FromPointId { get; set; }
        public int ToPointId { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
    }
}
