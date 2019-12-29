using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        bool Add(User user);
        bool Delete(User user);
        bool Update(User user);
        List<User> GetAll();
        User GetUser(int userId);
    }
}
