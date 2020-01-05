using RentCar.Entities;
using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Models.Abstract
{
    public interface IUserService
    {
        bool Add(User user);
        bool Delete(int userId);
        bool Update(User user);
        User GetById(int userId);
        IList<User> GetAll();
    }
}
