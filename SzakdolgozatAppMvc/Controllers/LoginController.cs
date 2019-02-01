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

        public bool GetFelhasznalo(string username, string pswd)
        {
            bool belep_E = userService.GetUser(username, pswd);
            if (belep_E)
                return true;
            else return false;
        }
    }
}