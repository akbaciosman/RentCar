using RentCar.Entities;
using RentCar.Entities.HelperConrete;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentCar.Models
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }
        public User LoginFunc(Login loginDto)
        {
            throw new NotImplementedException();
        }

        public User RegisterFunc(Register registerDto)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}