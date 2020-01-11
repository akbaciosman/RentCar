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
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
            //_carService = new CarService();
        }
        // GET: Car
        public ActionResult Index()
        {
            if (Session["LoginedUser"] == null)
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            if (string.IsNullOrEmpty(Session["LoginedUser"].ToString()))
                return RedirectToAction(actionName: "Login", controllerName: "Login");

            //return View(_carService.GetAll().Where(x=>x.IsDeleted !=true));
            return View(_carService.GetAll());
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View(_carService.GetById(id));
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(CarView car)
        {
            try
            {
                Console.WriteLine(car.Photo.FileName);
                if (car.Photo.ContentLength>0)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + car.Photo.FileName;
                    car.Photo.SaveAs(Server.MapPath("~/img/" + uniqueFileName));
                    

                    Car _car = new Car
                    {
                        Brand = car.Brand,
                        Photo = uniqueFileName,
                        Price = car.Price,
                        Available = car.Available,
                        Address = new Address {City =car.Address.City,Disrict =car.Address.Disrict }
                    };
                    _carService.Add(_car);
                }
                return RedirectToAction("Index");
            }
            catch(Exception msg)
            {
                Console.WriteLine(msg);
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_carService.GetById(id));
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Car car)
        {
            try
            {

                Car _car = _carService.GetById(id);

                _car.Price = car.Price;
                _car.Available = car.Available;
                _car.Address.City= car.Address.City;
                _car.Address.Disrict = car.Address.Disrict;
                _car.IsDeleted = car.IsDeleted;
                _carService.Update(_car);
                return RedirectToAction("Index");
            }
            catch(Exception msg)
            {
                ModelState.AddModelError("Something got wrong!!", msg);
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            Car _car = _carService.GetById(id);
            return View(_car);
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                if(ModelState.IsValid)
                    _carService.Delete(id);                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
