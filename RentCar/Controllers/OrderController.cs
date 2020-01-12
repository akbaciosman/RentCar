using RentCar.Core;
using RentCar.Entities;
using RentCar.Models;
using RentCar.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCar.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
            //_orderService = new OrderService();
        }
        //GET: Order
        public ActionResult Index()
        {
            if (Session["LoginedUser"] == null)
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            if (string.IsNullOrEmpty(Session["LoginedUser"].ToString()))
                return RedirectToAction(actionName: "Login", controllerName: "Login");

            string[] userTemp;
            List<Order> orders = null;
            if (Session["LoginedUser"] != null) {
                userTemp = Session["LoginedUser"].ToString().Split(',');
                int _roleId;
                bool result1 = int.TryParse(userTemp[1],out _roleId);
                int _userId;
                bool result2 = int.TryParse(userTemp[0],out _userId);

                //Customer
                if (result1 == true && result2 == true && _roleId == 1)
                {
                    orders = _orderService.GetAll().Where(x => x.User.Id == _userId).ToList();

                }
                else if (result1 == true && result2 == true && _roleId == 2) //Admin 
                    orders = _orderService.GetAll().ToList();
                else
                    Logger.GetLogger().Error("User is not registered!!");
            }

            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
           Order _order= _orderService.GetById(id) ;
            return View(_order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                string _querCarId = Request.QueryString["id"];
                string[] userTemp = Session["LoginedUser"].ToString().Split(',');
                int _userId, _carId;
                int.TryParse(userTemp[0], out _userId);
                int.TryParse(_querCarId, out _carId);

                order.IsDeleted = false;
                order.User = new User { Id = _userId };
                order.Car = new Car { Id = _carId };

                if(ModelState.IsValid)
                    _orderService.Add(order);
                else
                {
                    return RedirectToAction("Car","Car");
                }

                return RedirectToAction("Index");
            }
            catch(Exception msg)
            {
                Logger.GetLogger().Error("Order was not added",msg);
                ModelState.AddModelError("Order was not added!!",msg);
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_orderService.GetById(id));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                Order _order = _orderService.GetById(id);
                _order.StartDate = order.StartDate;
                _order.EndDate = order.EndDate;
                _orderService.Update(_order);
                return RedirectToAction("Index");
            }
            catch(Exception msg)
            {
                Logger.GetLogger().Error("Order was not edited", msg);
                ModelState.AddModelError("Order was not edited!!" ,msg);
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_orderService.GetById(id));
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                _orderService.Delete(id);
                return RedirectToAction("Index");
            }
            catch(Exception msg)
            {
                ModelState.AddModelError("Order was not deleted!!",msg);
                return View();
            }
        }
    }
}
