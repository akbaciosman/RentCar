using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["LoginedUser"] == null)
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            if (string.IsNullOrEmpty(Session["LoginedUser"].ToString()))
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            string[] userTemp = Session["LoginedUser"].ToString().Split(',');
            if (userTemp.Count()<2)
                return RedirectToAction(actionName: "Login", controllerName: "Login");

            ViewBag.role = userTemp[1];

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
