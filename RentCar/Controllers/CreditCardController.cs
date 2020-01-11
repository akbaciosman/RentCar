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
    public class CreditCardController : Controller
    {
        private ICreditCardService _creditCardService;
        private IUserService _userService;

        public CreditCardController(ICreditCardService creditCardService, IUserService userService)
        {
            _creditCardService = creditCardService;
            _userService = userService;
        }

        // GET: CreditCard
        public ActionResult Index()
        {
            if (Session["LoginedUser"] == null)
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            if (string.IsNullOrEmpty(Session["LoginedUser"].ToString()))
                return RedirectToAction(actionName: "Login", controllerName: "Login");
            var list = _creditCardService.GetAll().ToList();
            return View(list);
        }

        // GET: CreditCard/Details/5
        public ActionResult Details(int id)
        {
            var card = _creditCardService.GetById(id);
            return View(card);
        }

        // GET: CreditCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCard/Create
        [HttpPost]
        public ActionResult Create(CreditCard card)
        {
            try
            {
                string[] userTemp = Session["LoginedUser"].ToString().Split(',');
                card.IsDeleted = false;
                card.User =_userService.GetById(int.Parse(userTemp[0]));
                _creditCardService.Add(card);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CreditCard/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_creditCardService.GetById(id));
        }

        // POST: CreditCard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreditCard card)
        {
            try
            {
                CreditCard _card = _creditCardService.GetById(id);
                _card.CardName = card.CardName;
                _card.IsDeleted = card.IsDeleted;
                _card.Limit = card.Limit;
                _creditCardService.Update(_card);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CreditCard/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_creditCardService.GetById(id));
        }

        // POST: CreditCard/Delete/5
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
