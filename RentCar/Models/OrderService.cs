using RentCar.DataAccess;
using RentCar.DataAccess.Abstract;
using RentCar.Entities;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RentCar.Models
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly ICarDal _carDal;
        private readonly IUserDal _userDal;

        public OrderService(IOrderDal orderDal, ICarDal carDal, IUserDal userDal)
        {
            _orderDal = orderDal;
            _carDal = carDal;
            _userDal = userDal;
            //_orderDal = new OrderDal();
        }
        public bool Add(Order Order)
        {
                User _user = _userDal.Get(x => x.Id == Order.User.Id);
                Car _car = _carDal.Get(x => x.Id == Order.Car.Id);

                if (_car.Available && !_car.IsDeleted)
                {
                    if(_user.Cards.Count<1)
                        throw new Exception("You cant rent this, please add your creditCard!!");
                    if (_user.Cards[0].Limit > _car.Price)
                    {
                        _user.Cards[0].Limit -= _car.Price; 
                        Order.User = _user;
                        Order.Car = _car;
                        Order.Car.Available = false;

                        _orderDal.Add(Order);
                    }
                    else
                        throw new Exception("You cant rent this, please check your creditCard Limit!!");
                }
                else {
                    throw new Exception("Related Car is not available for now!!!, Please choose new one");
                }
                return true;
            
        }

        public bool Delete(int id)
        {
            try
            {
                Order _order = _orderDal.Get(x => x.Id == id);
                _order.IsDeleted = true;
                _orderDal.Delete(_order);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Order> GetAll()
        {
            try
            {
                List<Order> list = _orderDal.GetList().ToList();
                return list;
            }
            catch (Exception msg)
            {
                throw;
            }
            
        }

        public Order GetById(int id)
        {
            try
            {
                return _orderDal.Get(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool Update(Order Order)
        {
            try
            {
                _orderDal.Update(Order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}