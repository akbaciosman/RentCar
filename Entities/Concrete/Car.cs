using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndtTime { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public double Price { get; set; }
        public Location Location { get; set; }
    }
}