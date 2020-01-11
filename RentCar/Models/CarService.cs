using RentCar.DataAccess;
using RentCar.DataAccess.Abstract;
using RentCar.Entities;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class CarService : ICarService
    {
        private readonly ICarDal _carDal;

        public CarService(ICarDal carDal)
        {
            _carDal = carDal;
            //_carDal = new CarDal();
        }
        public bool Add(Car car)
        {
            try
            {
                _carDal.Add(car);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int carId)
        {
            try
            {
                Car _car = _carDal.Get(x => x.Id == carId);
                _car.IsDeleted = true;
                _car.Available = false;
                _carDal.Delete(_car);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<Car>  GetAll()
        {
            try
            {
                return _carDal.GetList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Car GetById(int carId)
        {
            try
            {
                return _carDal.Get(x => x.Id == carId); 
            }
            catch (Exception msg)
            {
                return null;
            }

        }

        public bool Update(Car car)
        {
            try
            {
                _carDal.Update(car);
                return true;
            }
            catch (Exception msg)
            {
                return false;
            }
        }
    }
}