using RentCar.DataAccess;
using RentCar.Entities;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.Models
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }
        // GET: User
        public ActionResult Index()
        {
            var users = _userService.GetAll();
            
            return View(users);
        }

            // GET: User/Details/5
            public ActionResult Details(int id)
        {/*
            using (var session=NHibernateHelper.OpenSession()) {
                using (var transac = session.BeginTransaction())
                {
                    var result = session.Get<User>(id);
                    return View(result);
                }*/
           /* User user = new User {Name="Osman",Surname ="veli",Age=15,DriverLicence=true,Id=20,PhoneNumber="20550",RoleId=1,
                Password="sdsds5",Mail="osman.akbaci"};
                */

            var user = _userService.GetById(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
           
            try
            {
                _userService.Add(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                _userService.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                _userService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
