using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Entities
{
    public class CreditCard:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string CardName { get; set; }
        public virtual User User { get; set; }
        public virtual double Limit { get; set; }
        public virtual bool IsDeleted { get; set; }

    }
}