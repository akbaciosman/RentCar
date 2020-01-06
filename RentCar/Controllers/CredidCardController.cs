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
    public class CredidCardController : Controller
    {
        private ICreditCardService _creditCardService;

        public CredidCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
            //_creditCardService = new CreditCardService();
        }

        // GET: CredidCard
        public ActionResult Index()
        {
            var list = _creditCardService.GetAll();
            return View(list);
        }

        // GET: CredidCard/Details/5
        public ActionResult Details(int id)
        {
            var card = _creditCardService.GetById(id);
            return View(card);
        }

        // GET: CredidCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CredidCard/Create
        [HttpPost]
        public ActionResult Create(CreditCard card)
        {
            try
            {
                _creditCardService.Add(card);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CredidCard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CredidCard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreditCard card)
        {
            try
            {
                _creditCardService.Update(card);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CredidCard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CredidCard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,CreditCard card)
        {
            try
            {
                _creditCardService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
