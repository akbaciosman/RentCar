using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using RentCar.Entities.Abstract;
using RentCar.Mappings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Configuration = NHibernate.Cfg.Configuration;

namespace RentCar
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory CreateSession()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            Console.WriteLine("----- " + connectionString + " ----dsa dsadasd ");

            if (_sessionFactory != null)
                return _sessionFactory;

            FluentConfiguration _config = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008
            .ConnectionString(connectionString)
            .ShowSql())
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<UserMapping>();
                    m.FluentMappings.AddFromAssemblyOf<CarMapping>();
                    m.FluentMappings.AddFromAssemblyOf<OrderMapping>();
                    m.FluentMappings.AddFromAssemblyOf<PaymentCardMapping>();
                    m.FluentMappings.AddFromAssemblyOf<AddressMapping>();
                }).ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true));

                Console.WriteLine("----- " + _sessionFactory + "  " + _config + " ----dsa dsadasd ");
            
            _sessionFactory = _config.BuildSessionFactory();
                return _sessionFactory ;
            
        }

        public static ISession OpenSession() {
            return CreateSession().OpenSession();
        }


    }

}