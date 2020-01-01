using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;


        //Dependency Injection via Constructor
        public  CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        public bool Add(Car car)
        {
            _carDal.Add(car);

            return true;
        }

        public bool Delete(Car car)
        {
            _carDal.Delete(car);

            return true;
        }

        public List<Car> GetAll()
        {
            return (List<Car>)_carDal.GetList();

            
        }

        public Car GetCar(int carId)
        {
            return _carDal.Get(p => p.Id == carId);
            
            
        }

        public bool Update(Car car)
        {
            _carDal.Update(car);

            return true;
        }
    }
}
