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
        private ICarService _carService;

        public CarController()
        {
            _carService = new CarService();
        }
        // GET: Car
        public ActionResult Index()
        {
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
        public ActionResult Create(Car car)
        {
            try
            {
                _carService.Add(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var _car = _carService.GetById(id);
                _carService.Update(_car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
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
