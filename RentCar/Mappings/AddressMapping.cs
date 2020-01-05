using FluentNHibernate.Mapping;
using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Mappings
{
    public class AddressMapping: ComponentMap<Address>
    {
        public AddressMapping()
        {
            Map(x => x.City).Not.Nullable(); 
            Map(x => x.Disrict).Not.Nullable(); 
        }
    }
}