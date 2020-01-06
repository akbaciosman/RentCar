using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Entities
{
    public class Order:IEntity
    {
        public virtual int Id { get; set; }
        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual  DateTime StartDate { get; set; }
        public virtual  DateTime EndDate { get; set; }
    }
}