using RentCar.DataAccess;
using RentCar.DataAccess.Abstract;
using RentCar.Entities;
using RentCar.Entities.Abstract;
using RentCar.Entities.HelperConrete;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;

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

        public User LoginFunc(Login loginDto)
        {
            User user = _userDal.Get(u => u.Email == loginDto.UserName);
            if(user!=null)
                if (user.Email == loginDto.UserName && user.Password == GetMD5(loginDto.Password) && user.IsDeleted!=true)
                    return user;
            return null;


        }


        public User RegisterFunc(Register registerDto)
        {
            User user = new User{
                FirstName = registerDto.FirstName,
                SecondName = registerDto.SecondName,
                Password = GetMD5(registerDto.Password),
                Email = registerDto.Email,
                Age = registerDto.Age,
                PhoneNumber = registerDto.PhoneNumber,
                DriverLicense = registerDto.DriverLicense,
                IsDeleted = false,
                RoleId = 1
            };

            try
            {
                _userDal.Add(user);

            }
            catch (Exception msg)
            {

                return null;
            }
            
            return user;
        }


        public string GetMD5(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            MD5 hashString = new MD5CryptoServiceProvider();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}