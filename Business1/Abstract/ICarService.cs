using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICarService
    {
        bool Add(Car car);
        bool Delete(Car car);
        bool Update(Car car);
        List<Car> GetAll();
        Car GetCar(int carId);
    }
}
