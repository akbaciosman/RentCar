using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentCar.Controllers
{
    public class AuthenticationController : ApiController
    {/*
        [HttpPost]
        public ActionResult Login(LoginView loginView)
        {
            if (Session["LoginedUser"] != null)
            {
                //redirectToLoginPage
            }
            if (ModelState.IsValid)
            {
                var users = _userService.GetAll().Where(x => x.Mail == loginView.UserName && x.Password == loginView.Password);//MD5
                return null;
            }
            var st = 2;
            if (st == 1)
                return View("");
            else
                return RedirectToAction("");
        }*/
    }
}
