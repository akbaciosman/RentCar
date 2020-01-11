using FluentNHibernate.Mapping;
using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Mappings
{
    public class OrderMapping: ClassMap<Order>
    {
        public OrderMapping() {
            Table("Orders");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.StartDate).Not.Nullable(); 
            Map(x => x.EndDate).Not.Nullable();
            Map(x => x.IsDeleted).Nullable();
            References<User>(x => x.User).Column("UserId").Cascade.All().Not.LazyLoad();
            References<Car>(x => x.Car).Column("CarId").Cascade.All().Not.LazyLoad();
        }
    }
}