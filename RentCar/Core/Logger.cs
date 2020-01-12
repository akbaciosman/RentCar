using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Core
{
    public class Logger
    {
        private static ILog logger;

        private static ILog Create()
        {
            if(logger==null)
               return logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            return logger;
        }

        public static ILog GetLogger() {

            return Create();
        }
    }
}