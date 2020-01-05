using RentCar.Entities;
using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Models.Abstract
{
    public interface IOrderService
    {
        bool Add(Order Order);
        bool Delete(int id);
        bool Update(Order Order);
        Order GetById(int id);
        IList<Order> GetAll();
    }
}
