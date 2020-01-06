using RentCar.Entities;
using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Models.Abstract
{
    public interface ICarService
    {
        bool Add(Car car);
        bool Delete(int carId);
        bool Update(Car car);
        Car GetById(int carId);
        IList<Car> GetAll();
    }
}
