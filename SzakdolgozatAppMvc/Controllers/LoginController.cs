using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SzakdolgozatAppMvc.BusinessLogic;

namespace SzakdolgozatAppMvc.Controllers
{
    public class LoginController : Controller
    {

        UserService userService = new UserService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public string GetFelhasznalo(string username, string pswd)
        {
            bool belep_E = userService.GetUser(username, pswd);
            if (belep_E)
                return "Sikeres bejelentkezés: " + username.ToString() + " felhasználóval!";
            else return "Sikertelen bejelentkezés!";
        }
    }
}