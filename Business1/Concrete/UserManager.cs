using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal user) { _userDal = user;  }
        public bool Add(User user)
        {
            _userDal.Add(user);
            return true;
        }

        public bool Delete(User user)
        {
            _userDal.Delete(user);

            return true;
        }

        public List<User> GetAll()
        {
            return (List<User>)_userDal.GetList();

        }

        public User GetUser(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }

        public bool Update(User user)
        {
            _userDal.Update(user);
            return true;
        }
    }
}
