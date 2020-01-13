using RentCar.Core;
using RentCar.Entities;
using RentCar.Entities.HelperConrete;
using RentCar.Models.Abstract;
using System.Net;
using System.Web.Mvc;

namespace RentCar.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Register/Details/5
        public ActionResult Login()
        {
            if (Session["LoginedUser"] != null)
                if (!string.IsNullOrEmpty(Session["LoginedUser"].ToString()))
                    return RedirectToAction(actionName: "Index", controllerName: "Home");

            return View();
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Login(Login loginView)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.LoginFunc(loginView);
                if (user != null)
                {
                    string fullname = user.FirstName + "  " + user.SecondName;
                    string str = user.Id + "," + user.RoleId + "," + fullname;
                    Session["LoginedUser"] = str;

                    Logger.GetLogger().Info(fullname + "Loginned to application");
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                Logger.GetLogger().Error(" Username or Password invalid");
                ModelState.AddModelError("", "Username or Password invalid!!!");
                return View(loginView);
            }
            Logger.GetLogger().Error( " Please fill the fields");

            ModelState.AddModelError("", "Please fill the fields!!!");
            return View(loginView);
        }


        [HttpPost]
        public ActionResult LogOut()
        {
            string[] userTemp = Session["LoginedUser"].ToString().Split(',');
            int _userid = int.Parse(userTemp[0]);
            User user = _userService.GetById(_userid);

            Logger.GetLogger().Info(user.FirstName + " " + user.SecondName+" is log out!!");
            Session["LoginedUser"] = null;
            Session.Clear();
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}