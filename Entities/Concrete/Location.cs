using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Concrete
{
    public class Location:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int CarId { get; set; }
    }
}