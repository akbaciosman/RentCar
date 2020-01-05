using RentCar.Core;
using RentCar.DataAccess.Abstract;
using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.DataAccess
{
    public class CreditCardDal: FleuntNhibernateRepository<CreditCard>, ICreditCardDal
    {
    }
}