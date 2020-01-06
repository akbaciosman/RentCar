using RentCar.Entities;
using RentCar.Entities.HelperConrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Models.Abstract
{
    public interface IAuthService
    {
        User RegisterFunc(Register registerDto);
        User LoginFunc(Login loginDto);
        bool UserExists(string email);
    }
}
