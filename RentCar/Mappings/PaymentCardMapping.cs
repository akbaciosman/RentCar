using FluentNHibernate.Mapping;
using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Mappings
{
    public class PaymentCardMapping: ClassMap<CreditCard>
    {
        public PaymentCardMapping()
        {
            Table("Cards");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Limit).Not.Nullable();
            Map(x => x.CardName).Not.Nullable();
            Map(x => x.IsDeleted).Nullable();
            References(x => x.User);
        }
    }
}