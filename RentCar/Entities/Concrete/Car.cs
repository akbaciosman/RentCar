using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Entities
{
    public class Car:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Photo { get; set; }
        public virtual bool Available { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual double Price { get; set; }
        public virtual Address Address { get; set; }
        public virtual IList<Order> Orders { get; set; }

        public Car()
        {
            Orders = new List<Order>();
            Address = new Address();
        }
    }
}