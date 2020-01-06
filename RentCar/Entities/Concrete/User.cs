﻿using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Entities
{
    public class User:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual string Password { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual int Age { get; set; }
        public virtual bool DriverLicence { get; set; }
        public virtual int RoleId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual IList<CreditCard> Cards { get; set; }

    }
}