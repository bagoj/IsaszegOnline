using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SzakdolgozatAppMvc.BusinessLogic;
using SzakdolgozatAppMvc.Models;

namespace SzakdolgozatAppMvc.Controllers
{
    public class HomeController : Controller
    {
        UserService userService = new UserService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Regisztracio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regisztracio(UserModel eredmeny)
        {
            userService.Add(eredmeny);
            return View("Index");
        }
    }
}