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
    public class OrderService : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderService()
        {
            _orderDal = new OrderDal();
        }
        public bool Add(Order Order)
        {
            try
            {
                _orderDal.Add(Order);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                return false;
            }
        }

        public IList<Order> GetAll()
        {
            try
            {
                return _orderDal.GetList();
            }
            catch (Exception)
            {
                return null;
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