
using RentCar.Entities.HelperConrete;
using RentCar.Models.Abstract;
using System.Web.Mvc;

namespace RentCar.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Register(Register register)
        {
            
            if (_userService.RegisterFunc(register) != null)
                   return RedirectToAction(actionName: "Index", controllerName: "Home");

            
            ModelState.AddModelError("","Username : " + register.Email +  " already exist, please login the Page!!");
                return RedirectToAction(actionName:"Login" , controllerName: "Login");
        }
    }
}
