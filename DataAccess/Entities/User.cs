using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Map> Maps { get; set; }
        public List<Point> Points { get; set; }
        public List<Distance> Distances { get; set; }
    }
}
