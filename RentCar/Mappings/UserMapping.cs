using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using FluentNHibernate.Conventions.Inspections;

namespace RentCar.Mappings
{
    public class UserMapping: ClassMap<User>
    {
        public UserMapping() {

            Table("Users");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Not.Nullable().Length(100); 
            Map(x => x.Surname).Not.Nullable().Length(100);
            Map(x => x.Password).Not.Nullable(); 
            Map(x => x.Age).Not.Nullable().Length(2);
            Map(x => x.DriverLicence).Not.Nullable();
            Map(x => x.IsDeleted).Nullable();
            Map(x => x.PhoneNumber).Not.Nullable(); 
            Map(x => x.RoleId).Nullable();
            Map(x => x.Mail).Not.Nullable().Length(100);
            HasMany(x => x.Orders).Inverse().Cascade.All();
            HasMany(x => x.Cards).Inverse().Cascade.All();
            
        }
    }
}