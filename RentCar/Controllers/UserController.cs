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

        public UserController(IUserService userService)
        {
            _userService = userService;
           // _userService = new UserService();
        }
        // GET: User
        public ActionResult Index()
        {
            if (Session["LoginedUser"] == null)
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            if (string.IsNullOrEmpty(Session["LoginedUser"].ToString()))
                return RedirectToAction(actionName: "Login", controllerName: "Login");

            var users = _userService.GetAll();
            
            return View(users);
        }

            // GET: User/Details/5
            public ActionResult Details(int id)
        {
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
                User _user = _userService.GetById(id);
                _user.FirstName = user.FirstName;
                _user.SecondName = user.SecondName;
                _user.Email = user.Email;
                _user.IsDeleted = user.IsDeleted;
                _user.PhoneNumber = user.PhoneNumber;
                _user.RoleId = user.RoleId;
                _user.Age = user.Age;
                _userService.Update(_user);
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
