using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Models.Abstract
{
    public interface ICreditCardService
    {
        bool Add(CreditCard Card);
        bool Delete(int id);
        bool Update(CreditCard Card);
        CreditCard GetById(int id);
        IList<CreditCard> GetAll();
    }
}
