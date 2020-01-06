using RentCar.DataAccess;
using RentCar.DataAccess.Abstract;
using RentCar.Entities;
using RentCar.Entities.Abstract;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
           // _userDal = new UserDal();
        }
        public bool Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool Delete(int userId)
        {
            try
            {

                var user = _userDal.Get(u => u.Id == userId);
                user.IsDeleted=true;
                _userDal.Delete(user);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public IList<User> GetAll()
        {
            try
            {

                IList<User> users = _userDal.GetList();

                return users;
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public User GetById(int userId)
        {
            try
            {
                Console.WriteLine(userId);
                return _userDal.Get(u => u.Id == userId);
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
            
        }
    }
}