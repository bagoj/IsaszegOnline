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
            UserEditModel userEdit = new UserEditModel();
            return View(userEdit);
        }

        [HttpPost]
        public ActionResult Regisztracio(UserModel eredmeny)
        {
            userService.Add(eredmeny);
            return View("Index");
        }
        public ActionResult Profil(int id)
        {
            UserEditModel pm = new UserEditModel();
            pm = userService.GetUser(id);
            return View(pm);
        }

    }
}