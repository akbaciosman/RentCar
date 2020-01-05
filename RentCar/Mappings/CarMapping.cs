using FluentNHibernate.Mapping;
using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Mappings
{
    public class CarMapping : ClassMap<Car>
    {
        public CarMapping()
        {
            Table("Cars");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Brand).Not.Nullable().Length(50);
            Map(x => x.Photo).Not.Nullable();
            Map(x => x.Available).Nullable();
            Map(x => x.Price).Not.Nullable();
            Component(x => x.Address, m =>
            {
                m.Map(x => x.City);
                m.Map(x => x.Disrict);
            });
            HasMany(x => x.Orders).Inverse().Cascade.All();
        }
    }
}