using Autofac;
using Autofac.Integration.Mvc;
using RentCar.DataAccess;
using RentCar.DataAccess.Abstract;
using RentCar.Models;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RentCar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CarService>().As<ICarService>();
            builder.RegisterType<CarDal>().As<ICarDal>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderDal>().As<IOrderDal>();

            builder.RegisterType<CreditCardService>().As<ICreditCardService>();
            builder.RegisterType<CreditCardDal>().As<ICreditCardDal>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
