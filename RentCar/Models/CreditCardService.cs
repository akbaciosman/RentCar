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
    public class CreditCardService : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardService()
        {
            _creditCardDal = new CreditCardDal();
        }
        public bool Add(CreditCard Card)
        {
            try
            {
                _creditCardDal.Add(Card);
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
                CreditCard _card = _creditCardDal.Get(x => x.Id == id);
                _card.IsDeleted = true;
                _creditCardDal.Delete(_card);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IList<CreditCard> GetAll()
        {
            try
            {
                return _creditCardDal.GetList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public CreditCard GetById(int id)
        {
            try
            {
                return _creditCardDal.Get(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool Update(CreditCard Card)
        {
            try
            {
                _creditCardDal.Update(Card);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}