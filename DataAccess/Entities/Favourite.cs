using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Favourite
    {
        public int Id { get; set; }
        public int PointA_Id { get; set; }
        public int PointB_Id { get; set; }
        public string User_Id { get; set; }
     
    }
}
